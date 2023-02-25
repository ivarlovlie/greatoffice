<script lang="ts">
    import pwKey from "$actions/pwKey";
    import {random_string} from "$utilities/misc-helpers";
    import {ExclamationCircleIcon} from "./icons";

    export let label: string | undefined = undefined;
    export let type: string = "text";
    export let autocomplete: string | undefined = undefined;
    export let required: boolean | undefined = undefined;
    export let id: string | undefined = "input__" + random_string(4);
    export let name: string | undefined = undefined;
    export let placeholder: string | undefined = undefined;
    export let helpText: string | undefined = undefined;
    export let errorText: string | undefined = undefined;
    export let errors: Array<string> | undefined = undefined;
    export let disabled = false;
    export let hideLabel = false;
    export let cornerHint: string | undefined = undefined;
    export let icon: any = undefined;
    export let addon: string | undefined = undefined;
    export let value: string | undefined;
    export let wrapperClass: string | undefined = undefined;
    export let _pwKey: string | undefined = undefined;

    $: ariaErrorDescribedBy = id + "__" + "error";
    $: attributes = {
        "aria-describedby": errorText || errors?.length ? ariaErrorDescribedBy : null,
        "aria-invalid": errorText || errors?.length ? "true" : null,
        disabled: disabled || null,
        autocomplete: autocomplete || null,
        required: required || null,
    } as any;
    $: hasBling = icon || addon || errorText;
    const defaultColorClass = "border-gray-300 focus:border-teal-500 focus:ring-teal-500";
    let colorClass = defaultColorClass;
    $: if (errorText) {
        colorClass = "placeholder-red-300 focus:border-red-500 focus:outline-none focus:ring-red-500 text-red-900 pr-10 border-red-300";
    } else {
        colorClass = defaultColorClass;
    }

    function typeAction(node: HTMLInputElement) {
        node.type = type;
    }
</script>

<div class={wrapperClass}>
    {#if label && !cornerHint && !hideLabel}
        <label for={id} class={hideLabel ? "sr-only" : "block text-sm font-medium text-gray-700"}>
            {label}
            {@html required ? "<span class='text-red-500'>*</span>" : ""}
        </label>
    {:else if cornerHint && !hideLabel}
        <div class="flex justify-between">
            {#if label}
                <label for={id} class={hideLabel ? "sr-only" : "block text-sm font-medium text-gray-700"}>
                    {label}
                    {@html required ? "<span class='text-red-500'>*</span>" : ""}
                </label>
            {/if}
            <span class="text-sm text-gray-500">
                {cornerHint}
            </span>
        </div>
    {/if}
    <div class="{label ? 'mt-1' : ''} {hasBling ? 'relative rounded-md' : ''} {addon ? 'flex' : ''}">
        {#if icon}
            <div class="pointer-events-none absolute inset-y-0 left-0 flex items-center pl-3">
                <svelte:component this={icon} class={errorText ? "text-red-500" : "text-gray-400"}/>
            </div>
        {:else if addon}
            <div class="inline-flex items-center rounded-l-md border border-r-0 border-gray-300 bg-gray-50 px-3 text-gray-500 sm:text-sm">
                <span class="text-gray-500 sm:text-sm">{addon}</span>
            </div>
        {/if}
        <input
                use:typeAction
                use:pwKey={_pwKey}
                {name}
                {id}
                {...attributes}
                bind:value
                class="block w-full rounded-md shadow-sm sm:text-sm
                {colorClass}
                {disabled ? 'disabled:cursor-not-allowed disabled:border-gray-200 disabled:bg-gray-50 disabled:text-gray-500' : ''}
                {addon ? 'min-w-0 flex-1 rounded-none rounded-r-md' : ''}
                {icon ? 'pl-10' : ''}"
                {placeholder}
        />
        {#if errorText}
            <div class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-3">
                <ExclamationCircleIcon class="text-red-500"/>
            </div>
        {/if}
    </div>
    {#if helpText && !errorText}
        <p class="mt-2 text-sm text-gray-500">
            {helpText}
        </p>
    {/if}
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
