import React from "react";
import { Link } from "react-router-dom";
import SearchBar from "./search-bar";
import NavigationItem from "./navigation-item";
import "./top-panel.css";

const TopPanel = () => {
	return (
		<nav className="TopPanel">
			<div className="TitleContainer">
				<h1 className="Title">
					<Link to="/">Mansus</Link>
				</h1>
			</div>
			<ul>
				<NavigationItem title="Books" to="/books" />
			</ul>
			<div className="SearchContainer">
				<SearchBar />
			</div>
		</nav>
	);
};

export default TopPanel;
