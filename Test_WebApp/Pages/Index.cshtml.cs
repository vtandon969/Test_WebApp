using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_WebApp.Services;
using Test_WebApp.Model;

namespace Test_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        IBookService _bookService;
        public List<Book> books;

        public IndexModel(ILogger<IndexModel> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public void OnGet()
        {
           books = _bookService.GetBooks();
        }
    }
}