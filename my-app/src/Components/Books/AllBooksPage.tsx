import React, { useState, useEffect } from 'react';
import './AllBooksPage.css';
import BookCard from './BookCard';
import RightSideTab from './RightSideTab';
import EditBookForm from './EditBookForm';


export interface Book {
  id: number;
  isbn: string;
  name: string;
  author: string;
  price: number;
}

function AllBooksPage() {
  const [books, setBooks] = useState<Book[]>([]);
  const [selectedBook, setSelectedBook] = useState<Book | null>(null);
  const [isRightSideTabOpen, setIsRightSideTabOpen] = useState(false);
  const [searchValue, setSearchValue] = useState<string>('');
  const [currentPage, setCurrentPage] = useState(1);
  const [booksPerPage, setBooksPerBage] = useState(6);

  useEffect(() => {
    fetchBooks();
  }, [currentPage]);

  const fetchBooks = async () => {
    try {
      const response = await fetch(`https://localhost:7291/api/GetBooksPage/${currentPage}`);
      if (response.ok) {
        const data = await response.json();
        if (data.success && Array.isArray(data.obj)) {
          setBooks(data.obj);
        } else {
          console.error('Invalid books data format');
        }
      } else {
        console.error('Failed to fetch books');
      }
    } catch (error) {
      console.error('Error fetching books:', error);
    }
  };

  const handleShowDetails = (book: Book) => {
    setSelectedBook(book);
    setIsRightSideTabOpen(true);
  };

  const handleCloseDetails = () => {
    setSelectedBook(null);
    setIsRightSideTabOpen(false);
  };

  const handleEditBook = async (editedBook: Book, callback: () => void) => {
    try {
      const response = await fetch(`https://localhost:7291/api/EditBook/${editedBook.isbn}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name: editedBook.name,
          author: editedBook.author,
          price: editedBook.price
        }),
      });
      if (response.ok) {
        const updatedBook = await response.json();
        // Update the book in the state
        setBooks(prevBooks => prevBooks.map(b => b.isbn === updatedBook.isbn ? updatedBook : b));
        console.log('Book edited successfully:', updatedBook);
        callback(); // Close the tab and trigger page update
      } else {
        console.error('Failed to edit book');
      }
    } catch (error) {
      console.error('Error editing book:', error);
    }
  };

  const handleDeleteBook = async (book: Book, callback: () => void) => {
    try {
      const response = await fetch(`https://localhost:7291/api/DeleteBook/${book.isbn}`, {
        method: 'DELETE',
      });
      if (response.ok) {
        // Remove the deleted book from the state
        setBooks(prevBooks => prevBooks.filter(b => b.isbn !== book.isbn));
        console.log('Book deleted successfully:', book);
        callback(); // Close the tab
      } else {
        console.error('Failed to delete book');
      }
    } catch (error) {
      console.error('Error deleting book:', error);
    }
  };

  const filteredBooks = books.filter(book =>
    book.isbn.toLowerCase().includes(searchValue.toLowerCase()) ||
    book.author.toLowerCase().includes(searchValue.toLowerCase())
  );

  const goToNextPage = () => {
    setCurrentPage(currentPage + 1);
  };

  const goToPrevPage = () => {
    setCurrentPage(currentPage - 1);
  };

 
  return (
    <div className="container all-books-container">
      <h2 className="mt-3">All Books</h2>
      {/* Search bar */}
      <div className="search-bar">
        <input
          type="search"
          placeholder="Search by ISBN or author"
          value={searchValue}
          onChange={(e) => setSearchValue(e.target.value)}
          className="search-input"
        />
        <button
          className="search-button"
          type="button"
          onClick={() => setSearchValue('')}
        >
          Clear
        </button>
      </div>
      {/* Book cards */}
      <div className="row row-cols-1 row-cols-md-3 g-4">
        {filteredBooks.map((book) => (
          <BookCard key={book.id} book={book} onShowDetails={() => handleShowDetails(book)} />
        ))}
      </div>
      {/* Pagination buttons */}
      <div className="pagination-buttons mt-3">
        {currentPage > 1 && (
          <button className="btn btn-primary me-2" onClick={goToPrevPage}>
            Previous Page
          </button>
        )}
        {filteredBooks.length === booksPerPage && (
          <button className="btn btn-primary" onClick={goToNextPage}>
            Next Page
          </button>
        )}
      </div>

      {/* Right side tab for book details */}
      {isRightSideTabOpen && selectedBook && (
        <RightSideTab
          book={selectedBook}
          onClose={handleCloseDetails}
          onEdit={handleEditBook}
          onDelete={handleDeleteBook}
        />
      )}
    </div>

  );
}

export default AllBooksPage;
