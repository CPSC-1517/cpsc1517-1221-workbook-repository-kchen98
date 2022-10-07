using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSyntaxDemo.Pages
{
    public class FormExample02Model : PageModel
    {
        public void OnGet()
        {
        }

        public string FeedbackMessage { get; private set; }
        public void OnPost()
        {
            // Generate 7 unique numbers between 1 and 50
            var rand = new Random();
            var generatedNumbers = new List<int>();
            while (generatedNumbers.Count < 7)
            {
                var randomNumber = rand.Next(1, 51);
                if (!generatedNumbers.Contains(randomNumber))
                {
                    generatedNumbers.Add(randomNumber);
                }
            }
            generatedNumbers.Sort();
            // Sort the generated numbers in sequence
            FeedbackMessage = "";
            foreach (var num in generatedNumbers)
            {
                FeedbackMessage += num + " ";
            }     
        }
    }
}
