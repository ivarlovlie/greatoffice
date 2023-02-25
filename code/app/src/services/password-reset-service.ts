import { http_get_async, http_post_async } from "$utilities/_fetch";
import { api_base } from "$configuration";
import { is_known_problem } from "$models/internal/KnownProblem";
import type {
    CreateRequestResponse,
    FulfillRequestResponse,
    IPasswordResetService,
    RequestIsValidResponse,
} from "./abstractions/IPasswordResetService";

export class PasswordResetService implements IPasswordResetService {
    static resolve(): IPasswordResetService {
        return new PasswordResetService();
    }
    async create_request_async(email: string): Promise<CreateRequestResponse> {
        const response = await http_post_async(api_base("_/password-reset-request/create"), { email });
        if (response.ok) return { isCreated: true };
        if (is_known_problem(response)) return {
            isCreated: false,
            knownProblem: await response.json(),
        };

        return {
            isCreated: false,
        };
    }

    async fulfill_request_async(id: string, newPassword: string): Promise<FulfillRequestResponse> {
        const response = await http_post_async(api_base("_/password-reset-request/fulfill"), { id: id, newPassword });
        if (response.ok) return { isFulfilled: true };
        if (is_known_problem(response)) return {
            isFulfilled: false,
            knownProblem: await response.json(),
        };

        return {
            isFulfilled: false,
        };
    }

    async request_is_valid_async(id: string): Promise<RequestIsValidResponse> {
        const response = await http_get_async(api_base("_/password-reset-request/is-valid?id=" + id));
        const responseBody = await response.json() as { isValid: boolean };
        return {
            isValid: responseBody.isValid,
        };
    }
}