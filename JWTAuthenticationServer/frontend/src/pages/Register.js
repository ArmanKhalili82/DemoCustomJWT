import axios from 'axios';
import React from 'react'
import { useState } from 'react'

const Register = () => {
    const [name, setName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const handleRegister = async () => {
        const data = {
            name: name,
            email: email,
            password: password,
            confirmPassword: confirmPassword
        }

        await axios.post('https://localhost:44326/Account/register', data).then((result) => {
            alert(result.data)
        })
    }

  return (
    <div>
        <h1>Register</h1>
        <form>
            Name
            <input type='string' placeholder='Name' onChange={(e) =>setName(e.target.value)} />

            Email
            <input type='email' placeholder='Email' onChange={(e) =>setEmail(e.target.value)} />

            Password
            <input type='password' placeholder='Password' onChange={(e) =>setPassword(e.target.value)} />

            Confirm Password
            <input type='password' placeholder='Confirm Password' onChange={(e) =>setConfirmPassword(e.target.value)} />

            <button type="submit" onClick={() => handleRegister()}>Register</button>
        </form>
    </div>
  )
}

export default Register