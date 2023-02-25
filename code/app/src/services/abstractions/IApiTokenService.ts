import type { Temporal } from "temporal-polyfill"

export interface IApiTokenService {
    create_token_async(payload: CreateTokenPayload): Promise<CreateTokenResponse>,
    delete_token_async(payload: DeleteTokenPayload): Promise<DeleteTokenResponse>,
    get_tokens_async(query: TokenQuery): Promise<GetTokensResponse>
}
export type GetTokensResponse = {
    results: Array<GetTokensTokenModel>
};
export type GetTokensTokenModel = {
    id: string,
    name: string,
    permissions: string[]
}
export type TokenQuery = {
    includeStale: boolean
};
export type DeleteTokenResponse = {
    isDeleted: boolean
};
export type DeleteTokenPayload = {
    id: string
};
export type CreateTokenResponse = {
    isCreated: boolean
};
export type CreateTokenPayload = {
    expiryDate: Temporal.PlainDateTime,
    allowRead: boolean,
    allowCreate: boolean,
    allowUpdate: boolean,
    allowDelete: boolean
};