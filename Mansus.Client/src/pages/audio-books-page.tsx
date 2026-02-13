import BookPublicationObject from "../components/products/book-publication-object.tsx";
import useAudioBooks from "../hooks/useAudioBooks.ts";

const AudioBooksPage = () => {
	const { audioBooks, audioBooksLoading } = useAudioBooks();

	return (
		<div>
			<h2>Audio Books Page</h2>
			{audioBooksLoading ? (
				<p>Audio books loading...</p>
			) : (
				audioBooks.map((audioBook) =>
					<BookPublicationObject
						key={audioBook.id}
						bookPublication={audioBook}
					/>
				)
			)}
		</div>
	);
};

export default AudioBooksPage;
