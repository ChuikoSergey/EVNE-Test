import axios from 'axios';

export const GET_CURRENT_USER_PENDING = "GET_CURRENT_USER_PERNDING";
export const GET_CURRENT_USER_SUCCESS = "GET_CURRENT_USER_SUCCESS";
export const GET_CURRENT_USER_ERROR = "GET_CURRENT_USER_ERROR";

const getCurrentUserBegin = () =>  { return { type: GET_CURRENT_USER_PENDING } };
const getCurrentUserSuccess = (user) => { return {type: GET_CURRENT_USER_SUCCESS, user }  };

export function getCurrentUser() {
    return dispatch => {
        dispatch(getCurrentUserBegin());
        axios({
            method: "get",
            url: "user/current"
        }).then(response => {
            dispatch(getCurrentUserSuccess(response));
        });
    };
}