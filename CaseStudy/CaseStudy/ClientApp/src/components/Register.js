import React from 'react';
import { useState }  from 'react';

function Register() {

    const [FirstName, setFirstName] = useState("");
    const [LastName, setLastName] = useState("");
    const [Email, setEmail] = useState("");
    const [Password, setPassword] = useState("");
    const [Address, setAddress] = useState("");
    const [Phone, setPhone] = useState("");
    const [Type, setType] = useState("User");


    function saveUser() {
        console.log({ FirstName, LastName, Email, Password, Address, Phone, Type });
        let data = { FirstName, LastName, Email, Password, Address, Phone, Type }

        fetch('api/Users/PostUser', {
            method: "Post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body:JSON.stringify(data)
            
            
        }).then((result) => {
            console.log(result)
        })
    }
    return (

        <div className="div1">
            <div className="div2">
            <form className = "form">
                    <label>FirstName: <br /> <input type="text" name="firstName" value={FirstName} onChange={(e) => { setFirstName(e.target.value) }} /></label> <br />
                    <label>LastName:  <br /> <input type="text" name="lastName" value={LastName} onChange={(e) => { setLastName(e.target.value) }}   /></label>  <br />
                    <label>Email:  <br /> <input type="text" name="email" value={Email} onChange={(e) => { setEmail(e.target.value) }}  /></label> <br />
                    <label>Password:  <br /> <input type="text" name="password" value={Password} onChange={(e) => { setPassword(e.target.value) }} /></label> <br />
                    <label>Address:  <br /> <input type="text" name="address" value={Address} onChange={(e) => { setAddress(e.target.value) }}  /></label> <br />
                    <label>Phone: <br />  <input type="text" name="phone" value={Phone} onChange={(e) => { setPhone(e.target.value) }}  /></label> <br />
               

                    <button type="button"  onClick={saveUser} >Submit </ button>
                </form>
                </div>
        </div>
        
        
        
        
        );

}
export default Register;
