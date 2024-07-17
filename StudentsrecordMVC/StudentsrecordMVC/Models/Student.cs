using System.Security.Cryptography.X509Certificates;

namespace StudentsrecordMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public int Class {  get; set; }
    }
}
