<script lang="ts" context="module">
    export type ComboboxOption = {
        id: string;
        name: string;
        selected?: boolean;
    };
</script>

<script lang="ts">
    import { CheckCircleIcon, ChevronUpDownIcon, XIcon } from "./icons";
    import { random_string } from "$utilities/misc-helpers";
    import { go, highlight } from "fuzzysort";
    import Badge from "./badge.svelte";
    import Button from "./button.svelte";
    import LL from "$i18n/i18n-svelte";
    import { element_has_focus } from "$utilities/dom-helpers";

    export let id = "combobox-" + random_string(3);
    export let label: string | undefined = undefined;
    export let errorText: string | undefined = undefined;
    export let disabled: boolean | undefined = undefined;
    export let required: boolean | undefined = undefined;
    export let maxlength: number | undefined = undefined;
    export let placeholder: string = $LL.combobox.search();
    export let options: Array<ComboboxOption> | undefined = [];
    export let createable = false;
    export let loading = false;
    export let multiple = false;
    export let noResultsText: string = $LL.combobox.noRecordsFound();
    export let on_create_async = async ({ name: string }) => {};

    export const reset = () => methods.reset();
    export const select = (id: string) => methods.select_entry(id);
    export const deselect = (id: string) => methods.deselect_entry(id);

    const INTERNAL_ID = "INTERNAL__" + id;

    let optionsListId = id + "--options";
    let searchInputNode;
    let searchResults: Array<any> = [];
    let searchValue = "";
    let showCreationHint = false;
    let showDropdown = false;
    let inputHasFocus = false;
    let lastKeydownCode = "";
    let mouseIsOverDropdown = false;
    let mouseIsOverComponent = false;

    $: ariaErrorDescribedBy = id + "__" + "error";
    $: colorName = errorText ? "red" : "teal";
    $: attributes = {
        "aria-describedby": errorText ? ariaErrorDescribedBy : null,
        "aria-invalid": errorText ? "true" : null,
        disabled: disabled || null,
        required: required || null,
        maxlength: maxlength || null,
        id: id || null,
        placeholder: placeholder || null,
    } as any;
    $: hasSelection = options.some((c) => c.selected === true);
    $: if (searchValue.trim()) {
        showCreationHint = createable && options.every((c) => search.normalise_value(c.name) !== search.normalise_value(searchValue));
    } else {
        showCreationHint = false;
        options = methods.get_sorted_array(options);
    }

    function on_select(event) {
        const node = event.target.closest("[data-id]");
        if (!node) return;
        methods.select_entry(node.dataset.id);
    }

    const search = {
        normalise_value(value: string): string {
            if (!value) {
                return "";
            }
            return value.trim().toLowerCase();
        },
        do() {
            const query = search.normalise_value(searchValue);

            if (!query.trim()) {
                searchResults = [];
                return;
            }

            // @ts-ignore
            searchResults = go(query, options, {
                limit: 15,
                allowTypo: true,
                threshold: -10000,
                key: "name",
            });
            showDropdown = true;
        },
        on_input_focus() {
            showDropdown = true;
            inputHasFocus = true;
        },
        on_input_click() {
            showDropdown = true;
            inputHasFocus = true;
        },
        on_input_focusout() {
            inputHasFocus = false;
            if (lastKeydownCode !== "Tab" && (mouseIsOverDropdown || lastKeydownCode === "ArrowDown")) {
                return;
            }
            const selected = options.find((c) => c.selected === true);
            if (selected && !multiple) {
                searchValue = selected.name;
            }
            document.querySelector("#" + INTERNAL_ID + " ul li.focus")?.classList.remove("focus");
            showDropdown = false;
        },
        on_input_wrapper_focus(event) {
            if (event.code && event.code !== "Space" && event.code !== "Enter") return;
            if (!element_has_focus(searchInputNode)) searchInputNode.focus();
            showDropdown = true;
        },
    };

    const methods = {
        reset(focus_input = false) {
            searchValue = "";
            const copy = options;
            for (const entry of copy) {
                entry.selected = false;
            }
            options = methods.get_sorted_array(copy);
            if (focus_input) {
                searchInputNode?.focus();
                showDropdown = true;
            } else {
                showDropdown = false;
            }
        },
        async create_entry(name: string) {
            if (!name || !createable || loading) {
                console.log("Not sending creation event due to failed preconditions", { name, createable, loading });
                return;
            }
            try {
                await on_create_async({ name });
                searchValue = "";
                loading = false;
            } catch (e) {
                console.error(e);
            }
        },
        select_entry(entryId: string) {
            if (!entryId || loading) {
                console.log("Not selecting entry due to failed preconditions", {
                    entryId,
                    loading,
                });
                return;
            }

            const copy = options;
            for (const entry of options) {
                if (entry.id === entryId) {
                    entry.selected = true;
                    if (multiple) {
                        searchValue = "";
                    } else {
                        searchValue = entry.name;
                    }
                } else if (!multiple) {
                    entry.selected = false;
                }
            }
            options = methods.get_sorted_array(copy);
            searchInputNode?.focus();
            searchResults = [];
        },
        deselect_entry(entryId: string) {
            if (!entryId || loading) {
                console.log("Not deselecting entry due to failed preconditions", {
                    entryId,
                    loading,
                });
                return;
            }
            console.log("Deselecting entry", entryId);

            const copy = options;

            for (const entry of copy) {
                if (entry.id === entryId) {
                    entry.selected = false;
                }
            }

            options = methods.get_sorted_array(copy);
            searchInputNode?.focus();
        },
        get_sorted_array(options: Array<ComboboxOption>): Array<ComboboxOption> {
            if (!options) {
                return;
            }
            if (options.length < 1) {
                return [];
            }
            if (searchValue) {
                return options;
            }

            return options.sort((a, b) => search.normalise_value(a.name).localeCompare(search.normalise_value(b.name)));
        },
    };

    const windowEvents = {
        on_mousemove(event: any) {
            if (!event.target) return;
            mouseIsOverDropdown = event.target?.closest("#" + INTERNAL_ID + " .tongue") != null ?? false;
            mouseIsOverComponent = event.target?.closest("#" + INTERNAL_ID) != null ?? false;
        },
        on_click() {
            if (showDropdown && !mouseIsOverDropdown && !mouseIsOverComponent) {
                showDropdown = false;
            }
        },
        on_keydown(event: any) {
            lastKeydownCode = event.code;
            const enterPressed = event.code === "Enter";
            const backspacePressed = event.code === "Backspace";
            const arrowUpPressed = event.code === "ArrowUp";
            const spacePressed = event.code === "Space";
            const arrowDownPressed = event.code === "ArrowDown";
            const searchInputHasFocus = element_has_focus(searchInputNode);
            const focusedEntry = document.querySelector("#" + INTERNAL_ID + " ul li.focus") as HTMLLIElement;

            if (showDropdown && (enterPressed || arrowDownPressed || arrowUpPressed)) {
                event.preventDefault();
            }

            if (searchInputHasFocus && backspacePressed && !searchValue && options.length > 0) {
                if (options.filter((c) => c.selected === true).at(-1)?.id ?? false) {
                    methods.deselect_entry(options.filter((c) => c.selected === true).at(-1)?.id ?? "");
                }
                return;
            }

            if (searchInputHasFocus && enterPressed && showCreationHint) {
                methods.create_entry(searchValue.trim());
                return;
            }

            if (searchInputHasFocus && !focusedEntry && arrowDownPressed) {
                const firstEntry = document.querySelector("#" + INTERNAL_ID + " ul li:first-of-type");
                if (firstEntry) {
                    firstEntry.classList.add("focus");
                    return;
                }
            }

            if (focusedEntry && (arrowUpPressed || arrowDownPressed)) {
                if (arrowDownPressed) {
                    if (focusedEntry.nextElementSibling) {
                        focusedEntry.nextElementSibling.classList.add("focus");
                        focusedEntry.nextElementSibling.scrollIntoView(false);
                    } else {
                        const firstLIEl = document.querySelector("#" + INTERNAL_ID + " ul li:first-of-type");
                        firstLIEl.classList.add("focus");
                        firstLIEl.scrollIntoView(false);
                    }
                } else if (arrowUpPressed) {
                    if (focusedEntry.previousElementSibling) {
                        focusedEntry.previousElementSibling.classList.add("focus");
                        focusedEntry.previousElementSibling.scrollIntoView(false);
                    } else {
                        const lastLIEl = document.querySelector("#" + INTERNAL_ID + " ul li:last-of-type");
                        lastLIEl.classList.add("focus");
                        lastLIEl.scrollIntoView(false);
                    }
                }
                focusedEntry.classList.remove("focus");
                return;
            }

            if (focusedEntry && (spacePressed || enterPressed)) {
                methods.select_entry(focusedEntry.dataset.id);
                return;
            }

            if (lastKeydownCode === "Tab" && !searchInputHasFocus) {
                showDropdown = false;
            }
        },
        on_touchend(event) {
            windowEvents.on_mousemove(event);
        },
    };
