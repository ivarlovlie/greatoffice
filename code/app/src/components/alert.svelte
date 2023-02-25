<script lang="ts">
    import {random_string} from "$utilities/misc-helpers";
    import {createEventDispatcher} from "svelte";
    import {onMount} from "svelte";
    import pwKey from "$actions/pwKey";
    import {Temporal} from "temporal-polyfill";
    import {ExclamationTriangleIcon, CheckCircleIcon, InformationCircleIcon, XCircleIcon, XMarkIcon} from "./icons";

    const dispatch = createEventDispatcher();
    const noCooldownSetting = "no-cooldown";

    let iconComponent: any;
    let colorClassPart = "";

    /**
     * An optional id for this alert, a default is set if not specified.
     * This value is necessary for closeable cooldown to work.
     */
        // if no unique id is supplied, cooldown will not work between page loads.
        // Therefore we are disabling it with noCooldownSetting in the fallback id.
    export let id = "alert--" + noCooldownSetting + "--" + random_string(4);
    /**
     * The title to communicate, value is optional
     */
    export let title = "";
    /**
     * The message to communicate, value is optional
     */
    export let message = "";
    /**
     * Changes the alerts color and icon.
     */
    export let type: "info" | "success" | "warning" | "error" = "info";
    /**
     * If true the alert can be removed from the DOM by clicking on a X icon on the upper right hand courner
     */
    export let closeable = false;
    /**
     * The amount of seconds that should go by before this alert is shown again, only works when a unique id is set.
     * Set to ~ if it should only be shown once per client (State stored in localestorage).
     **/
    export let closeableCooldown = "-1";
    /**
     * The text that is displayed on the right link
     */
    export let rightLinkText = "";
    /**
     * An array of list items displayed under the message or title
     */
    export let listItems: Array<string> = [];
    /**
     * An array of {id:string;text:string;color?:string}, where id is dispatched back as an svelte event with this syntax act$id (ex: on:actcancel).
     * Text is the button text
     * Color is the optional tailwind color to used, the value is used in classes like bg-$color-50.
     */
    export let actions: Array<{ id: string; text: string; color?: string }> = [];
    /**
     * This value is set on a plain anchor tag without any svelte routing,
     * listen to the on:rightLinkClick if you want to intercept the click without navigating
     */
    export let rightLinkHref = "javascript:void(0)";
    $: cooldownEnabled =
        id.indexOf(noCooldownSetting) === -1 && closeable && (closeableCooldown === "~" || parseInt(closeableCooldown) > 0);
    /**
     * Sets this alerts visibility state, when this is false it is removed from the dom using an {#if} block.
     */
    export let visible = closeableCooldown === "~" || parseInt(closeableCooldown) > 0 ? false : true;

    export let _pwKey: string | undefined = undefined;

    const cooldownStorageKey = "lastseen--" + id;

    $: switch (type) {
        case "info": {
            colorClassPart = "blue";
            iconComponent = InformationCircleIcon;
            break;
        }
        case "warning": {
            colorClassPart = "yellow";
            iconComponent = ExclamationTriangleIcon;
            break;
        }
        case "error": {
            colorClassPart = "red";
            iconComponent = XCircleIcon;
            break;
        }
        case "success": {
            colorClassPart = "green";
            iconComponent = CheckCircleIcon;
            break;
        }
    }

    function close() {
        visible = false;
        if (cooldownEnabled) {
            console.log("Cooldown enabled for " + id + ", " + closeableCooldown === "~" ? "with an endless cooldown" : "");
            localStorage.setItem(cooldownStorageKey, String(Temporal.Now.instant().epochSeconds));
        }
    }

    function rightLinkClicked() {
        dispatch("rightLinkCliked");
    }

    function actionClicked(name: string) {
        dispatch("act" + name);
    }

    // Manages the state of the alert if cooldown is enabled
    function run_cooldown() {
        if (!cooldownEnabled) {
            console.log("Alert cooldown is not enabled for " + id);
            return;
        }
        if (!localStorage.getItem(cooldownStorageKey)) {
            console.log("Alert " + id + " has not been seen yet, displaying");
            visible = true;
            return;
        }
        // if (!visible) {
        //     console.log(
        //         "Alert " + id + " is not visible, stopping cooldown change"
        //     );
        //     return;
        // }
        if (closeableCooldown === "~") {
            console.log("Alert " + id + " has an infinite cooldown, hiding");
            visible = false;
            return;
        }

        const lastSeen = Temporal.Instant.fromEpochSeconds(parseInt(localStorage.getItem(cooldownStorageKey) ?? "-1"));
        if (Temporal.Instant.compare(Temporal.Now.instant(), lastSeen.add({seconds: parseInt(closeableCooldown)})) === 1) {
            console.log(
                "Alert " +
                id +
                " has a cooldown of " +
                closeableCooldown +
                " and was last seen " +
                lastSeen.toLocaleString() +
                " making it due for a showing",
            );
            visible = true;
        } else {
            visible = false;
        }
    }

    onMount(() => {
        if (cooldownEnabled) {
            run_cooldown();
        }

        if (closeable && closeableCooldown && id.indexOf(noCooldownSetting) !== -1) {
            // TODO: This prints twice before shutting up as it should, in this example look at the only alert with closeableCooldown in alertsbook.
            // Looks like svelte mounts three times and that my id is only set on the third. Not sure it does at all after logging the id onMount.
            console.error("Alert cooldown does not work without specifying a unique id, related id: " + id);
        }
    });
