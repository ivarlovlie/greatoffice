<script lang="ts">
    import type {ProjectStatus} from "$models/projects/ProjectStatus";
    import Badge from "./badge.svelte";

    export let status: string | ProjectStatus;

    let text = "";
    let type = "default" as any;
    $: switch (status) {
        case "idl":
            type = "tame";
            text = "IDLE";
            break;
        case "exp":
            type = "yellow";
            text = "EXPIRED";
            break;
        case "act":
            type = "green";
            text = "ACTIVE";
            break;
    }
</script>

<Badge {text} {type} uppercase/>
