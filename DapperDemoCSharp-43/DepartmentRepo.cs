using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoCSharp_43
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly IDbConnection _conn;

        public DepartmentRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName);", new { newDepartmentName });
        }
    }
}
