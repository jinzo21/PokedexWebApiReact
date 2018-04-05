import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

import * as PokedexService from '../services/pokedexService';

class pokedexSearch extends Component {
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
        pokemonDescription: "",
    }

    handlePokedexSearch = (e) => {
        this.setState({ pokedexSearchName: e.target.value });
    }

    getPokemonData = () => {
        const pokemonName = this.state.pokedexSearchName;
        console.log("searched pokemon: " + pokemonName);

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
                this.props.callbackFromParent(this.state);
            },
            err => {
                console.log(err);
            }
            )
    }

    render() {
        return (
            <div className="showcase">
                <Grid>
                    <Row className="show-grid">
                        <Col xs={12} md={12}>
                            <input className="inputPosition" type="text" placeholder="Search" value={this.state.value} onChange={this.handlePokedexSearch} />
                            <input className="inputPosition" type="submit" value="+" onClick={this.getPokemonData} />
                        </Col>
                    </Row>
                </Grid>
            </div>
        )

    }
}

export default pokedexSearch;