using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WestwindWebApp.Pages
{
    public class FormControlDemoUsingPureHtmlModel : PageModel
    {
        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public int Age { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            FeedbackMessage = $"Username = {Username}, Age = {Age}";
        }
    }
}
