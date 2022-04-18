using E_Commerce.Business.Abstract;
using E_Commerce.Entities.Concrete;
using E_Commerce.WebUI.Helper;
using E_Commerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        ProductListViewModel vm = new ProductListViewModel();
        string path = string.Empty;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page=1,int category=0)
        {

            int pageSize = 10;
            var products = _productService.GetByCategory(category);


            vm = new  ProductListViewModel()
            {

                Products = new ObservableCollection<Product>(products.Skip((page - 1) * pageSize).Take(pageSize))
            };



            ObservableCollection<Product> SortedList = new ObservableCollection<Product>(vm.Products.OrderBy(o => o.UnitPrice));
            vm.Products = SortedList;
            //vm.Products.Sort((x, y) => string.Compare(x.ProductName, y.ProductName));
            HelperContainer.Products = vm.Products;
            HelperContainer.Cat = category;
            return View(vm);
        }
        public IActionResult AToZSort()
        {

            HelperContainer.Products = new ObservableCollection<Product>(HelperContainer.Products.OrderBy(x => x.ProductName));
            vm.Products = HelperContainer.Products;
            return View("Index", vm);
        }
        public IActionResult ZToASort()
        {

            HelperContainer.Products = new ObservableCollection<Product>(HelperContainer.Products.OrderByDescending(x => x.ProductName));
            vm.Products = HelperContainer.Products;
            return View("Index", vm);
        }


    }
}
