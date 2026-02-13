import { Link, useMatch, useResolvedPath } from "react-router-dom";
import { type IconType } from 'react-icons';

import "./navigation-item.css";


interface NavigationItemProps {
	title: string;
	icon?: IconType;
	to: string;
}

const NavigationItem = ({ title, icon: Icon, to }: NavigationItemProps) => {
	const resolvedPath = useResolvedPath(to);
	const isActive = useMatch({ path: resolvedPath.pathname, end: true });

	return (
		<Link to={to}>
			<li className={isActive ? "NavigationItem active" : "NavigationItem"}>
				{Icon && <div className="Icon"><Icon /></div>}
				{title}
			</li>
		</Link>
	);
};

export default NavigationItem;
