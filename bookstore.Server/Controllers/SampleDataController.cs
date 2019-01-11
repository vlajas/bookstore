using bookstore.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly BookstoreDbContext _context;

        public SampleDataController(BookstoreDbContext context)
        {
            _context = context;
        }
    }
}
