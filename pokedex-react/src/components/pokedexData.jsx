import React, { Component } from 'react';
import Description from './pokedexDescription';
import Image from './pokedexImg';
import Stats from './pokedexStats';

class pokedexData extends Component {

    state = {
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

    pokeBall = () => {
        this.setState({ isLoading: false })
    }

    handlePokedexData = (datafromSearch) => {
        let pokemon = datafromSearch;
        this.setState(
            {
                pokemonName: pokemon.pokemonName,
                pokemonImg: pokemon.pokemonImg,
                pokemonImgFront: pokemon.pokemonImgFront,
                pokemonImgBack: pokemon.pokemonImgBack,
                pokemonTypes: pokemon.pokemonTypes,
                pokemonStats: pokemon.pokemonStats,
                pokemonHeight: pokemon.pokemonHeight,
                pokemonWeight: pokemon.pokemonWeight,
                pokemonId: pokemon.pokemonId,
                pokemonStatAttack: pokemon.pokemonStatAttack,
                pokemonStatDefense: pokemon.pokemonStatDefense,
                pokemonStatHp: pokemon.pokemonStatHp,
                pokemonStatSpAttack: pokemon.pokemonStatSpAttack,
                pokemonStatSpDefense: pokemon.pokemonStatSpDefense,
                pokemonStatSpeed: pokemon.pokemonStatSpeed,
                pokemonStatTotal: pokemon.pokemonStatTotal,
                pokemonDescription: pokemon.pokemonDescription,
                isLoading: true
            }
        );
    }

    //UPDATE State on new data coming in from props (of parent)
    componentWillMount() {
        let pokemon = this.props.callbackFromResponse.dataFromResponse;
        this.setState(
            {
                pokemonName: pokemon.pokemonName,
                pokemonImg: pokemon.pokemonImg,
                pokemonImgFront: pokemon.pokemonImgFront,
                pokemonImgBack: pokemon.pokemonImgBack,
                pokemonTypes: pokemon.pokemonTypes,
                pokemonStats: pokemon.pokemonStats,
                pokemonHeight: pokemon.pokemonHeight,
                pokemonWeight: pokemon.pokemonWeight,
                pokemonId: pokemon.pokemonId,
                pokemonStatAttack: pokemon.pokemonStatAttack,
                pokemonStatDefense: pokemon.pokemonStatDefense,
                pokemonStatHp: pokemon.pokemonStatHp,
                pokemonStatSpAttack: pokemon.pokemonStatSpAttack,
                pokemonStatSpDefense: pokemon.pokemonStatSpDefense,
                pokemonStatSpeed: pokemon.pokemonStatSpeed,
                pokemonStatTotal: pokemon.pokemonStatTotal,
                pokemonDescription: pokemon.pokemonDescription,
                isLoading: true
            }
        );
    }

    render() {
        if (this.state.isLoading === true) {
            return (
                <div className="center-on-page">
                    <div className="pokeball">
                        <div className="pokeball__button"></div>
                    </div>
                    {setTimeout(this.pokeBall, 4000)}
                </div>
            )
        } else {
            return (
                <div>
                    <div className="pokedexBack">
                        <div className="show-grid">
                            <div xs={12} md={12} className="pokedexImg">
                                <div className="pokedexImgTwo">
                                    <Image img={this.state.pokemonImg} name={this.state.pokemonName} id={this.state.pokemonId} description={this.state.pokemonDescription} callbackFromData={this.handlePokedexData}/>
                                </div>
                            </div>
                        </div>
                        <div className="show-grid">
                            <div xs={12} md={12} className="pokedexDescription">
                                <div className="pokedexDescriptionTwo">
                                    <Description height={this.state.pokemonHeight} weight={this.state.pokemonWeight} types={this.state.pokemonTypes} imgFront={this.state.pokemonImgFront} imgBack={this.state.pokemonImgBack} />
                                </div>
                            </div>
                        </div>
                        <div className="show-grid">
                            <div xs={12} md={12} className="pokedexStats">
                                <div className="pokedexStatsTwo">
                                    <Stats attack={this.state.pokemonStatAttack} defense={this.state.pokemonStatDefense} hp={this.state.pokemonStatHp} spAttack={this.state.pokemonStatSpAttack} spDefense={this.state.pokemonStatSpDefense} speed={this.state.pokemonStatSpeed} total={this.state.pokemonStatTotal} />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            )
        }
    }
}
export default pokedexData