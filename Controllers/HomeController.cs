using Microsoft.AspNetCore.Mvc;
using Mission11_Escobar.Models;
using Mission11_Escobar.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Escobar.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;
        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var Blah = new BookListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(Blah);
        }
    }
}
