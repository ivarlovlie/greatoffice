import { env } from "$env/dynamic/private";

export const APP_ADDRESS = "https://stage.greatoffice.app";
export const API_ADDRESS = "https://stage-api.greatoffice.app";
export const DEV_APP_ADDRESS = "http://localhost";
export const DEV_API_ADDRESS = "http://localhost:5000";

export function api_base(path: string = "", explicitVersion = 1): string {
    if (path && !path.startsWith("_")) path = "v" + explicitVersion + path;
    return (is_development() ? DEV_API_ADDRESS : API_ADDRESS) + (path !== "" ? "/" + path : "");
}

export function is_development(): boolean {
    return import.meta.env.DEV;
}

export function is_testing(): boolean {
    return env.TESTING == "true";
}

export function is_debug(): boolean {
    return localStorage.getItem(StorageKeys.debug) !== "true";
}

export const CookieNames = {
    theme: "go_theme",
    locale: "go_locale",
    session: "go_session",
};

export function get_test_context(): TestContext {
    return {
        user: {
            username: env.TEST_USERNAME,
            password: env.TEST_PASSWORD,
        },
    };
}

export interface TestContext {
    user: {
        username: string,
        password: string
    };
}

export const QueryKeys = {
    labels: "labels",
    categories: "categories",
    entries: "entries",
};

export const StorageKeys = {
    session: "sessionData",
    theme: "theme",
    debug: "debug",
    categories: "categories",
    labels: "labels",
    entries: "entries",
    stopwatch: "stopwatchState",
    logLevel: "logLevel",
};

export type PortalMessage = "emailValidated";