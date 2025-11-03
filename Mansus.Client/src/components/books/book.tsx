import { useState } from "react";
import "./book.css"

function Book({ book }) {
	const [title, setTitle] = useState(book.title);
	const [description, setDescription] = useState(book.description);


	return (
		<div>
			<h2>{title}</h2>
			<p>{description}</p>
		</div>
	);
}

export default Book;
