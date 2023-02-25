import { capitalise } from "$utilities/misc-helpers";
import type { FormattersInitializer } from "typesafe-i18n";
import type { Locales, Formatters } from "./i18n-types";

export const initFormatters: FormattersInitializer<Locales, Formatters> = (locale: Locales) => {

    const formatters: Formatters = {
        // add your formatter functions here
        capitalise: (value: string) => capitalise(value),
    };

    return formatters;
};
