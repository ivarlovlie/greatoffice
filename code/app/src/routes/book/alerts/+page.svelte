<script>
    import Alert from "$components/alert.svelte";
</script>

<section>
    <h2>Info</h2>
    <Alert type="info" message="This is message" title="This is title"/>
</section>
<section>
    <h2>Warning</h2>
    <Alert type="warning" message="This is message" title="This is title"/>
</section>
<section>
    <h2>Error</h2>
    <Alert type="error" message="This is message" title="This is title"/>
</section>
<section>
    <h2>Success</h2>
    <Alert type="success" message="This is message" title="This is title"/>
</section>
<section>
    <h2>Actions</h2>
    <Alert
            type="info"
            message="This is message"
            title="This is title"
            closeable
            actions={[
            {
                id: "confirm",
                text: "Yes!",
            },
            {
                id: "cancel",
                text: "No!",
                color: "red",
            },
        ]}
    />
</section>
<section>
    <h2>Right link</h2>
    <Alert
            on:rightLinkCliked={() => alert("Right link clicked")}
            rightLinkText="Link or action"
            title="Go here"
            message="Hehe"
            type="error"
    />
</section>
<section>
    <h2>List</h2>
    <Alert
            title="This is title"
            listItems={["Message 1", "Message 2"]}
            type="error"
            message="This is bad dude"
            closeable
            closeableCooldown="60"
            id="alert-1"
            on:actrepeat={() => {
            alert("Repeat requested");
        }}
            actions={[{ id: "repeat", text: "Try again" }]}
    />
</section>
<section>
    <h2>Closeable</h2>
    <Alert message="This is message" closeable type="info"/>
</section>
