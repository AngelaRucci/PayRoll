import React, { Component } from 'react';
import { BrowserRouter, Route} from 'react-router-dom';
import Home from './components/home/Home'
import Books from "./components/books/Books";
import Adviser from "./components/adviser/Adviser";
import Activites from "./components/activites/Activites";
import Mentalhealth from "./components/mental-health/Mentalhealth";


class App extends Component {
  render() {
    return (
        <BrowserRouter>
          <div>
              <Route path="/books" component={Books}/>
              <Route path="/adviser" component={Adviser}/>
              <Route path="/mental-health" component={Mentalhealth}/>
              <Route path="/activites" component={Activites}/>
              <Route path="/" component={Home} exact/>
          </div>
        </BrowserRouter>
    );
  }
}

export default App;
