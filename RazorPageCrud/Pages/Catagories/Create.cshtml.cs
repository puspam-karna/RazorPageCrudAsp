using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCrud.Data;
using RazorPageCrud.Model;

namespace RazorPageCrud.Pages.Catagories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Catagory Catagory { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
          
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Catagory.Name == Catagory.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError(string.Empty, "Display Order cannot be exactly as Name");
            }
            if (ModelState.IsValid)
            {
                await _db.CatagoryList.AddAsync(Catagory);
                await _db.SaveChangesAsync();
                TempData["success"] = "Catagory Created Successfully";
                return RedirectToPage("Index");
            }
            return Page();
         

        }
    }
}
