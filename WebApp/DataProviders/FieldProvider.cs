using System.Collections.Generic;
using Npgsql;
using Dapper;
using Dapper.Contrib.Extensions;
using WebApp.Models;

namespace WebApp.DataProviders
{
    public class FieldProvider : IBaseProvider<Field>
    {
        private readonly NpgsqlConnection Connection;
        public FieldProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public FieldProvider(NpgsqlConnection connection) { this.Connection = connection; }
        public IEnumerable<Field> GetAll()
        {
            IEnumerable<Field> fields = Connection.GetAll<Field>();
            foreach (var field in fields)
                field.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = field.CompanyId });
            return fields;
        }
        public Field Get(long id)
        {
            Field field = Connection.QueryFirstOrDefault<Field>("select * from field where \"Id\" = @Id", new { Id = id });
            field.CompanyEntity = Connection.QueryFirstOrDefault<Company>("select * from company where \"Id\" = @Id", new { Id = field.CompanyId });
            return field;
        }
        public bool Set(Field field) { return Connection.Update(field); }
        public long Add(Field field) { return Connection.Insert(field); }
        public bool Del(long id) { return Connection.Delete(Get(id)); }
        public bool DelAll() { return Connection.DeleteAll<Field>(); }
    }
}
