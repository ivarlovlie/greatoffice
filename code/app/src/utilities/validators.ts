export const EMAIL_REGEX = new RegExp(/^([a-z0-9]+(?:([._\-])[a-z0-9]+)*@(?:[a-z0-9]+(?:(-)[a-z0-9]+)?\.)+[a-z0-9](?:[a-z0-9]*[a-z0-9])?)$/i);
export const URL_REGEX = new RegExp(/^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-.][a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/gm);
export const GUID_REGEX = new RegExp(/^[0-9a-f]{8}-[0-9a-f]{4}-[0-5][0-9a-f]{3}-[089ab][0-9a-f]{3}-[0-9a-f]{12}$/i);
export const NORWEGIAN_PHONE_NUMBER_REGEX = new RegExp(/(0047|\+47|47)?\d{8,12}/);

export function is_email(value: string): boolean {
    return EMAIL_REGEX.test(String(value).toLowerCase());
}

export function is_url(value: string): boolean {
    return URL_REGEX.test(String(value).toLowerCase());
}

export function is_norwegian_phone_number(value: string): boolean {
    if (value.length < 8 || value.length > 12) {
        return false;
    }
    return NORWEGIAN_PHONE_NUMBER_REGEX.test(String(value));
}

export function is_guid(value: string): boolean {
    if (!value) {
        return false;
    }
    if (value[0] === "{") {
        value = value.substring(1, value.length - 1);
    }
    return GUID_REGEX.test(value);
}

export function is_empty_object(obj: object): boolean {
    if (!obj) return true;
    return obj !== void 0 && Object.keys(obj).length > 0;
}