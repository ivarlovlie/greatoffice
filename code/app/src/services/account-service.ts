import { http_delete_async, http_get_async, http_post_async } from "$utilities/_fetch";
import { browser } from "$app/environment";
import { api_base, CookieNames, StorageKeys } from "$configuration";
import { is_known_problem } from "$models/internal/KnownProblem";
import { log_debug } from "$utilities/logger";
import { StoreType, create_writable_persistent } from "$utilities/persistent-store";
import { get } from "svelte/store";
import type { Writable } from "svelte/store";
import { Temporal } from "temporal-polyfill";
import type {
    CreateAccountPayload,
    CreateAccountResponse,
    DeleteAccountResponse,
    IAccountService,
    LoginPayload,
    LoginResponse,
    Session,
    UpdateAccountPayload,
    UpdateAccountResponse,
} from "./abstractions/IAccountService";

export class AccountService implements IAccountService {
    session: Writable<Session> | undefined;
    private sessionCooldown = 3600;

    constructor() {
        if (browser) {
            this.session = create_writable_persistent({
                name: StorageKeys.session,
                initialState: {} as Session,
                options: {
                    store: StoreType.LOCAL,
                },
            });
            this.refresh_session();
        } else {
            this.session = undefined;
        }
    }

    static resolve(): IAccountService {
        return new AccountService();
    }

    async refresh_session(forceRefresh: boolean = false): Promise<void> {
        if (!this.session) return;
        const currentValue = get(this.session);
        const currentEpoch = Temporal.Now.instant().epochSeconds;
        if (!forceRefresh && ((currentValue?._lastUpdated ?? 0) + this.sessionCooldown) > currentEpoch) {
            log_debug("Session is not stale yet", {
                currentEpoch,
                staleEpoch: currentValue?._lastUpdated + this.sessionCooldown,
            });
            return;
        }
        const sessionResponse = await http_get_async(api_base("_/session-data"));
        if (sessionResponse.ok) {
            this.session.set(await sessionResponse.json());
        } else {
            this.session.set(null);
        }
    }

    async end_session_async(callback: Function = undefined): Promise<void> {
        if (!this.session) return;
        await this.logout_async();
        this.session.set(null);
        if (callback && typeof callback === "function") callback();
    }

    async login_async(payload: LoginPayload): Promise<LoginResponse> {
        const response = await http_post_async(api_base("_/account/login"), payload);
        if (response.ok) return { isLoggedIn: true };
        if (is_known_problem(response)) return {
            isLoggedIn: false,
            knownProblem: await response.json(),
        };
        return {
            isLoggedIn: false,
        };
    }

    async logout_async(): Promise<void> {
        const response = await http_get_async(api_base("_/account/logout"));
        if (!response.ok) {
            const deleteCookieResponse = await fetch("/delete-cookie?key=" + CookieNames.session);
            if (!deleteCookieResponse.ok) {
                throw new Error("Could neither logout nor delete session cookie.");
            }
        }
        return;
    }

    async create_account_async(payload: CreateAccountPayload): Promise<CreateAccountResponse> {
        const response = await http_post_async(api_base("_/account/create"), payload);
        if (response.ok) return { isCreated: true };
        if (is_known_problem(response)) return {
            isCreated: false,
            knownProblem: await response.json(),
        };
        return {
            isCreated: false,
        };
    }

    async delete_current_async(): Promise<DeleteAccountResponse> {
        const response = await http_delete_async(api_base("_/account/delete"));
        return {
            isDeleted: response.ok,
        };
    }

    async update_current_async(payload: UpdateAccountPayload): Promise<UpdateAccountResponse> {
        const response = await http_post_async(api_base("_/account/update"), payload);
        if (response.ok) return { isUpdated: true };
        if (is_known_problem(response)) return {
            isUpdated: false,
            knownProblem: await response.json(),
        };
        return {
            isUpdated: false,
        };
    }
}