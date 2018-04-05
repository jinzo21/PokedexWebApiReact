import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

class pokemonStats extends Component {

    componentDidMount() {
        document.querySelector(".hp").style.width = (this.props.hp / 2) + "%";
        document.querySelector(".speed").style.width = (this.props.speed / 2) + "%";
        document.querySelector(".defense").style.width = (this.props.defense / 2) + "%";
        document.querySelector(".spDefense").style.width = (this.props.spDefense / 2) + "%";
        document.querySelector(".attack").style.width = (this.props.attack / 2) + "%";
        document.querySelector(".spAttack").style.width = (this.props.spAttack / 2) + "%";
    }

    render() {
        return (

            <Grid>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>HP</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills hp">{this.props.hp}</div>
                            </div>
                            <div>
                                <img src={require("../images/health.png")} alt="" width="30" height="30" />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>ATTACK</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills attack">{this.props.attack}</div>
                            </div>
                            <div>
                                <img src={require("../images/attack.png")} alt="" width="30" height="30" />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>SPECIAL ATTACK</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills spAttack">{this.props.spAttack}</div>
                            </div>
                            <div>
                                {/*<img src={require("..images/attackSp.png")} alt="" width="30" height="30" />*/}
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>DEFENSE</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills defense">{this.props.defense}</div>
                            </div>
                            <div>
                                <img src={require("../images/defense.png")} alt="" width="30" height="30" />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>SPECIAL DEFENSE</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills spDefense">{this.props.spDefense}</div>
                            </div>
                            <div>
                                <img src={require("../images/defenseSp.png")} alt="" width="30" height="30" />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h2>SPEED</h2>
                        <div className="statSpacing">
                            <div className="skillsContainer">
                                <div className="skills speed">{this.props.speed}</div>
                            </div>
                            <div>
                                <img src={require("../images/speed.png")} alt="" width="30" height="30" />
                            </div>
                        </div>
                    </Col>
                </Row>
                <Row>
                    <Col sm={12} md={12} lg={12}>
                        <h1 class="total">Total: {this.props.total}</h1>
                    </Col>
                </Row>
            </Grid>

        )
    }
}

export default pokemonStats