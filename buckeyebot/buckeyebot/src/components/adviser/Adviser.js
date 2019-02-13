import React, { Component } from 'react';
import Chatroom from "../Chatroom";


class Adviser extends Component {
    render() {
        return (
           <Chatroom endPointUrl="advising" welcomeMessage="Welcome to buckeyebot! What advising issues are you having?"/>
        );
    }
}

export default Adviser;
