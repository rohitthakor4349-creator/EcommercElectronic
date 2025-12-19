using Ecommerce.Entity.Model;
using Ecommerce.Model;
using Ecommerce.NTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Ecommerce.Pages.Admin
{
    public class ProductFormModel : PageModel
    {
        private readonly IProductTblServices db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductFormModel(IProductTblServices db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public ProductDTO Products { get; set; }

        [BindProperty]
        public string img { get; set; }

        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> BrandList { get; set; }
        public List<SelectListItem> SubCategoryList { get; set; }
        public List<SelectListItem> ThirdCategoryList { get; set; }
        // CategoryListFill

        public async Task FillCategory()
        {
            CategoryList = await db.DropCategory();
        }
        // BrandListFill
        public async Task FillBrand()
        {
            BrandList = await db.DropBrand();
        }
        public async Task<IActionResult> OnGet(int EditId)
        {
            await FillCategory();
            await FillBrand();

            if (EditId > 0)
            {
                var Data = await db.GetByProductId(EditId);

                if (Data.CategoryId != null && Data.SubCategoryId != null)
                {
                    SubCategoryList = await db.DropSubCategory(Data.CategoryId.Value);
                    ThirdCategoryList = await db.DropThirdCategory(Data.SubCategoryId.Value);
                }
                else
                {
                    SubCategoryList = new List<SelectListItem>();
                    ThirdCategoryList = new List<SelectListItem>();
                }
                if (Data != null)
                {
                    Products = new ProductDTO();
                    Products.ProductName = Data.ProductName;
                    Products.ProductPrice = Data.ProductPrice;
                    Products.CategoryId = Data.CategoryId;
                    Products.SubCategoryId = Data.SubCategoryId;
                    Products.ThirdCategoryId = Data.ThirdCategoryId;
                    Products.BrandId = Data.BrandId;
                    Products.Photo = Data.Photo;
                    Products.Description = Data.Description;
                    Products.ProductId = Data.ProductId;

                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostCreate()
        {


            //if (ModelState.IsValid)
            //{
                if (Products.ImgUpload != null)
                {
                    if (Products.ImgUpload.Length > 0)
                    {
                        var path = Path.Combine(webHostEnvironment.WebRootPath, "img", Products.ImgUpload.FileName);
                        FileStream fs = new FileStream(path, FileMode.Create);
                        Products.ImgUpload.CopyTo(fs);
                        img = "/img/" + Products.ImgUpload.FileName;

                    }
                    else
                    {
                        img = "/img/" + Products.ImgUpload.FileName;
                    }
                }
                var Data = await db.AddProduct(new ProductTbl()
                {

                    ProductName = Products.ProductName,
                    ProductPrice = Products.ProductPrice,
                    CategoryId = Products.CategoryId,
                    SubCategoryId = Products.SubCategoryId,
                    ThirdCategoryId = Products.ThirdCategoryId,
                    BrandId = Products.BrandId,
                    Photo = img,
                    Description = Products.Description,
                    Status = true,
                    EntryDate = DateTime.Now

                });
                return RedirectToPage("ProductForm", new { Message = Data });
            //}
            //return Page();
        }
          


        public async Task<IActionResult> OnPostUpdate()
        {
            if (Products.ImgUpload != null)
            {
                if (Products.ImgUpload.Length > 0)
                {
                    var path = Path.Combine(webHostEnvironment.WebRootPath, "img", Products.ImgUpload.FileName);
                    FileStream fs = new FileStream(path, FileMode.Create);
                    Products.ImgUpload.CopyTo(fs);
                    img = "/img/" + Products.ImgUpload.FileName;

                }
                else
                {
                    img = "/img/" + Products.ImgUpload.FileName;
                }
            }
            var Data = await db.UpdateProduct(Products.ProductId, new ProductTbl()
            {

                ProductName = Products.ProductName,
                ProductPrice = Products.ProductPrice,
                CategoryId = Products.CategoryId,
                SubCategoryId = Products.SubCategoryId,
                ThirdCategoryId = Products.ThirdCategoryId,
                BrandId = Products.BrandId,
                Photo = img,
                Description = Products.Description,
            });

            return RedirectToPage("ProductForm", new { Message = Data });
        }

    }
}
