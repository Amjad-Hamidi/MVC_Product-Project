using Microsoft.AspNetCore.Mvc;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model) 
        { 
            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult changeProductPublish(int id)
        {
            var product= _context.Products.Find(id);
            if (product.InStock) { 
                product.InPublish = !product.InPublish;
            }
            else
            {
                product.InPublish = false;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult changeProductAvailability(int id)
        {
            var product = _context.Products.Find(id);
			product.InStock = !product.InStock;
			if (!product.InStock)
			{
				product.InPublish = false;
				product.Qty = 0;
			}
			_context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            return View(_context.Products.Find(id)); // id صاحب هاد ال  products برجع 
        }
        [HttpPost]
        public IActionResult Edit(Product prod) 
        {
            var product = _context.Products.Find(prod.ProductId);
            product.Name = prod.Name;
            product.Price = prod.Price;
            product.Qty = prod.Qty;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Delete(int id) 
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
