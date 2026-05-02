import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";
import type PagedResponse from "../types/responses/pagedResponse";

export default function useEBooks(page: number) {
	return useQuery<PagedResponse<BookPublication>>({
		queryKey: ["ebooks", page],
		queryFn: () =>
			axios
				.get(`/api/ebooks/?page=${page}`)
				.then(res => res.data)
	});
};

