import { SIGN_IN_PENDING, SIGN_IN_SUCCESS, SIGN_IN_ERROR } from "../actions/accountActions";

function accountReducer(state = { isLoading: false }, action) {
    switch (action.type) {
        case SIGN_IN_PENDING: {
            return Object.assign({}, state, { isLoading: true });
        }
        case SIGN_IN_SUCCESS: {
            return Object.assign({}, state, { isLoading: false, token: action.token });
        }
        default: {
            return state;
        }
    }
}

export default accountReducer;