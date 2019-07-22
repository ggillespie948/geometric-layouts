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
    [Route("api/[controller]")]
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
    }
}
