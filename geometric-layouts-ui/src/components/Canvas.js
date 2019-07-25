import React, { Component } from 'react';
import InfoHeader from './InformationHeader';
import VertexSearchForm from './VertexSearchForm';

class Canvas extends Component {
  constructor(props) {
    super(props);
    this.state = { inspectedTriangleId: "",
                   inspectedTriangleVertices: "",
                   showVertexSearchForm: false };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleRenderBtnSubmit.bind(this);
    this.inspectTriangle = this.inspectTriangle.bind(this);
    this.toggleVertexSearch = this.toggleVertexSearch.bind(this);
  }

  renderTriangles() {
    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    const scale = 10;

    this.props.triangles.map(
      triangle => (
        ctx.beginPath(),
        ctx.moveTo(
          triangle.v1.split(",")[0] * scale,
          triangle.v1.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v2.split(",")[0] * scale,
          triangle.v2.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v3.split(",")[0] * scale,
          triangle.v3.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v1.split(",")[0] * scale,
          triangle.v1.split(",")[1] * scale
        ),
        (ctx.fillStyle = "#5B9BD5"),
        ctx.fill(),
        (ctx.lineWidth = 1),
        (ctx.strokeStyle = "white"),
        ctx.stroke(),
        (ctx.textBaseline = "top"),
        (ctx.fillStyle = "white"),
        (ctx.font = scale + 8 + "px Arial"),
        ctx.fillText(
          triangle.id,
          triangle.centroid.split(",")[0] * scale,
          triangle.centroid.split(",")[1] * scale
        )
      )
    );
  }

  inspectTriangle(triangleId) {

    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    const scale = 10;

    if(triangleId == null)
      triangleId = 'None';

    var uninspectedTriangles = this.props.triangles.filter(function(triangle) {
      return triangle.id != triangleId;
    });

    uninspectedTriangles.map(
      triangle => (
        ctx.beginPath(),
        ctx.moveTo(
          triangle.v1.split(",")[0] * scale,
          triangle.v1.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v2.split(",")[0] * scale,
          triangle.v2.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v3.split(",")[0] * scale,
          triangle.v3.split(",")[1] * scale
        ),
        ctx.lineTo(
          triangle.v1.split(",")[0] * scale,
          triangle.v1.split(",")[1] * scale
        ),
        (ctx.fillStyle = "grey"),
        ctx.fill(),
        (ctx.lineWidth = 1),
        (ctx.strokeStyle = "white"),
        ctx.stroke(),
        (ctx.textBaseline = "top"),
        (ctx.fillStyle = "darkgrey"),
        (ctx.font = scale + 5 + "px Arial"),
        ctx.fillText(
          triangle.id,
          triangle.centroid.split(",")[0] * scale,
          triangle.centroid.split(",")[1] * scale
        )
      )
    );


    if(triangleId != 'None')
    {
      var triangleToInspect = this.props.triangles.filter(function(triangle) {
        return triangle.id == triangleId;
      });

      triangleToInspect.map(
        triangle => (
          ctx.beginPath(),
          ctx.moveTo(
            triangle.v1.split(",")[0] * scale,
            triangle.v1.split(",")[1] * scale
          ),
          ctx.lineTo(
            triangle.v2.split(",")[0] * scale,
            triangle.v2.split(",")[1] * scale
          ),
          ctx.lineTo(
            triangle.v3.split(",")[0] * scale,
            triangle.v3.split(",")[1] * scale
          ),
          ctx.lineTo(
            triangle.v1.split(",")[0] * scale,
            triangle.v1.split(",")[1] * scale
          ),
          (ctx.fillStyle = "#5B9BD5"),
          ctx.fill(),
          (ctx.lineWidth = 2),
          (ctx.strokeStyle = "yellow"),
          ctx.stroke(),
          (ctx.textBaseline = "top"),
          (ctx.fillStyle = "white"),
          (ctx.font = scale + 10 + "px sans-serif"),
          ctx.fillText(
            triangle.id,
            triangle.centroid.split(",")[0] * scale,
            triangle.centroid.split(",")[1] * scale
          )
        )
      );
    }

    if(triangleId=='None')
    {
      this.setState({ inspectedTriangleId: "None" });
      this.setState({ inspectedTriangleVertices: "" });
      return;
    }

    this.drawVertexCoordinares(triangleId);
  }

  drawVertexCoordinares(triangleId) {
    var triangleToInspect = this.props.triangles.filter(function(triangle) {
      return triangle.id == triangleId;
    });
    this.setState({ inspectedTriangleId: triangleToInspect[0].id });
    this.setState({ inspectedTriangleVertices: triangleToInspect[0].verticesToString });
  }

  toggleVertexSearch()
  {
    this.setState({ showVertexSearchForm: !this.state.showVertexSearchForm });
  }


  handleChange(event) {
    const canvas = this.refs.canvas;
    const ctx = canvas.getContext("2d");
    ctx.clearRect(0, 0, ctx.width, ctx.height);
    this.inspectTriangle(event.target.value);
  }

  handleRenderBtnSubmit(event) {
    this.setState({ inspectedTriangleId: "" });
    this.setState({ inspectedTriangleVertices: "" });
    this.renderTriangles();
    event.preventDefault();
  }

  render() {
    if (!this.props.triangles) {
      return <div>Loading...</div>;
    } else {
      return (
        <div>
          <br></br>
          <form onSubmit={this.handleSubmit}>
          <input type="submit" value="Render Full Layout" className="myButton" />
            <label>
              Inspect Triangle:
              </label>
              <select
                value={this.state.inspectedTriangleId}
                onChange={this.handleChange}>

                <option value="None"> None </option>
                {this.props.triangles.map(triangleOption => (
                  <option key={triangleOption.id} value={triangleOption.id}>
                    {" "}
                    {triangleOption.id}{" "}
                  </option>
                ))}
              </select>
          </form>
          
          {/* Search toggle button*/}
          <input type="submit" value="Search Vertex Coordinates" className="myButton" onClick={this.toggleVertexSearch} /> <br></br>
          
          {/* Render vertex search form if the state has been toggled*/}
          { this.state.showVertexSearchForm ? <VertexSearchForm inspectTriangle={this.inspectTriangle} ></VertexSearchForm> : null }
          
          {/* Render inspected shape certices if there is one */}
          { this.state.inspectedTriangleVertices != "" ? <InfoHeader title={this.state.inspectedTriangleVertices} /> : <br></br> }

          <div style={{ width: "600px", float: "none" }}>
          </div>
          <canvas ref="canvas" width={600} height={600}>
            Error: Browser not supported!
          </canvas>
        </div>
      );
    }
  }
}

export default Canvas;
