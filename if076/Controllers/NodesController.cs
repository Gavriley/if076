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
        public async Task<IEnumerable<Node>> GetNode()
        {
            return await _db.GetList();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNodeForm([FromRoute]int id)
        {
            Node node = await _db.GetById(id);

            if (node != null)
            {
                return Ok(node);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNode([FromBody]Node node)
        {
            if (await _db.Create(node) != null)
            {
                return Ok(node);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNode([FromBody]Node node)
        {
            if (await _db.Update(node))
            {
                return Ok(node);
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
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}