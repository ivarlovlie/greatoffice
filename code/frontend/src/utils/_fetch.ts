import { Temporal } from "temporal-polyfill";
import { redirect } from "@sveltejs/kit";
import { browser } from "$app/environment";
import { goto } from "$app/navigation";
import { SignInPageMessage, signInPageMessageQueryKey } from "$routes/(main)/(public)/sign-in";
import { AccountService } from "$services/account-service";


export async function http_post_async(url: string, body?: object | string, timeout = -1, skip_401_check = false, abort_signal?: AbortSignal): Promise<Response> {
    const init = make_request_init("post", body, abort_signal);
    const response = await internal_fetch_async({ url, init, timeout });
    if (!skip_401_check && await redirect_if_401_async(response)) throw new Error("Server returned 401");
    return response;
}

export async function http_get_async(url: string, timeout = -1, skip_401_check = false, abort_signal?: AbortSignal): Promise<Response> {
    const init = make_request_init("get", undefined, abort_signal);
    const response = await internal_fetch_async({ url, init, timeout });
    if (!skip_401_check && await redirect_if_401_async(response)) throw new Error("Server returned 401");
    return response;
}

export async function http_delete_async(url: string, body?: object | string, timeout = -1, skip_401_check = false, abort_signal?: AbortSignal): Promise<Response> {
    const init = make_request_init("delete", body, abort_signal);
    const response = await internal_fetch_async({ url, init, timeout });
    if (!skip_401_check && await redirect_if_401_async(response)) throw new Error("Server returned 401");
    return response;
}

async function internal_fetch_async(request: InternalFetchRequest): Promise<Response> {
    if (!request.init) throw new Error("request.init is required");
    const fetch_request = new Request(request.url, request.init);
    let response: any;

    try {
        if (request.timeout && request.timeout > 500) {
            response = await Promise.race([
                fetch(fetch_request),
                new Promise((_, reject) => setTimeout(() => reject(new Error("Timeout")), request.timeout)),
            ]);
        } else {
            response = await fetch(fetch_request);
        }
    } catch (error: any) {
        if (error.message === "Timeout") {
            console.error("Request timed out", error);
        } else if (error.message === "Network request failed") {
            console.error("No internet connection", error);
        } else {
            throw error;
        }
    }

    return response;
}

async function redirect_if_401_async(response: Response): Promise<boolean> {
    if (response.status === 401) {
        const redirectUrl = `/sign-in?${signInPageMessageQueryKey}=${SignInPageMessage.LOGGED_OUT}`;
        await AccountService.resolve().end_session_async();
        if (browser) {
            await goto(redirectUrl);
        } else {
            throw redirect(307, redirectUrl);
        }
    }
    return false;
}

function make_request_init(method: string, body?: any, signal?: AbortSignal): RequestInit {
    const init = {
        method,
        credentials: "include",
        signal,
        headers: {
            "X-TimeZone": Temporal.Now.timeZone().id,
        },
    } as RequestInit;

    if (body) {
        init.body = JSON.stringify(body);
        init.headers["Content-Type"] = "application/json;charset=UTF-8";
    }

    return init;
}

export type InternalFetchRequest = {
    url: string,
    init: RequestInit,
    timeout?: number
    retry_count?: number,
}