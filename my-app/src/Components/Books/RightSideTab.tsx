// RightSideTab.tsx

import React from 'react';
import { Book } from './AllBooksPage';
import EditBookForm from './EditBookForm';

interface RightSideTabProps {
  book: Book;
  onClose: () => void;
  onEdit: (editedBook: Book, callback: () => void) => void; // Modify onEdit to accept a callback
  onDelete: (book: Book, callback: () => void) => void; // Modify onDelete to accept a callback
}

const RightSideTab: React.FC<RightSideTabProps> = ({ book, onClose, onEdit, onDelete }) => {
  const handleEdit = (editedBook: Book) => {
    onEdit(editedBook, onClose); // Pass onClose as the callback function
  };

  const handleDeleteBook = () => {
    onDelete(book, onClose); // Pass onClose as the callback function
  };

  return (
    <div className="right-side-tab">
      <div className="card">
        <div className="card-header">
          <h5>Book Details</h5>
        </div>
        <div className="card-body">
          <EditBookForm initialBook={book} onSubmit={handleEdit} />
          <button className="btn btn-danger" onClick={handleDeleteBook}>Delete</button> {/* Delete button */}
          <button className="btn btn-secondary" onClick={onClose}>Close</button>
        </div>
      </div>
    </div>
  );
};

export default RightSideTab;
