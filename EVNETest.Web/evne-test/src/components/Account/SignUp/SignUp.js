import React from "react";
import { Row, Col, Input, Button } from "antd";
import { connect } from "react-redux";
import { signUp } from "../../../redux/actions/accountActions";

class SignUp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: "",
            password: "",
            confirmPassword: ""
        };
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSignUp(event) {
        if (this.state.email && this.state.password && this.state.password == this.state.confirmPassword) {
            this.props.signUp({
                Email: this.state.email,
                Password: this.state.password
            });
        }
    }

    render() {
        return (
            <Col span={8} offset={8}>
                <Row justify="center">
                    <h1>Sign Up</h1>
                </Row>
                <Row justify="center">
                    <Col>
                        <Input placeholder="Email"
                            name="email"
                            value={this.state.email}
                            onChange={event => this.handleChange(event)}></Input>
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
                        <Input.Password placeholder="Confirm password"
                            name="confirmPassword"
                            value={this.state.confirmPassword}
                            onChange={event => this.handleChange(event)}></Input.Password>
                    </Col>
                </Row>
                <Row justify="center">
                    <Col>
                        <Row justify="space-between">
                            <Col>
                                <Button type="primary" onClick={(event => this.handleSignUp(event))}>Sign up</Button>
                            </Col>
                        </Row>
                    </Col>
                </Row>
            </Col>
        );
    }
}

export default connect(state => { return {}; }, dispatch => {
    return {
        signUp: (signUpModel) => dispatch(signUp(signUpModel))
    };
})(SignUp)