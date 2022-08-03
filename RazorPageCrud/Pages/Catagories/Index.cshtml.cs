using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageCrud.Data;
using RazorPageCrud.Model;

namespace RazorPageCrud.Pages.Catagories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Catagory> Catagories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;        }
        public void OnGet()
        {
            Catagories = _db.CatagoryList;//name of database created
        }
    }
}
