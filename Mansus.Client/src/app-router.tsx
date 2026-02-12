import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/home-page.tsx";
import PaperBooksPage from "./pages/paper-books-page.tsx";
import AppLayout from "./app-layout.tsx";

const Router: React.FC = () => {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<AppLayout />}>
					<Route index element={<HomePage />} />
					<Route path="books" element={<PaperBooksPage />} />
				</Route>
			</Routes>
		</BrowserRouter>
	);
}

export default Router;
