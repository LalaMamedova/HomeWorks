import React, { useState} from 'react';
import SignIn from "./components/signin";
import SignUp from './components/signup';
import Home from './components/home';
import Navbar from './components/navbar';
import Footer from './components/footer';
import './css/index.css'

export default function App() {
    const [mode, setMode] = useState(false);
    const [currentPage, setCurrentPage] = useState('home');

    const pageLinks = {
        home: <Home></Home>,
        signin: <SignIn setCurrentPage={setCurrentPage}/>,
        signup: <SignUp setCurrentPage={setCurrentPage} />,
    };


    return (
        <div className='App' id={mode ? 'light' : 'dark'}>
            <Navbar mode={mode} setMode={setMode} setCurrentPage={setCurrentPage} />

            <main id={mode ? 'light' : 'dark'}>
                {pageLinks[currentPage]}
            </main>
            <Footer setCurrentPage={setCurrentPage} />
        </div>
    );
  
}
