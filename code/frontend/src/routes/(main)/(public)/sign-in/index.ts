export enum SignInPageMessage {
    AFTER_PASSWORD_RESET = "after-password-reset",
    USER_INACTIVITY = "user-inactivity",
    USER_DISABLED = "user-disabled",
    LOGGED_OUT = "logged-out"
}

export const signInPageMessageQueryKey = "m";
export const signInPageTestKeys = {
    passwordInput: "password-input",
    usernameInput: "username-input",
    rememberMeCheckbox: "remember-me-checkbox",
    signInForm: "sign-in-form",
    userInactivityAlert: SignInPageMessage.USER_INACTIVITY + "-alert",
    userDisabledAlert: SignInPageMessage.USER_DISABLED + "-alert",
    afterPasswordResetAlert: SignInPageMessage.AFTER_PASSWORD_RESET + "-alert",
    formErrorAlert: "form-error-alert",
    resetPasswordAnchor: "reset-password-anchor",
    signUpAnchor: "sign-up-anchor",
};