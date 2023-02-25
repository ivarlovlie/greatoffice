<script lang="ts">
    import { createEventDispatcher } from "svelte";

    export let id: string | undefined = undefined;
    export let type: "default" | "red" | "yellow" | "green" | "blue" | "tame" = "default";
    export let text: string;
    export let size: "large" | "default" = "default";
    export let withDot: boolean = false;
    export let removable: boolean = false;
    export let uppercase: boolean = false;
    export let tabindex: string | undefined = undefined;

    let colorName = "gray";
    let sizeClass = "rounded px-2 py-0.5 text-xs";
    let dotSizeClass = "mr-1.5 h-2 w-2";

    const dispatch = createEventDispatcher();

    function handle_remove(event) {
        dispatch("remove", { event, id, text });
    }

    $: switch (type) {
        case "red":
            colorName = "red";
            break;
        case "yellow":
            colorName = "yellow";
            break;
        case "blue":
            colorName = "blue";
            break;
        case "green":
            colorName = "teal";
            break;
        case "default":
        case "tame":
        default:
            colorName = "gray";
            break;
    }

    $: switch (size) {
        case "large":
            sizeClass = "rounded-md px-2.5 py-0.5 text-sm";
            dotSizeClass = "-ml-0.5 mr-1.5 h-2 w-2";
            break;
        case "default":
        default:
            sizeClass = "rounded px-2 py-0.5 text-xs";
            dotSizeClass = "mr-1.5 h-2 w-2";
            break;
    }
</script>

<span class="inline-flex items-center font-medium {uppercase ? 'uppercase' : ''} bg-{colorName}-100 text-{colorName}-800 {sizeClass}" {id}>
    {#if withDot}
        <svg class="{dotSizeClass} text-{colorName}-400" fill="currentColor" viewBox="0 0 8 8">
            <circle cx="4" cy="4" r="3" />
        </svg>
    {/if}
    {text}
    {#if removable}
        <button
            on:click={handle_remove}
            tabindex={parseInt(tabindex)}
            type="button"
            class="ml-0.5 inline-flex h-4 w-4 flex-shrink-0 items-center justify-center rounded-full text-{colorName}-400 hover:bg-{colorName}-200 hover:text-{colorName}-500 focus:bg-{colorName}-500 focus:outline-none"
        >
            <span class="sr-only">Remove badge</span>
            <svg class="h-2 w-2" stroke="currentColor" fill="none" viewBox="0 0 8 8">
                <path stroke-linecap="round" stroke-width="1.5" d="M1 1l6 6m0-6L1 7" />
            </svg>
        </button>
    {/if}
</span>
