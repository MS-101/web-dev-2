import React from 'react';
import { useState } from 'react';
import { FaImage } from 'react-icons/fa';
import type { IconType } from 'react-icons';

import type Product from "../../types/product";
import './product-object.css'


interface ProductObjectProps {
	product: Product;
	icon?: IconType;
	additionalInfo?: React.ReactNode;
}

const ProductObject = ({ product, icon: Icon, additionalInfo }: ProductObjectProps) => {
	const [name] = useState(product.name);
	const [description] = useState(product.description);

	return (
		<div className='ProductObject'>
			{Icon ? (
				<Icon className='ProductImage' />
			) : (
				<FaImage className='ProductImage' />
			)}

            <div className='ProductDetails'>
				<h2>{name}</h2>

				{additionalInfo}

				<p>{description}</p>
			</div>
		</div>
	);
}

export default ProductObject;
