using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DB;

namespace WebApp.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly CompanyProvider companyProvider;
        public CompanyController()
        {
            companyProvider = new CompanyProvider();
        }

        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return companyProvider.GetAll();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Get(long id)
        {
            Company company = companyProvider.Get(id);
            if (company == null)
                return NotFound();
            else
                return Ok(company);
        }

        // POST: api/Company
        [HttpPost]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] Company value)
        {
            long res = companyProvider.Add(value);
            if (res == 0)
                return BadRequest();
            else
                return Ok(res);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, [FromBody] Company value)
        {
            value.id = id;
            if (companyProvider.Set(value))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (companyProvider.Del(id))
                return Ok();
            else
                return BadRequest();
        }
    }

    [Produces(MediaTypeNames.Application.Json)]
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
        public IEnumerable<Department> Get()
        {
            return departmentProvider.GetAll();
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
            value.id = id;
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

    [Produces(MediaTypeNames.Application.Json)]
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
        public IEnumerable<Field> Get()
        {
            return FieldProvider.GetAll();
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
            value.id = id;
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

    [Produces(MediaTypeNames.Application.Json)]
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
        public IEnumerable<Borehole> Get()
        {
            return BoreholeProvider.GetAll();
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
            value.id = id;
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
