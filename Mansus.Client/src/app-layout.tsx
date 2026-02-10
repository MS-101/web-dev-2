import React from "react";
import { Outlet } from "react-router-dom";
import TopPanel from "./components/navigation/top-panel";
import "./app-layout.css";

const AppLayout: React.FC = () => {
	return (
		<div className="App">
			<TopPanel />
			<div className="ContentWrapper">
				<div className="Content">
					<Outlet />
				</div>
			</div>
		</div>
	);
};

export default AppLayout;
