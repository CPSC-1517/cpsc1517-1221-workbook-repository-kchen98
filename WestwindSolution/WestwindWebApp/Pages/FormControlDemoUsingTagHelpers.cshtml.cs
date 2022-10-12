using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestwindWebApp.Pages
{
    public class FormControlDemoUsingTagHelpersModel : PageModel
    {
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public bool Subscribe { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        public string Department { get; set; }

        [BindProperty]
        public string Comments { get; set; }    
        public void OnGet()
        {
        }
        public void OnPost()
        {
            FeedbackMessage = $"Username = {Username}, Age = {Age}, Subscribe = {Checkbox}";
        }
    }
}
