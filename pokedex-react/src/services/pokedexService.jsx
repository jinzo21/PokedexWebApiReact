import * as axios from 'axios';

export function getAll(pokemonName) {
    const url = 'https://pokeapi.co/api/v2/pokemon/' + pokemonName

    return axios.get(url);
}

export function getByName(pokemonName) {
    const url = "http://localhost:63468/pokemon/" + pokemonName

    return axios.get(url);
}