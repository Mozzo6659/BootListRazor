using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BootListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace BootListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Book> Books { get; set; }


        public IndexModel (ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
