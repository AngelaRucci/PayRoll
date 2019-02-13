import React, { Component } from 'react';
import './home.css';

class Home extends Component {
    render() {
        return (
           <div className="row">
               <div className="card col-md-3" >
                   <img className="card-img-top" src={require('../../images/books.png')} alt="Card image cap"/>
                   <div className="card-body">
                       <h5 className="card-title">Books</h5>
                       <p className="card-text">Talk to buckeye bot to find the books you need</p>
                       <a href="/books" className="btn btn-primary">Books</a>
                   </div>
               </div>
               <div className="card col-md-3" >
                   <img className="card-img-top" src={require('../../images/desk.png')} alt="Card image cap"/>
                   <div className="card-body">
                       <h5 className="card-title">Advising</h5>
                       <p className="card-text">Need help with advising? Buckeyebot is here to help!</p>
                       <a href="/adviser" className="btn btn-primary">Advising</a>
                   </div>
               </div>
               <div className="card col-md-3" >
                   <img className="card-img-top" src={require('../../images/heart.png')} alt="Card image cap"/>
                   <div className="card-body">
                       <h5 className="card-title">Mental Health</h5>
                       <p className="card-text">Buckeye bot can help guide you to the correct source for your mental needs</p>
                       <a href="/mental-health" className="btn btn-primary">Mental Health</a>
                   </div>
               </div>
               <div className="card col-md-3" >
                   <img className="card-img-top" src={require('../../images/american-football.png')} alt="Card image cap"/>
                   <div className="card-body">
                       <h5 className="card-title">Activities</h5>
                       <p className="card-text">Talk to buckeye bot to find activities nearby</p>
                       <a href="/activites" className="btn btn-primary">Activities</a>
                   </div>
               </div>
           </div>


        );
    }
}

export default Home;
