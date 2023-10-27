import React, { useState } from 'react';
import '../css/btns.css';
import '../css/autorization.css';

export default function SignIn(probs) {
    const [showPass, setShowPass] = useState(false);

    return (
        <div className='signin-div'>
            <form className='autorization-form'>
                <h1>Sign In</h1>

                <input placeholder='Email'  />

                <div className='pass-div'>
                    <input
                        type={showPass ? 'text' : 'password'}
                        placeholder='Password' />
                    <label onClick={() => setShowPass(!showPass)}>{showPass ? 'Show' : 'Hide'}</label>
                </div>

                <div className='btn-div'>
                    <button style={{marginTop:'45px'}} className='transparent-btn' id='forgot-pass-btn'>Forgot password?</button>
                    <button style={{ marginTop: '45px' }}  className='transparent-btn' id='account-state'>Don't have account? <a onClick={() => probs.setCurrentPage('signup')}> Sign up </a></button>
                </div>

                <button id='signin-btn' className='submit-btn' type='submit'>Login</button>
            </form>
        </div>

    )
}