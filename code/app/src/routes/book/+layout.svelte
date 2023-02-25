<script>
    import { page } from "$app/stores";
    import "../../app.pcss";
</script>

<div id="wrapper">
    <nav>
        <a href="/book/alerts" class="link" class:active={$page.url.pathname.startsWith("/book/alerts")}>Alerts</a>
        <a href="/book/buttons" class="link" class:active={$page.url.pathname.startsWith("/book/buttons")}>Buttons</a>
        <a href="/book/toggles" class="link" class:active={$page.url.pathname.startsWith("/book/toggles")}>Toggles</a>
        <a href="/book/inputs" class="link" class:active={$page.url.pathname.startsWith("/book/inputs")}>Inputs</a>
        <a href="/book/badges" class="link" class:active={$page.url.pathname.startsWith("/book/badges")}>Badges</a>
        <a href="/book/notifications" class="link" class:active={$page.url.pathname.startsWith("/book/notifications")}>Notifications</a>
    </nav>
    <main>
        <slot />
    </main>
</div>

<style global lang="postcss">
    #wrapper {
        display: flex;
        flex-direction: row;
    }
    nav {
        min-width: 120px;
        padding: 10px;
        display: flex;
        flex-direction: column;
        position: sticky;
        position: -webkit-sticky;
        top: 0;
        height: fit-content;
    }
    main {
        width: 100%;
        padding: 10px;
    }
    section {
        margin-bottom: 25px;

        h2 {
            margin-bottom: 5px;
        }
    }
</style>
