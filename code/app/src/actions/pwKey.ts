import { is_testing } from "$configuration";

export default function pwKey(node: HTMLElement, value: string | undefined) {
    if (!value) return;
    if (!is_testing()) return;
    node.setAttribute("pw-key", value);
}