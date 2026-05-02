import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";
import type PagedResponse from "../types/responses/pagedResponse";

export default function usePaperBooks(page: number) {
	return useQuery<PagedResponse<BookPublication>>({
		queryKey: ["paperbooks", page],
		queryFn: () =>
			axios
				.get(`/api/paperbooks/?page=${page}`)
				.then(res => res.data)
	});
};