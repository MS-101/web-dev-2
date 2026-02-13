import { useState } from 'react';

import type BookPublication from '../../types/book-publication';


interface PaperBookObjectProps {
	bookPublication: BookPublication;
}

const BookPublicationObject = ({ bookPublication }: PaperBookObjectProps) => {
	const [name] = useState(bookPublication.name);
	const [description] = useState(bookPublication.description);

	return (
		<div>
			<h2>{name}</h2>
			<p>{description}</p>
		</div>
	);
}

export default BookPublicationObject;
