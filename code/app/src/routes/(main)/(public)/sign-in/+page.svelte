<script lang="ts">
    import { goto } from "$app/navigation";
    import { Button, Checkbox, Input, Alert } from "$components";
    import LL from "$i18n/i18n-svelte";
    import pwKey from "$actions/pwKey";
    import { onMount } from "svelte";
    import { signInPageMessageQueryKey, signInPageTestKeys, type SignInPageMessage } from ".";
    import { AccountService } from "$services/account-service";
    import type { LoginPayload } from "$services/abstractions/IAccountService";
    import { FormError } from "$models/internal/FormError";
    import type { IForm } from "$models/internal/IForm";

    let messageType: SignInPageMessage | undefined = undefined;

    const accountService = AccountService.resolve();
    const form = {
        fields: {
            username: {
                value: "",
                errors: [],
            },
            password: {
                value: "",
                errors: [],
            },
            persist: {
                value: false,
                errors: [],
            },
        },
        error: new FormError(),
        isLoading: false,
        showError: false,
        get_payload(): LoginPayload {
            return {
                password: form.fields.password.value,
                username: form.fields.username.value,
                persist: !form.fields.persist.value,
            };
        },
        async submit_async() {
            console.log("sadf");
            form.error.set();
            form.showError = form.error.has_error();
            form.isLoading = true;
            const loginResponse = await accountService.login_async(form.get_payload());
            if (loginResponse.isLoggedIn) {
                await goto("/home");
            } else if (loginResponse.knownProblem) {
                form.error.set_from_known_problem(loginResponse.knownProblem);
            } else {
                form.error.set($LL.unexpectedError(), $LL.tryAgainSoon());
            }
            form.isLoading = false;
            form.showError = form.error.has_error();
        },
    } as IForm;

    onMount(() => {
        const queryParams = new URLSearchParams(window.location.search);
        if (queryParams.get(signInPageMessageQueryKey)) {
            messageType = queryParams.get(signInPageMessageQueryKey) as SignInPageMessage;
            queryParams.delete(signInPageMessageQueryKey);
            window.history.replaceState(null, "", window.location.origin + window.location.pathname);
        }
    });
</script>

<div class="min-h-full flex flex-col justify-center py-12 sm:px-6 lg:px-8">
    {#if messageType}
        <div class="sm:max-w-md sm:mx-auto sm:w-full">
            {#if messageType === "after-password-reset"}
                <Alert
                    title={$LL.signInPage.yourNewPasswordIsApplied()}
                    _pwKey={signInPageTestKeys.afterPasswordResetAlert}
                    message={$LL.signInPage.signInBelow()}
                    closeable
                />
            {:else if messageType === "user-disabled"}
                <Alert
                    title={$LL.signInPage.yourAccountIsDisabled()}
                    _pwKey={signInPageTestKeys.userDisabledAlert}
                    message={$LL.signInPage.contactYourAdminIfDisabled()}
                    closeable
                />
            {:else if messageType === "user-inactivity"}
                <Alert
                    title={$LL.signInPage.youHaveReachedInactivityLimit()}
                    _pwKey={signInPageTestKeys.userInactivityAlert}
                    message={$LL.signInPage.feelFreeToSignInAgain()}
                    closeable
                />
            {/if}
        </div>
    {/if}
    <div class="sm:mx-auto sm:w-full p-2 sm:p-0 sm:max-w-md">
        <h2 class="mt-6 text-3xl tracking-tight font-bold text-gray-900">
            {$LL.signInPage.signIn()}
        </h2>
        <p class="mt-2 text-sm text-gray-600">
            {$LL.or().toLowerCase()}
            <a href="/sign-up" use:pwKey={signInPageTestKeys.signUpAnchor} class="link">
                {$LL.createANewAccount().toLowerCase()}
            </a>
        </p>
    </div>
    <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-md">
        <div class="bg-white py-8 px-4 shadow sm:rounded-lg sm:px-10">
            {#if form.showError}
                <Alert title={form.error.title} message={form.error.subtitle} type="error" _pwKey={signInPageTestKeys.formErrorAlert} />
            {/if}
            <form class="space-y-6 mt-2" use:pwKey={signInPageTestKeys.signInForm} on:submit|preventDefault={() => form.submit_async()}>
                <Input
                    id="username"
                    _pwKey={signInPageTestKeys.usernameInput}
                    name="username"
                    type="email"
                    label={$LL.emailAddress()}
                    required
                    errors={form.fields.username.errors}
                    bind:value={form.fields.username.value}
                />

                <Input
                    id="password"
                    name="password"
                    type="password"
                    label={$LL.password()}
                    _pwKey={signInPageTestKeys.passwordInput}
                    autocomplete="current-password"
                    required
                    errors={form.fields.password.errors}
                    bind:value={form.fields.password.value}
                />

                <div class="flex items-center justify-between">
                    <Checkbox
                        id="remember-me"
                        _pwKey={signInPageTestKeys.rememberMeCheckbox}
                        name="remember-me"
                        bind:checked={form.fields.persist.value}
                        label={$LL.signInPage.notMyComputer()}
                    />
                    <div class="text-sm">
                        <a href="/reset-password" class="link" use:pwKey={signInPageTestKeys.resetPasswordAnchor}>
                            {$LL.signInPage.resetPassword()}
                        </a>
                    </div>
                </div>

                <Button text={$LL.submit()} fullWidth type="submit" loading={form.isLoading} />
            </form>
        </div>
    </div>
</div>