</script>

{#if visible}
    <div class="rounded-md bg-{colorClassPart}-50 p-4 {$$restProps.class ?? ''}" use:pwKey={_pwKey}>
        <div class="flex">
            <div class="flex-shrink-0">
                <svelte:component this={iconComponent} class="text-{colorClassPart}-400"/>
            </div>
            <div class="ml-3 text-sm w-full">
                {#if !rightLinkText}
                    {#if title}
                        <h3 class="font-bold text-{colorClassPart}-800">
                            {title}
                        </h3>
                    {/if}
                    {#if message}
                        <div class="{title ? 'mt-2' : ''} text-{colorClassPart}-700 justify-start">
                            <p>
                                {@html message}
                            </p>
                        </div>
                    {/if}
                    {#if listItems?.length ?? 0}
                        <ul class="list-disc space-y-1 pl-5 text-{colorClassPart}-700">
                            {#each listItems as listItem}
                                <li>{listItem}</li>
                            {/each}
                        </ul>
                    {/if}
                {:else}
                    <div class="flex-1 md:flex md:justify-between">
                        <div>
                            {#if title}
                                <h3 class="font-medium text-{colorClassPart}-800">
                                    {title}
                                </h3>
                            {/if}
                            {#if message}
                                <div class="{title ? 'mt-2' : ''} text-{colorClassPart}-700 justify-start">
                                    <p>
                                        {@html message}
                                    </p>
                                </div>
                            {/if}
                            {#if listItems?.length ?? 0}
                                <ul class="list-disc space-y-1 pl-5 text-{colorClassPart}-700">
                                    {#each listItems as listItem}
                                        <li>{listItem}</li>
                                    {/each}
                                </ul>
                            {/if}
                        </div>
                        <p class="mt-3 text-sm md:mt-0 md:ml-6 flex items-end">
                            <a
                                    href={rightLinkHref}
                                    on:click={() => rightLinkClicked()}
                                    class="whitespace-nowrap font-medium text-{colorClassPart}-700 hover:text-{colorClassPart}-600"
                            >
                                {rightLinkText}
                                <span aria-hidden="true"> &rarr;</span>
                            </a>
                        </p>
                    </div>
                {/if}
                {#if actions?.length ?? 0}
                    <div class="ml-2 mt-4">
                        <div class="-mx-2 -my-1.5 flex gap-1">
                            {#each actions as action}
                                {@const color = action?.color ?? colorClassPart}
                                <button
                                        type="button"
                                        on:click={() => actionClicked(action.id)}
                                        class="rounded-md
                            bg-{color}-50
                            px-2 py-1.5 text-sm font-medium
                            text-{color}-800
                            hover:bg-{color}-100
                            focus:outline-none focus:ring-2
                            focus:ring-{color}-600
                            focus:ring-offset-2
                            focus:ring-offset-{color}-50"
                                >
                                    {action.text}
                                </button>
                            {/each}
                        </div>
                    </div>
                {/if}
            </div>
            {#if closeable}
                <div class="ml-auto pl-3">
                    <div class="-mx-1.5 -my-1.5">
                        <button
                                type="button"
                                on:click={() => close()}
                                class="inline-flex rounded-md bg-{colorClassPart}-50 p-1.5 text-{colorClassPart}-500 hover:bg-{colorClassPart}-100 focus:outline-none focus:ring-2 focus:ring-{colorClassPart}-600 focus:ring-offset-2 focus:ring-offset-{colorClassPart}-50"
                        >
                            <span class="sr-only">Dismiss</span>
                            <XMarkIcon/>
                        </button>
                    </div>
                </div>
            {/if}
        </div>
    </div>
{/if}
