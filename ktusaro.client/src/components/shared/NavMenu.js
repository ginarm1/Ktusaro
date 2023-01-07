import React from "react";
import { NavLink } from "reactstrap";
import { Link } from "react-router-dom";
import useDarkMode from "../hooks/useDarkMode";
import "./NavMenu.css";

export const NavMenu = () => {
  const [isMenuOpen, setIsMenuOpen] = React.useState(false);
  const [theme, setTheme] = useDarkMode();
  return (
    <header>
      <nav className="flex items-center justify-between flex-wrap bg-gray-200 border-gray-200 dark:bg-gray-900 dark:border-gray-700 p-6 pl-10">
        <div className="flex items-center flex-shrink-0 text-dark dark:text-white mr-6">
          <a href="/" className="font-semibold text-xl tracking-tight">
              KTU SA RO
          </a>
        </div>
        <div className="block lg:hidden">
          <button
            onClick={() => setIsMenuOpen(!isMenuOpen)}
            className="inline-flex items-center p-2 ml-3 text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
          >
            <svg
              className="fill-current h-3 w-3"
              viewBox="0 0 20 20"
              xmlns="http://www.w3.org/2000/svg"
            >
              <title>Menu</title>
              <path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z" />
            </svg>
          </button>
        </div>
        <div
          className={`w-full md:block md:w-auto ${
            isMenuOpen ? "block" : "hidden"
          }`}
        >
          <ul className="flex flex-col p-4 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 md:mt-0 md:text-sm md:font-medium md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
          <button
            title="Toggle Theme"
            onClick={() => setTheme(theme === "light" ? "dark" : "light")}
            class="
            w-12 
            h-6 
            rounded-full 
            p-1 
            bg-gray-400 
            dark:bg-gray-600 
            relative 
            transition-colors 
            duration-500 
            ease-in
            focus:outline-none 
            focus:ring-2 
            focus:ring-blue-700 
            dark:focus:ring-blue-600 
            focus:border-transparent
          "
          >
            <div
              id="toggle"
              class="
                rounded-full 
                w-4 
                h-4 
                bg-blue-600 
                dark:bg-blue-500 
                relative 
                ml-0 
                dark:ml-6 
                pointer-events-none 
                transition-all 
                duration-300 
                ease-out
            "
            ></div>
          </button>
            <NavLink
              tag={Link}
              className="block py-2 pl-3 pr-4 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-gray-400 md:dark:hover:text-white dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
              aria-current="page"
              to="/"
            >
              Home
            </NavLink>
            <NavLink
              tag={Link}
              className="block py-2 pl-3 pr-4 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-gray-400 md:dark:hover:text-white dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent"
              to="/events"
            >
              Events
            </NavLink>
          </ul>
        </div>
      </nav>
    </header>
  );
};
