<script lang="ts">
    import { Notification } from "$components";
    import type { NotificationType } from "$components/notification.svelte";

    let type = "info" as NotificationType;
    let nonClosable = false;
    let title = "Title";
    let subtitle = "Subtitle";
    let hideAfterSeconds = -1;
    let timeout;

    function open(newtype: NotificationType) {
        console.log(newtype);
        type = newtype;
    }
</script>

<section style="display: flex;flex-direction: column; max-width:200px;gap:5px">
    <h2>Type:</h2>
    <select
        on:change={(e) => {
            //@ts-ignore
            open(e.target.selectedOptions[0].value);
        }}
    >
        <option value="info">info</option>
        <option value="warning">warning</option>
        <option value="error">error</option>
        <option value="success">success</option>
        <option value="subtle">subtle</option>
    </select>
    <label for="nonClosable">
        <input type="checkbox" id="nonClosable" bind:checked={nonClosable} />
        nonClosable
    </label>
    <input type="text" bind:value={title} />
    <input type="text" bind:value={subtitle} />
    <input type="number" bind:value={timeout} placeholder="hideAfterSeconds" />
    <small class="text-sm justify-end">
        <span class="link" on:click={() => (hideAfterSeconds = timeout ?? -1)}>Apply</span>
        <span
            class="link"
            on:click={() => {
                hideAfterSeconds = -1;
                timeout = 0;
            }}>Reset</span
        >
    </small>
    <Notification {title} {subtitle} show={true} {type} {nonClosable} {hideAfterSeconds} />
</section>
