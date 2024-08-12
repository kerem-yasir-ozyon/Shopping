using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shopping.BLL.Managers.Concrete;
using Shopping.ViewModel.Category;

namespace ShoppingAdmin.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryManager _categoryManager;

        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<CategoryViewModel> list = _categoryManager.GetAll();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            CategoryViewModel? model = _categoryManager.Get(id);
            return View(model);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();
            return View(model);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.AppUserId = 1;

                if(_categoryManager.Add(model) > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("DbError", "Veri tabanı ekleme hatası");

                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                ModelState.AddModelError("GeneralInnerException", ex.InnerException?.Message);
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryViewModel model = _categoryManager.Get(id);

            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                model.AppUserId = 1;

                if (_categoryManager.Update(model) > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("DbError", "Veri tabanı ekleme hatası");

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GeneralException", ex.Message);
                ModelState.AddModelError("GeneralInnerException", ex.InnerException?.Message);
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            _categoryManager.Delete(id);

            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
