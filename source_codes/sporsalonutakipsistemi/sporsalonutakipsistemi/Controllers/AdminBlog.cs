using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sporsalonutakipsistemi.Models.Data;
using sporsalonutakipsistemi.Repositories;
using System;

namespace sporsalonutakipsistemi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBlog : Controller
    {
        BlogRepository blogRepository = new BlogRepository();
        public IActionResult Index()
        {

            return View(blogRepository.TList());
        }

        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            blog.BlogDate = DateTime.Now;
            blogRepository.TAdd(blog);
            return RedirectToAction("Index", "AdminBlog");
        }

        public IActionResult Edit(int id)
        {

            return View(blogRepository.TGet(id));

        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            blogRepository.TUpdate(blog);
            return View(blog);

        }
        public IActionResult Delete(int id)
        {
            var blog = blogRepository.TGet(id);
            blogRepository.TRemove(blog);

            return RedirectToAction("Index", "AdminBlog");

        }
    }
}
