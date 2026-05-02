import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";
import type PagedResponse from "../types/responses/pagedResponse";

export default function useAudioBooks(page: number) {
	return useQuery<PagedResponse<BookPublication>>({
		queryKey: ["audiobooks", page],
		queryFn: () =>
			axios
				.get(`/api/audiobooks/?page=${page}`)
				.then(res => res.data)
	});
};
