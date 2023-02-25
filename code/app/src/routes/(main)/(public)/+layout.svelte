<script>
    import { LocaleSwitcher } from "$components";
    import LL from "$i18n/i18n-svelte";
</script>

<LocaleSwitcher tabindex={-1} />
<slot />
<footer class="grid sm:gap-5 grid-flow-row sm:justify-center px-2 sm:grid-flow-col">
    <a href="https://greatoffice.life/privacy" class="link">
        {$LL.privacyPolicy()}
    </a>
    <a href="https://greatoffice.life/terms" class="link">
        {$LL.tos()}
    </a>
    <a href="https://greatoffice.life/docs" class="link">
        {$LL.documentation()}
    </a>
</footer>
