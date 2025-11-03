import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/home-page.tsx";
import BooksPage from "./pages/books-page.tsx";
import AppLayout from "./app-layout.tsx";

const Router: React.FC = () => {
	return (
		<BrowserRouter>
			<Routes>
				<Route path="/" element={<AppLayout />}>
					<Route index element={<HomePage />} />
					<Route path="books" element={<BooksPage />} />
				</Route>
			</Routes>
		</BrowserRouter>
	);
}

export default Router;
