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
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //List
        public async Task<ActionResult> Index(int page = 1)
        {

            int pageSize = 10;
            var items = _mapper.Map<IEnumerable<ProductCategoryViewModel>>(await _service.GetItems(pageSize, page - 1));
            var pageInfo = new PageInfo() { PageNumber = page, PageSize = pageSize, TotalItems = await _service.Count() };
            ProductCategoryListViewModel categorytList = new ProductCategoryListViewModel() { Categories = items, PageInfo = pageInfo };
            return View(categorytList);
        }

        //Create
        public async Task<ActionResult> Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] ProductCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(_mapper.Map<ProductCategoryCore>(item));
                return Json(new { success = true });
            }
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        //Edit
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _mapper.Map<ProductCategoryViewModel>(await _service.GetById(id.Value));
            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name")] ProductCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(_mapper.Map<ProductCategoryCore>(item));
                return Json(new { success = true });
            }
            return Json(item, JsonRequestBehavior.AllowGet);
        }


        //Delete
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _mapper.Map<ProductCategoryViewModel>(await _service.GetById(id.Value));
            return PartialView(category);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductCategoryViewModel item)
        {
            await _service.Delete(await _service.GetById(item.Id));
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}