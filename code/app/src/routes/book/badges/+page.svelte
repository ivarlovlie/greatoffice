<script lang="ts">
    import Badge from "$components/badge.svelte";
</script>

<section>
    <h2>Variants</h2>
    <Badge text="default"/>
    <Badge type="blue" text="blue"/>
    <Badge type="green" text="green"/>
    <Badge type="red" text="red"/>
    <Badge type="tame" text="tame"/>
    <Badge type="yellow" text="yellow"/>
    <Badge size="large" text="large"/>
    <Badge text="with dot" withDot type="blue"/>
    <Badge text="removable" removable id="badge-1" on:remove={(e) => alert("removed " + e.detail.id)}/>
    <Badge text="with dot" size="large" withDot type="blue"/>
    <Badge text="removable" removable size="large" id="badge-2" uppercase
           on:remove={(e) => alert("removed " + e.detail.id)}/>
</section>
