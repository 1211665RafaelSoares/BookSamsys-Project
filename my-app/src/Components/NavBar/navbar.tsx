import React from 'react';
import { Link } from 'react-router-dom'; // Import Link from react-router-dom
import './Navbar.css';

function NavBar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/home">BookSamsys</Link> {/* Use Link instead of anchor */}
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link className="nav-link active" aria-current="page" to="/home">Home</Link> {/* Use Link instead of anchor */}
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/all-books">All Books</Link> {/* Use Link instead of anchor */}
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/create-book">Create Book</Link> {/* Use Link instead of anchor */}
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default NavBar;
