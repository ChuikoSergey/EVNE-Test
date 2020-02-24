import axios from "axios";
import { getCurrentUser } from "./userActions";

export const SIGN_IN_PENDING = "SIGN_IN_PENDING";
export const SIGN_IN_SUCCESS = "SIGN_IN_SUCCESS";
export const SIGN_IN_ERROR = "SIGN_IN_ERROR";

const signInBegin = () => { return { type: SIGN_IN_PENDING } };
const signInSuccess = (token) => { return { type: SIGN_IN_SUCCESS, token } };

export function signIn(signInModel) {
    // const history = useHistory();
    return dispatch => {
        dispatch(signInBegin());
        axios({
            method: "post",
            url: "/account/signIn",
            data: signInModel
        }).then(response => {
            axios.defaults.common['Authorization'] = response.token;
            dispatch(signInSuccess(response.token));
            dispatch(getCurrentUser())
        });
    }
}

export const SIGN_UP_PENDING = "SIGN_UP_PENDING";
export const SIGN_UP_SUCCESS = "SIGN_UP_SUCCESS";
export const SIGN_UP_ERROR = "SIGN_UP_ERROR";

const signUpBegin = () => { return { type: SIGN_UP_PENDING } };
const signUpSuccess = () => { return { type: SIGN_UP_SUCCESS } };

export function signUp(signUpModel) {
    // const history = useHistory();
    return dispatch => {
        dispatch(signUpBegin());
        axios({
            method: "post",
            url: "/account/signUp",
            data: signUpModel,
            headers: {
                "Access-Control-Allow-Origin": "*",
                'Access-Control-Allow-Methods': '*',
                'Access-Control-Allow-Headers': '*',
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(response => {
            axios.defaults.common['Authorization'] = response.token;
            dispatch(signUpSuccess());
            // history.push("/account/signIn");
        });
    };
}