</script>

<svelte:window
    on:keydown={windowEvents.on_keydown}
    on:mousemove={windowEvents.on_mousemove}
    on:touchend={windowEvents.on_touchend}
    on:click={windowEvents.on_click}
/>

<div id={INTERNAL_ID} class:cursor-wait={loading}>
    {#if label}
        <label for={id} class="block text-sm font-medium text-gray-700">
            {label}
            {@html required ? "<span class='text-red-500'>*</span>" : ""}
        </label>
    {/if}
    <div class="relative {label ? 'mt-1' : ''}">
        <div
            on:click={search.on_input_wrapper_focus}
            on:keypress={search.on_input_wrapper_focus}
            class="cursor-text w-full flex rounded-md border bg-white py-2 pl-3 pr-12 sm:text-sm
            {inputHasFocus ? `border-${colorName}-500 outline-none ring-1 ring-${colorName}-500` : 'shadow-sm border-gray-300'}"
        >
            {#if multiple === true && hasSelection}
                <div class="flex gap-1 flex-wrap">
                    {#each options.filter((c) => c.selected === true) as option}
                        <Badge
                            id={option.id}
                            removable
                            tabindex="-1"
                            on:remove={(e) => methods.deselect_entry(e.detail.id)}
                            text={option.name}
                        />
                    {/each}
                </div>
            {/if}
            <div>
                <input
                    {...attributes}
                    type="text"
                    style="all: unset;"
                    role="combobox"
                    aria-controls={optionsListId}
                    aria-expanded={showDropdown}
                    bind:value={searchValue}
                    bind:this={searchInputNode}
                    on:input={() => search.do()}
                    on:click={search.on_input_click}
                    on:focus={search.on_input_focus}
                    on:blur={search.on_input_focusout}
                    autocomplete="off"
                />
                {#if hasSelection}
                    <button
                        type="button"
                        on:click={() => reset()}
                        title={$LL.reset()}
                        tabindex="-1"
                        class="text-gray-400 absolute cursor-pointer inset-y-0 right-0 flex items-center rounded-r-md px-2"
                    >
                        <XIcon />
                    </button>
                {:else}
                    <span tabindex="-1" class="text-gray-400 absolute inset-y-0 right-0 flex items-center rounded-r-md px-2">
                        <ChevronUpDownIcon />
                    </span>
                {/if}
            </div>
        </div>
        {#if errorText}
            <p class="mt-2 text-sm text-red-600" id={ariaErrorDescribedBy}>
                {errorText}
            </p>
        {/if}
        <div
            class="tongue {showDropdown ? 'absolute' : 'hidden'}
                z-10 mt-1 max-h-60 w-full overflow-auto rounded-md bg-white
                text-base shadow-lg ring-1 ring-teal ring-opacity-5 focus:outline-none sm:text-sm"
        >
            <ul id={optionsListId} role="listbox" tabindex="-1">
                {#if searchResults.length > 0}
                    {#each searchResults.filter((c) => !c.selected) as result}
                        <li
                            class="item"
                            data-id={result.obj.id}
                            aria-selected={result.obj.selected}
                            role="option"
                            on:click={on_select}
                            on:keypress={on_select}
                            tabindex="-1"
                        >
                            {@html highlight(result, '<span class="font-bold">', "</span>")}
                        </li>
                    {/each}
                {:else if options.length > 0}
                    {#each options as option}
                        <!--
                            Combobox option, manage highlight styles based on mouseenter/mouseleave and keyboard navigation.
                            Active: "text-white bg-indigo-600", Not Active: "text-gray-900"
                        -->
                        <li
                            class="item"
                            aria-selected={option.selected}
                            role="option"
                            data-id={option.id}
                            on:click={on_select}
                            on:keypress={on_select}
                            tabindex="-1"
                        >
                            <span class="block truncate {option.selected ? 'text-semibold' : ''}">{option.name}</span>
                            {#if option.selected}
                                <span class="absolute inset-y-0 right-0 flex items-center pr-4 text-{colorName}-600">
                                    <CheckCircleIcon />
                                </span>
                            {/if}
                        </li>
                    {/each}
                {:else}
                    <slot name="no-records">
                        <p class="px-2">{noResultsText}</p>
                        {#if createable && !searchValue}
                            <p class="px-2 text-gray-500">{$LL.combobox.createRecordHelpText()}</p>
                        {/if}
                    </slot>
                {/if}
            </ul>
            {#if showCreationHint}
                <div class="sticky bottom-0 w-full bg-white">
                    <Button
                        text={$LL.combobox.createRecordButtonText(searchValue.trim())}
                        title={$LL.combobox.createRecordButtonText(searchValue.trim())}
                        {loading}
                        kind="reset"
                        type="button"
                        on:click={() => methods.create_entry(searchValue.trim())}
                    />
                </div>
            {/if}
        </div>
    </div>
</div>

<style lang="postcss">
    .focus {
        @apply text-white bg-teal-300;
    }

    .item {
        @apply relative cursor-pointer select-none py-2 pl-3 pr-9 text-gray-900;
    }

    .item[aria-selected="true"] {
        @apply bg-teal-200;
    }
</style>
