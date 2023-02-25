<script lang="ts">
    import {random_string} from "$utilities/misc-helpers";

    export let id = "textarea-" + random_string(4);
    export let disabled = false;
    export let rows = 2;
    export let cols = 0;
    export let name = "";
    export let placeholder = "";
    export let value;
    export let label = "";
    export let required = false;
    export let errorText = "";
    export let errors: Array<string> | undefined = undefined;

    $: ariaErrorDescribedBy = id + "__" + "error";
    $: attributes = {
        "aria-describedby": errorText || errors?.length ? ariaErrorDescribedBy : null,
        "aria-invalid": errorText || errors?.length ? "true" : null,
        rows: rows || null,
        cols: cols || null,
        name: name || null,
        id: id || null,
        disabled: disabled || null,
        required: required || null,
    } as any;

    let textareaElement;
    let scrollHeight = 0;
    const defaultColorClass = "border-gray-300 focus:border-teal-500 focus:ring-teal-500";
    let colorClass = defaultColorClass;

    $: if (errorText) {
        colorClass = "placeholder-red-300 focus:border-red-500 focus:outline-none focus:ring-red-500 text-red-900 pr-10 border-red-300";
    } else {
        colorClass = defaultColorClass;
    }

    $: if (textareaElement) {
        scrollHeight = textareaElement.scrollHeight;
    }

    function on_input(event) {
        event.target.style.height = "auto";
        event.target.style.height = this.scrollHeight + "px";
    }
</script>

<div>
    {#if label}
        <label for={id} class="block text-sm font-medium text-gray-700">
            {label}
            {@html required ? "<span class='text-red-500'>*</span>" : ""}
        </label>
    {/if}
    <div class="mt-1">
        <textarea
                {rows}
                {name}
                {id}
                {...attributes}
                style="overflow-y:hidden;min-height:calc(1.5em + .75rem + 2px);{scrollHeight ? 'height:{scrollHeight}px' : ''};"
                bind:value
                bind:this={textareaElement}
                on:input={on_input}
                {placeholder}
                class="block w-full rounded-md {colorClass} shadow-sm sm:text-sm"
        />
        {#if errorText || errors?.length === 1}
            <p class="mt-2 text-sm text-red-600" id={ariaErrorDescribedBy}>
                {errorText ?? errors[0]}
            </p>
        {:else if errors && errors.length}
            <ul class="mt-2 list-disc" id={ariaErrorDescribedBy}>
                {#each errors as error}
                    <li class="text-sm text-red-600">{error}</li>
                {/each}
            </ul>
        {/if}
    </div>
</div>
