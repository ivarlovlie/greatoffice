<script lang="ts">
    import "../app.pcss";
    import { page } from "$app/stores";
    import type { LayoutData } from "./$types";
    import Sonner from "$components/sonner.svelte";
    import { ModeWatcher } from "mode-watcher";
    import StyleChanger from "$components/style-changer.svelte";
    import { browser } from "$app/environment";
    import { QueryClient, QueryClientProvider } from "@tanstack/svelte-query";
    import { setLocale } from "$i18n/i18n-svelte";
    import { ExclamationTriangle } from "svelte-radix";

    let online = true;
    export let data: LayoutData;
    setLocale(data.locale);

    const queryClient = new QueryClient({
        defaultOptions: {
            queries: {
                enabled: browser
            }
        }
    });
</script>

<svelte:window bind:online/>
<svelte:head>
    <title>{$page.data.title ? $page.data.title + " - Greatoffice" : "Greatoffice"}</title>
</svelte:head>

<ModeWatcher/>
<Sonner/>
<StyleChanger/>

<QueryClientProvider client={queryClient}>
    <slot/>
</QueryClientProvider>

{#if !online}
    <div class="bg-yellow-50 relative z-50 p-4">
        <div class="flex">
            <div class="flex-shrink-0">
                <ExclamationTriangle class="bg-yellow-50 text-yellow-500"/>
            </div>
            <div class="ml-3">
                <p class="text-sm text-yellow-700">You seem to be offline, please check your internet connection.</p>
            </div>
        </div>
    </div>
{/if}
