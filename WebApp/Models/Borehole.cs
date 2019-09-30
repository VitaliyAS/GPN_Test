using Dapper.Contrib.Extensions;

namespace WebApp.Models
{
    [Table("Borehole")]
    public class Borehole
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long Depth { get; set; }
        public long CompanyId { get; set; }
        public Company CompanyEntity;
        public long DepartmentId { get; set; }
        public Department DepartmentEntity;
        public long FieldId { get; set; }
        public Field FieldEntity;

        public Borehole() { }
        public Borehole(long companyId, long deprtmentId, long fieldId)
        {
            Id = 0; Name = ""; Depth = 0;
            CompanyId = companyId; DepartmentId = deprtmentId; FieldId = fieldId;
        }
        public Borehole(string name, long depth, long companyId, long deprtmentId, long fieldId)
        {
            Id = 0; Name = name; Depth = depth;
            CompanyId = companyId; DepartmentId = deprtmentId; FieldId = fieldId;
        }
        public override string ToString()
        {
            return "{Id = " + Id.ToString() + ", Name = " + Name + ", Depth = " + Depth + ", CompanyEntity = " + CompanyEntity?.ToString() +
                ", DepartmentEntity = " + DepartmentEntity?.ToString() + ", FieldEntity = " + FieldEntity?.ToString() + "}";
        }
    }
}
