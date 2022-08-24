using ExempelProject.Services;
using ExempelProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExempelProject.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService mailService;

        public AppController(IMailService mailService)
        {
            this.mailService = mailService;
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
    }
}
