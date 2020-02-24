import React from "react";
import { Row, Col, Input, Button } from "antd";
import { connect } from "react-redux";
import { signIn } from "../../../redux/actions/accountActions";
import { Link } from "react-router-dom";

class SignIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: "",
            password: ""
        };
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSignIn(event) {
        if (this.state.email && this.state.password) {
            this.props.signIn({
                Email: this.state.email,
                Password: this.state.Password
            });
        }
    }

    render() {
        return (
            <Row>
                <Col span={8} offset={8}>
                    <Row justify="center" align="middle">
                        <h1>Login</h1>
                    </Row>
                    <Row justify="center">
                        <Col>
                            <Input placeholder="Email"
                                name="email"
                                value={this.state.email}
                                onChange={event => this.handleEmailChange(event)}></Input>
                        </Col>
                    </Row>
                    <Row justify="center">
                        <Col>
                            <Input.Password placeholder="Password"
                                name="password"
                                value={this.state.password}
                                onChange={event => this.handleChange(event)}></Input.Password>
                        </Col>
                    </Row>
                    <Row justify="center">
                        <Col>
                            <Row justify="space-between" type="flex">
                                <Col>
                                    <Button type="primary"><Link to="/account/signup">Sign up</Link></Button>
                                </Col>
                                <Col>
                                    <Button onClick={(event) => this.handleSignIn(event)}>Sign in</Button>
                                </Col>
                            </Row>
                        </Col>
                    </Row>
                </Col>
            </Row>
        );
    }
}

export default connect(props => { return {}; }, dispatch => {
    return {
        signIn: (signInModel) => dispatch(signIn(signInModel))
    }
})(SignIn)