import { useNavigate } from "react-router-dom";

import type Product from "../../types/product";
import ProductObject from "./product-object";

const PageButton = (
    { baseUrl, page, isActive = false }:
    { baseUrl: string, page: number, isActive?: boolean }
) => {
    const navigate = useNavigate();

    const url = baseUrl + '?page=' + page;

    return <button
        className={"border p-2 hover:cursor-pointer " + (isActive ? "bg-red-600" : "")}
        onClick = {() => {
            navigate(url);
        }}>{page}</button>
}

const Dots = () => {
    return <div className="content-center">...</div>
}

interface ProductsGridProps {
    products: Product[];
    baseUrl: string;
    page: number;
    totalPages: number;
}

const ProductsGrid = ({ products, baseUrl, page, totalPages }: ProductsGridProps) => {
    return (
        <div className="flex flex-col gap-5">
            <div className="grid grid-cols-2 gap-5">
                {products.map((product) => (
                    <ProductObject
                        key={product.id}
                        product={product}
                    />
                ))}
            </div>
            <div className="flex w-full h-10 gap-2 justify-center">
                {page > 1 &&
                    <PageButton
                        baseUrl={baseUrl}
                        page={1}
                    />
                }
                {page > 4 ? (
                    <Dots/>
                ) : page == 4 && 
                    <PageButton
                        baseUrl={baseUrl}
                        page={2}
                    />
                }
                {page > 2 && 
                    <PageButton
                        baseUrl={baseUrl}
                        page={page-1}
                    />
                }
                <PageButton
                        baseUrl={baseUrl}
                        page={page}
                        isActive={true}
                />
                {page < totalPages && (
                    <PageButton
                        baseUrl={baseUrl}
                        page={page+1}
                    />
                )}
                {totalPages - page > 3 ? (
                    <Dots />
                ) : totalPages - page == 3 && (
                    <PageButton
                        baseUrl={baseUrl}
                        page={totalPages-1}
                    />
                )}
                {totalPages - page > 1 && (
                    <PageButton
                        baseUrl={baseUrl}
                        page={totalPages}
                    />
                )}
            </div>
        </div>
    );
};

export default ProductsGrid;
