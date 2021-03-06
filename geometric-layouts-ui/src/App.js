import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from "axios";
import Canvas from "./components/Canvas";

class App extends Component {
  state = {
    triangles: []
  };
  
  componentDidMount() {
    axios
      .get("https://localhost:44382/api/trianglelayout/get", { crossdomain: true }) //note: local host port may differ
      .then(data => {
        this.setState({triangles: data.data}); 
        console.log(this.state.triangles);

      }).catch(function(error) {
        console.log("Error fetching data form api: " + error.data)
      })
  }
  
  render() {

    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Geometric Layouts</h2>
        </div>
        <Canvas triangles={this.state.triangles} />
      </div>
    );
  }
}

export default App;
