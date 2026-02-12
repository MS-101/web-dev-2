import React from "react";
import PaperBookObject from "../components/books/paper-book-object.tsx";
import usePaperBooks from "../hooks/usePaperBooks.ts";

const PaperBooksPage: React.FC = () => {
	const { paperBooks, paperBooksLoading } = usePaperBooks();

	return (
		<div>
			<h2>Paper Books Page</h2>
			{paperBooksLoading
				? <p>Paper books loading...</p>
				: paperBooks.map(
					(element) => <PaperBookObject bookPublication={element} />
				)
			}
		</div>
	);
};

export default PaperBooksPage;
