<script lang="ts">
    import { Alert, Input, Button } from "$components";
    import LL from "$i18n/i18n-svelte";
    import { FormError } from "$models/internal/FormError";
    import { PasswordResetService } from "$services/password-reset-service";

    const formData = {
        email: {
            value: "",
            errors: [],
        },
    };

    const formError = new FormError();
    const passwordResetService = PasswordResetService.resolve();

    let loading = false;
    let showSuccessAlert = false;
    let showErrorAlert = false;

    async function submit_form_async() {
        formError.set();
        showSuccessAlert = false;
        showErrorAlert = false;
        loading = true;
        const response = await passwordResetService.create_request_async(formData.email.value);
        loading = false;
        if (response.isCreated) {
            showSuccessAlert = true;
        } else if (response.knownProblem) {
            formError.set_from_known_problem(response.knownProblem);
            for (const error of Object.entries(response.knownProblem.errors)) {
                if (error[0] === "email") {
                    let errors = [];
                    error[1].forEach((e) => errors.push(e));
                    formData.email.errors = errors;
                }
            }
        } else {
            formError.set($LL.unexpectedError(), $LL.tryAgainSoon());
        }
        showErrorAlert = formError.has_error() && !showSuccessAlert;
    }
</script>

<div class="min-h-full flex flex-col justify-center py-12 sm:px-6 lg:px-8">
    <div class="sm:mx-auto sm:w-full p-2 sm:p-0 sm:max-w-md">
        <h2 class="mt-6 text-3xl tracking-tight font-bold text-gray-900">
            {$LL.resetPasswordPage.requestAPasswordReset()}
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
            <form class="space-y-6" on:submit|preventDefault={submit_form_async}>
                {#if showErrorAlert}
                    <Alert title={formError.title} message={formError.subtitle} type="error" />
                {:else if showSuccessAlert}
                    <Alert type="success" title={$LL.success()} message={$LL.resetPasswordPage.requestSentMessage()} />
                {/if}
                <Input
                    id="email"
                    name="email"
                    type="email"
                    autocomplete="email"
                    errors={formData.email.errors}
                    bind:value={formData.email.value}
                    required
                    label={$LL.emailAddress()}
                />
                <Button text={$LL.submit()} type="submit" {loading} fullWidth />
            </form>
        </div>
    </div>
</div>
