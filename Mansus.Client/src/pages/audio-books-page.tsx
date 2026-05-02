import { useSearchParams } from "react-router-dom";

import ProductsGrid from "../components/products/products-grid.tsx";
import useAudioBooks from "../hooks/useAudioBooks.ts";

const AudioBooksPage = () => {
    const [searchParams] = useSearchParams();
    const page = Number(searchParams.get("page") ?? 1);

	const { data: audioBooksData, isLoading: audioBooksLoading } = useAudioBooks(page-1);

	return (
        <div className="size-full gap-5">
            <h2 className="text-2xl font-medium mb-5">Audio Books Page</h2>

            {audioBooksLoading ? (
                <p>Audio books loading...</p>
            ) : (
                audioBooksData?.items && (
                    <ProductsGrid
                        products={audioBooksData?.items}
                        baseUrl="/audiobooks"
                        page={page}
                        totalPages={audioBooksData?.totalPages}
                    />
                )
            )}
        </div>
	);
};

export default AudioBooksPage;
