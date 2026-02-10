import { useState } from "react";
import "./book.css"

function Book({ book }) {
	const [name, setName] = useState(book.name);
	const [description, setDescription] = useState(book.description);


	return (
		<div>
			<h2>{name}</h2>
			<p>{description}</p>
		</div>
	);
}

export default Book;
