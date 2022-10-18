using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestwindWebApp.Pages
{
    public class FormControlDemoUsingTagHelpersModel : PageModel
    {
        [TempData]
        public string FeedbackMessage { get; set; } = null!;

        [BindProperty]
        public string Username { get; set; } = null!;

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public bool Subscribe { get; set; }

        [BindProperty]
        public string Gender { get; set; } = null!;

        [BindProperty]
        public string Department { get; set; } = null!;

        [BindProperty]
        public string Comments { get; set; } = null!;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            FeedbackMessage = $"Username = {Username}, Age = {Age}, Gender = {Gender}, Department = {Department}, Comments = {Comments}, Subscribe = {Subscribe}";
        }
    }
}
