import React from "react";
import "./HomePage.css"; // Import the CSS file for HomePage styling
import { Container, Row, Col } from 'react-bootstrap'; // Import Bootstrap components

const HomePage: React.FC = () => {
  return (
    <div className="background-container">
      {/* Content for the home page */}
      <Container>
        <Row className="justify-content-md-center align-items-center">
          <Col md="8">
            <h1>Welcome to BookSamsys</h1>
            <p>Discover a vast collection of books.</p>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default HomePage;
