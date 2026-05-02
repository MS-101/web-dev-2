import React, { useState } from 'react';
import type { IconType } from 'react-icons';
import { FaImage } from 'react-icons/fa';

import type Product from "../../types/product";

interface ProductObjectProps {
	product: Product;
	icon?: IconType;
	additionalInfo?: React.ReactNode;
}

const ProductObject = ({ product, icon: Icon, additionalInfo }: ProductObjectProps) => {
	const [name] = useState(product.name);
	const [description] = useState(product.description);

	return (
		<div className='flex w-full border p-5 gap-5'>
			{Icon ? (
				<Icon className='w-40 h-40' />
			) : (
				<FaImage className='w-40 h-40' />
			)}

			<div className=''>
				<h2 className="text-xl font-medium">{name}</h2>

				{additionalInfo}

				<p>{description}</p>
			</div>
		</div>
	);
}

export default ProductObject;
