import { Link, useMatch, useResolvedPath } from "react-router-dom";
import { type IconType } from 'react-icons';

interface NavigationItemProps {
	title: string;
	icon?: IconType;
	to: string;
}

const NavigationItem = ({ title, icon: Icon, to }: NavigationItemProps) => {
	const resolvedPath = useResolvedPath(to);
	const isActive = useMatch({ path: resolvedPath.pathname, end: true });

	return (
		<Link className="flex h-full hover:bg-red-800" to={to}>
			<li className="flex items-center px-5 gap-2">
				{Icon && <div className="Icon"><Icon /></div>}
				<span className={"text-xl " + (isActive ? "font-bold" : "font-normal")}>{title}</span>
			</li>
		</Link>
	);
};

export default NavigationItem;
