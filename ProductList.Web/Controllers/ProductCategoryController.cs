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
        public async Task<ActionResult> Index(int pageSize = 10, int pageIndex = 1)
        {
            var itemsDto = _mapper.Map<IEnumerable<ProductCategoryViewModel>>(await _service.GetItems(pageSize, pageIndex));
            return View(itemsDto);
        }

        //Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id, Name")] ProductCategoryViewModel item)
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

            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Name")] ProductCategoryViewModel item)
        {
            if (ModelState.IsValid)
            {
                _mapper.Map<ProductCategoryViewModel>(await _service.Update(_mapper.Map<ProductCategoryCore>(item)));
                return Json(new { success = true });
            }
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        //Delete
        public ActionResult Delete()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(await _service.GetById(id));
            return Json(new { success = true });
        }

    }
}