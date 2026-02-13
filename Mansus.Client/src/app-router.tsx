import { BrowserRouter, Routes, Route } from "react-router-dom";

import AppLayout from "./app-layout.tsx";
import HomePage from "./pages/home-page.tsx";
import PaperBooksPage from "./pages/paper-books-page.tsx";
import EBooksPage from "./pages/e-books-page.tsx";
import AudioBooksPage from "./pages/audio-books-page.tsx";

const AppRouter = () => {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<AppLayout />}>
					<Route index element={<HomePage />} />
					<Route path="books" element={<PaperBooksPage />} />
					<Route path="ebooks" element={<EBooksPage />} />
					<Route path="audiobooks" element={<AudioBooksPage />} />
				</Route>
			</Routes>
		</BrowserRouter>
	);
}

export default AppRouter;
