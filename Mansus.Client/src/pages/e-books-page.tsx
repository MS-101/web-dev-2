import BookPublicationObject from "../components/products/book-publication-object.tsx";
import useEBooks from "../hooks/useEBooks.ts";

import './e-books-page.css'

const EBooksPage = () => {
	const { eBooks, eBooksLoading } = useEBooks();

	return (
		<div>
			<h2>E-Books Page</h2>
			{eBooksLoading ? (
				<p>Ebooks loading...</p>
            ) : (
                <div className="BooksGrid">
                    {eBooks.map((eBook) => (
                        <BookPublicationObject
                            key={eBook.id}
                            bookPublication={eBook}
                        />
                    ))}
                </div>
            )}
		</div>
	);
};

export default EBooksPage;
