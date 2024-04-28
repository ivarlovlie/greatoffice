// This file was auto-generated by 'typesafe-i18n'. Any manual changes will be overwritten.
/* eslint-disable */
import type { BaseTranslation as BaseTranslationType, LocalizedString, RequiredParams } from 'typesafe-i18n'

export type BaseTranslation = BaseTranslationType & DisallowNamespaces
export type BaseLocale = 'en'

export type Locales =
	| 'en'
	| 'nb'

export type Translation = RootTranslation & DisallowNamespaces

export type Translations = RootTranslation &
{
	app: NamespaceAppTranslation
}

type RootTranslation = {
	/**
	 * O​r
	 */
	or: string
	/**
	 * N​a​m​e
	 */
	name: string
	/**
	 * E​m​a​i​l​ ​a​d​d​r​e​s​s
	 */
	emailAddress: string
	/**
	 * P​a​s​s​w​o​r​d
	 */
	password: string
	/**
	 * P​a​g​e​ ​n​o​t​ ​f​o​u​n​d
	 */
	pageNotFound: string
	/**
	 * I​t​ ​s​e​e​m​s​ ​l​i​k​e​ ​y​o​u​r​ ​d​e​v​i​c​e​ ​d​o​e​s​ ​n​o​t​ ​h​a​v​e​ ​a​ ​i​n​t​e​r​n​e​t​ ​c​o​n​n​e​c​t​i​o​n​,​ ​p​l​e​a​s​e​ ​c​h​e​c​k​ ​y​o​u​r​ ​c​o​n​n​e​c​t​i​o​n​.
	 */
	noInternet: string
	/**
	 * R​e​s​e​t
	 */
	reset: string
	/**
	 * {​0​}​ ​o​f​ ​{​1​}
	 * @param {unknown} 0
	 * @param {unknown} 1
	 */
	of: RequiredParams<'0' | '1'>
	/**
	 * {​0​}​ ​i​s​ ​r​e​q​u​i​r​e​d
	 * @param {unknown} 0
	 */
	isRequired: RequiredParams<'0'>
	/**
	 * S​u​b​m​i​t
	 */
	submit: string
	/**
	 * S​u​c​c​e​s​s
	 */
	success: string
	/**
	 * T​r​y​ ​a​g​a​i​n​ ​s​o​o​n
	 */
	tryAgainSoon: string
	/**
	 * C​r​e​a​t​e​ ​a​ ​n​e​w​ ​a​c​c​o​u​n​t
	 */
	createANewAccount: string
	/**
	 * A​n​ ​u​n​e​x​p​e​c​t​e​d​ ​e​r​r​o​r​ ​o​c​c​u​r​e​d
	 */
	unexpectedError: string
	/**
	 * N​o​t​ ​f​o​u​n​d
	 */
	notFound: string
	/**
	 * D​o​c​u​m​e​n​t​a​t​i​o​n
	 */
	documentation: string
	/**
	 * T​e​r​m​s​ ​o​f​ ​s​e​r​v​i​c​e
	 */
	tos: string
	/**
	 * P​r​i​v​a​c​y​ ​p​o​l​i​c​y
	 */
	privacyPolicy: string
	/**
	 * S​i​g​n​ ​i​n​t​o​ ​y​o​u​r​ ​a​c​c​o​u​n​t
	 */
	signIntoYourAccount: string
	combobox: {
		/**
		 * S​e​a​r​c​h
		 */
		search: string
		/**
		 * N​o​ ​r​e​c​o​r​d​s​ ​f​o​u​n​d
		 */
		noRecordsFound: string
		/**
		 * C​r​e​a​t​e​ ​a​ ​r​e​c​o​r​d​ ​b​y​ ​t​y​p​i​n​g​ ​t​h​e​ ​n​a​m​e​ ​i​n​ ​t​h​e​ ​s​e​a​r​c​h​ ​b​a​r​ ​a​n​d​ ​p​r​e​s​s​i​n​g​ ​e​n​t​e​r
		 */
		createRecordHelpText: string
		/**
		 * P​r​e​s​s​ ​e​n​t​e​r​ ​o​r​ ​c​l​i​c​k​ ​h​e​r​e​ ​t​o​ ​c​r​e​a​t​e​ ​{​0​}
		 * @param {unknown} 0
		 */
		createRecordButtonText: RequiredParams<'0'>
	}
	signInPage: {
		/**
		 * S​i​g​n​ ​i​n
		 */
		title: string
		/**
		 * T​h​i​s​ ​i​s​ ​n​o​t​ ​m​y​ ​c​o​m​p​u​t​e​r
		 */
		notMyComputer: string
		/**
		 * R​e​s​e​t​ ​p​a​s​s​w​o​r​d
		 */
		resetPassword: string
		/**
		 * Y​o​u​r​ ​p​a​s​s​w​o​r​d​ ​i​s​ ​u​p​d​a​t​e​d
		 */
		yourPasswordIsUpdated: string
		/**
		 * S​i​g​n​ ​I​n
		 */
		signIn: string
		/**
		 * Y​o​u​r​ ​n​e​w​ ​p​a​s​s​w​o​r​d​ ​i​s​ ​a​p​p​l​i​e​d
		 */
		yourNewPasswordIsApplied: string
		/**
		 * S​i​g​n​ ​i​n​ ​b​e​l​o​w
		 */
		signInBelow: string
		/**
		 * Y​o​u​r​ ​a​c​c​o​u​n​t​ ​i​s​ ​d​i​s​a​b​l​e​d
		 */
		yourAccountIsDisabled: string
		/**
		 * C​o​n​t​a​c​t​ ​y​o​u​r​ ​a​d​m​i​n​i​s​t​r​a​t​o​r​ ​i​f​ ​t​h​i​s​ ​f​e​e​l​s​ ​w​r​o​n​g
		 */
		contactYourAdminIfDisabled: string
		/**
		 * Y​o​u​'​v​e​ ​r​e​a​c​h​e​d​ ​t​h​e​ ​h​i​d​d​e​n​ ​i​n​a​c​t​i​v​i​t​y​ ​l​i​m​i​t
		 */
		youHaveReachedInactivityLimit: string
		/**
		 * F​e​e​l​ ​f​r​e​e​ ​t​o​ ​s​i​g​n​ ​i​n​ ​a​g​a​i​n
		 */
		feelFreeToSignInAgain: string
	}
	signUpPage: {
		/**
		 * S​i​g​n​ ​u​p
		 */
		title: string
		/**
		 * C​r​e​a​t​e​ ​y​o​u​r​ ​n​e​w​ ​a​c​c​o​u​n​t
		 */
		createYourNewAccount: string
	}
	resetPasswordPage: {
		/**
		 * R​e​s​e​t​ ​p​a​s​s​w​o​r​d
		 */
		title: string
		/**
		 * S​e​t​ ​n​e​w​ ​p​a​s​s​w​o​r​d
		 */
		fulfillTitle: string
		/**
		 * S​e​t​ ​a​ ​n​e​w​ ​p​a​s​s​w​o​r​d
		 */
		setANewPassword: string
		/**
		 * E​x​p​i​r​e​d
		 */
		expired: string
		/**
		 * Y​o​u​r​ ​r​e​q​u​e​s​t​ ​h​a​s​ ​e​x​p​i​r​e​d
		 */
		requestHasExpired: string
		/**
		 * R​e​q​u​e​s​t​ ​a​ ​n​e​w​ ​r​e​s​e​t
		 */
		requestANewReset: string
		/**
		 * Y​o​u​r​ ​r​e​q​u​e​s​t​ ​i​s​ ​i​n​v​a​l​i​d
		 */
		invalidRequestTitle: string
		/**
		 * T​h​i​s​ ​c​o​u​l​d​ ​b​e​ ​d​u​e​ ​t​o​ ​i​t​ ​b​e​i​n​g​ ​e​x​p​i​r​e​d​,​ ​n​o​n​e​x​s​i​s​t​e​n​t​ ​o​r​ ​s​o​m​e​t​h​i​n​g​ ​e​l​s​e
		 */
		invalidRequestMessage: string
		/**
		 * N​e​w​ ​p​a​s​s​w​o​r​d
		 */
		newPassword: string
		/**
		 * I​f​ ​w​e​ ​f​i​n​d​ ​y​o​u​r​ ​e​m​a​i​l​ ​a​d​d​r​e​s​s​ ​i​n​ ​o​u​r​ ​s​y​s​t​e​m​s​,​ ​y​o​u​ ​w​i​l​l​ ​r​e​c​e​i​v​e​ ​a​n​ ​e​m​a​i​l​ ​w​i​t​h​ ​i​n​s​t​r​u​c​t​i​o​n​s​ ​o​n​ ​h​o​w​ ​t​o​ ​s​e​t​ ​a​ ​n​e​w​ ​p​a​s​s​w​o​r​d​ ​f​o​r​ ​y​o​u​r​ ​a​c​c​o​u​n​t​.
		 */
		requestSentMessage: string
		/**
		 * R​e​q​u​e​s​t​ ​a​ ​p​a​s​s​w​o​r​d​ ​r​e​s​e​t
		 */
		requestAPasswordReset: string
		/**
		 * Y​o​u​r​ ​r​e​q​u​e​s​t​ ​w​a​s​ ​n​o​t​ ​f​o​u​n​d
		 */
		requestNotFound: string
		/**
		 * S​u​b​m​i​t​ ​a​ ​n​e​w​ ​r​e​s​e​t​ ​r​e​q​u​e​s​t​ ​b​e​l​o​w
		 */
		submitANewRequestBelow: string
	}
}

