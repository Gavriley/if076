using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using if076.Entities;
using if076.Repositories;

namespace if076.Controllers
{
    public class NodesController : BaseController
    {
        private readonly IRepository<Node> _db;

        public NodesController(IRepository<Node> connection)
        {
            _db = connection;
        }

        [HttpGet]
        public async Task<IActionResult> GetNode()
        {
            return PartialView("List", await _db.GetList());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNodeForm([FromRoute]int id)
        {
            if (id == 0)
            {
                return PartialView("Form");
            }
            else
            {
                Node node = await _db.GetById(id);
                if (node != null)
                {
                    return PartialView("Form", node);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNode([FromBody]Node node)
        {
            if (await _db.Create(node) != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateNode([FromRoute] int id, [FromBody]Node node)
        {
            if(node.Id != id)
            {
                return BadRequest();
            }


            if (await _db.Update(node))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteNode(int id)
        {
            if (await _db.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}