export function merge_obj_arr<T>(a: Array<T>, b: Array<T>, props: Array<string>): Array<T> {
    let start = 0;
    let merge = [];

    while (start < a.length) {

        if (a[start] === b[start]) {
            //pushing the merged objects into array
            merge.push({ ...a[start], ...b[start] });
        }
        //incrementing start value
        start = start + 1;
    }
    return merge;
}

export function no_type_check(x: any) {
    return x;
}

export function capitalise(value: string): string {
    return value.charAt(0).toUpperCase() + value.slice(1);
}

export function get_query_string(params: any = {}): string {
    const map = Object.keys(params).reduce((arr: Array<string>, key: string) => {
        if (params[key] !== undefined) {
            return arr.concat(`${key}=${encodeURIComponent(params[key])}`);
        }
        return arr;
    }, [] as any);

    if (map.length) {
        return `?${map.join("&")}`;
    }

    return "";
}

export function make_url(url: string, params: object): string {
    return `${url}${get_query_string(params)}`;
}

export function noop() {
}

export function random_string(length: number): string {
    if (!length) {
        throw new Error("length is undefined");
    }
    let result = "";
    const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}

export function get_random_int(min: number, max: number): number {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

export function get_hash_code(value: string): number | undefined {
    let hash = 0;
    if (value.length === 0) {
        return;
    }
    for (let i = 0; i < value.length; i++) {
        const char = value.charCodeAt(i);
        hash = (hash << 5) - hash + char;
        hash |= 0;
    }
    return hash;
}
