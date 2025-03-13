import { Link } from "react-router-dom";

const Nav = () => {
    return (
        <nav className="p-4 bg-gray-200 text-black text-lg shadow-md fixed top-0 w-full">
            <div className="max-w-6xl mx-auto flex items-center">
                <Link to="/" className="hover:underline cursor-pointer px-4 py-2">Dashboard</Link>
            </div>
        </nav>
    );
}

export default Nav;