import React, { Component } from 'react';
import Chatroom from "../Chatroom";


class Mentalhealth extends Component {
    render() {
        return (
           <Chatroom endPointUrl="mental_health" welcomeMessage="Welcome to buckeyebot! What mental health issues can I help with?"/>
        );
    }
}

export default Mentalhealth;
