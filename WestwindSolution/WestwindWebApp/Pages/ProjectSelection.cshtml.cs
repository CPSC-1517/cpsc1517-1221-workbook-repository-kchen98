using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindWebApp.Models;

namespace WestwindWebApp.Pages
{
    public class ProjectSelectionModel : PageModel
    {
   
        public ProjectSelectionModel()
        {
            
        }

        public List<Student> Students { get; private set; }
        public void OnGet()
        {
           Students = new List<Student>();
            using (StreamReader reader = new StreamReader("wwwroot/data/CPSC1517.1221.A03.ClassList.txt"))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Student currentStudent = new Student();
                    currentStudent.Id = int.Parse(parts[2]);
                    currentStudent.FirstName = parts[0];
                    currentStudent.LastName = parts[1];
                    Students.Add(currentStudent);
                }
            }
        }
    }
}
