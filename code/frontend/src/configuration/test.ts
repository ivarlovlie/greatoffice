import {env} from "$env/dynamic/private";

export function get_test_context(): TestContext {
    return {
        user: {
            username: env.TEST_USERNAME,
            password: env.TEST_PASSWORD,
        },
    };
}

export function is_testing(): boolean {
    return env.TESTING == "true";
}

export interface TestContext {
    user: {
        username: string,
        password: string
    };
}
