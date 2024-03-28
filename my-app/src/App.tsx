import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import AllBooksPage from "./Components/Books/AllBooksPage";
import NavBar from "./Components/NavBar/navbar";
import HomePage from "./Components/HomePage/HomePage"; // Import the HomePage component
import CreateBookPage from "./Components/Books/CreateBookPage";
import "./App.css";

const App: React.FC = () => {
  return (
    <Router>
      <div>
        <NavBar />
        <div className="home-section">
          <Routes>
            <Route path="/" element={<HomePage />} /> {}
            <Route path="/home" element={<HomePage />} />
            <Route path="/all-books" element={<AllBooksPage />} />
            <Route path="/create-book" element={<CreateBookPage />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
