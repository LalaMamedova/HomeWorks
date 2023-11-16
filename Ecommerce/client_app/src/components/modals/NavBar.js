import React, { useState, useEffect, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { SHOP_ROUTE } from '../../utilits/const';
import '../../css/navbar.css';
import '../../css/btns.css';

export default function NavBar(props) {
    const [open, setOpen] = useState(false);
    const [catalogOpen, setCatalogOpen] = useState(false);
    const dropdownRef = useRef(null);
    const navigate = useNavigate();

    const handleClickOutside = (event) => {
        if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
            setOpen(false);
        }
    };

    useEffect(() => {
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    return (
        <header>
            <div id='navbar-div'>
                <h1 onClick={() => navigate(SHOP_ROUTE) } >Computers</h1>
                <nav>
                    <button className='nav-btn'>
                        Catalog
                        <i className={`fa ${catalogOpen ? 'fa-chevron-up' : 'fa-chevron-down'}`} aria-hidden="true"></i>
                    </button>
                </nav>
                <div id='side-bar-div'>
                    <div className="dropdown" ref={dropdownRef}>
                        <button className='dropdown-btn' onClick={() => setOpen(!open)}>
                            <i className="fa fa-user" aria-hidden="true"></i>Account
                            <i className={`fa ${open ? 'fa-chevron-up' : 'fa-chevron-down'}`} aria-hidden="true"></i>
                        </button>
                        {open ? (
                            <ul className="menu">
                                <li className="menu-item">
                                    <button  onClick={() => navigate("/signin") } className="auto-btn">
                                        <i className="fa fa-sign-in" aria-hidden="true"></i>Sign in
                                    </button>
                                </li>
                                <li className="menu-item">
                                    <button onClick={() => navigate("/signup") } className="auto-btn">
                                        <i className="fa fa-user-plus" aria-hidden="true"></i>Sign up
                                    </button>
                                </li>
                            </ul>
                        ) : null}
                    </div>
                    <button className='transparent-btn' id='mode-btn' onClick={() => props.setMode(!props.mode)}>{!props.mode ? '🌙' : '☀️'}</button>
                </div>
            </div>
        </header>
    );
}
