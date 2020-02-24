import { combineReducers } from 'redux';
import accountReducer from './accountReducer';

const applicationReducers = combineReducers({
    accountReducer
})

export default applicationReducers