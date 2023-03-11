import { typedFetch } from "./typedFetch";
import { z } from "zod";

const urlBase = process.env.NODE_ENV === "production" ? "" : "http://localhost:5216";

const regionSchema = z.record(z.string(), z.string());
export type Regions = z.infer<typeof regionSchema>;

export async function getRegions(): Promise<Regions> {
	const regions = await typedFetch(regionSchema, `${urlBase}/api/regions`);

	if (regions === null) {
		alert("Could not get regions!");
		return {};
	}

	return regions;
}

const resultSchema = z.object({
	isValid: z.boolean(),
	isPossible: z.boolean(),
	phoneType: z.string(),
	internationalFormat: z.string(),
});
export type Results = z.infer<typeof resultSchema>;

export async function validate(phoneNumber: string, region: string): Promise<Results | null> {
	const params = new URLSearchParams({
		phoneNumber,
		region,
	});

	const result = await typedFetch(resultSchema, `${urlBase}/api/validate?${params}`);

	if (result === null) {
		alert("A error ocurred while validating number!");
		return null;
	}

	return result;
}
