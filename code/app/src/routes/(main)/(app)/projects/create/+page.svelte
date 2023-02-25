<script lang="ts">
    import { Input, TextArea, Combobox, Button } from "$components";
    import type { ProjectMember } from "$models/projects/ProjectMember";
    import LL from "$i18n/i18n-svelte";

    let members = [];
    const formData = {
        name: {
            value: "",
            errors: [],
        },
        description: {
            value: "",
            errors: [],
        },
        start: {
            value: "",
            errors: [],
        },
        stop: {
            value: "",
            errors: [],
        },
        members: {
            value: [] as Array<ProjectMember>,
            errors: [],
        },
    };

    const formError = {
        title: "",
        subtitle: "",
    };

    async function submit_form_async() {
        alert("Submitted");
    }
</script>

<h1>Create a new project</h1>
<form on:submit|preventDefault={submit_form_async} class="max-w-md flex flex-col gap-2">
    <Input label="Name" bind:value={formData.name.value} errors={formData.name.errors} required />
    <TextArea label="Description" bind:value={formData.description.value} errors={formData.description.errors} />
    <section class="grid grid-flow-row sm:grid-flow-col gap-2">
        <Input type="date" label="Start" bind:value={formData.start.value} errors={formData.start.errors} />
        <Input type="date" label="Stop" bind:value={formData.stop.value} errors={formData.stop.errors} />
    </section>
    <Combobox options={members} label={$LL.app.members()}>
        <svelte:fragment slot="no-records">
            <h1>No members found</h1>
            {#if !members?.length}
                <p>
                    <a href="/users/create" class="link">Click here</a> to create your first user
                </p>
            {/if}
        </svelte:fragment>
    </Combobox>
    <Button text={$LL.submit()} />
</form>
