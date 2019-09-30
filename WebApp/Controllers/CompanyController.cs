using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DataProviders;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly CompanyProvider CompanyProvider;
        public CompanyController()
        {
            CompanyProvider = new CompanyProvider();
        }

        // GET: api/Company
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CompanyProvider.GetAll());
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        //[ProducesResponseType(typeof(Company), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        public IActionResult Get(long id)
        {
            Company company = CompanyProvider.Get(id);
            if (company == null)
                return NotFound();
            else
                return Ok(company);
        }

        // POST: api/Company
        [HttpPost]
        //[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        public IActionResult Post([FromBody] Company value)
        {
            long res = CompanyProvider.Add(value);
            if (res == 0)
                return BadRequest();
            else
                return Ok(res);
        }

        // PUT: api/Company/5
        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(long id, [FromBody] Company value)
        {
            value.Id = id;
            if (CompanyProvider.Set(value))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (CompanyProvider.Del(id))
                return Ok();
            else
                return BadRequest();
        }
    }

}
