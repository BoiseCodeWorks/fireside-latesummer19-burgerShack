using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buergershack.Data;
using buergershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace buergershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : ControllerBase
  {
    private readonly BurgersRepository _repo;
    public BurgersController(BurgersRepository repo)
    {
      _repo = repo;
    }
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        return Ok(_repo.GetBurgers());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Burger> Post([FromBody] Burger burgerData)
    {
      try
      {
        Burger burger = _repo.CreateBurger(burgerData);
        return Created($"/api/burgers/{burger.Id}", burger);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
