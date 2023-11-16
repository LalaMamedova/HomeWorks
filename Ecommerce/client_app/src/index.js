import React, { createContext } from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import User from './store/User';
import Computer from './store/Computer';

export const Context = createContext(null);
const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
    <Context.Provider value={{
        user: new User(),
        computer:new Computer(),
    }}>
        <App />
    </Context.Provider>
);

