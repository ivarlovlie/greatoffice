import type { FormError } from "./FormError";

export interface IForm {
    fields: Record<string, IFormField>;
    error: FormError;
    get_payload: Function;
    submit_async: Function;
    isLoading: boolean;
    showError: boolean;
}

export interface IFormField {
    value: any;
    errors: Array<string>;
}
