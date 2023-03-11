<script setup lang="ts">
import type { Regions, Results } from "./api";
import { getRegions, validate } from "./api";
import { ref } from "vue";
import { generateCSV } from "./generateCSV";

const results = ref<Results | null>(null);
const regions = ref<Regions>({});
const working = ref(false);

const region = ref("");
const phoneNumber = ref("");

async function onSubmit() {
	working.value = true;
	results.value = await validate(phoneNumber.value, region.value);
	working.value = false;
}

async function loadRegions() {
	working.value = true;
	regions.value = await getRegions();
	working.value = false;
}
loadRegions();
</script>

<template>
	<main class="flex flex-col items-center gap-8 p-4">
		<h1 class="text-6xl font-light text-center">
			Phone number validator
		</h1>

		<form @submit.prevent="onSubmit" class="flex flex-col gap-2 max-w-sm w-full">
			<fieldset :disabled="working" class="contents">
				<select class="p-2 rounded bg-gray-200" v-model="region" :disabled="working">
					<option class="text-gray-500 rounded" default value="">Select a region...</option>
					<option v-for="(code, name) in regions" :value="code">
						{{ name }}
					</option>
				</select>
				<input class="border-slate-500/50 p-1 border-2 rounded" type="tel" v-model="phoneNumber" placeholder="0411 000 000" autocomplete="off" required/>
				<button class="button" type="submit">Validate</button>
			</fieldset>
		</form>

		<section class="max-w-sm w-full">
			<h2 class="font-light text-3xl">Results:</h2>
			<div v-if="results !== null" class="grid grid-cols-[max-content_1fr] gap-x-1">
				<span class="font-bold text-right">Is valid:</span> <span>{{results.isValid}}</span>
				<span class="font-bold text-right">Is possible:</span> <span>{{results.isPossible}}</span>
				<span class="font-bold text-right">Phone type:</span> <span>{{results.phoneType}}</span>
				<span class="font-bold text-right">International Format:</span> <span>{{results.internationalFormat}}</span>
				<a class="col-span-2 mt-2 button" :href="generateCSV(results)" download="Validation results.csv">Download CSV</a>
			</div>
		</section>
	</main>
</template>