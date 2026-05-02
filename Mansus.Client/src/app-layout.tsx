import { Outlet } from "react-router-dom";

import TopPanel from "./components/navigation/top-panel";

const AppLayout = () => {
	return (
		<div className="h-screen flex flex-col">
			<TopPanel />
			<div className="flex-1 px-100 py-20">
				<Outlet />
			</div>
		</div>
	);
};

export default AppLayout;