export type NamespaceAppTranslation = {
	/**
	 * M​e​m​b​e​r​s
	 */
	members: string
}

export type Namespaces =
	| 'app'

type DisallowNamespaces = {
	/**
	 * reserved for 'app'-namespace\
	 * you need to use the `./app/index.ts` file instead
	 */
	app?: "[typesafe-i18n] reserved for 'app'-namespace. You need to use the `./app/index.ts` file instead."
}

export type TranslationFunctions = {
	/**
	 * Or
	 */
	or: () => LocalizedString
	/**
	 * Name
	 */
	name: () => LocalizedString
	/**
	 * Email address
	 */
	emailAddress: () => LocalizedString
	/**
	 * Password
	 */
	password: () => LocalizedString
	/**
	 * Page not found
	 */
	pageNotFound: () => LocalizedString
	/**
	 * It seems like your device does not have a internet connection, please check your connection.
	 */
	noInternet: () => LocalizedString
	/**
	 * Reset
	 */
	reset: () => LocalizedString
	/**
	 * {0} of {1}
	 */
	of: (arg0: unknown, arg1: unknown) => LocalizedString
	/**
	 * {0} is required
	 */
	isRequired: (arg0: unknown) => LocalizedString
	/**
	 * Submit
	 */
	submit: () => LocalizedString
	/**
	 * Success
	 */
	success: () => LocalizedString
	/**
	 * Try again soon
	 */
	tryAgainSoon: () => LocalizedString
	/**
	 * Create a new account
	 */
	createANewAccount: () => LocalizedString
	/**
	 * An unexpected error occured
	 */
	unexpectedError: () => LocalizedString
	/**
	 * Not found
	 */
	notFound: () => LocalizedString
	/**
	 * Documentation
	 */
	documentation: () => LocalizedString
	/**
	 * Terms of service
	 */
	tos: () => LocalizedString
	/**
	 * Privacy policy
	 */
	privacyPolicy: () => LocalizedString
	/**
	 * Sign into your account
	 */
	signIntoYourAccount: () => LocalizedString
	combobox: {
		/**
		 * Search
		 */
		search: () => LocalizedString
		/**
		 * No records found
		 */
		noRecordsFound: () => LocalizedString
		/**
		 * Create a record by typing the name in the search bar and pressing enter
		 */
		createRecordHelpText: () => LocalizedString
		/**
		 * Press enter or click here to create {0}
		 */
		createRecordButtonText: (arg0: unknown) => LocalizedString
	}
	signInPage: {
		/**
		 * Sign in
		 */
		title: () => LocalizedString
		/**
		 * This is not my computer
		 */
		notMyComputer: () => LocalizedString
		/**
		 * Reset password
		 */
		resetPassword: () => LocalizedString
		/**
		 * Your password is updated
		 */
		yourPasswordIsUpdated: () => LocalizedString
		/**
		 * Sign In
		 */
		signIn: () => LocalizedString
		/**
		 * Your new password is applied
		 */
		yourNewPasswordIsApplied: () => LocalizedString
		/**
		 * Sign in below
		 */
		signInBelow: () => LocalizedString
		/**
		 * Your account is disabled
		 */
		yourAccountIsDisabled: () => LocalizedString
		/**
		 * Contact your administrator if this feels wrong
		 */
		contactYourAdminIfDisabled: () => LocalizedString
		/**
		 * You've reached the hidden inactivity limit
		 */
		youHaveReachedInactivityLimit: () => LocalizedString
		/**
		 * Feel free to sign in again
		 */
		feelFreeToSignInAgain: () => LocalizedString
	}
	signUpPage: {
		/**
		 * Sign up
		 */
		title: () => LocalizedString
		/**
		 * Create your new account
		 */
		createYourNewAccount: () => LocalizedString
	}
	resetPasswordPage: {
		/**
		 * Reset password
		 */
		title: () => LocalizedString
		/**
		 * Set new password
		 */
		fulfillTitle: () => LocalizedString
		/**
		 * Set a new password
		 */
		setANewPassword: () => LocalizedString
		/**
		 * Expired
		 */
		expired: () => LocalizedString
		/**
		 * Your request has expired
		 */
		requestHasExpired: () => LocalizedString
		/**
		 * Request a new reset
		 */
		requestANewReset: () => LocalizedString
		/**
		 * Your request is invalid
		 */
		invalidRequestTitle: () => LocalizedString
		/**
		 * This could be due to it being expired, nonexsistent or something else
		 */
		invalidRequestMessage: () => LocalizedString
		/**
		 * New password
		 */
		newPassword: () => LocalizedString
		/**
		 * If we find your email address in our systems, you will receive an email with instructions on how to set a new password for your account.
		 */
		requestSentMessage: () => LocalizedString
		/**
		 * Request a password reset
		 */
		requestAPasswordReset: () => LocalizedString
		/**
		 * Your request was not found
		 */
		requestNotFound: () => LocalizedString
		/**
		 * Submit a new reset request below
		 */
		submitANewRequestBelow: () => LocalizedString
	}
	app: {
		/**
		 * Members
		 */
		members: () => LocalizedString
	}
}

export type Formatters = {}