// EditBookForm.tsx

import React, { useState } from 'react';
import { Book } from './AllBooksPage';

interface EditBookFormProps {
  initialBook: Book;
  onSubmit: (editedBook: Book) => void;
}

const EditBookForm: React.FC<EditBookFormProps> = ({ initialBook, onSubmit }) => {
  const [editedBook, setEditedBook] = useState<Book>({ ...initialBook });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setEditedBook((prevBook) => ({
      ...prevBook,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(editedBook); // Pass the edited book data to the parent component
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="mb-3">
        <label className="form-label">Name</label>
        <input type="text" className="form-control" name="name" value={editedBook.name} onChange={handleChange} />
      </div>
      <div className="mb-3">
        <label className="form-label">Author</label>
        <input type="text" className="form-control" name="author" value={editedBook.author} onChange={handleChange} />
      </div>
      <div className="mb-3">
        <label className="form-label">Price</label>
        <input type="number" className="form-control" name="price" value={editedBook.price} onChange={handleChange} />
      </div>
      <button type="submit" className="btn btn-primary">Submit</button>
    </form>
  );
};

export default EditBookForm;
