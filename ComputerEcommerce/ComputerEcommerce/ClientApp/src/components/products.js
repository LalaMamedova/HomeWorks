import React, { useState, useEffect } from 'react';
import MyPagination from './pagination';
import '../css/products.css';
   

export default function Products() {

    const [page, setPage] = useState(1);
    const [books, setBooks] = useState([]);
    const [pageCount, setPageCount] = useState(1);

   

    useEffect(() => {
        fetch(`https://localhost:44492/api/book/GetAll/${page}`)
            .then(response => response.json())
            .then(responseJson => {
                setBooks(responseJson.results);
                setPageCount(Number.parseInt(responseJson.count / 32));
            });
    }, [page]); 
    
    return (
        <div className='book-container'>
            <div className='books-cards'>
                {
                    books.map((book) => (
                        <div className='book-card' key={book.id}>
                            <img src={book.formats["image/jpeg"]} alt={book.title} />
                            <h2>{book.title}</h2>
                            {
                                book.authors.map((author, index) => ( 
                                    <p key={index}>{author.name}</p>
                                ))
                            }
                        </div>
                    ))
                }
            </div>

            
            <div className='page-div'>
                <MyPagination pageCount={pageCount} setPage={setPage}></MyPagination>
            </div>
        </div>
    );
}

