import { useSearchParams } from "react-router-dom";

import ProductsGrid from "../components/products/products-grid.tsx";
import usePaperBooks from "../hooks/usePaperBooks.ts";

const PaperBooksPage = () => {
    const [searchParams] = useSearchParams();
    const page = Number(searchParams.get("page") ?? 1);

	const { data: paperBooksData, isLoading: paperBooksLoading } = usePaperBooks(page-1);

    return (
        <div className="size-full gap-5">
            <h2 className="text-2xl font-medium mb-5">Paper Books Page</h2>

            {paperBooksLoading ? (
                <p>Paper books loading...</p>
            ) : (
                paperBooksData?.items && (
                    <ProductsGrid
                        products={paperBooksData?.items}
                        baseUrl="/books"
                        page={page}
                        totalPages={paperBooksData?.totalPages}
                    />
                )
            )}
        </div>
    ); 
};

export default PaperBooksPage;
