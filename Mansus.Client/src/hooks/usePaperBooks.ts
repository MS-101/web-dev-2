import React, { useState, useEffect } from "react";
import axios from "axios";


const usePaperBooks = () => {
	const [paperBooks, setPaperBooks] = useState([]);
	const [paperBooksLoading, setPaperBooksLoading] = useState<boolean>(true);
	const [error, setError] = useState<string | null>(null);

	useEffect(() => {
		axios
			.get("/api/paperbooks")
			.then((response) => {
				setPaperBooks(response.data);
				setPaperBooksLoading(false);
			})
			.catch((err) => {
				setError(err.message || "Failed to fetch paper books");
				setPaperBooksLoading(false);
			});
	}, []);

	return { paperBooks, paperBooksLoading, error };
};

export default usePaperBooks;

