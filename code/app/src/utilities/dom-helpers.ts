interface CreateElementOptions {
    name: string,
    properties?: object,
    children?: Array<HTMLElement | Function | Node>
}

export function create_element_from_object(elementOptions: CreateElementOptions): HTMLElement {
    return create_element(elementOptions.name, elementOptions.properties, elementOptions.children);
}

export function create_element(name: string, properties?: object, children?: Array<HTMLElement | any>): HTMLElement {
    if (!name || name.length < 1) {
        throw new Error("name is required");
    }
    const node = document.createElement(name);
    if (properties) {
        for (const [key, value] of Object.entries(properties)) {
            // @ts-ignore
            node[key] = value;
        }
    }

    if (children && children.length > 0) {
        let actualChildren = children;
        if (typeof children === "function") {
            // @ts-ignore
            actualChildren = children();
        }
        for (const child of actualChildren) {
            node.appendChild(child as Node);
        }
    }
    return node;
}

// https://stackoverflow.com/a/45215694/11961742
export function get_selected_options(domElement: HTMLSelectElement): Array<string> {
    const ret = [];

    // fast but not universally supported
    if (domElement.selectedOptions !== undefined) {
        for (let i = 0; i < domElement.selectedOptions.length; i++) {
            ret.push(domElement.selectedOptions[i].value);
        }

        // compatible, but can be painfully slow
    } else {
        for (let i = 0; i < domElement.options.length; i++) {
            if (domElement.options[i].selected) {
                ret.push(domElement.options[i].value);
            }
        }
    }
    return ret;
}


export function get_element_position(element: HTMLElement | any) {
    if (!element) return {x: 0, y: 0};
    let x = 0;
    let y = 0;
    while (true) {
        x += element.offsetLeft;
        y += element.offsetTop;
        if (element.offsetParent === null) {
            break;
        }
        element = element.offsetParent;
    }
    return {x, y};
}

export function restrict_input_to_numbers(element: HTMLElement, specials: Array<string> = [], mergeSpecialsWithDefaults: boolean = false): void {
    if (!element) return;
    element.addEventListener("keydown", (e) => {
        const defaultSpecials = ["Backspace", "ArrowLeft", "ArrowRight", "Tab"];
        let keys = specials.length > 0 ? specials : defaultSpecials;
        if (mergeSpecialsWithDefaults && specials) {
            keys = [...specials, ...defaultSpecials];
        }
        if (keys.indexOf(e.key) !== -1) {
            return;
        }
        if (isNaN(parseInt(e.key))) {
            e.preventDefault();
        }
    });
}

export function element_has_focus(element: HTMLElement): boolean {
    return element === document.activeElement;
}

export function move_focus(element: HTMLElement): void {
    if (!element) {
        element = document.getElementsByTagName("body")[0];
    }
    element.focus();
    // @ts-ignore
    if (!element_has_focus(element)) {
        element.setAttribute("tabindex", "-1");
        element.focus();
    }
}

