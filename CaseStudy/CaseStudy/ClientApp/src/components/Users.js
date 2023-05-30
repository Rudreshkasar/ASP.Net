import React from 'react';
import { useEffect, useState } from 'react';
import Table from 'react-bootstrap/Table';

    function User() {

        const [users, setUsers] = useState([])

        const fetchData = () => {
            fetch('api/Users/GetUsers')
                .then(response => {
                    return response.json()
                })
                .then(data => {
                    console.log(data)
                    setUsers(data)
                })
        }

        useEffect(() => {
            fetchData()
        }, [])

        return (
            <div className="User">
                <Table striped bordered hover>
                    <thead>
                    <tr>
                        <th>FirstName</th>
                        <th>LastName</th>
                        <th>Email</th>
                        <th>Address</th>
                            <th>Phone</th>
                            <th>Type</th>
                     </tr>
                    </thead>
                    <tbody>
                    {users.map((item, index) => (
                        <tr key={index}>
                            <td>{item.firstName}</td>
                            <td>{item.lastName}</td>
                            <td>{item.email}</td>
                            <td>{item.address}</td>
                                <td>{item.phone}</td>
                                <td>{item.type}</td>
                        </tr>
                    ))}
                    </tbody>
                </Table>
            </div>

        );
    }

 export default User;