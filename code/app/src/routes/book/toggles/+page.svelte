<script>
    import Switch from "$components/switch.svelte";
</script>

<section>
    <h2>Default</h2>
    <Switch />
</section>
<section>
    <h2>Short</h2>
    <Switch type="short" />
</section>
<section>
    <h2>Icon</h2>
    <Switch type="icon" />
</section>
<section>
    <h2>Label / Description</h2>
    <div class="max-w-md">
        <Switch label="Label" description="Some text" />
    </div>
</section>

<section>
    <h2>Label / Description (right aligned)</h2>
    <Switch label="Label" description="Some text" rightAlignedLabelDescription />
</section>
