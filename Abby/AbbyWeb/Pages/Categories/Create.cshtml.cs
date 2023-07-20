using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public Category Category { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(string.Empty, "Value Name and Display order should be different.");
            }

            if(ModelState.IsValid) 
            { 
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();  
        }
    }
}
