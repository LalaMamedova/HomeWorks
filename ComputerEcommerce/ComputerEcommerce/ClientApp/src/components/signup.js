import React, { useState } from 'react';
import '../css/btns.css';
import '../css/autorization.css';

export default function SignUp(probs) {

    const [showPass, setShowPass] = useState(false);
    const [showConfirmPass, setShowConfrimPass] = useState(false);

    return (
        <div className='signin-div'>
            <form className='autorization-form'>
                <h1>Sign up</h1>

                <input   placeholder='Email'></input>
                <input   placeholder='Username'></input>

                <div className='pass-div'>
                    <input
                        type={showPass ? 'text' : 'password'}
                        placeholder='Password' />
                    <label onClick={() => setShowPass(!showPass)}>{showPass ? 'Show' : 'Hide'}</label>
                </div>

                <div className='pass-div'>
                    <input
                        type={showConfirmPass ? 'text' : 'password'}
                        placeholder='Confirm password'></input>
                    <label onClick={() => setShowConfrimPass(!showConfirmPass)}>{showConfirmPass ? 'Show' : 'Hide'}</label>
                </div>
                
                
                <button id='signin-btn' className='submit-btn' type='submit'>Sign up</button>

                <div className='btn-div'>
                    <button style={{ left: "0%", marginTop: '45px' }}
                
                        className='transparent-btn'
                        id='account-state'>Alredy have account? <a onClick={() => probs.setCurrentPage('signin')}> Sign in </a> </button>
                </div>
            </form>

        </div>
    )
}