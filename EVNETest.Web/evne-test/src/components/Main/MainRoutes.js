import React from 'react';
import { Route, Switch, useHistory } from 'react-router-dom';
import NotFound from '../NotFound/NotFound';
import { connect } from 'react-redux';

const mapStateToProps = store => ({
    currentUser: store.current != null ? store.current.user : null
});

class MainRoute extends React.Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        // const history = useHistory();
        if(!this.props.currentUser) {
            // history.push("/account/signin");
        }
    }

    render() {
        return (
            <Switch>
                <Route path="*" component={NotFound}/>
            </Switch>
        );
    }
}

export default connect(mapStateToProps)(MainRoute);