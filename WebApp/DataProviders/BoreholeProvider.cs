using System.Collections.Generic;
using Npgsql;
using Dapper;
using Dapper.Contrib.Extensions;
using WebApp.Models;

namespace WebApp.DataProviders
{
    public class BoreholeProvider : IBaseProvider<Borehole>
    {
        private readonly NpgsqlConnection Connection;
        public BoreholeProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public BoreholeProvider(NpgsqlConnection connection) { this.Connection = connection; }
        public IEnumerable<Borehole> GetAll()
        {
            IEnumerable<Borehole> boreholes = Connection.GetAll<Borehole>();
            foreach (var borehole in boreholes)
            {
                borehole.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = borehole.CompanyId });
                borehole.DepartmentEntity = Connection.QueryFirstOrDefault<Department>("select * from department where \"Id\" = @Id", new { Id = borehole.DepartmentId });
                borehole.FieldEntity = Connection.QueryFirstOrDefault<Field>("select * from field where \"Id\" = @Id", new { Id = borehole.FieldId });
            }
            return boreholes;
        }
        public Borehole Get(long id)
        {
            var borehole = Connection.QueryFirstOrDefault<Borehole>("select * from borehole where \"Id\" = @Id", new { Id = id });
            borehole.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = borehole.CompanyId });
            borehole.DepartmentEntity = Connection.QueryFirstOrDefault<Department>("select * from department where \"Id\" = @Id", new { Id = borehole.DepartmentId });
            borehole.FieldEntity = Connection.QueryFirstOrDefault<Field>("select * from field where \"Id\" = @Id", new { Id = borehole.FieldId });
            return borehole;
        }
        public bool Set(Borehole field) { return Connection.Update<Borehole>(field); }
        public long Add(Borehole field) { return Connection.Insert<Borehole>(field); }
        public bool Del(long id) { return Connection.Delete<Borehole>(Get(id)); }
        public bool DelAll() { return Connection.DeleteAll<Borehole>(); }
    }
}
