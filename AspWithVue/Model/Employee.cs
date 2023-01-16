using System.ComponentModel.DataAnnotations;

namespace AspWithVue.Model;

public class Employee
{
    [Key]
    public int empId  { get; set; }
    
    public string EmployeName  { get; set; }
    
    public string Department  { get; set; }
    
    public DateTime DateOfJoining  { get; set; }
    
    public string PhotoFileName  { get; set; }
}