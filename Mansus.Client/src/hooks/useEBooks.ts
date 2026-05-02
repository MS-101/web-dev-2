import axios from "axios";
import { useQuery } from "@tanstack/react-query";

import type BookPublication from "../types/book-publication";

export default function useEBooks(page: number) {
	return useQuery<BookPublication[]>({
		queryKey: ["ebooks", page],
		queryFn: () =>
			axios
				.get<BookPublication[]>(`/api/ebooks/?page=${page}`)
				.then(res => res.data)
	});
};

