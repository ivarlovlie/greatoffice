export function generate_random_hex_color(skip_contrast_check = false) {
    let hex = __generate_random_hex_color();
    if (skip_contrast_check) return hex;
    while ((__calculate_contrast_ratio("#ffffff", hex) < 4.5) || (__calculate_contrast_ratio("#000000", hex) < 4.5)) {
        hex = __generate_random_hex_color();
    }

    return hex;
}

// Largely copied from chroma js api
function __generate_random_hex_color(): string {
    let code = "#";
    for (let i = 0; i < 6; i++) {
        code += "0123456789abcdef".charAt(Math.floor(Math.random() * 16));
    }
    return code;
}

function __calculate_contrast_ratio(hex1: string, hex2: string): number {
    const rgb1 = __hex_to_rgb(hex1);
    const rgb2 = __hex_to_rgb(hex2);
    const l1 = __get_luminance(rgb1[0], rgb1[1], rgb1[2]);
    const l2 = __get_luminance(rgb2[0], rgb2[1], rgb2[2]);
    const result = l1 > l2 ? (l1 + 0.05) / (l2 + 0.05) : (l2 + 0.05) / (l1 + 0.05);
    return result;
}

function __hex_to_rgb(hex: string): number[] {
    if (!hex.match(/^#([A-Fa-f0-9]{6})$/)) return [];
    if (hex[0] === "#") hex = hex.substring(1, hex.length);
    return [parseInt(hex.substring(0, 2), 16), parseInt(hex.substring(2, 4), 16), parseInt(hex.substring(4, 6), 16)];
}

function __get_luminance(r: any, g: any, b: any) {
    // relative luminance
    // see http://www.w3.org/TR/2008/REC-WCAG20-20081211/#relativeluminancedef
    r = __luminance_x(r);
    g = __luminance_x(g);
    b = __luminance_x(b);
    return 0.2126 * r + 0.7152 * g + 0.0722 * b;
}

function __luminance_x(x: any) {
    x /= 255;
    return x <= 0.03928 ? x / 12.92 : Math.pow((x + 0.055) / 1.055, 2.4);
}
