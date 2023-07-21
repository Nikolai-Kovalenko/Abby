using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public Category Category { get; set; }

        public EditModel(AppDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString()) {
                ModelState.AddModelError("Category.Name", "Value Name and Display order should be different.");
            }

            if(ModelState.IsValid) 
            {
                _db.Category.Update(Category);   
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated seccessfely";
                return RedirectToPage("Index"); 
            }
            return Page();  
        }
    }
}
