import { Link, useMatch, useResolvedPath } from "react-router-dom";
import "./navigation-item.css";

const NavigationItem = ({ title, icon, to }) => {
	const resolvedPath = useResolvedPath(to);
	const isActive = useMatch({ path: resolvedPath.pathname, end: true });

	return (
		<Link to={to}>
			<li className={isActive ? "NavigationItem active" : "NavigationItem"}>
				{icon && <div className="Icon">{icon}</div>}
				{title}
			</li>
		</Link>
	);
};

export default NavigationItem;
