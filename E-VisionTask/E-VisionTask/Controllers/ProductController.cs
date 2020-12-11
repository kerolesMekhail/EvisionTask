using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using E_VisionTask.Model;
using E_VisionTask.ProductRequest;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_VisionTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("*")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        public static byte[] Base64ToByteArray(string s)
        {
            var data = Convert.FromBase64String(s);
            return data;
        }


        [EnableCors]
        [HttpGet("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            return  _context.Product.Where(x => x.Active == true).ToList();
        }

        [EnableCors]
        [HttpGet("GetAllProductByOne")]
        public Product GetAllProductByOne(int id)
        {
            return _context.Product.FirstOrDefault(x=>x.Id == id && x.Active == true);
        }

        [HttpPost("SoftDeleteProduct")]
        [EnableCors]
        public async Task SoftDeleteProduct(int id)
        {
            var productDel= _context.Product.FirstOrDefault(x => x.Id == id && x.Active == true);
            productDel.Active = false;
            await _context.SaveChangesAsync();

        }

        [EnableCors]
        [HttpPost("PostProduct")]
        public async Task<string> PostProduct()
        {
            string issuccess = null;
            try
            {
                string dbPath = null;
                IFormFile file = null;

                var Name= Request.Form["Name"];
                var Price =decimal.Parse( Request.Form["Price"]);
                var CategoryId = 1;
                if (Request.Form.Files.Count > 0)
                {
                    file = Request.Form.Files[0];
                }
                if (file != null)
                {
                    var folderName = Path.Combine(@"Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                else
                {
                    dbPath = @"Images/favicon.ico";
                }

                Product item = new Product
                {
                    Name = Name,
                    Active = true,
                    CreatedDT = DateTime.Now,
                    Price = Price,
                    Photo=dbPath
                };
                _context.Product.Add(item);
                await _context.SaveChangesAsync();

                Cat_Product item2 = new Cat_Product
                {
                    CategoryId = CategoryId,
                    ProductId = item.Id,
                    Active = true,
                };
                _context.Cat_Product.Add(item2);
                await _context.SaveChangesAsync();
                issuccess = "success";

            }
            catch
            {
                issuccess = "failed";

            }
            return issuccess;
        }


        [EnableCors]
        [HttpPost("PutProduct")]
        public async Task<string> PutProduct()
        {
           string issuccess = null;

            try
            {
                var Name = Request.Form["Name"];
                var Price = decimal.Parse(Request.Form["Price"]);
                var CategoryId = 1;
                var id = int.Parse(Request.Form["id"]);
                string dbPath = null;
                IFormFile file = null;
                var ProductById = _context.Product.FirstOrDefault(x => x.Id == id);
                if (ProductById == null)
                {
                     
                }
                if (Request.Form.Files.Count > 0)
                {
                    file = Request.Form.Files[0];
                }

                if (file != null)
                {
                    if (System.IO.File.Exists(ProductById.Photo))
                    {
                        System.IO.File.Delete(ProductById.Photo);
                    }

                    var folderName = Path.Combine(@"Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                    else
                    {
                        dbPath = ProductById.Photo;
                    }
                    if (dbPath.Count() > 0)
                    {
                        ProductById.Photo = dbPath;
                    }
                }
                ProductById.Name = Name;
                ProductById.Price = Price;
                ProductById.ModifiedDT = DateTime.Now;
               
                await _context.SaveChangesAsync();

                var list = _context.Cat_Product.ToList();
                var listOfCat_Products = _context.Cat_Product.Where(x => x.ProductId == ProductById.Id).ToList();
                List<int> ListCatProduct = listOfCat_Products.Select(s => (int)s.ProductId).ToList();


                var ListCat_ProductById = _context.Cat_Product.Where(x => x.Id == id).ToList();
                if(ListCat_ProductById != null)
                {
                    foreach (var item in ListCat_ProductById)
                    {
                        item.Active = false;
                        await _context.SaveChangesAsync();

                    }
                }

                Cat_Product item2 = new Cat_Product
                {
                    CategoryId = CategoryId,
                    ProductId = ProductById.Id,
                    Active = true,
                };
                _context.Cat_Product.Add(item2);
                await _context.SaveChangesAsync();
                issuccess = "success";

            }
            catch
            {
                issuccess = "failed";

            }
            return issuccess;
        }

        [EnableCors]
        [HttpGet("SearchProduct")]
        public List<Product> SearchProduct(string Name =null ,DateTime? ModifiedDT=null)//SearchProductRequest request)
        {
            List<Product> listOfProduct = new List<Product>();
            var products = (from Product in _context.Product.Where(x => x.Name == null ? true : x.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase)
                             ||  x.ModifiedDT == null ? true : x.ModifiedDT == ModifiedDT
            //x.Active == null ? true : x.Active == request.Active
            //                                 &&
            //                                 &&
            //                                 x.CreatedDT == null ? true : x.CreatedDT == request.CreatedDT
            //                                
            //                                 &&
            //                                 x.Price == null ? true : x.Price == request.Price

                                             )
                            select new Product
                           {
                               Id = Product.Id,
                               Price = Product.Price,
                               Active = Product.Active,
                               CreatedDT = Product.CreatedDT,
                               ModifiedDT = Product.ModifiedDT,
                               Name = Product.Name,
                               Photo = Product.Photo
                           }
            ).ToList();
            listOfProduct = products;
            return listOfProduct;
        }

    }
}