import React from "react";
import useBooks from "../hooks/useBooks.ts";
import Book from "../components/books/book.tsx"

const BooksPage = () => {
	const { books, booksLoading } = useBooks();

	return (
		<div>
			<h2>Books Page</h2>
			{booksLoading ? <p>Books loading...</p> : books.map((element) => <Book book={element} />)}
		</div>
	);
};

export default BooksPage;
