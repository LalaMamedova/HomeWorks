import React from 'react'
import { SIGNIN_ROUTE } from '../utilits/const';
import { useNavigate } from 'react-router-dom';

const Signup = () => {
    const navigate = useNavigate();

    return (
        <div className='ml-auto' id='autorization-div'>
            <form className='autorization-form'>
                <h1>Sign up</h1>
                <input type='text' placeholder="You'r username"></input>
                <input type='email' placeholder="You'r email"></input>
                <input type='password' placeholder="You'r password"></input>
                <input type='password' placeholder="Confirm password"></input>

                <nav className='auto-nav'>
                    <span style={{marginLeft:'25px'}} id='account-state'>Have account? 
                    <a onClick={() => navigate(SIGNIN_ROUTE) }> Signup</a></span>
                </nav>

                <button id='login' className='submit-btn' type='submit'>Login</button>
            </form>
        </div>
    )
}
export default Signup;