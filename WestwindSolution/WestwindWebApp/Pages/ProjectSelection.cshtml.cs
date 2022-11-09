using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindWebApp.Models;

namespace WestwindWebApp.Pages
{
    public class ProjectSelectionModel : PageModel
    {
   
        public ProjectSelectionModel()
        {
            NumberOfGroups = 5;
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
            AvailableScenariosDict.Add("Group1", "Scenario A01");
            AvailableScenariosDict.Add("Group2", "Scenario A02");
            AvailableScenariosDict.Add("Group3", "Scenario A03");
            AvailableScenariosDict.Add("Group4", "Scenario A04");
            AvailableScenariosDict.Add("Group5", "Scenario A14");
        }

        public List<Student> Students { get; private set; } = new();

        [BindProperty]
        public int NumberOfGroups { get; set; }

        public Dictionary<string, string> AvailableScenariosDict { get; private set; } = new();

        public Dictionary<string, List<Student>> StudentGroupDict { get; private set; } = new();
        public void OnGet()
        {
           
        }

        //public IActionResult OnPostSplitIntoGroups()
        //{
        //    return RedirectToPage("/ProjectSelection");
        //}

        public void OnPostSplitIntoGroups()
        {
            // Determine the number of members per group
            int membersPerGroup = (int) Math.Ceiling(1.0 * Students.Count / NumberOfGroups);
            // Clear all existing groups
            StudentGroupDict.Clear();
            // Create a copy of the Students list
            var studentListCopy = Students.ToList();
            // Create an object for generating random
            Random rand = new();
            // Create a number to track the current group
            int currentGroup = 1;
            // Repeat until all students have been removed from studentListCopy
            while (studentListCopy.Count > 0)
            {
                // Create a new list of student for each group
                List<Student> currentStudentGroup = new();
                // Create a unique group name
                string groupName = $"Group{currentGroup}";


                for (int memberCount = 1; memberCount <= membersPerGroup && studentListCopy.Count > 0; memberCount++)
                {
                    // Generate a random index for the element to remove
                    int randomIndex = rand.Next(0, studentListCopy.Count);
                    // Add the current element to the student group
                    currentStudentGroup.Add(studentListCopy[randomIndex]);
                    // Remove the current element from the list
                    studentListCopy.RemoveAt(randomIndex);
                }
                // Add the currentStudentGroup to the dictionary
                StudentGroupDict.Add(groupName, currentStudentGroup);
                // Set the next currentGroup
                currentGroup++;
            }
        }
    }
}
