using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataProviders;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/Field")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        readonly FieldProvider FieldProvider;
        public FieldController()
        {
            FieldProvider = new FieldProvider();
        }

        // GET: api/Field
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(FieldProvider.GetAll());
        }

        // GET: api/Field/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(long id)
        {
            Field field = FieldProvider.Get(id);
            if (field == null)
                return NotFound();
            else
                return Ok(field);
        }

        // POST: api/Field
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] Field value)
        {
            long res = FieldProvider.Add(value);
            if (res == 0)
                return BadRequest();
            else
                return Ok(res);
        }

        // PUT: api/Field/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, [FromBody] Field value)
        {
            value.Id = id;
            if (FieldProvider.Set(value))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Field/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (FieldProvider.Del(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
