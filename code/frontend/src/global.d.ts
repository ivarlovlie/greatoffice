/// <reference types="@sveltejs/kit" />

type Locales = import('$lib/i18n/i18n-types').Locales
type TranslationFunctions = import('$lib/i18n/i18n-types').TranslationFunctions

declare namespace App {
    interface Locals {
        locale: Locales
        LL: TranslationFunctions
    }
}