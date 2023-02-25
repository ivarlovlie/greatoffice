<script lang="ts">
    import pwKey from "$actions/pwKey";
    import {random_string} from "$utilities/misc-helpers";

    export let label: string;
    export let id: string | undefined = "input__" + random_string(4);
    export let name: string | undefined = undefined;
    export let disabled: boolean | null = null;
    export let checked: boolean;
    export let required: boolean | null = null;
    export let _pwKey: string | undefined = undefined;
</script>

<div class="flex items-center">
    <input
            {name}
            use:pwKey={_pwKey}
            {disabled}
            {id}
            {required}
            type="checkbox"
            bind:checked
            class="h-4 w-4 text-teal-600 focus:ring-teal-500 border-gray-300 rounded"
    />
    <label for={id} class="ml-2 block text-sm text-gray-900">
        {@html required ? "<span class='text-red-500'>*</span>" : ""}
        {label}
    </label>
</div>
