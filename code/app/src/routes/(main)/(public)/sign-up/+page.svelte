<script lang="ts">
    import { goto } from "$app/navigation";
    import { Button, Input, Alert } from "$components";
    import LL from "$i18n/i18n-svelte";
    import { FormError } from "$models/internal/FormError";
    import type { CreateAccountPayload } from "$services/abstractions/IAccountService";
    import { AccountService } from "$services/account-service";

    const formData = {
        username: {
            value: "",
            errors: [],
        },
        password: {
            value: "",
            errors: [],
        },
        as_payload(): CreateAccountPayload {
            return {
                username: formData.username.value,
                password: formData.password.value,
            };
        },
    };

    const formError = new FormError();
    const accountService = new AccountService();

    let loading = false;
    let showErrorAlert = false;

    async function submit_form_async() {
        loading = true;
        showErrorAlert = false;
        formError.set();
        formData.username.errors = [];
        formData.password.errors = [];
        const response = await accountService.create_account_async(formData.as_payload());
        if (response.isCreated) {
            await goto("/home");
        } else if (response.knownProblem) {
            formError.set_from_known_problem(response.knownProblem);
            for (const error of Object.entries(response.knownProblem.errors)) {
                if (error[0] === "username") {
                    const errors = [];
                    error[1].forEach((e) => errors.push(e));
                    formData.username.errors = errors;
                }
                if (error[0] === "password") {
                    const errors = [];
                    error[1].forEach((e) => errors.push(e));
                    formData.password.errors = errors;
                }
            }
        } else {
            formError.set($LL.unexpectedError(), $LL.tryAgainSoon());
        }
        loading = false;
        showErrorAlert = formError.has_error();
    }
</script>

<div class="min-h-full flex flex-col justify-center py-12 sm:px-6 lg:px-8">
    <div class="sm:mx-auto sm:w-full p-2 sm:p-0 sm:max-w-md">
        <h2 class="mt-6 text-3xl tracking-tight font-bold text-gray-900">
            {$LL.signUpPage.createYourNewAccount()}
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
            {#if showErrorAlert}
                <Alert title={formError.title} message={formError.subtitle} type="error" class="mb-2" />
            {/if}
            <form class="space-y-6" on:submit|preventDefault={submit_form_async}>
                <Input
                    label={$LL.emailAddress()}
                    id="email"
                    name="email"
                    autocomplete="email"
                    required
                    type="email"
                    bind:value={formData.username.value}
                    errors={formData.username.errors}
                />

                <Input
                    label={$LL.password()}
                    id="password"
                    name="password"
                    required
                    type="password"
                    bind:value={formData.password.value}
                    errors={formData.password.errors}
                />
                <Button type="submit" text={$LL.submit()} {loading} fullWidth />
            </form>
        </div>
    </div>
</div>
