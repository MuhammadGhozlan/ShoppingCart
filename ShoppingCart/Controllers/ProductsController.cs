﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<IActionResult> Index(string searchString, string categorySlug = "", int p = 1)
        {


             var products = from m in _context.Products
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.ToLower()!.Contains(searchString.ToLower()));
                return View(await products.ToListAsync());
            }

            // if (!String.IsNullOrEmpty(categorySlug))
            // {
            //     products = products.Where(s => s.Slug == categorySlug);
            // }



            int pageSize = 10;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;
            

            if (categorySlug == "")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);

                return View(await _context.Products.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
            }
            Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();

            if (category == null)
            {
                return RedirectToAction("Index");

            }
            var productsByCategory = _context.Products.Where(p => p.Category.Id == category.Id);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);

            return View(await productsByCategory.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());


        }
    }
}


