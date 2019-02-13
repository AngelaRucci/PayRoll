import React, { Component } from 'react';
import Chatroom from "../Chatroom";


class Books extends Component {
    render() {
        return (
           <Chatroom endPointUrl="books" welcomeMessage="Welcome to buckeyebot! What book are you looking for?"/>
        );
    }
}

export default Books;
