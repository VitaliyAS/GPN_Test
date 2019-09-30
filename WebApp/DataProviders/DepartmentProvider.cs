using System.Collections.Generic;
using Npgsql;
using Dapper;
using Dapper.Contrib.Extensions;
using WebApp.Models;

namespace WebApp.DataProviders
{
    public class DepartmentProvider : IBaseProvider<Department>
    {
        private readonly NpgsqlConnection Connection;
        public DepartmentProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public DepartmentProvider(NpgsqlConnection _Connection) { this.Connection = _Connection; }
        public IEnumerable<Department> GetAll()
        {
            IEnumerable<Department> departments = Connection.GetAll<Department>();
            foreach (var department in departments)
                department.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = department.CompanyId });
            return departments;
        }
        public Department Get(long id)
        {
            Department department = Connection.QueryFirstOrDefault<Department>("select * from department where \"Id\" = @Id", new { Id = id });
            department.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = department.CompanyId });
            return department;
        }
        public bool Set(Department department) { return Connection.Update(department); }
        public long Add(Department department) { return Connection.Insert(department); }
        public bool Del(long id) { return Connection.Delete(Get(id)); }
        public bool DelAll() { return Connection.DeleteAll<Department>(); }
    }
}
