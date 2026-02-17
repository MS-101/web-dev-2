import { Outlet } from "react-router-dom";
import TopPanel from "./components/navigation/top-panel";
import "./app-layout.css";

const AppLayout = () => {
	return (
		<div className="App">
			<TopPanel />
			<div className="Content">
				<Outlet />
			</div>
		</div>
	);
};

export default AppLayout;
