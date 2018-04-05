import React, { Component } from 'react';
import './App.css';
import Pokedex from './components/pokedex';

class App extends Component {
  render() {
    
    return (
      <div className="backgroundImg">
        <Pokedex />
      </div>
    );
  }
}

export default App;
