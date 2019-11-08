using AutoMapper;
using ProductList.Core.Models;
using ProductList.Core.Services.Contracts;
using ProductList.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductList.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCategoryService _categoryService;
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper, IProductCategoryService categoryService)
        {
            _categoryService = categoryService;
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductCategoryViewModel>> GetAllCategory()
        {
            var items = await _categoryService.GetAll();
            return _mapper.Map<IEnumerable<ProductCategoryViewModel>>(items);
        }

        //List
        public async Task<ActionResult> Index(int pageSize = 10, int pageIndex = 0)
        {
            var items = _mapper.Map<IEnumerable<ProductViewModel>>(await _service.GetItems(pageSize, pageIndex));
            return View(items);
        }

        //Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await GetAllCategory(), "Id", "Name", 1);
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CategoryId")] ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(_mapper.Map<ProductCore>(item));
                return Json(new { success = true });
            }
            ViewBag.CategoryId = new SelectList(await GetAllCategory(), "Id", "Name", item.CategoryId);

            return Json(item, JsonRequestBehavior.AllowGet);
        }

        //Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _mapper.Map<ProductViewModel>(await _service.GetById(id.Value));
            ViewBag.CategoryId = new SelectList(await GetAllCategory(), "Id", "Name", product.CategoryId);
            return PartialView(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CategoryId")] ProductViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(_mapper.Map<ProductCore>(item));
                return Json(new { success = true });
            }
            ViewBag.CategoryId = new SelectList(await GetAllCategory(), "Id", "Name", item.CategoryId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        //Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _mapper.Map<ProductViewModel>(await _service.GetById(id.Value));
            return PartialView(product);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductViewModel item)
        {
            var product = await _service.GetById(item.Id);
            await _service.Delete(product);
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            _categoryService.Dispose();
            base.Dispose(disposing);
        }
    }
}