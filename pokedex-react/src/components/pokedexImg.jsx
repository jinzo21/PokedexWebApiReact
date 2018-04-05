import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

const url = "http://pokedream.com"

class pokemonImg extends Component {

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
                            <input type="text" placeholder="Search" />
                            <input type="submit" value="+" />
                        </Col>
                    </Row>
                </Grid>
            </div>
        )
    }

}

export default pokemonImg