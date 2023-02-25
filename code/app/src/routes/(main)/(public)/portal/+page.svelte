<script lang="ts">
    import { onMount } from "svelte";
    import type { PageData } from "./$types";
    import type { PortalMessage } from "$configuration";
    import { goto } from "$app/navigation";
    import { sgs } from "$utilities/global-state";

    export let data: PageData;

    onMount(async () => {
        switch (data.message as PortalMessage) {
            case "emailValidated": {
                sgs("showEmailValidatedAlertWhenLoggedIn", true);
                await goto("/home");
                break;
            }
            default: {
                await goto("/home");
            }
        }
    });
</script>

<div class="p-3">
    <h1>Warping...</h1>
</div>
