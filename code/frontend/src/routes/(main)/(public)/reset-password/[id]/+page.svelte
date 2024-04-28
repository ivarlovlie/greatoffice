<script lang="ts">
    import { onMount } from "svelte";
    import LL from "$i18n/i18n-svelte";
    import { Alert, Input, Button } from "$components";
    import type { PageServerData } from "./$types";
    import { goto } from "$app/navigation";
    import { SignInPageMessage, signInPageMessageQueryKey } from "$routes/(main)/(public)/sign-in";
    import { PasswordResetService } from "$services/password-reset-service";

    export let data: PageServerData;
    const passwordResetService = PasswordResetService.resolve();

    const formData = {
        newPassword: {
            value: "",
            errors: [],
        },
    };

    let finishedPreliminaryLoading = false;
    let loading = false;
    let canSubmit = true;
    let requestIsInvalid = false;

    async function submitFormAsync() {
        if (!canSubmit) return;
        loading = true;
        const request = await passwordResetService.fulfill_request_async(data.resetRequestId, formData.newPassword.value);
        if (request.isFulfilled) {
            goto("/sign-in?" + signInPageMessageQueryKey + "=" + SignInPageMessage.AFTER_PASSWORD_RESET);
        } else if (request.knownProblem) {
        }
        loading = false;
    }

    onMount(async () => {
        const response = await passwordResetService.request_is_valid_async(data.resetRequestId);
        requestIsInvalid = !response.isValid;
        finishedPreliminaryLoading = true;
    });
</script>

<div class="min-h-full flex flex-col justify-center py-12 sm:px-6 lg:px-8">
    {#if finishedPreliminaryLoading}
        <div class="sm:mx-auto sm:w-full p-2 sm:p-0 sm:max-w-md">
            <h2 class="mt-6 text-3xl tracking-tight font-bold text-gray-900">
                {$LL.resetPasswordPage.setANewPassword()}
            </h2>
            <p class="mt-2 text-sm text-gray-600">
                {$LL.or().toLowerCase()}
                <a href="/sign-in" class="link">
                    {$LL.signIntoYourAccount().toLowerCase()}
                </a>
            </p>
        </div>

        <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
            <div class="bg-white py-8 px-4 shadow sm:rounded-lg sm:px-10">
                <form class="space-y-6" on:submit|preventDefault={submitFormAsync}>
                    {#if requestIsInvalid}
                        <Alert
                            title={$LL.resetPasswordPage.invalidRequestTitle()}
                            message={$LL.resetPasswordPage.invalidRequestMessage()}
                        />
                    {/if}
                    <Input
                        id="password"
                        name="password"
                        type="password"
                        autocomplete="new-password"
                        required
                        bind:value={formData.newPassword.value}
                        label={$LL.resetPasswordPage.newPassword()}
                    />
                    <Button text={$LL.submit()} type="submit" {loading} fullWidth />
                </form>
            </div>
        </div>
    {:else}
        <p>Checking your request...</p>
    {/if}
</div>
