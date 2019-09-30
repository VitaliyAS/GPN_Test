using System.Collections.Generic;
using Npgsql;
using Dapper;
using Dapper.Contrib.Extensions;
using WebApp.Models;

namespace WebApp.DataProviders
{
    public class CompanyProvider:IBaseProvider<Company>
    {
        private readonly NpgsqlConnection Connection;
        public CompanyProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public CompanyProvider(NpgsqlConnection _Connection) { this.Connection = _Connection; }
        public IEnumerable<Company> GetAll() { return Connection.GetAll<Company>(); }
        public Company Get(long id) { return Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = id }); }
        public bool Set(Company company) { return Connection.Update(company); }
        public long Add(Company company) { return Connection.Insert(company); }
        public bool Del(long id) { return Connection.Delete(Get(id)); }
        public bool DelAll() { return Connection.DeleteAll<Company>(); }
    }
}
