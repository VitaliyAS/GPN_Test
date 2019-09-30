using Dapper.Contrib.Extensions;

namespace WebApp.Models
{
    [Table("Field")]
    public class Field
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public float Reserve { get; set; }
        public long CompanyId { get; set; }
        public Company CompanyEntity;
        public Field() { }
        public Field(long companyId) { Id = 0; Name = ""; Reserve = 0; CompanyId = companyId; }
        public Field(string name, float reserve, long companyId) { Id = 0; Name = name; Reserve = reserve; CompanyId = companyId; }
        public override string ToString() { return "{id = " + Id.ToString() + ", name = " + Name + ", reserve = " + Reserve + ", company = " + CompanyEntity?.ToString() + "}"; }
    }
}
