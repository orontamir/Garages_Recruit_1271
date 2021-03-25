using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garages_Recruit_1271.Models;
using Microsoft.AspNetCore.Mvc;
using Garages_Recruit_1271.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Garages_Recruit_1271.Security;

namespace Garages_Recruit_1271.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly IHostingEnvironment _hostingEnvironment;
        //private readonly IDataProtector protector;

        public HomeController(IUserRepository userRepository, IHostingEnvironment hostingEnvironment,
            IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            _userRepository = userRepository;
            this._hostingEnvironment = hostingEnvironment;
      //      protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }
     
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
             var userRepository= _userRepository.GetAllUsers();
             return View(userRepository);
            //return View();

        }

        

       // [Route("Home/Details/{id?}")]
        public ViewResult Details(int id)
        {
          //  int userId = Convert.ToInt32(protector.Unprotect(id));
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                User = _userRepository.GetUser(id),
                PageTitle = "User Details"
            };
           //  User model = _userRepository.GetUser(1);
            //ViewBag.User = model;
            ViewBag.PageTitle = "User Details";
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ViewResult Edit(int id)
        {
            User _user = _userRepository.GetUser(id);
            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                Id = _user.Id,
                Name = _user.Name,
                Mail = _user.Mail,
                Address = _user.Address,
                ExistingPhotoPath = _user.PhotoPath,
                Password = _user.Password
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User _user = _userRepository.GetUser(model.Id);
                _user.Name = model.Name;
                _user.Mail = model.Mail;
                _user.Password = model.Password;
                _user.Phone = model.Phone;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    string uniqFileName = ProcessUploadedFile(model);
                }

               
                _userRepository.Update(_user);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(CreateUserViewModel model)
        {
            string uniqFileName = null;
            if (model.Photo != null)
            {

                string uploadFolder = Path.Combine(this._hostingEnvironment.WebRootPath, "images");
                uniqFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            return uniqFileName;
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqFileName = ProcessUploadedFile(model);
                
                User newUser = new User
                {
                    Name = model.Name,
                    Password = model.Password,
                    Address = model.Address,
                    Phone = model.Phone,
                    UpdateDate = DateTime.Now,
                    CreationDate = DateTime.Now,
                    Mail  = model.Mail,
                    PhotoPath = uniqFileName
                };
                _userRepository.AddUser(newUser);
                return RedirectToAction("details", new { id = newUser.Id });
            }
            return View();
        }

    }
}