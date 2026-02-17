import axios from "axios";
import { useState, useEffect, useCallback } from "react";

import type BookPublication from "../types/book-publication";


const usePaperBooks = () => {
	const [paperBooks, setPaperBooks] = useState<BookPublication[]>([]);
	const [paperBooksLoading, setPaperBooksLoading] = useState<boolean>(true);
	const [paperBooksError, setPaperBooksError] = useState<string | null>(null);

	const fetchPaperBooks = useCallback(() => {
		setPaperBooksLoading(true);

		axios
			.get<BookPublication[]>("/api/paperbooks")
			.then((response) => {
				setPaperBooks(response.data);
				setPaperBooksLoading(false);
				setPaperBooksError(null);
			})
			.catch((err) => {
				setPaperBooks([]);
				setPaperBooksLoading(false);
				setPaperBooksError(err.message);
			});
	}, []);

	useEffect(() => {
		fetchPaperBooks();
	}, [fetchPaperBooks]);

	return { paperBooks, paperBooksLoading, paperBooksError, fetchPaperBooks };
};

export default usePaperBooks;

