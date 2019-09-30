using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataProviders;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/Borehole")]
    [ApiController]
    public class BoreholeController : ControllerBase
    {
        readonly BoreholeProvider BoreholeProvider;
        public BoreholeController()
        {
            BoreholeProvider = new BoreholeProvider();
        }

        // GET: api/Borehole
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(BoreholeProvider.GetAll());
        }

        // GET: api/Borehole/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(long id)
        {
            Borehole borehole = BoreholeProvider.Get(id);
            if (borehole == null)
                return NotFound();
            else
                return Ok(borehole);
        }

        // POST: api/Borehole
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] Borehole value)
        {
            long res = BoreholeProvider.Add(value);
            if (res == 0)
                return BadRequest();
            else
                return Ok(res);
        }

        // PUT: api/Borehole/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, [FromBody] Borehole value)
        {
            value.Id = id;
            if (BoreholeProvider.Set(value))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Borehole/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (BoreholeProvider.Del(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}

