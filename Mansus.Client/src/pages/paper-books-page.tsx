import BookPublicationObject from "../components/products/book-publication-object.tsx";
import usePaperBooks from "../hooks/usePaperBooks.ts";

import './paper-books-page.css'

const PaperBooksPage = () => {
	const { paperBooks, paperBooksLoading } = usePaperBooks();

    return (
        <div>
            <h2>Paper Books Page</h2>

            {paperBooksLoading ? (
                <p>Paper books loading...</p>
            ) : (
                <div className="BooksGrid">
                    {paperBooks.map((paperBook) => (
                        <BookPublicationObject
                            key={paperBook.id}
                            bookPublication={paperBook}
                        />
                    ))}
                </div>
            )}
        </div>
    ); 
};

export default PaperBooksPage;
