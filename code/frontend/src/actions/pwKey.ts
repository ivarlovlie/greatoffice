export default function pwKey(node: HTMLElement, value: string | undefined) {
    if (!value) return;
    node.setAttribute("pw-key", value);
}