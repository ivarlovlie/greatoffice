import type { KnownProblem } from "$models/internal/KnownProblem"

export interface IPasswordResetService {
    create_request_async(email: string): Promise<CreateRequestResponse>,
    fulfill_request_async(id: string, newPassword: string): Promise<FulfillRequestResponse>,
    request_is_valid_async(id: string): Promise<RequestIsValidResponse>
}

export type RequestIsValidResponse = {
    isValid: boolean
}

export type FulfillRequestResponse = {
    isFulfilled: boolean,
    knownProblem?: KnownProblem
}

export type CreateRequestResponse = {
    isCreated: boolean,
    knownProblem?: KnownProblem
}