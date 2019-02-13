import React, { Component } from 'react';
import Chatroom from "../Chatroom";


class Activites extends Component {
    render() {
        return (
           <Chatroom endPointUrl="activities" welcomeMessage="Welcome to buckeyebot! What activites are you interested in?"/>
        );
    }
}

export default Activites;
