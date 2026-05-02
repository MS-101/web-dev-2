import { Link } from "react-router-dom";
import { FaBook, FaFilePdf, FaVolumeUp } from "react-icons/fa";

import SearchBar from "./search-bar";
import NavigationItem from "./navigation-item";

const TopPanel = () => {
	return (
		<nav className="flex bg-red-600 px-100 h-15">
			<div className="flex items-center">
				<h1 className="w-50 text-2xl font-medium">
					<Link to="/">Mansus</Link>
				</h1>
			</div>
			<ul className="flex">
				<NavigationItem icon={FaBook} title="Books" to="/books" />
				<NavigationItem icon={FaFilePdf} title="Ebooks" to="/ebooks" />
				<NavigationItem icon={FaVolumeUp} title="Audiobooks" to="/audiobooks" />
			</ul>
			<div className="flex items-center w-60">
				<SearchBar />
			</div>
		</nav>
	);
};

export default TopPanel;
