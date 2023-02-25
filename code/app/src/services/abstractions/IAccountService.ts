import type { KnownProblem } from "$models/internal/KnownProblem";
import type { Writable } from "svelte/store";

export interface IAccountService {
    session: Writable<Session>,
    login_async(payload: LoginPayload): Promise<LoginResponse>,
    logout_async(): Promise<void>,
    end_session_async(callback?: Function): Promise<void>,
    create_account_async(payload: CreateAccountPayload): Promise<CreateAccountResponse>,
    delete_current_async(): Promise<DeleteAccountResponse>,
    update_current_async(payload: UpdateAccountPayload): Promise<UpdateAccountResponse>,
}

export type Session = {
    username: string,
    displayName: string,
    id: string,
    _lastUpdated: number
}

export type LoginPayload = {
    username: string,
    password: string,
    persist: boolean
}

export type LoginResponse = {
    isLoggedIn: boolean,
    knownProblem?: KnownProblem
}

export type CreateAccountPayload = {
    username: string,
    password: string,
}

export type CreateAccountResponse = {
    isCreated: boolean,
    knownProblem?: KnownProblem
}

export type DeleteAccountResponse = {
    isDeleted: boolean
}

export type UpdateAccountPayload = {
    username: string,
    password: string
}

export type UpdateAccountResponse = {
    isUpdated: boolean,
    knownProblem?: KnownProblem
}