using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Models;
using System.Diagnostics;

namespace StudentCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NHibernate.ISession _session;


        public HomeController(ILogger<HomeController> logger, NHibernate.ISession session)
        {
            _logger = logger;
            _session = session;
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.CreatedAt = DateTime.Now;
            //student.UpdatedAt = DateTime.Now;
          
            if (ModelState.IsValid)
            {
                try
                {
                    using var transaction = _session.BeginTransaction();
                    _session.Save(student);
                    transaction.Commit();

                    return RedirectToAction("GetAll");
                    //return Json(new { redirectUrl = Url.Action("GetAll") });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");
                    return View("Create");
                }
            }

            return View("Create");
        }


        public IActionResult SerializedJSON()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SerializedJSON([FromBody] Student student)
        {
            student.CreatedAt = DateTime.Now;
            //student.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    using var transaction = _session.BeginTransaction();
                    _session.Save(student);
                    transaction.Commit();

                    //return RedirectToAction("GetAll");
                    return Json(new { redirectUrl = Url.Action("GetAll") });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");
                    return View("Create");
                }
            }

            return View("Create");
        }





        public IActionResult GetAll()
        {
            try
            {
                List<Student> students = _session.Query<Student>().ToList();
                return View(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }


        [HttpGet]
        public IActionResult GetById(int? id)
        {
            if(!id.HasValue)
            {
                ViewData["ErrorMessage"] = "Please provide a student id";
                return View();
            }
            
            var student = _session.Get<Student>(id.Value);

            if (student == null) 
            {
                ViewData["ErrorMessage"] = "No id found";
                return View();
            }
          
            ////_session.QueryOver<Student>(id).Where(x => x.Id == id).ToList();
            ////_session.Get<Student>(id) as Student;
            return View(student);
        }



        public IActionResult Edit(int id)
        {
            try
            {
                Student student = _session.Get<Student>(id);
                if (student == null)
                {
                    return NotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while editing. Please try again later.");
            }
        }




        [HttpPost]
        public IActionResult EditUpdate(int id,Student student)
        {
            var studentSearch = _session.Get<Student>(id);
            if (studentSearch == null)
            {
                return NotFound();
            }

            try
            {
                studentSearch.Name = student.Name;
                studentSearch.Age = student.Age;
                studentSearch.Email = student.Email;
                studentSearch.UpdatedAt = DateTime.Now;

                using var transaction = _session.BeginTransaction();
                _session.Update(studentSearch);
                transaction.Commit();


                return RedirectToAction("GetAll");

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }

            return RedirectToAction("GetAll");

        }


        public IActionResult Delete(int id)
        {
            using var transaction = _session.BeginTransaction();

            try
            {
                var student = _session.Get<Student>(id);
                if (student == null)
                {
                    return NotFound();
                }

                _session.Delete(student);
                transaction.Commit();
                return RedirectToAction("GetAll");

            }
            catch (Exception ex) 
            {
                transaction.Rollback();
                return StatusCode(500,"An error occured while deleting the student");
            }

        }

       


public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
