import { api_base } from "$configuration";
import { http_delete_async, http_get_async, http_post_async } from "$utilities/_fetch";
import type { CreateTokenPayload, CreateTokenResponse, DeleteTokenPayload, DeleteTokenResponse, GetTokensResponse, IApiTokenService, TokenQuery } from "./abstractions/IApiTokenService";

export class ApiTokenService implements IApiTokenService {
    constructor() { }
    static resolve() {
        return new ApiTokenService();
    }
    async create_token_async(payload: CreateTokenPayload): Promise<CreateTokenResponse> {
        const response = await http_post_async(api_base("v1/api-tokens/create"), payload);
        return;
    };
    async delete_token_async(payload: DeleteTokenPayload): Promise<DeleteTokenResponse> {
        const response = await http_delete_async(api_base("v1/api-tokens/delete"), payload);
        return;
    };
    async get_tokens_async(query: TokenQuery): Promise<GetTokensResponse> {
        const response = await http_get_async(api_base("v1/api-tokens"));
        return;
    };
}