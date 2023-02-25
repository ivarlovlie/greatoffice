import { get } from "svelte/store";
import { create_writable_persistent } from "./persistent-store";

const state = create_writable_persistent<any>({
    initialState: {},
    name: "global-state"
});

export type GlobalStateKeys = "isLoggedIn" | "showEmailValidatedAlertWhenLoggedIn" | "all";

export function fgs(key: GlobalStateKeys): any {
    const value = get(state);
    if (key === "all") return value;
    return value[key];
}

export function sgs(key: GlobalStateKeys, value: any) {
    if (key === "all") throw new Error("Not allowed to set global state key: all");
    const stateValue = get(state);
    stateValue[key] = JSON.stringify(value)
    state.set(stateValue);
}