using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profile.BLL;
using Profile.DAL;

namespace Profile.Controllers
{
    public class LoginController : Controller
    {

        #region Dependencys
        private PersonBLL personBLL;

        #endregion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            //Authenticate User
            personBLL = new PersonBLL();
            var ticket = personBLL.GetPersonSecurity(username, password);
            if (ticket != null)
            {
                //Create Token Welcome

                ViewBag.UserToken = ticket.PersonEntityID;
                
                //Redirect To Home
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}