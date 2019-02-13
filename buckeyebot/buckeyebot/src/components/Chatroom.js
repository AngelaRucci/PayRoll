import React, {Component} from 'react'
import {Launcher} from 'react-chat-window'
import axios from 'axios';

class Chatroom extends Component {

    constructor(props) {
        super(props);
        this.state = {
            endPointUrl: this.props.endPointUrl,
            messageList: [{
                author: 'them',
                type: 'text',
                data: {
                    text: this.props.welcomeMessage
                }
            }]
        };
    }

    _onMessageWasSent(message) {
        console.log(message);
        console.log("Message Sent!");
        this.setState({
            messageList: [...this.state.messageList, message]
        });
        // TODO: We might need to add a header to this post
        // TODO: maybe body isn't being sent up correctly?
        axios.post(`http://127.0.0.1:8000/`+this.state.endPointUrl+"/", { "message": message.data.text})
            .then(res => {
                // TODO: need check if it is a 200
                console.log(res);
                console.log(res.data);
                // TODO: check to make sure that it is returning {"message": ....}
                this._sendMessage(res.data.message)
            });
    }

    // send as buckeye bot
    _sendMessage(text) {
        if (text.length > 0) {
            this.setState({
                messageList: [...this.state.messageList, {
                    author: 'them',
                    type: 'text',
                    data: { text }
                }]
            })
        }
    }

    render() {
        return (<div>
            <Launcher
                agentProfile={{
                    teamName: 'Buckeye Book Bot',
                    imageUrl: 'https://a.slack-edge.com/66f9/img/avatars-teams/ava_0001-34.png'
                }}
                onMessageWasSent={this._onMessageWasSent.bind(this)}
                messageList={this.state.messageList}
                showEmoji
                isOpen
            />
        </div>)
    }
}

export default Chatroom;