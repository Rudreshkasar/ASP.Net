import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Register from './components/Register';
import './components/Register.css';
import Users from './components/Users';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
        <Layout>
            <Routes>
                <Route exact path='/' element={<Home />} />
                <Route path='/counter' element={<Counter />} />
                <Route path='/fetchdata' element={<FetchData />} />
                <Route path='/register' element={<Register />} />
                <Route path='/users' element={<Users />} />
            </Routes>
        </Layout>
        
    );
  }
}
