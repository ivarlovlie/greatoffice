import { defineConfig } from "vitest/config";
import { sveltekit } from "@sveltejs/kit/vite";
import { SvelteKitPWA } from "@vite-pwa/sveltekit";

export default defineConfig({
    plugins: [sveltekit(), SvelteKitPWA()],
    build: {
        target: "es2020",
    },
    test: {
        include: ["src/**/*.{test,spec}.{js,ts}"]
    },
    optimizeDeps: {
        esbuildOptions: {
            target: "es2020",
        },
    },
});
