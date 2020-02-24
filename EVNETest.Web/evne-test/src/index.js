import React from 'react';
import { createStore, applyMiddleware, compose } from 'redux';
import { render } from 'react-dom';
import applicationReducers from './redux/reducers/applicationReducers';
import axios from 'axios';
import 'antd/dist/antd.css';
import thunk from 'redux-thunk';

import Root from './components/Root/Root';

const store = createStore(applicationReducers, compose(
    applyMiddleware(thunk),
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()));
axios.defaults.baseURL = "http://localhost:5002";
axios.defaults.withCredentials = true
axios.interceptors.response.use(function (response) { return response; }, function (error) {
    
    return Promise.reject(error);
})
render(<Root store={store} />, document.getElementById('root'));
