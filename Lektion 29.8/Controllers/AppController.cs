using ExempelProject.Data;
using ExempelProject.Services;
using ExempelProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExempelProject.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;
        private readonly ExempelProjectContext context;

        public AppController(IMailService mailService, ExempelProjectContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }
      
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            
          
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailService.SendMessage("nina@kicanovic.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent!";
            }
            return View();
        }
        
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
        public IActionResult Shop()
        {
            var results = from p in context.Products
                         orderby p.Category
                         select p;
            return View(results.ToList());
        }
    }
}
