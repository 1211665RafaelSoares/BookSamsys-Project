import React from 'react';
import { Book } from './AllBooksPage';

interface BookCardProps {
  book: Book;
  onShowDetails: () => void;
}

const BookCard: React.FC<BookCardProps> = ({ book, onShowDetails }) => {
  return (
    <div className="col">
      <div className="card h-100">
        <div className="card-body">
          <h5 className="card-title">{book.name}</h5>
          <h6 className="card-subtitle mb-2 text-muted">by {book.author}</h6>
          <p className="card-text">ISBN: {book.isbn}</p>
          <p className="card-text">Price: {book.price}</p>
          <button className="btn btn-primary" onClick={onShowDetails}>Show Details</button>
        </div>
      </div>
    </div>
  );
};

export default BookCard;
