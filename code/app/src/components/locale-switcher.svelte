<script lang="ts">
    import pwKey from "$actions/pwKey";
    import {browser} from "$app/environment";
    import {page} from "$app/stores";
    import {CookieNames} from "$configuration";
    import {setLocale, locale} from "$i18n/i18n-svelte";
    import type {Locales} from "$i18n/i18n-types";
    import {locales} from "$i18n/i18n-util";
    import {loadLocaleAsync} from "$i18n/i18n-util.async";
    import Cookies from "js-cookie";

    export let _pwKey: string | undefined = undefined;
    export let tabindex: number | undefined = undefined;
    let currentLocale = Cookies.get(CookieNames.locale);

    async function switch_locale(newLocale: Locales) {
        if (!newLocale || $locale === newLocale) return;
        await loadLocaleAsync(newLocale);
        setLocale(newLocale);
        document.querySelector("html")?.setAttribute("lang", newLocale);
        Cookies.set(CookieNames.locale, newLocale);
        currentLocale = newLocale;
        console.log("Switched to: " + newLocale);
    }

    function on_change(event: Event) {
        const target = event.target as HTMLSelectElement;
        switch_locale(target.options[target.selectedIndex].value as Locales);
    }

    $: if (browser) {
        switch_locale($page.params.lang as Locales);
    }

    function get_locale_name(iso: string) {
        switch (iso) {
            case "nb": {
                return "Norsk Bokmål";
            }
            case "en": {
                return "English";
            }
        }
    }
</script>

<select
        {tabindex}
        use:pwKey={_pwKey}
        on:change={on_change}
        class="mt-1 mr-1 block border-none py-2 pl-3 pr-10 text-base rounded-md right-0 absolute focus:outline-none focus:ring-teal-500 sm:text-sm"
>
    {#each locales as aLocale}
        <option value={aLocale} selected={aLocale === currentLocale}>{get_locale_name(aLocale)}</option>
    {/each}
</select>
