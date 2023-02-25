export function get_element_by_pw_key(key: string): HTMLElement | null {
    return document.querySelector("[pw-key='" + key + "']");
}

export function get_pw_key_selector(key: string): string {
    return "[pw-key='" + key + "']";
}