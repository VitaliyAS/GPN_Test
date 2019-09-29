using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Npgsql;
using System.Data;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace ca_test
{
    [Table("pg_catalog.pg_database")]
    public class PG_DB
    {
        [Key]
        public string DATNAME { get; }
    }

    [Table("pg_catalog.pg_tables")]
    public class PG_Tables
    {
        [Key]
        public string tablename { get; }
        public string tableowner { get; }
    }

    [Table("Company")]
    public class CompanyEntity
    {
        [Key]
        public int CompanyID { get; set; }
        public String CompanyName { get; set; }
        public String CompanyBoss { get; set; }
    }

    class CompanyTable
    {
        GPN_DB DB;
        public CompanyTable(GPN_DB db)
        {
            DB = db;
            if(db.nsConn.Get<PG_Tables>("Company")==null)
            {
/*                var affRows = db.nsConn.Execute("CREATE TABLE \"" + _TableName + "\" WITH OWNER = \"" + _UserName + "\" ENCODING = 'UTF8' CONNECTION LIMIT = -1;");
                if (affRows > 0)
                    Console.WriteLine("DB was created!");
                else
                    Console.WriteLine("Sorry! DB was not created!");
                    */
            }

        }
        
    }


    class GPN_Table
    {
        String _SchemaName = "public";
        String _TableName;
        String _FieldID;
        String _FieldName;


        readonly GPN_DB DB;

        GPN_Table(String name, NpgsqlConnection conn)
        {
            _TableName = name;
            
            //Exist ?
            var tableName = DB.nsConn.ExecuteScalar("SELECT tablename FROM pg_catalog.pg_tables WHERE schemaname = '" + _SchemaName +
                "' and tablename = '" + _TableName + "' and tableowner = '" + DB.UserName + "'");
            if (!tableName.ToString().Equals(_TableName))
            {
                var affRows = DB.nsConn.Execute("");
            }
            var cc = DB.nsConn.Get<CompanyEntity>(1);
            var cc2 = DB.nsConn.Insert<CompanyEntity>(new CompanyEntity { CompanyName = "ABC", CompanyBoss = "Vasya" });
            var cc3 = DB.nsConn.GetAll<CompanyEntity>();
        }
    }

    class GPN_DB
    {
        String _Host;
        String _Port;
        String _DBName;
        String _UserName;

        public NpgsqlConnection nsConn;

        public String Host { get => _Host; set => _Host = value; }
        public String Port { get => _Port; set => _Port = value; }
        public String DBName{ get => _DBName; set => _DBName = value; }
        public String UserName { get => _UserName; set => _UserName = value; }

        public GPN_DB()
        {
            _Host = "";
            _Port = "";
            _DBName = "";
            _UserName = "";
        }

        public GPN_DB(String host, String port, String dbname, String username)
        {
            _Host = host;
            _Port = port;
            _DBName = dbname;
            _UserName = username;
        }

        public Boolean Connect(String sUser,String sPass)
        {
            String sConnString = "Host=" + _Host + ";" +
                "Port=" + _Port + ";" +
                "Username=" + sUser + ";" +
                "Password=" + sPass + ";" +
                "Database=postgres;";
                 
            nsConn = new NpgsqlConnection(sConnString);
            try 
            {
                nsConn.Open();
                if (nsConn.Get<PG_DB>(_DBName) == null)
                {
                    Console.WriteLine("DB not exists. Creating...");
                    var AffRow = nsConn.Execute("CREATE DATABASE \"" + _DBName + "\" WITH OWNER = \"" + _UserName + "\" ENCODING = 'UTF8' CONNECTION LIMIT = -1;");
                    if ( AffRow > 0)
                    {
                        Console.WriteLine("DB was created!");
                        nsConn.ChangeDatabase(_DBName);
                        String sSQLscript = "";
                        using(StreamReader sr = new StreamReader("TableSctruct.sql"))
                        {
                            String s = "";
                            while ((s = sr.ReadLine()) != null)
                                sSQLscript += sr;
                        }

                        if (nsConn.Execute(sSQLscript) > 0)
                            Console.WriteLine("Tables was created!");
                        else
                            Console.WriteLine("Tables was not created!");
                    }
                    else
                        Console.WriteLine("Sorry! DB was not created!");
                }
                else
                {
                    nsConn.ChangeDatabase(_DBName);
                }
                return true;
            }
            catch (Npgsql.NpgsqlException ex)
            {
                //String output = Encoding.UTF8.GetString(Encoding.Convert(Encoding.ASCII, ;
                String s = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(ex.Message));
                Console.WriteLine("{0} - {1}", ex.ErrorCode.ToString(), ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} - {1}", ex.HResult.ToString(), ex.Message);
                return false;
            }
        }

    }


}
