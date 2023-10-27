import React from "react";
import '../css/btns.css';

export default function Footer(props) {

    return (
        <footer>
            <div className='footer-div'>
                <nav className='social-media-nav'>
                    <li>Facebook</li>
                    <li>Insta</li>
                </nav>

                <nav className='link-nav'>
                    <button className='transparent-btn' onClick={() => props.setCurrentPage('aboutUs')}>About Us</button>
                </nav>
            </div>
        </footer>
    );
}