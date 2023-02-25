import adapter from "@sveltejs/adapter-node";
import preprocess from "svelte-preprocess";

/** @type {import('@sveltejs/kit').Config} */
const config = {
    preprocess: [
        preprocess({
            postcss: true,
        }),
    ],
    kit: {
        adapter: adapter(),
        alias: {
            "$actions": "./src/actions",
            "$routes": "./src/routes",
            "$models": "./src/models",
            "$api": "./src/api",
            "$components": "./src/components",
            "$utilities": "./src/utilities",
            "$i18n": "./src/i18n",
            "$services": "./src/services",
            "$configuration": "./src/configuration",
        }
    },
};

export default config;
