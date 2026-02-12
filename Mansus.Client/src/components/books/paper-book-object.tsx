import type BookPublication from '../../types/book-publication';

import React, { useState } from 'react';


interface PaperBookObjectProps {
	bookPublication: BookPublication;
}

const PaperBookObject: React.FC<PaperBookObjectProps> = ({ bookPublication }) => {
	const [name] = useState(bookPublication.name);
	const [description] = useState(bookPublication.description);

	return (
		<div>
			<h2>{name}</h2>
			<p>{description}</p>
		</div>
	);
}

export default PaperBookObject;
