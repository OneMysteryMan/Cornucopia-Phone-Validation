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
	<main>
		<h1>
			Phone number validator
		</h1>

		<form @submit.prevent="onSubmit" class="flex flex-col">
			<fieldset :disabled="working" class="contents">
				<select v-model="region" :disabled="working">
					<option default value="">Select a region...</option>
					<option v-for="(code, name) in regions" :value="code">
						{{ name }}
					</option>
				</select>
				<input  type="tel" v-model="phoneNumber" placeholder="0411 000 000" autocomplete="off" required/>
				<button type="submit">Validate</button>
			</fieldset>
		</form>

		<section>
			<h2>Results:</h2>
			<div v-if="results !== null">
				<span>Is valid:</span> <span>{{results.isValid}}</span>
				<span>Is possible:</span> <span>{{results.isPossible}}</span>
				<span>Phone type:</span> <span>{{results.phoneType}}</span>
				<span>International Format:</span> <span>{{results.internationalFormat}}</span>
				<a :href="generateCSV(results)" download="Validation results.csv">Download CSV</a>
			</div>
		</section>
	</main>
</template>