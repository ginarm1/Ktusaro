import React, { Component } from "react";
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <header>
      <nav className="px-2 bg-white border-gray-200 dark:bg-gray-900 dark:border-gray-700">
        <div className="container flex flex-wrap items-center justify-between mx-auto">
          <a href="/" className="flex items-center">
              <span className="self-center text-xl font-semibold whitespace-nowrap dark:text-white">KTU SA RO IS</span>
          </a>
          <div className="hidden w-full md:block md:w-auto" id="navbar-dropdown">
            <ul className="flex flex-col p-4 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 md:mt-0 md:text-sm md:font-medium md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
              <NavLink tag={Link} className="block px-4 py-2 text-white hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white" to="/">
                Home
              </NavLink>
              <NavLink tag={Link} className="block px-4 py-2 text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white" to="/events">
                Events
              </NavLink>
            </ul>
          </div>
        </div>
      </nav>
      </header>
      // <header>
      //   <Navbar className="px-2 bg-white border-gray-200 dark:bg-gray-900 dark:border-gray-700">
      //     <div className="container flex flex-wrap items-center justify-between mx-auto">
      //       <NavbarBrand tag={Link} to="/" className="flex items-center">
      //         {/* <img
      //           src="ktusa_logo.png"
      //           className="h-6 mr-3 sm:h-10"
      //           alt="KTU SA Logo"
      //         /> */}
      //         KTU SA RO
      //       </NavbarBrand>
      //       <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
      //       <Collapse
      //         className="d-sm-inline-flex flex-sm-row-reverse bg-white"
      //         isOpen={!this.state.collapsed}
      //         navbar
      //       >
      //         <ul className="navbar-nav flex-grow">
      //           <NavItem>
      //             <NavLink tag={Link} className="text-dark" to="/">
      //               Home
      //             </NavLink>
      //           </NavItem>
      //           <NavItem>
      //             <NavLink tag={Link} className="text-dark" to="/events">
      //               Events
      //             </NavLink>
      //           </NavItem>
      //         </ul>
      //       </Collapse>
      //     </div>
      //   </Navbar>
      // </header>
    );
  }
}
