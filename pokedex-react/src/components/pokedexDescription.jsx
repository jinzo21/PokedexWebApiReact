import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

const url = "http://pokedream.com"

class pokedexDescription extends Component {

    render() {
        
        return (
            <Grid>
                <Row>
                    <Col sm={12} md={6} lg={6}>
                        <h2>TYPE</h2>
                        <h3>{this.props.types}</h3>
                        <img src={url + this.props.imgFront} alt="" />
                        <img src={url + this.props.imgBack} alt="" />
                    </Col>
                    <Col sm={12} md={6} lg={6}>
                        <h2>HEIGHT</h2>
                        <h3>{this.props.height}</h3>
                        <h2>WEIGHT</h2>
                        <h3>{this.props.weight}</h3>
                    </Col>
                </Row>
            </Grid>
        )
    }
}


export default pokedexDescription