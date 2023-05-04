using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System.Linq;
using X.PagedList;

namespace sporsalonutakipsistemi.Controllers
{
    public class BlogController : Controller
    {
        BlogRepository blogRepository = new BlogRepository();
        Context context = new Context();
        public IActionResult Index(int pageNumber = 1)
        {
            var degerler = context.Blogs.OrderByDescending(x => x.Id).ToList().ToPagedList(pageNumber, 5);
            return View(degerler);
        }

        public IActionResult Details(int id)
        {
            ViewData["PAGE_URL"] = Request.Scheme + "://" + Request.Host + Request.Path + Request.QueryString;
            ViewData["PAGE_IDENTIFIER"] = id.ToString();
            var blog = blogRepository.TGet(id);
            return View(blog);
        }
    }
}
