import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

import * as PokedexService from '../services/pokedexService';

const url = "http://pokedream.com"

class pokemonImg extends Component {

    state = {
        pokedexSearchName: '',
        pokemonName: "",
        pokemonImg: "",
        pokemonImgFront: "",
        pokemonImgBack: "",
        pokemonTypes: "",
        pokemonStats: "",
        pokemonHeight: "",
        pokemonWeight: "",
        pokemonId: "",
        pokemonStatAttack: "",
        pokemonStatDefense: "",
        pokemonStatHp: "",
        pokemonStatSpAttack: "",
        pokemonStatSpDefense: "",
        pokemonStatSpeed: "",
        pokemonStatTotal: "",
        pokemonDescription: ""
    }

    handlePokedexSearch = (e) => {
        this.setState({ pokedexSearchName: e.target.value });
    }

    getPokemonData = () => {
        const pokemonName = this.state.pokedexSearchName;

        PokedexService.getByName(pokemonName)
            .then(
            resp => {
                console.log(resp);
                this.setState(
                    {
                        pokemonName: resp.data.pokemonName,
                        pokemonImg: resp.data.pokemonImage,
                        pokemonImgFront: resp.data.pokemonImageSFront,
                        pokemonImgBack: resp.data.pokemonImageSBack,
                        pokemonTypes: resp.data.pokemonType,
                        pokemonStatAttack: resp.data.statAttack,
                        pokemonStatDefense: resp.data.statDefense,
                        pokemonStatHp: resp.data.statHp,
                        pokemonStatSpAttack: resp.data.statSpAttack,
                        pokemonStatSpDefense: resp.data.statSpDefense,
                        pokemonStatSpeed: resp.data.statSpeed,
                        pokemonStatTotal: resp.data.statTotal,
                        pokemonHeight: resp.data.pokemonHeight,
                        pokemonWeight: resp.data.pokemonWeight,
                        pokemonId: resp.data.pokemonId,
                        pokemonDescription: resp.data.pokemonDescription,
                    },
                );
                this.props.callbackFromData(this.state);
            },
            err => {
                console.log(err);
            }
            )
    }

    render() {
        return (
            <div>
                <Grid>
                    <Row className="show-grid">
                        <Col xs={12} sm={4} md={4} lg={6}>
                            <img className="pokedexImgThree" src={url + this.props.img} alt="" width="200" height="200" />
                        </Col>
                        <Col xs={12} sm={8} md={8} lg={6} >
                            <h3>{this.props.id}</h3>
                            <h1>{this.props.name.toUpperCase()}</h1>
                        </Col>
                    </Row>
                    <Row className="show-grid">
                        <Col xs={12} md={12}>
                            <h5>{'"' + this.props.description + '"'}</h5>
                        </Col>
                        <Col xs={12} md={12}>
                            <input type="text" placeholder="Search" value={this.state.value} onChange={this.handlePokedexSearch}/>
                            <input type="submit" value="+" onClick={this.getPokemonData}/>
                        </Col>
                    </Row>
                </Grid>
            </div>
        )
    }

}

export default pokemonImg