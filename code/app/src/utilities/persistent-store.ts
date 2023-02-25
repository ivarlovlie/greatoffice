import { browser } from "$app/environment";
import { writable as _writable, readable as _readable } from "svelte/store";
import type { Writable, Readable, StartStopNotifier } from "svelte/store";
import { log_debug, log_info } from "./logger";

enum StoreType {
    SESSION = 0,
    LOCAL = 1
}

interface StoreOptions {
    store?: StoreType;
}

interface WritableStoreInit<T> {
    name: string,
    initialState: T,
    options?: StoreOptions
}

interface ReadableStoreInit<T> {
    name: string,
    initialState: T,
    callback: StartStopNotifier<any>,
    options?: StoreOptions
}

function get_store(type: StoreType): Storage {
    if (!browser) return undefined;
    switch (type) {
        case StoreType.SESSION:
            return window.sessionStorage;
        case StoreType.LOCAL:
            return window.localStorage;
    }
}

function prepared_store_value(value: any): string {
    try {
        return JSON.stringify(value);
    } catch (e) {
        console.error(e);
        return "__INVALID__";
    }
}

function get_store_value<T>(init: WritableStoreInit<T> | ReadableStoreInit<T>): any {
    try {
        const storage = get_store(init.options.store);
        if (!storage) return;
        const value = storage.getItem(init.name);
        if (!value) return false;
        return JSON.parse(value);
    } catch (e) {
        console.error(e);
        return { __INVALID__: true };
    }
}

function hydrate<T>(store: Writable<T>, init: WritableStoreInit<T> | ReadableStoreInit<T>): void {
    const value = get_store_value<T>(init);
    if (value && store.set) store.set(value);
}

function subscribe<T>(store: Writable<T> | Readable<T>, init: WritableStoreInit<T> | ReadableStoreInit<T>): void {
    const storage = get_store(init.options.store);
    if (!storage) return;
    if (!store.subscribe) return;
    store.subscribe((state: any) => {
        storage.setItem(init.name, prepared_store_value(state));
    });
}

function create_writable_persistent<T>(init: WritableStoreInit<T>): Writable<T> {
    if (!browser) {
        log_info("WARN: Persistent store is only available in the browser");
        return;
    }
    if (init.options === undefined) throw new Error("init is a required parameter");
    log_debug("creating writable store with options: ", init);
    const store = _writable<T>(init.initialState);
    hydrate(store, init);
    subscribe(store, init);
    return store;
}

function create_readable_persistent<T>(init: ReadableStoreInit<T>): Readable<T> {
    if (!browser) {
        log_info("WARN: Persistent store is only available in the browser");
        return;
    }
    if (init.options === undefined) throw new Error("init is a required parameter");
    log_debug("Creating readable store with options: ", init);
    const store = _readable<T>(init.initialState, init.callback);
    // hydrate(store, options);
    subscribe(store, init);
    return store;
}

export {
    create_writable_persistent,
    create_readable_persistent,
    StoreType,
};

export type {
    WritableStoreInit as WritableStore,
    ReadableStoreInit as ReadableStore,
    StoreOptions,
};

