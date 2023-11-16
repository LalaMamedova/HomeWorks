import React from 'react'
import { useNavigate } from 'react-router-dom';
import { SIGNUP_ROUTE } from '../utilits/const';
import '../css/autorization.css'

const Signin = () => {
    const navigate = useNavigate();

    return (
        <div className='ml-auto' id='autorization-div'>
            <form className='autorization-form'>

                <h1>Sign in</h1>
                <input type='email' placeholder="You'r email"></input>
                <input type='password' placeholder="You'r password"></input>

                <nav className='auto-nav'>
                    <span id='account-state'>Don't have account? <a onClick={() => navigate(SIGNUP_ROUTE) } >Signup</a></span>
                    <span id='forgot-pass'>Forgot password</span>
                </nav>

                    <button id='login' className='submit-btn' type='submit'>Login</button>
                <div className='btn-div'>
                </div>

            </form>
        </div>
    )
}
export default Signin;