import { FaBook } from 'react-icons/fa';

import ProductObject from './product-object';
import type BookPublication from '../../types/book-publication';


interface BookPublicationObjectProps {
	bookPublication: BookPublication;
}

const BookPublicationObject = ({ bookPublication }: BookPublicationObjectProps) => {
	return (
		<ProductObject
			product={bookPublication}
			icon={FaBook}
			additionalInfo={
				<p>
					<strong>Authors: </strong>
					{bookPublication.book.authors.map(author => author.name).join(", ")}
				</p>
			}
		/>
	)
}

export default BookPublicationObject;
