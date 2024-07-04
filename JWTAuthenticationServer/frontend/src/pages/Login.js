import axios from 'axios';
import React from 'react'
import { useState } from 'react';

const Login = () => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async () => {
        const data = {
            email: email,
            password: password
        }

        await axios.post('https://localhost:44326/Account/login', data).then((result) => {
            alert(result.data)
        })
    }

  return (
    <div>
        <h1>Login</h1>
        <form>
            Email
            <input type='email' placeholder='Email' onChange={(e) =>setEmail(e.target.value)} />

            Password
            <input type='password' placeholder='Password' onChange={(e) =>setPassword(e.target.value)} />

            <button type='submit' onClick={() => handleLogin()}></button>
        </form>
    </div>
  )
}

export default Login