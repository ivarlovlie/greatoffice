import { sveltekit } from "@sveltejs/kit/vite";
import { SvelteKitPWA } from "@vite-pwa/sveltekit";
/** @type {import('vite').UserConfig} */
const config = {
  plugins: [sveltekit(), SvelteKitPWA()],
  build: {
    target: "es2020",
  },
  optimizeDeps: {
    esbuildOptions: {
      target: "es2020",
    },
  },
};

export default config;
