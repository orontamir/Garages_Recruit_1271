using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garages_Recruit_1271.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Garages_Recruit_1271.Controllers
{
    public class PortalController : Controller
    {

        private readonly IUserRepository _userRepository;

        private readonly IHostingEnvironment _hostingEnvironment;


        public PortalController(IUserRepository userRepository, IHostingEnvironment hostingEnvironment)
        {
            _userRepository = userRepository;
            this._hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index()
        {
             var userRepository= _userRepository.GetAllUsers();
             return View(userRepository);
        }
    }
}