using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCrud.Data;
using RazorPageCrud.Model;

namespace RazorPageCrud.Pages.Catagories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Catagory Catagory { get; set; }


        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
          
        }
        public void OnGet(int id)
        {
            Catagory = _db.CatagoryList.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
           
           
                var catagoryFromDb=_db.CatagoryList.Find(Catagory.Id);
                if(catagoryFromDb!=null)
                {
                    _db.CatagoryList.Remove(catagoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Catagory Deleted Successfully";

                return RedirectToPage("Index");
                }
           
               
            
            return Page();
         

        }
    }
}
