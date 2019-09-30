using Dapper.Contrib.Extensions;


namespace WebApp.Models
{
    [Table("Company")]
    public class Company
    { 
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Boss { get; set; }
        public Company() { }
        public Company(string name, string boss) { Id = 0; Name = name; Boss = boss; }
        public override string ToString() { return "{Id = " + Id.ToString() + ", Name = " + Name + ", Boss = " + Boss + "}"; }
    }
}
