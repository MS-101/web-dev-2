import BookPublicationObject from "../components/products/book-publication-object.tsx";
import useEBooks from "../hooks/useEBooks.ts";

const EBooksPage = () => {
	const { eBooks, eBooksLoading } = useEBooks();

	return (
		<div>
			<h2>E-Books Page</h2>
			{eBooksLoading ? (
				<p>E-books loading...</p>
			) : (
				eBooks.map((eBook) =>
					<BookPublicationObject
                        key={eBook.id}
						bookPublication={eBook}
					/>
				)
			)}
		</div>
	);
};

export default EBooksPage;
