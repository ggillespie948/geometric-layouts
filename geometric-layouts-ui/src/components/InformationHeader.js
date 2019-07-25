import React, { Component } from 'react';

export default class Header extends Component {
  constructor(props) {
    super(props);
    this.state = { title: ''};
  }

  render() {
    return (
      <header >
        <h3> <span className="infoHeader">{this.props.title}</span></h3>
      </header>
    );
  }
}



