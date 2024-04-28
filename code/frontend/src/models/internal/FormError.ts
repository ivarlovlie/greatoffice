import type { KnownProblem } from "./KnownProblem";

export class FormError {
    title: string;
    subtitle: string;
    constructor(title: string = "", subtitle: string = "") {
        this.title = title;
        this.title = subtitle;
    }

    set(title: string = "", subtitle: string = "") {
        this.title = title;
        this.subtitle = subtitle;
    }

    set_from_known_problem(knownProblem: KnownProblem) {
        this.title = knownProblem.title ?? "";
        this.subtitle = knownProblem.subtitle ?? "";
    }

    has_error() {
        return this.title?.length > 0 || this.subtitle?.length > 0;
    }
}