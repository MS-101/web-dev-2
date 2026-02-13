import axios from "axios";
import { useState, useEffect, useCallback } from "react";

import type BookPublication from "../types/book-publication";


const useAudioBooks = () => {
	const [audioBooks, setAudioBooks] = useState<BookPublication[]>([]);
	const [audioBooksLoading, setAudioBooksLoading] = useState<boolean>(true);
	const [audioBooksError, setAudioBooksError] = useState<string | null>(null);

	const fetchAudioBooks = useCallback(() => {
        setAudioBooksLoading(true);

		axios
			.get<BookPublication[]>("/api/audiobooks")
			.then((response) => {
				setAudioBooks(response.data);
				setAudioBooksLoading(false);
				setAudioBooksError(null);
			})
			.catch((err) => {
				setAudioBooks([]);
				setAudioBooksLoading(false);
				setAudioBooksError(err.message);
			});
	}, []);

	useEffect(() => {
		fetchAudioBooks();
	}, [fetchAudioBooks]);

	return { audioBooks, audioBooksLoading, audioBooksError, fetchAudioBooks };
};

export default useAudioBooks;

