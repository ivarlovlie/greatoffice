<script context="module" lang="ts">
    export type ButtonKind = "primary" | "secondary" | "white" | "reset";
    export type ButtonSize = "sm" | "lg" | "md" | "xl";
</script>

<script lang="ts">
    import pwKey from "$actions/pwKey";
    import { SpinnerIcon } from "./icons";

    export let kind = "primary" as ButtonKind;
    export let size = "md" as ButtonSize;
    export let type: "button" | "submit" | "reset" = "button";
    export let id: string | undefined = undefined;
    export let tabindex: string | undefined = undefined;
    export let style: string | undefined = undefined;
    export let title: string | undefined = undefined;
    export let disabled: boolean | null = false;
    export let href: string | undefined = undefined;
    export let text: string;
    export let loading = false;
    export let fullWidth = false;
    export let _pwKey: string | undefined = undefined;

    let sizeClasses = "";
    let kindClasses = "";
    let spinnerTextClasses = "";
    let spinnerMarginClasses = "";

    $: shared_props = {
        type: type,
        id: id || null,
        title: title || null,
        disabled: disabled || loading || null,
        tabindex: tabindex || null,
        style: style || null,
    } as any;

    $: switch (size) {
        case "sm":
            sizeClasses = "px-2.5 py-1.5 text-xs";
            spinnerMarginClasses = "mr-2";
            break;
        case "md":
            sizeClasses = "px-3 py-2 text-sm";
            spinnerMarginClasses = "mr-2";
            break;
        case "lg":
            sizeClasses = "px-3 py-2 text-lg";
            spinnerMarginClasses = "mr-2";
            break;
        case "xl":
            sizeClasses = "px-6 py-3 text-xl";
            spinnerMarginClasses = "mr-2";
            break;
    }

    $: switch (kind) {
        case "secondary":
            kindClasses = "border-transparent text-teal-800 bg-teal-100 hover:bg-teal-200 focus:ring-teal-500";
            spinnerTextClasses = "teal-800";
            break;
        case "primary":
            kindClasses = "border-transparent text-teal-900 bg-teal-300 hover:bg-teal-400 focus:ring-teal-500";
            spinnerTextClasses = "text-teal-900";
            break;
        case "white":
            kindClasses = "border-gray-300 text-gray-700 bg-white hover:bg-gray-50 focus:ring-gray-400";
            spinnerTextClasses = "text-gray-700";
            break;
        case "reset":
            kindClasses = "reset outline-none ring-0 focus:ring-0 focus-visible:ring-0";
            break;
    }
</script>

{#if href}
    <a
        use:pwKey={_pwKey}
        {...shared_props}
        {href}
        class="{sizeClasses} {kindClasses} {loading ? 'disabled:' : ''} {$$restProps.class ?? ''} {fullWidth
            ? 'w-full justify-center'
            : ''} disabled:cursor-not-allowed inline-flex items-center border font-bold rounded shadow-sm focus:outline-none focus:ring-2"
    >
        {#if loading}
            <SpinnerIcon class={spinnerTextClasses + " " + spinnerMarginClasses} />
        {/if}
        {text}
    </a>
{:else}
    <button
        use:pwKey={_pwKey}
        {...shared_props}
        on:click
        class="btn {sizeClasses} {kindClasses} {$$restProps.class ?? ''}
        {fullWidth
            ? 'w-full justify-center'
            : ''} inline-flex items-center border font-bold rounded shadow-sm focus:outline-none focus:ring-2"
    >
        {#if loading}
            <SpinnerIcon class={spinnerTextClasses + " " + spinnerMarginClasses} />
        {/if}
        {text}
    </button>
{/if}

<style>
    .reset {
        border: 0px;
        outline: none;
    }

    .reset:focus {
        outline: none;
    }
</style>
