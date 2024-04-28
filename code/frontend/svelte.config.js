import adapter from '@sveltejs/adapter-node';
import { vitePreprocess } from '@sveltejs/vite-plugin-svelte';

/** @type {import('@sveltejs/kit').Config} */
const config = {
	preprocess: [vitePreprocess({})],
	kit: {
		adapter: adapter(),
		alias: {
			"$actions": "./src/actions",
			"$routes": "./src/routes",
			"$models": "./src/models",
			"$api": "./src/api",
			"$components": "./src/components",
			"$utils": "./src/utils",
			"$i18n": "./src/i18n",
			"$services": "./src/services",
			"$configuration": "./src/configuration",
		}
	}
};

export default config;
