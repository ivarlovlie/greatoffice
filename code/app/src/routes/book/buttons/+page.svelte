<script>
    import Button from "$components/button.svelte";
</script>

<section>
    <h2>Primary</h2>
    <Button kind="primary" text="Small" size="sm"/>
    <Button kind="primary" text="Medium/Default"/>
    <Button kind="primary" text="Large" size="lg"/>
    <Button kind="primary" text="Extra large" size="xl"/>
</section>
<section>
    <h2>Secondary</h2>
    <Button kind="secondary" text="Click me!"/>
</section>
<section>
    <h2>White</h2>
    <Button kind="white" text="Click me!"/>
</section>
<section>
    <h2>Loading</h2>
    <Button kind="primary" loading={true} text="Wait"/>
</section>
