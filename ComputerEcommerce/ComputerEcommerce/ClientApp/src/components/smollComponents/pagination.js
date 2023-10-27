import React, { useState } from 'react';
import '../css/products.css';

export default function MyPagination(props) {
    const pageCount = props.pageCount;
    const [currentPage, setCurrentPage] = useState(1);
    const [prevA, setPrevA] = useState(null);
    const pageValues = [];

    const handlePageClick = (pageValue) => {
        if (pageValue !== '...' && pageValue !== 'next' && pageValue !== 'prev') {
            if (pageValue <= pageCount) {
                props.setPage(pageValue);
                setCurrentPage(pageValue);
            }
        } else if (pageValue === 'next') {
            if (currentPage < pageCount) {
                const nextPage = currentPage + 1;
                setCurrentPage(nextPage);
                props.setPage(nextPage);
            }
        } else if (pageValue === 'prev') {
            if (currentPage > 1) {
                const prevPage = currentPage - 1;
                setCurrentPage(prevPage);
                props.setPage(prevPage);
            }
        }

        const current = document.getElementById(currentPage);
        if (prevA) {
            prevA.style.color = 'lightseagreen';
        }

        setPrevA(current);
        current.style.color = 'red';

    };

    for (var i = currentPage; i < (pageCount + currentPage + 3) - pageCount; i++) {
        if (i < pageCount) {
            pageValues.push(i);
        }
    }

    pageValues.push('...');
    for (var i = pageCount - 5; i < pageCount; i++) pageValues.push(i);
    
    return (
        <nav className='page-div'>

            <a onClick={() => handlePageClick('prev')} className='next-prev'>Prev</a>
            <ul>{

                   pageValues.map((nums) => (
                    <li>
                           <a onClick={() => handlePageClick(nums)} id={nums} className='page-a'>{nums}</a>
                    </li>
                    ))
                }
            </ul>
            <a onClick={() => handlePageClick('next')} className='next-prev'>Next</a>
           
        </nav>
    );
}
