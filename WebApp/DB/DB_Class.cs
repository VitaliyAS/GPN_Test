using System;
using System.Collections.Generic;
using Npgsql;
using Dapper.Contrib.Extensions;

namespace WebApp.DB
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string boss { get; set; }
        public Company() { }
        public Company(string _name, string _boss) { id = 0; name = _name; boss = _boss; }
        public override string ToString() { return "{id = " + id.ToString() + ", name = " + name + ", boss = " + boss + "}"; }
    }
    public interface ICompanyProvider
    {
        IEnumerable<Company> GetAll();
        Company Get(long _id);
        bool Set(Company _company);
        long Add(Company _company);
        bool Del(long _id);
        bool DelAll();
    }
    public class CompanyProvider : ICompanyProvider
    {
        private readonly NpgsqlConnection Connection;
        public CompanyProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public CompanyProvider(NpgsqlConnection _connection) { this.Connection = _connection; }
        public IEnumerable<Company> GetAll() { return Connection.GetAll<Company>(); }
        public Company Get(long _id) { return Connection.Get<Company>(_id); }
        public bool Set(Company _company) { return Connection.Update<Company>(_company); }
        public long Add(Company _company) { return Connection.Insert<Company>(_company); }
        public bool Del(long _id) { return Connection.Delete<Company>(Get(_id)); }
        public bool DelAll() { return Connection.DeleteAll<Company>(); }
    }

    [Table("Department")]
    public class Department
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public string boss { get; set; }
        public long company_id { get; set; }
        public Company company;
        public Department() { }// { company = new Company(); }
        public Department(long _company_id) { id = 0; name = ""; boss = ""; company_id = _company_id; }
        public Department(string _name, string _boss, long _company_id) { id = 0; name = _name; boss = _boss; company_id = _company_id; }
        public override string ToString() { return "{id = " + id.ToString() + ", name = " + name + ", boss = " + boss + ", company = " + company?.ToString() + "}"; }
    }
    public interface IDepartmentProvider
    {
        IEnumerable<Department> GetAll();
        Department Get(long _id);
        bool Set(Department _department);
        long Add(Department _department);
        bool Del(long _id);
        bool DelAll();
    }
    public class DepartmentProvider : IDepartmentProvider
    {
        private readonly NpgsqlConnection Connection;
        public DepartmentProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public DepartmentProvider(NpgsqlConnection _connection) { this.Connection = _connection; }
        public IEnumerable<Department> GetAll()
        {
            IEnumerable<Department> res = Connection.GetAll<Department>();
            foreach (Department dep in res)
                dep.company = Connection.Get<Company>(dep.company_id);
            return res;
        }
        public Department Get(long _id)
        {
            Department res = Connection.Get<Department>(_id);
            res.company = Connection.Get<Company>(res.company_id);
            return res;
        }
        public bool Set(Department _department) { return Connection.Update<Department>(_department); }
        public long Add(Department _department) { return Connection.Insert<Department>(_department); }
        public bool Del(long _id) { return Connection.Delete<Department>(Get(_id)); }
        public bool DelAll() { return Connection.DeleteAll<Department>(); }
    }

    [Table("Field")]
    public class Field
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public float reserve { get; set; }
        public long company_id { get; set; }
        public Company company;
        public Field() { }
        public Field(long _company_id) { id = 0; name = ""; reserve = 0; company_id = _company_id; }
        public Field(string _name, float _reserve, long _company_id) { id = 0; name = _name; reserve = _reserve; company_id = _company_id; }
        public override string ToString() { return "{id = " + id.ToString() + ", name = " + name + ", reserve = " + reserve + ", company = " + company?.ToString() + "}"; }
    }
    public interface IFieldProvider
    {
        IEnumerable<Field> GetAll();
        Field Get(long _id);
        bool Set(Field _field);
        long Add(Field _field);
        bool Del(long _id);
        bool DelAll();
    }
    public class FieldProvider : IFieldProvider
    {
        private readonly NpgsqlConnection Connection;
        public FieldProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public FieldProvider(NpgsqlConnection _connection) { this.Connection = _connection; }
        public IEnumerable<Field> GetAll()
        {
            IEnumerable<Field> res = Connection.GetAll<Field>();
            foreach (Field f in res)
                f.company = Connection.Get<Company>(f.company_id);
            return res;
        }
        public Field Get(long _id)
        {
            Field res = Connection.Get<Field>(_id);
            res.company = Connection.Get<Company>(res.company_id);
            return res;
        }
        public bool Set(Field _field) { return Connection.Update<Field>(_field); }
        public long Add(Field _field) { return Connection.Insert<Field>(_field); }
        public bool Del(long _id) { return Connection.Delete<Field>(Get(_id)); }
        public bool DelAll() { return Connection.DeleteAll<Field>(); }
    }

    [Table("Borehole")]
    public class Borehole
    {
        [Key]
        public long id { get; set; }
        public string name { get; set; }
        public long depth { get; set; }
        public long company_id { get; set; }
        public Company company;
        public long department_id { get; set; }
        public Department department;
        public long field_id { get; set; }
        public Field field;

        public Borehole() { }
        public Borehole(long _company_id, long _deprtment_id, long _field_id)
        {
            id = 0; name = ""; depth = 0;
            company_id = _company_id; department_id = _deprtment_id; field_id = _field_id;
        }
        public Borehole(string _name, long _depth, long _company_id, long _deprtment_id, long _field_id)
        {
            id = 0; name = _name; depth = _depth;
            company_id = _company_id; department_id = _deprtment_id; field_id = _field_id;
        }
        public override string ToString()
        {
            return "{id = " + id.ToString() + ", name = " + name + ", depth = " + depth + ", company = " + company?.ToString() +
                ", department = " + department?.ToString() + ", field = " + field?.ToString() + "}";
        }
    }
    public interface IBoreholeProvider
    {
        IEnumerable<Borehole> GetAll();
        Borehole Get(long _id);
        bool Set(Borehole _field);
        long Add(Borehole _field);
        bool Del(long _id);
        bool DelAll();
    }
    public class BoreholeProvider : IBoreholeProvider
    {
        private readonly NpgsqlConnection Connection;
        public BoreholeProvider() { this.Connection = new NpgsqlConnection(Program.sConnectionString); }
        public BoreholeProvider(NpgsqlConnection _connection) { this.Connection = _connection; }
        public IEnumerable<Borehole> GetAll()
        {
            IEnumerable<Borehole> res = Connection.GetAll<Borehole>();
            foreach (Borehole b in res)
            {
                b.company = Connection.Get<Company>(b.company_id);
                b.department = Connection.Get<Department>(b.department_id);
                b.field = Connection.Get<Field>(b.field_id);
            }
            return res;
        }
        public Borehole Get(long _id)
        {

            Borehole res = Connection.Get<Borehole>(_id);
            res.company = Connection.Get<Company>(res.company_id);
            res.department = Connection.Get<Department>(res.department);
            res.field = Connection.Get<Field>(res.field);
            return res;
        }
        public bool Set(Borehole _field) { return Connection.Update<Borehole>(_field); }
        public long Add(Borehole _field) { return Connection.Insert<Borehole>(_field); }
        public bool Del(long _id) { return Connection.Delete<Borehole>(Get(_id)); }
        public bool DelAll() { return Connection.DeleteAll<Borehole>(); }
    }
}
