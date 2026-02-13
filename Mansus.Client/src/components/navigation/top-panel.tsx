import { Link } from "react-router-dom";
import SearchBar from "./search-bar";
import NavigationItem from "./navigation-item";
import { FaBook, FaFilePdf, FaVolumeUp } from "react-icons/fa";
import "./top-panel.css";

const TopPanel = () => {
	return (
		<nav className="TopPanel">
			<div className="TitleContainer">
				<h1 className="Title">
					<Link to="/">Mansus</Link>
				</h1>
			</div>
			<ul className="NavigationContainer">
				<NavigationItem icon={FaBook} title="Books" to="/books" />
				<NavigationItem icon={FaFilePdf} title="E-books" to="/ebooks" />
				<NavigationItem icon={FaVolumeUp} title="Audiobooks" to="/audiobooks" />
			</ul>
			<div className="SearchContainer">
				<SearchBar />
			</div>
		</nav>
	);
};

export default TopPanel;
