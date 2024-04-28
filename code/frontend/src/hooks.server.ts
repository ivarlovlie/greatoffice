import {CookieNames} from "$configuration";
import {detectLocale, i18n, isLocale, locales} from "$i18n/i18n-util";
import type {Handle, RequestEvent} from "@sveltejs/kit";
import {initAcceptLanguageHeaderDetector} from "typesafe-i18n/detectors";
import type {Locales} from "$i18n/i18n-types";
import {loadAllLocales} from "$i18n/i18n-util.sync";

loadAllLocales();
const L = i18n();

export const handle: Handle = async ({event, resolve}) => {
    const localeCookie = event.cookies.get(CookieNames.locale);
    const preferredLocale = getPreferredLocale(event);
    let finalLocale = localeCookie ?? preferredLocale;
    let forceCookieSet = false;

    console.debug("Handling locale", {
        locales,
        localeCookie,
        preferredLocale,
        finalLocale,
    });

    if (!isLocale(finalLocale)) {
        console.debug(finalLocale + " is not a valid locale or it does not exist, switching to default: en");
        finalLocale = "en";
        forceCookieSet = true;
    }

    if (!localeCookie || forceCookieSet) {
        // Set a locale cookie
        event.cookies.set(CookieNames.locale, finalLocale, {
            sameSite: "strict",
            path: "/",
            httpOnly: false,
        });
    }

    event.locals.locale = finalLocale as Locales;
    event.locals.LL = L[finalLocale as Locales];

    return resolve(event, {transformPageChunk: ({html}) => html.replace("%lang%", finalLocale)});
};

function getPreferredLocale(event: RequestEvent) {
    const acceptLanguageDetector = initAcceptLanguageHeaderDetector(event.request);
    return detectLocale(acceptLanguageDetector);
}
