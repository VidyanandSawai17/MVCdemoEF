using Microsoft.AspNetCore.Mvc;
using MVCdemoEF.Models;
using Microsoft.AspNetCore.Http;
using MVCdemoEF.Entities;

namespace MVCdemoEF.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController

        private readonly ApplicationDbContext configuration;
        ProductDAL db;
        public ProductController(ApplicationDbContext configuration)
        {
            this.configuration = configuration;
            db = new ProductDAL(this.configuration);
        }
        public ActionResult Index()
        {
            List<Product> model = db.GetAllProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetProductById(id);
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                int res = db.AddProduct(prod);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Product prod)
        {
            try
            {
                int res = db.UpdateProduct(prod);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = db.DeleteProduct(id);
                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error("Something went wrong");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
