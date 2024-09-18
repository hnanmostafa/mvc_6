using Demo.BusinessLogicLayer.Interfaces;
using Demo.BusinessLogicLayer.Repositories;
using Demo.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PresentationLayer.Controllers
{
    public class DepartmentsController : Controller
    {

      // private IGendericRepository<Department> _DepartmentRepository;
      private IDepartmentRepository _DepartmentRepository;
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _DepartmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            // Retrieve All Department
            var departments= _DepartmentRepository.GetAll();
            return View(departments);
        }

        public IActionResult Create() 
        { 
         return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid) return View(department);
            _DepartmentRepository.Create(department);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id) => DepartmentContollorModeler(id, nameof(Details));
     
        public IActionResult Edit(int? id) => DepartmentContollorModeler(id, nameof(Edit));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if(id != department.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _DepartmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(department);
        }
        public IActionResult Delete(int? id) => DepartmentContollorModeler(id,nameof(Delete));


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete( int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _DepartmentRepository.Get(id.Value);
            if (department is null) return NotFound();
        
            {
                try
                {
                    _DepartmentRepository.Delete(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(department);
        }
        private IActionResult DepartmentContollorModeler(int? id,string viewName)
        {
            if (!id.HasValue) return BadRequest();
            var department = _DepartmentRepository.Get(id.Value);
            if (department is null) return NotFound();
            return View(viewName,department);
        }
    }
}
