import { Results } from "./api";

const headers = ["IsValid", "IsPossible", "PhoneType", "InternationalFormat"].join(",");

export function generateCSV(results: Results) {
	const data = [
		results.isValid,
		results.isPossible,
		`"${results.phoneType}"`, // Could have comma if multiple types are possible
		results.internationalFormat,
	].join(",");

	return "data:text/csv;charset=utf-8," + encodeURIComponent([headers, data].join("\n"));
}
