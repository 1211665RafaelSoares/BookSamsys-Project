import React, { useState } from "react";

const CreateBookPage: React.FC = () => {
  const [isbn, setIsbn] = useState<string>("");
  const [name, setName] = useState<string>("");
  const [author, setAuthor] = useState<string>("");
  const [price, setPrice] = useState<number>(0);
  const [successMessage, setSuccessMessage] = useState<string>("");
  const [errorMessage, setErrorMessage] = useState<string>("");

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    // Validation checks
    if (isbn.length !== 13) {
      setErrorMessage("ISBN must be 13 digits");
      setTimeout(() => setErrorMessage(""), 10000); // Clear error message after 10 seconds
      return;
    }

    if (price < 0) {
      setErrorMessage("Price cannot be negative");
      setTimeout(() => setErrorMessage(""), 10000); // Clear error message after 10 seconds
      return;
    }

    try {
      const response = await fetch("https://localhost:7291/api/CreateBook", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({ isbn, name, author, price })
      });

      if (response.ok) {
        setSuccessMessage("Book created successfully!");
        setTimeout(() => setSuccessMessage(""), 5000); 
        // Reset form fields after 2 seconds
        setTimeout(() => {
          setIsbn("");
          setName("");
          setAuthor("");
          setPrice(0);
        }, 2000);
      } else {
        console.error("Failed to create book");
      }
    } catch (error) {
      console.error("Error creating book:", error);
    }
  };

  return (
    <div className="container">
      <h2>Create New Book</h2>
      {errorMessage && <div className="alert alert-danger">{errorMessage}</div>}
      {successMessage && <div className="alert alert-success">{successMessage}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="isbn" className="form-label">ISBN:</label>
          <input
            type="text"
            className="form-control"
            id="isbn"
            value={isbn}
            onChange={(e) => setIsbn(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="name" className="form-label">Name:</label>
          <input
            type="text"
            className="form-control"
            id="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="author" className="form-label">Author:</label>
          <input
            type="text"
            className="form-control"
            id="author"
            value={author}
            onChange={(e) => setAuthor(e.target.value)}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="price" className="form-label">Price:</label>
          <input
            type="number"
            className="form-control"
            id="price"
            value={price}
            onChange={(e) => setPrice(parseFloat(e.target.value))}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">Create Book</button>
      </form>
    </div>
  );
};

export default CreateBookPage;
