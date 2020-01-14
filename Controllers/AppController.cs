using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
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
                // send the email
                _mailService.SendMessage("bogdan.manole92@gmail.com", model.Subject, $"From:{model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {

            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        [Authorize]
        public IActionResult Shop()
        {
            return View();
        }
    }
}
