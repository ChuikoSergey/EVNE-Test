import { GET_CURRENT_USER_PENDING, GET_CURRENT_USER_SUCCESS } from "../actions/userActions";

function userReducer(state = { isLoading: false }, action) {
    switch (action.type) {
        case GET_CURRENT_USER_SUCCESS: {
            return Object.assign({}, state, { isLoading: true });
        }
        case GET_CURRENT_USER_SUCCESS: {
            return Object.assign({}, state, { isLoading: false, current: Object.assign({}, state.current, action.user)} );
        }
        default: {
            return state;
        }
    }
}

export default userReducer;