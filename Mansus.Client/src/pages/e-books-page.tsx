import { useSearchParams } from "react-router-dom";

import ProductsGrid from "../components/products/products-grid.tsx";
import useEBooks from "../hooks/useEBooks.ts";

const EBooksPage = () => {
    const [searchParams] = useSearchParams();
    const page = Number(searchParams.get("page") ?? 1);
    const totalPages = 10;

    const { data: eBooks, isLoading: eBooksLoading } = useEBooks(page-1);

    return (
        <div className="size-full gap-5">
            <h2 className="text-2xl font-medium mb-5">E-Books Page</h2>

			{eBooksLoading ? (
				<p>Ebooks loading...</p>
            ) : (
                eBooks && (
                    <ProductsGrid
                        products={eBooks}
                        baseUrl="/ebooks"
                        page={page}
                        totalPages={totalPages}
                    />
                )
            )}
		</div>
	);
};

export default EBooksPage;
