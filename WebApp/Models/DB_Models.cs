using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string boss { get; set; }
    }

    public class Department
    {
        public long id { get; set; }
        public string name { get; set; }
        public string boss { get; set; }
        public long company_id { get; set; }
        public Company company;
    }

    public class Field
    {
        public long id { get; set; }
        public string name { get; set; }
        public float reserve { get; set; }
        public long company_id { get; set; }
        public Company company;
    }

    public class Borehole
    {
        public long id { get; set; }
        public string name { get; set; }
        public long depth { get; set; }
        public long company_id { get; set; }
        public Company company;
        public long department_id { get; set; }
        public Department department;
        public long field_id { get; set; }
        public Field field;
    }
}