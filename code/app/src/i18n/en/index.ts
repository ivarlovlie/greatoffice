import type { BaseTranslation } from "../i18n-types";

const en: BaseTranslation = {
    or: "Or",
    name: "Name",
    emailAddress: "Email address",
    password: "Password",
    pageNotFound: "Page not found",
    noInternet: "It seems like your device does not have a internet connection, please check your connection.",
    reset: "Reset",
    of: "{0} of {1}",
    isRequired: "{0} is required",
    submit: "Submit",
    success: "Success",
    tryAgainSoon: "Try again soon",
    createANewAccount: "Create a new account",
    unexpectedError: "An unexpected error occured",
    notFound: "Not found",
    documentation: "Documentation",
    tos: "Terms of service",
    privacyPolicy: "Privacy policy",
    signIntoYourAccount: "Sign into your account",
    combobox: {
        search: "Search",
        noRecordsFound: "No records found",
        createRecordHelpText: "Create a record by typing the name in the search bar and pressing enter",
        createRecordButtonText: "Press enter or click here to create {0}"
    },
    signInPage: {
        title: "Sign in",
        notMyComputer: "This is not my computer",
        resetPassword: "Reset password",
        yourPasswordIsUpdated: "Your password is updated",
        signIn: "Sign In",
        yourNewPasswordIsApplied: "Your new password is applied",
        signInBelow: "Sign in below",
        yourAccountIsDisabled: "Your account is disabled",
        contactYourAdminIfDisabled: "Contact your administrator if this feels wrong",
        youHaveReachedInactivityLimit: "You've reached the hidden inactivity limit",
        feelFreeToSignInAgain: "Feel free to sign in again"
    },
    signUpPage: {
        title: "Sign up",
        createYourNewAccount: "Create your new account",
    },
    resetPasswordPage: {
        title: "Reset password",
        fulfillTitle: "Set new password",
        setANewPassword: "Set a new password",
        expired: "Expired",
        requestHasExpired: "Your request has expired",
        requestANewReset: "Request a new reset",
        invalidRequestTitle: "Your request is invalid",
        invalidRequestMessage: "This could be due to it being expired, nonexsistent or something else",
        newPassword: "New password",
        requestSentMessage: "If we find your email address in our systems, you will receive an email with instructions on how to set a new password for your account.",
        requestAPasswordReset: "Request a password reset",
        requestNotFound: "Your request was not found",
        submitANewRequestBelow: "Submit a new reset request below"
    }
};

export default en;
