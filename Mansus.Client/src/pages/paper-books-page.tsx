import { useSearchParams } from "react-router-dom";

import ProductsGrid from "../components/products/products-grid.tsx";
import usePaperBooks from "../hooks/usePaperBooks.ts";

const PaperBooksPage = () => {
    const [searchParams] = useSearchParams();
    const page = Number(searchParams.get("page") ?? 1);
    const totalPages = 10;

	const { data: paperBooks, isLoading: paperBooksLoading } = usePaperBooks(page-1);

    return (
        <div className="size-full gap-5">
            <h2 className="text-2xl font-medium mb-5">Paper Books Page</h2>

            {paperBooksLoading ? (
                <p>Paper books loading...</p>
            ) : (
                paperBooks && (
                    <ProductsGrid
                        products={paperBooks}
                        baseUrl="/books"
                        page={page}
                        totalPages={totalPages}
                    />
                )
            )}
        </div>
    ); 
};

export default PaperBooksPage;
