import { browser } from "$app/environment";
import { is_empty_object } from "./validators";

export type StorageType = "local" | "session";
export const browserStorage = {
    remove_with_regex(type: StorageType, regex: RegExp): void {
        if (!browser) return;
        const storage = (type === "local" ? window.localStorage : window.sessionStorage);
        let n = storage.length;
        while (n--) {
            const key = storage.key(n);
            if (key && regex.test(key)) {
                storage.removeItem(key);
            }
        }
    },
    set_stringified(type: StorageType, key: string, value: object): void {
        if (!browser) return;
        if (is_empty_object(value)) return;
        (type === "local" ? window.localStorage : window.sessionStorage).setItem(key, JSON.stringify(value));
    },
    get_stringified<T>(type: StorageType, key: string): T | any {
        if (!browser) return;
        return JSON.parse((type === "local" ? window.localStorage : window.sessionStorage).getItem(key) ?? "{}");
    }
}