import {api_base, CookieNames} from "$configuration";
import {cached_result_async, CacheKeys} from "$utils/cache";
import {get_md5_hash} from "$utils/crypto-helpers";
import {error, redirect} from "@sveltejs/kit";
import type {LayoutServerLoad} from "./$types";

export const load: LayoutServerLoad = async ({route, cookies, locals, fetch}) => {
    const isBaseRoute = route.id === "/(main)";
    const isPortalRoute = route.id === "/(main)/(public)/portal";
    const isPublicRoute = (isBaseRoute || (route.id?.startsWith("/(main)/(public)") ?? false)) ?? true;
    const sessionCookieValue = cookies.get(CookieNames.session);
    let sessionIsValid = false;
    if ((sessionCookieValue?.length > 0 ?? false)) {
        const sessionHash = get_md5_hash(sessionCookieValue);
        sessionIsValid = (await cached_result_async<Response>(sessionHash + "_" + CacheKeys.isAuthenticated, 120, () => fetch(api_base("_/is-authenticated"), {
            headers: {
                Cookie: CookieNames.session + "=" + sessionCookieValue,
            },
        }).catch((e) => {
            console.error(e);
            throw error(503, {
                message: "We are experiencing a service disruption! Have patience while we resolve the issue.",
            });
        }))).ok;
    }

    console.debug("Base Layout loaded", {
        sessionIsValid,
        isPublicRoute,
        isBaseRoute,
        isPortalRoute,
        routeId: route.id,
    });

    if (sessionIsValid && isPublicRoute && !isPortalRoute) {
        throw redirect(302, "/home");
    } else if (!isPortalRoute && (isBaseRoute || !sessionIsValid && !isPublicRoute)) {
        throw redirect(302, "/sign-in");
    }

    return {
        locale: locals.locale,
    };
};
