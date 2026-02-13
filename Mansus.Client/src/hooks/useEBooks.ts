import axios from "axios";
import { useState, useEffect, useCallback } from "react";

import type BookPublication from "../types/book-publication";


const useEBooks = () => {
	const [eBooks, setEBooks] = useState<BookPublication[]>([]);
	const [eBooksLoading, setEBooksLoading] = useState<boolean>(true);
	const [eBooksError, setEBooksError] = useState<string | null>(null);

	const fetchEBooks = useCallback(() => {
        setEBooksLoading(true);

		axios
			.get<BookPublication[]>("/api/ebooks")
			.then((response) => {
				setEBooks(response.data);
				setEBooksLoading(false);
				setEBooksError(null);
			})
			.catch((err) => {
				setEBooks([]);
				setEBooksLoading(false);
				setEBooksError(err.message);
			});
	}, [])

	useEffect(() => {
		fetchEBooks();
	}, [fetchEBooks]);

	return { eBooks, eBooksLoading, eBooksError, fetchEBooks };
};

export default useEBooks;

