import React, { Component } from 'react';

class App extends Component {
componentDidUpdate(){
    //this.renderTriangles();
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

  inspectTriangle(triangleId) {
    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    const scale = 10;

    var uninspectedTriangles = this.props.triangles.filter(function (triangle) {
      return triangle.id != triangleId;
    });

    var triangleToInspect = this.props.triangles.filter(function (triangle) {
      return triangle.id == triangleId;
    });

    uninspectedTriangles.map(triangle => (
        ctx.beginPath(),
        ctx.moveTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
        ctx.lineTo(triangle.v2.split(",")[0] * scale, triangle.v2.split(",")[1] * scale),
        ctx.lineTo(triangle.v3.split(",")[0] * scale, triangle.v3.split(",")[1] * scale),
        ctx.lineTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
        (ctx.fillStyle = "grey"),
        ctx.fill(),
        ctx.lineWidth = 1,
        ctx.strokeStyle="white",
        ctx.stroke(),
        ctx.textBaseline = "top",
        ctx.fillStyle = "darkgrey",
        ctx.font = scale+5+"px Arial",
        ctx.fillText(
          triangle.id,
          triangle.centroid.split(",")[0]*scale,
          triangle.centroid.split(",")[1]*scale
        )
      )
    );
    

    triangleToInspect.map(triangle => (
      ctx.beginPath(),
      ctx.moveTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
      ctx.lineTo(triangle.v2.split(",")[0] * scale, triangle.v2.split(",")[1] * scale),
      ctx.lineTo(triangle.v3.split(",")[0] * scale, triangle.v3.split(",")[1] * scale),
      ctx.lineTo(triangle.v1.split(",")[0] * scale, triangle.v1.split(",")[1] * scale),
      (ctx.fillStyle = "#4397AC"),
      ctx.fill(),
      ctx.lineWidth = 2,
      ctx.strokeStyle="yellow",
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

  this.drawVertexCoordinares(triangleId);

  }
  

  drawVertexCoordinares(triangleId){
    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    const scale = 10;

    var triangleToInspect = this.props.triangles.filter(function (triangle) {
      return triangle.id == triangleId;
    });

    this.setState({ value: triangleToInspect[0].verticesToString });

  }

  constructor(props) {
    super(props);
    this.state = { value: "" };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    
    const canvas = this.refs.canvas;
    const  ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, ctx.width, ctx.height);
    this.inspectTriangle(event.target.value);
  }

  handleSubmit(event) {
    this.setState({ value: "" });
    this.renderTriangles();
    event.preventDefault();
  }


  render() {
    if (!this.props.triangles) {
      return <div>Loading...</div>;
    } else {
        return (
          <div>
            <form onSubmit={this.handleSubmit}>
                <input type="submit" value="Render Full Layout" />
                <br />
              <label>
                Inspect Triangle:
                <select
                  value={this.state.value}
                  onChange={this.handleChange}
                >
                  <option value=""> None </option>
                  {this.props.triangles.map(triangleOption => (
                    <option value={triangleOption.id}>
                      {" "}
                      {triangleOption.id}{" "}
                    </option>
                  ))}
                </select>
              </label>
            </form>
            <h3>
              {this.state.value}
            </h3>
            <canvas ref="canvas" width={600} height={600}>
              Error: Browser not supported!
            </canvas>
          </div>
        );
    }
  }
}

export default App;
