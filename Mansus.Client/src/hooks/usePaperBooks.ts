import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";

export default function usePaperBooks(page: number) {
	return useQuery<BookPublication[]>({
		queryKey: ["paperbooks", page],
		queryFn: () =>
			axios
				.get<BookPublication[]>(`/api/paperbooks/?page=${page}`)
				.then(res => res.data)
	});
};
