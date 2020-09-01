using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BootListRazor.Model;

namespace BootListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public Book Book { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task OnGet(int Id)
        {

            Book = await _db.Book.FindAsync(Id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);

                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            else
            {
                return RedirectToPage(); 
            }


        }
    }
}
