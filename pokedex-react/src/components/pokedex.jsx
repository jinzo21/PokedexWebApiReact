import React, { Component } from 'react';
import PokedexSearch from './pokedexSearch';
import PokedexData from './pokedexData';


class pokedex extends Component {
    state = {
        dataFromResponse: null,
    }

    //Takes in Data from Child and puts into State
    handlePokedexData = (dataFromChild) => {
        this.setState({ dataFromResponse: dataFromChild });
    }

    render() {
        if (this.state.dataFromResponse == null) {
            return (
                <div className="App">
                    <PokedexSearch callbackFromParent={this.handlePokedexData} />
                </div>
            )
        } else {
            return (
                <div className="App">
                    debugger
                    <PokedexData callbackFromResponse={this.state} />
                </div>
            )
        }
    }
}

export default pokedex