using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeometricLayouts.Interfaces;
using GeometricLayouts.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeometricLayouts.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TriangleLayoutController : Controller
    {
        private readonly TriangleLayout _layoutUtility;

        public TriangleLayoutController()
        {
            _layoutUtility = new TriangleLayout(6, 12, 10);
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<IShape> Get()
        {
            return _layoutUtility.GenerateLayout();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var triangle = (Triangle)_layoutUtility.GenerateShapeFromId(id);
            if (triangle == null)
                return NotFound();
            else
                return Ok(triangle);
        }

        [HttpGet]
        public ActionResult FromVertex([FromQuery]int v1X, [FromQuery]int v1Y, [FromQuery]int v2X, [FromQuery]int v2Y, [FromQuery]int v3X, [FromQuery]int v3Y)
        {
            string triangleId = _layoutUtility.GetShapeIdFromVertexCoordinates(v1X, v1Y, v2X, v2Y, v3X, v3Y);
            if (triangleId == "")
                return NotFound();
            else
                return Ok(triangleId);
        }
    }
}
