import { z } from "zod";

type Result<T extends z.ZodType> = Promise<z.infer<T> | null>;

export async function typedFetch<T extends z.ZodType>(schema: T, url: string): Result<T> {
	try {
		const response = await fetch(url);
		const json = await response.json();
		return await schema.parseAsync(json);
	} catch {
		return null;
	}
}
