import React, { Component } from 'react'
import axios from "axios";

export default class VertexSearchForm extends Component {
    constructor(props) {
        super(props);
    
        this.state = {
            v1x: null,
            v1y: null,
            v2x: null,
            v2y: null,
            v3x: null,
            v3y: null
        };

        this.processVertexInput = this.processVertexInput.bind(this);
        this.getShapeIdFromVertexCoordinates = this.getShapeIdFromVertexCoordinates.bind(this);
        this.inspectTriangle = this.props.inspectTriangle.bind(this);
    }
    
    processVertexInput(event)
    {
        switch(event.target.id)
        {
            case 'v1':
                    if(event.target.value.length < 3 || !event.target.value.includes(","))
                    {
                        this.props.inspectTriangle();
                        this.setState({ v1x: null });
                        this.setState({ v1y: null });
                        return;
                    }

                    this.setState({ v1x: event.target.value.split(",")[0] }, this.getShapeIdFromVertexCoordinates);
                    this.setState({ v1y: event.target.value.split(",")[1] }, this.getShapeIdFromVertexCoordinates);
                break;

            case 'v2':
                    if(event.target.value.length < 3 || !event.target.value.includes(","))
                    {
                        this.props.inspectTriangle();
                        this.setState({ v2x: null });
                        this.setState({ v2y: null });
                        return;
                    }

                    this.setState({ v2x: event.target.value.split(",")[0] }, this.getShapeIdFromVertexCoordinates);
                    this.setState({ v2y: event.target.value.split(",")[1] }, this.getShapeIdFromVertexCoordinates);
                break;

            case 'v3':
                    if(event.target.value.length < 3 || !event.target.value.includes(","))
                    {
                        this.props.inspectTriangle();
                        this.setState({ v3x: null });
                        this.setState({ v3y: null });
                        return;
                    }

                    this.setState({ v3x: event.target.value.split(",")[0] }, this.getShapeIdFromVertexCoordinates);
                    this.setState({ v3y: event.target.value.split(",")[1] }, this.getShapeIdFromVertexCoordinates);
                break;

            default:
                return;
        }

    }


    allSearchCoordinatesSet()
    {
        if(this.state.v1x !== null && this.state.v1y !== null && this.state.v2x !== null && this.state.v2y !== null && this.state.v3x !== null && this.state.v3y !== null)
            return true;
        else
            return false;
    }

    getShapeIdFromVertexCoordinates()
    {
        if(this.allSearchCoordinatesSet() === false) 
        {
            //inspect none
            this.props.inspectTriangle();
            return;
        }

        let params = {
            v1x: this.state.v1x,
            v1y: this.state.v1y,
            v2x: this.state.v2x,
            v2y: this.state.v2y,
            v3x: this.state.v3x,
            v3y: this.state.v3y
        };

        axios
          .get("https://localhost:44382/api/trianglelayout/fromvertex/", {
            crossdomain: true,
            responsetype:'text',
            params:params
          }) 
          .then(data => {
            if(data.data !== null){
                this.props.inspectTriangle(data.data);
                return;
            } 
          })
          .catch(function(error) {
              //404 or 500
        });
        
    }

    render() {
        return (
            <div>
                <form>
                    <label>
                        V1:
                    </label>
                    <input id="v1" className="inputField" placeholder="v1x, v1y" onChange={this.processVertexInput} maxLength='5' />
                    <label>
                        V2:
                    </label>
                    <input id="v2" className="inputField" placeholder="v2x, v2y" onChange={this.processVertexInput} maxLength='5' />
                    <label>
                        V3:
                    </label>
                    <input id="v3" className="inputField" placeholder="v3x, v3y" onChange={this.processVertexInput} maxLength='5' />
                </form>
            </div>
        );
    }
}
