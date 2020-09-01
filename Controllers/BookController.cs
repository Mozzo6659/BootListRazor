using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BootListRazor.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;

namespace BootListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        public readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });

        }
    }
}
