using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCrud.Data;
using RazorPageCrud.Model;

namespace RazorPageCrud.Pages.Catagories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Catagory Catagory { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
          
        }
        public void OnGet(int id)
        {
            Catagory = _db.CatagoryList.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Catagory.Name == Catagory.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError(string.Empty, "Display Order cannot be exactly as Name");
            }
            if (ModelState.IsValid)
            {
                _db.CatagoryList.Update(Catagory);
                await _db.SaveChangesAsync();
                TempData["success"] = "Catagory Edited Successfully";

                return RedirectToPage("Index");
            }
            return Page();
         

        }
    }
}
