import React, { useState, useEffect, useRef } from 'react';
import '../css/navbar.css';
import '../css/btns.css';

export default function Navbar(props) {
    const [open, setOpen] = useState(false);
    const [catalogOpen, setCatalogOpen] = useState(false);
    const dropdownRef = useRef(null);

    useEffect(() => {
        function handleClickOutside(event) {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setOpen(false);
            }
        }
        document.addEventListener('mousedown', handleClickOutside);

        return () => {
            document.removeEventListener('mousedown', handleClickOutside);}}, []);

    return (
        <header>
            <div className='navbar-div' >

                <h1 onClick={() => props.setCurrentPage('home')}>Computers</h1>

                <nav>
                    <button className='nav-btn' onClick={() => props.setCurrentPage('products')}>
                        Catalog   <i className={`fa ${catalogOpen ? 'fa-chevron-up' : 'fa-chevron-down'}`} aria-hidden="true"></i>
                    </button>
                 
                </nav>

               
                <div className='auto-div'>

                    <div className="dropdown" ref={dropdownRef}>
                        <button className='dropdown-btn' onClick={() => setOpen(!open)}>
                            <i className="fa fa-user" aria-hidden="true"></i>Account
                            <i className={`fa ${open ? 'fa-chevron-up' : 'fa-chevron-down'}`} aria-hidden="true"></i>
                        </button>
                        {open ? (
                            <ul className="menu">
                                <li className="menu-item">
                                    <button onClick={() => props.setCurrentPage('signin')} className="auto-btn">
                                        <i className="fa fa-sign-in" aria-hidden="true"></i>Sign in
                                    </button>
                                </li>
                                <li className="menu-item">
                                    <button onClick={() => props.setCurrentPage('signup')} className="auto-btn">
                                        <i className="fa fa-user-plus" aria-hidden="true"></i>Sign up
                                    </button>
                                </li>
                            </ul>
                        ) : null}
                    </div>

                </div>

                <div className='side-head-div'>
                    <button className='transparent-btn'  onClick={() => props.setMode(!props.mode)}>{!props.mode ? '🌙' : '☀️'}</button>
                </div>
            </div>
        </header>
    );
}