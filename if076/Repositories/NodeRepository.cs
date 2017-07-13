using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using if076.Entities;

namespace if076.Repositories
{
    public class NodeRepository : IRepository<Node> 
    {
        private readonly string _connectionString;

        public NodeRepository(IConfigurationRoot config)
        {
            _connectionString = config.GetConnectionString("if076");
        }

        public async Task<IEnumerable<Node>> GetList()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Node> list = await db.QueryAsync<Node>("NodesList", commandType: CommandType.StoredProcedure);
                return list;
            }
        }

        public async Task<Node> GetById(int id)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                Node node = await db.QuerySingleAsync<Node>("NodesGet", new { Id = id }, commandType: CommandType.StoredProcedure);
                return node;
            }
        }

        public async Task<Node> Create(Node node)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                node.Id = await db.ExecuteScalarAsync<int>("NodesCreate", node, commandType: CommandType.StoredProcedure);
                return (node.Id > 0) ? node : null;
            }
        }

        public async Task<bool> Update(Node node)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                int result = await db.ExecuteAsync("NodesUpdate", node, commandType: CommandType.StoredProcedure);
                return (result >= 1) ? true : false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                int result = await db.ExecuteAsync("NodesDelete", new { Id = id }, commandType: CommandType.StoredProcedure);
                return (result >= 1) ? true : false;
            }
        }
    }
}