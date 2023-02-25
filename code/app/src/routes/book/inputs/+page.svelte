<script lang="ts">
    import {TextArea, Input, Combobox} from "$components";
    import {DatabaseIcon} from "$components/icons";

    let value;
    let i = 0;
    let options = [];
    let tempOptions = [];
    while (i < 101) {
        tempOptions.push({
            id: crypto.randomUUID(),
            name: "Option " + i,
        });
        options = tempOptions;
        i++;
    }

    async function add({name}) {
        const copy = options;
        copy.push({
            id: crypto.randomUUID(),
            name: name,
        });
        options = copy;
    }
</script>

<section>
    <h2>Combobox</h2>
    <Combobox {options} label="Wiii" multiple createable on_create_async={add}/>
</section>

<section>
    <h2>Default</h2>
    <Input label="Input me" placeholder="Hello" bind:value/>
</section>

<section>
    <h2>With icon</h2>
    <Input label="Input me" placeholder="Hello" icon={DatabaseIcon} bind:value/>
</section>

<section>
    <h2>With corner hint</h2>
    <Input label="Input me ->" placeholder="Hello" cornerHint="Hint hint" bind:value/>
</section>

<section>
    <h2>Disabled</h2>
    <Input label="No" placeholder="Sorry" disabled bind:value/>
</section>

<section>
    <h2>Errored</h2>
    <Input label="No" placeholder="Sorry" errorText="That's not right" bind:value icon={DatabaseIcon}/>
</section>

<section>
    <h2>Many errors</h2>
    <Input label="No" placeholder="Sorry" errors={["That's not right", "Call help!", "Get it together"]} bind:value
           icon={DatabaseIcon}/>
</section>

<section>
    <h2>Help</h2>
    <Input label="Go ahead" placeholder="Write here" helpText="Write above" bind:value/>
</section>
<section>
    <h2>Addon</h2>
    <Input label="Go ahead" placeholder="Write here" bind:value helpText="Write above" addon="To the right"/>
</section>
<section>
    <h2>Textarea</h2>
    <TextArea bind:value label="Hi"/>
</section>
