import { Temporal } from "temporal-polyfill";
import { log_debug } from "$utilities/logger";

let cache = {};

export const CacheKeys = {
    isAuthenticated: "isAuthenticated"
}

export async function cached_result_async<T>(key: string, staleAfterSeconds: number, get_result: any, forceRefresh: boolean = false) {
    if (!cache[key]) {
        cache[key] = {
            l: 0,
            c: undefined as T,
        };
    }
    const staleEpoch = ((cache[key]?.l ?? 0) + staleAfterSeconds);
    const isStale = forceRefresh || (staleEpoch < Temporal.Now.instant().epochSeconds);
    if (isStale || !cache[key]?.c) {
        cache[key].c = typeof get_result === "function" ? await get_result() : get_result;
        cache[key].l = Temporal.Now.instant().epochSeconds;
    }

    log_debug("Ran cached_result_async", {
        cacheKey: key,
        isStale,
        cache: cache[key],
        staleEpoch,
    });

    return cache[key].c as T;
}

export function clear_cache_key(key: string) {
    if (!key) throw new Error("No key was specified");
    cache[key].c = undefined;
    log_debug("Cleared cache with key: " + key);
}