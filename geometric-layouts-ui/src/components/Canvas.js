import React, { Component } from 'react';

class App extends Component {
componentDidUpdate(){
    this.renderTriangles();
}

renderTriangles() {
    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    const scale = 10;

    this.props.triangles.map(triangle => (
        ctx.beginPath(),
        ctx.moveTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
        ctx.lineTo(triangle.v2.split(",")[0] * scale, triangle.v2.split(",")[1] * scale),
        ctx.lineTo(triangle.v3.split(",")[0] * scale, triangle.v3.split(",")[1] * scale),
        ctx.lineTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
        (ctx.fillStyle = "#4397AC"),
        ctx.fill(),
        ctx.lineWidth = 1,
        ctx.strokeStyle="white",
        ctx.stroke(),
        ctx.textBaseline = "top",
        ctx.fillStyle = "white",
        ctx.font = scale+5+"px Arial",
        ctx.fillText(
          triangle.id,
          triangle.centroid.split(",")[0]*scale,
          triangle.centroid.split(",")[1]*scale
        )
      )
    );
  }

  render() {
    if (!this.props.triangles) {
      return <div>Loading...</div>;
    } else {
        return (
        <div>
          <h2>Triangle Layout</h2>
          <canvas ref="canvas" width={600} height={600}>
            Error: Browser not supported!
          </canvas>
        </div>
      );
    }
  }
}

export default App;
