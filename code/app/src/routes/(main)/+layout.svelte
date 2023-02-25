<script lang="ts">
    import "../../app.pcss";
    import { setLocale } from "$i18n/i18n-svelte";
    import { ExclamationTriangleIcon } from "$components/icons";
    import { page } from "$app/stores";
    import type { LayoutData } from "./$types";

    let online = true;
    export let data: LayoutData;
    setLocale(data.locale);
</script>

<svelte:window bind:online />
<svelte:head>
    <title>{$page.data.title ? $page.data.title + " - Greatoffice" : "Greatoffice"}</title>
</svelte:head>

{#if !online}
    <div class="bg-yellow-50 relative z-50 p-4">
        <div class="flex">
            <div class="flex-shrink-0">
                <ExclamationTriangleIcon class="bg-yellow-50 text-yellow-500" />
            </div>
            <div class="ml-3">
                <p class="text-sm text-yellow-700">You seem to be offline, please check your internet connection.</p>
            </div>
        </div>
    </div>
{/if}

<slot />
