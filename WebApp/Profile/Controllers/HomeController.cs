using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

//Dependencys
using Profile.Models;
using Profile.BLL;

namespace Profile.Controllers
{
    public class HomeController : Controller
    {
        #region Dependency
        private const string url = "https://maps.googleapis.com/maps/api/js?key=";

        private PersonBLL personBLL;
        private EducationBLL educationBLL;
        private ExperienceBLL experienceBLL;
        private SkillBLL skillBLL;
        private ProjectWorkBLL projectWorkBLL;
        private CommentBLL commentBLL;
        private ContactBLL contactBLL;
        private PricingBLL pricingSkillBLL;

        #endregion

        #region Actions
        public IActionResult Index()
        {
            personBLL = new PersonBLL();
            var modelPerson = personBLL.GetPerson();
            if (modelPerson == null) { return NotFound(); }
            else { ViewBag.Person = modelPerson; }

            //Education
            educationBLL = new EducationBLL();
            var modelEducation = educationBLL.GetCollectionEducation();
            if (modelEducation == null) { return NotFound(); }
            else { ViewBag.Education = modelEducation; }

            //Experience
            experienceBLL = new ExperienceBLL();
            var modelExperience = experienceBLL.GetCollectionExperience();
            if (modelExperience == null) { return NotFound(); }
            else { ViewBag.Experience = modelExperience; }

            //Skill Coding
            skillBLL = new SkillBLL();
            var modelSkillCode = skillBLL.GetCollectionSkillsByType("C");
            if (modelSkillCode == null) { return NotFound(); }
            else { ViewBag.SkillsCoding = modelSkillCode; }

            //Skill Others
            var modelSkillOthers = skillBLL.GetCollectionSkillsByType("O");
            if (modelSkillOthers == null) { return NotFound(); }
            else { ViewBag.SkillsOthers = modelSkillOthers; }

            //Pricing Freelancer Skill
            pricingSkillBLL = new PricingBLL();
            var modelPricing = pricingSkillBLL.GetPricingByType("FL");
            if (modelPricing == null) { return NotFound(); }
            else { ViewBag.PricingSkillFreelancer = modelPricing; }

            //Pricing Freelancer Skills Collection
            var modelPSCollection = pricingSkillBLL.GetCollectionPricingSkill("FL");
            if (modelPSCollection == null) { return NotFound(); }
            else { ViewBag.PricingSkillCollectionFreelancer = modelPSCollection; }

            //Pricing Fulltime Skill
            var modelPricingFullTime = pricingSkillBLL.GetPricingByType("FT");
            if (modelPricingFullTime == null) { return NotFound(); }
            else { ViewBag.PricingSkillFulltime = modelPricingFullTime; }

            //Pricing FullTime Skills Collection 
            var modelPSFullTimeCollection = pricingSkillBLL.GetCollectionPricingSkill("FT");
            if (modelPSFullTimeCollection == null) { return NotFound(); }
            else { ViewBag.PricingSkillCollectionFulltime = modelPSFullTimeCollection; }

            //Project Work
            projectWorkBLL = new ProjectWorkBLL();
            var modelProjectWork = projectWorkBLL.GetCollectionProjectWorkFactory();
            if (modelProjectWork == null) { return NotFound(); }
            else { ViewBag.ProjectWorkCollection = modelProjectWork; }

            //Comments
            commentBLL = new CommentBLL();
            var modelComment = commentBLL.GetCollectionComment();
            if (modelComment == null) { return null; }
            else { ViewBag.Comments = modelComment; }

            //Contacts
            contactBLL = new ContactBLL();
            var modelContact = contactBLL.GetCollectionContact();
            if (modelContact == null) { return null; }
            else { ViewBag.Contacts = modelContact; }

            return View();
        }

        public IActionResult Dashboard()
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

        #endregion

        #region Post

        [HttpPost]
        public bool PutContact(Contact contact)
        {
            bool status = false;

            contactBLL = new ContactBLL();
            if (ModelState.IsValid)
            {
                status = contactBLL.PutContact(contact);
            }

            return status;
        }

        [HttpPost]
        public bool PutComment(Comment comment)
        {
            commentBLL = new CommentBLL();
            bool status = commentBLL.PutComment(comment);
            return status;
        }

        #endregion
    }
}
