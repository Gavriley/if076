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
    public class ValuesController : BaseController
    {
        private readonly IRepository<Node> _db;

        public ValuesController(IRepository<Node> connection)
        {
            _db = connection;
        }

        [HttpGet]
        public async Task<IEnumerable<Node>> Get()
        {
            return await _db.GetList();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Node> GetById(int id)
        {
            return await _db.GetById(id);
        }

        [HttpGet]
        [Route("Create")]
        public async Task<Node> Create()
        {
            return await _db.Create(new Node { Name = "Charlie"}) ?? new Node { Id = 0, Name = "Bad Request" };
        }

        [HttpGet]
        [Route("Update/{id:int}")]
        public async Task<bool> Update(int id)
        {
            Node node = await _db.GetById(id);
            node.Name += "!";
            return await _db.Update(node);
        }
    }
}