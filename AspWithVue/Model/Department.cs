using System.ComponentModel.DataAnnotations;

namespace AspWithVue.Model;

public class Department
{
    [Key]
    public  int DepartmentId  { get; set; }
    
    [Required]
    public  string DepartmentName  { get; set; }
}