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
        isLoading: ""
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
                        pokemonName: resp.data.PokemonName,
                        pokemonImg: resp.data.PokemonImage,
                        pokemonImgFront: resp.data.PokemonImageSFront,
                        pokemonImgBack: resp.data.PokemonImageSBack,
                        pokemonTypes: resp.data.PokemonType,
                        pokemonStatAttack: resp.data.StatAttack,
                        pokemonStatDefense: resp.data.StatDefense,
                        pokemonStatHp: resp.data.StatHp,
                        pokemonStatSpAttack: resp.data.StatSpAttack,
                        pokemonStatSpDefense: resp.data.StatSpDefense,
                        pokemonStatSpeed: resp.data.StatSpeed,
                        pokemonStatTotal: resp.data.StatTotal,
                        pokemonHeight: resp.data.PokemonHeight,
                        pokemonWeight: resp.data.PokemonWeight,
                        pokemonId: resp.data.PokemonId,
                        pokemonDescription: resp.data.PokemonDescription,
                    },
                );
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
                        <Col xs={12} md={12}>
                            <div className="statSpacing">
                                <input className="arrow-left" />
                                <input className="inputPosition" type="text" placeholder="Search" value={this.state.value} onChange={this.handlePokedexSearch} />
                                <input className="inputPosition" type="submit" value="+" onClick={this.getPokemonData} />
                                <input className="arrow-right" />
                            </div>
                        </Col>
                    </Row>
                </Grid>
            </div>
        )
    }
}

export default pokedexSearch;