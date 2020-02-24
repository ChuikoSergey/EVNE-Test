import React from 'react';
import { Route, Switch, useRouteMatch, useHistory } from 'react-router-dom';
import NotFound from '../NotFound/NotFound'
import { connect } from 'react-redux';
import SignIn from './SignIn/SignIn';
import SignUp from './SignUp/SignUp';

const mapStateToProps = store => ({
    currentUser: store.current != null ? store.current.user : null
});

class AccountRoute extends React.Component {
    constructor(props){
        super(props);
    }

    componentDidMount() {
        const history = this.props.history;
        if(this.props.currentUser){
            history.push("/home");
        }        
    }

    render() {
        return (
            <Switch>
                <Route path={`${this.props.match.path}/signin`} component={SignIn}/>
                <Route path={`${this.props.match.path}/signup`} component={SignUp}/>
                <Route path={`${this.props.match.path}/forgot`}/>
                <Route path="*" component={NotFound} />
            </Switch>
        );
    }
}

export default connect(mapStateToProps)(AccountRoute);