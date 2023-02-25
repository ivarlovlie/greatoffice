<script context="module" lang="ts">
    export type NotificationType = "info" | "error" | "success" | "warning" | "subtle";
</script>

<script lang="ts">
    import { Transition } from "@rgossiaux/svelte-headlessui";
    import { onDestroy } from "svelte";
    import { XMarkIcon, ExclamationCircleIcon, InformationCircleIcon, XCircleIcon, CheckCircleIcon } from "./icons";

    export let title: string;
    export let subtitle = "";
    export let show = false;
    export let type: NotificationType = "info";
    export let hideAfterSeconds = -1;
    export let nonClosable = false;

    $: _show = show && title.length > 0;
    let timeout;
    let iconClass = "";
    let icon = undefined;
    let bgClass = "";
    let ringClass = "";

    onDestroy(() => {
        clearTimeout(timeout);
    });

    $: if (hideAfterSeconds > 0) {
        timeout = setTimeout(() => close(), hideAfterSeconds * 1000);
    } else {
        timeout = -1;
        show = true;
    }

    $: switch (type) {
        case "error":
            iconClass = "text-red-400";
            bgClass = "bg-red-50";
            ringClass = "ring-1 ring-red-100";
            icon = XCircleIcon;
            break;
        case "info":
            iconClass = "text-blue-400";
            bgClass = "bg-blue-50";
            ringClass = "ring-1 ring-blue-100";
            icon = InformationCircleIcon;
            break;
        case "success":
            iconClass = "text-green-400";
            bgClass = "bg-green-50";
            ringClass = "ring-1 ring-green-100";
            icon = CheckCircleIcon;
            break;
        case "warning":
            iconClass = "text-yellow-400";
            bgClass = "bg-yellow-50";
            ringClass = "ring-1 ring-yellow-100";
            icon = ExclamationCircleIcon;
            break;
        case "subtle":
            icon = undefined;
            bgClass = "bg-white";
            ringClass = "ring-1 ring-gray-100";
            break;
        default:
            icon = undefined;
            bgClass = "bg-white";
            ringClass = "";
            break;
    }

    function close() {
        show = false;
    }
</script>

<div aria-live="assertive" class="pointer-events-none fixed inset-0 flex items-end px-4 py-6 sm:items-start sm:p-6">
    <div class="flex w-full flex-col items-center space-y-4 sm:items-end">
        <Transition
            class="w-full flex justify-end"
            show={_show}
            enter="transform ease-out duration-300 transition"
            enterFrom="translate-y-2 opacity-0 sm:translate-y-0 sm:translate-x-2"
            enterTo="translate-y-0 opacity-100 sm:translate-x-0"
            leave="transition ease-in duration-100"
            leaveFrom="opacity-100"
            leaveTo="opacity-0"
        >
            <div class="pointer-events-auto w-full max-w-sm overflow-hidden rounded-lg shadow-md {bgClass} {ringClass}">
                <div class="p-4">
                    <div class="flex items-start">
                        {#if icon}
                            <div class="flex-shrink-0">
                                <svelte:component this={icon} class={iconClass} />
                            </div>
                        {/if}
                        <div class="ml-3 w-0 flex-1 pt-0.5">
                            <p class="text-sm font-medium text-gray-900">{title}</p>
                            {#if subtitle}
                                <p class="mt-1 text-sm text-gray-500">{subtitle}</p>
                            {/if}
                        </div>
                        {#if !nonClosable}
                            <div class="ml-4 flex flex-shrink-0">
                                <button
                                    on:click={close}
                                    type="button"
                                    class="inline-flex rounded-md text-gray-400 hover:text-gray-500 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
                                >
                                    <XMarkIcon />
                                </button>
                            </div>
                        {/if}
                    </div>
                </div>
            </div>
        </Transition>
    </div>
</div>
