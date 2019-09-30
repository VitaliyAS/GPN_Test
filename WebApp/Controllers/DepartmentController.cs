using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataProviders;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly DepartmentProvider departmentProvider;
        public DepartmentController()
        {
            departmentProvider = new DepartmentProvider();
        }

        // GET: api/Department
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(departmentProvider.GetAll());
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(long id)
        {
            Department department = departmentProvider.Get(id);
            if (department == null)
                return NotFound();
            else
                return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] Department value)
        {
            long res = departmentProvider.Add(value);
            if (res == 0)
                return BadRequest();
            else
                return Ok(res);
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, [FromBody] Department value)
        {
            value.Id = id;
            if (departmentProvider.Set(value))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (departmentProvider.Del(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
