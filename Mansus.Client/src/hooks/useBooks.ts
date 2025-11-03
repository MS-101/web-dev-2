import { useState, useEffect } from "react";
import axios from "axios";


const useBooks = () => {
	const [books, setBooks] = useState([]);
	const [booksLoading, setBooksLoading] = useState<boolean>(true);
	const [error, setError] = useState<string | null>(null);

	useEffect(() => {
		axios
			.get("/api/books")
			.then((response) => {
				setBooks(response.data);
				setBooksLoading(false);
			})
			.catch((err) => {
				setError(err.message || "Failed to fetch books");
				setBooksLoading(false);
			});
	}, []);

	return { books, booksLoading, error };
};

export default useBooks;

