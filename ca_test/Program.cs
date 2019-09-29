using System;
using System.Text;

using Npgsql;
using Dapper;

namespace ca_test
{
    class Program
    {
        static void Main(string[] args)
        {
            String sConnString = "Host=" + "localhost" + ";" +
                "Port=" + "5432" + ";" +
                "Username=" + "GPN_test" + ";" +
                "Password=" + "1" + "; " +
                "Database=GPN_test;";
            NpgsqlConnection nsConn = new NpgsqlConnection(sConnString);
            try
            {
                nsConn.Open();
                //GPN_DB db = new GPN_DB("localhost", "5432", "GPN_test", "GPN_test");
                //db.Connect("GPN_test", "1");
                /*
                CompanyProvider cp = new CompanyProvider(nsConn);
                Company company_1 = new Company("Number_1", "Ivanov Ivan");
                long id1 = cp.Add(company_1);
                Company company_2 = new Company("Number_2", "Petrov Petr");
                long id2 = cp.Add(company_2);
                Company company_3 = new Company("Number_3", "Vasechkina Vasilisa");
                long id3 = cp.Add(company_3);
                foreach (Company c in cp.GetAll()) Console.WriteLine(c.ToString());

                company_3.boss = "Smironova Vasilisa";
                cp.Del(id2);
                cp.Set(company_3);
                foreach (Company c in cp.GetAll()) Console.WriteLine(c.ToString());
                */
                /*
                DepartmentProvider dp = new DepartmentProvider(nsConn);
                Department dep_1 = new Department("Dep_1", "Abrec", 1);
                long id1 = dp.Add(dep_1);
                Department dep_2 = new Department("Dep_2", "Bebrec", 1);
                long id2 = dp.Add(dep_2);
                Department dep_3 = new Department("Dep_3", "Cebrec", 3);
                long id3 = dp.Add(dep_3);
                 Department dd = dp.Get(id1);
                foreach (Department d in dp.GetAll()) Console.WriteLine(d.ToString());
                */
                /*
                FieldProvider fp = new FieldProvider(nsConn);
                Field field_1 = new Field("Field_1", 1000, 1);
                long id1 = fp.Add(field_1);
                Field field_2 = new Field("Field_2", 2000, 1);
                long id2 = fp.Add(field_2);
                Field field_3 = new Field("Filed_3", 3000, 3);
                long id3 = fp.Add(field_3);
                foreach (Field f in fp.GetAll()) Console.WriteLine(f.ToString());
                fp.Del(id2);
                field_3.reserve = 5000;
                fp.Set(field_3);
                foreach (Field f in fp.GetAll()) Console.WriteLine(f.ToString());
                */
                BoreholeProvider bp = new BoreholeProvider(nsConn);
                Borehole Borehole_1 = new Borehole("Borehole_1", 1800, 1, 1, 1);
                long id1 = bp.Add(Borehole_1);
                Borehole Borehole_2 = new Borehole("Borehole_2", 2050, 1, 1, 1);
                long id2 = bp.Add(Borehole_2);
                Borehole Borehole_3 = new Borehole("Borehole_3", 3000, 3, 3, 1);
                long id3 = bp.Add(Borehole_3);
                foreach (Borehole b in bp.GetAll()) Console.WriteLine(b.ToString());
                bp.Del(id2);
                Borehole_3.depth = 2500;
                bp.Set(Borehole_3);
                foreach (Borehole b in bp.GetAll()) Console.WriteLine(b.ToString());
            }
            finally
            {
                nsConn?.Close();
                Console.ReadKey();
            }
        }
    }
}
