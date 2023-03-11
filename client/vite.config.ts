import { defineConfig } from "vite";
import { resolve } from "node:path";
import vue from "@vitejs/plugin-vue";

export default defineConfig({
	plugins: [vue()],
	build: {
		outDir: resolve(__dirname, "..", "wwwroot"),
		emptyOutDir: true,
	},
});
