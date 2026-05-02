import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";

export default function useAudioBooks(page: number) {
	return useQuery<BookPublication[]>({
		queryKey: ["audiobooks", page],
		queryFn: () =>
			axios
				.get<BookPublication[]>(`/api/audiobooks/?page=${page}`)
				.then(res => res.data)
	});
};
