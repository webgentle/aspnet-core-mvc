using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;
using Webgentle.BookStore.Service;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,
            IMessageRepository messageRepository,
            IUserService userService,
            IEmailService emailService)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<ViewResult> Index()
        {

            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com"},
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}", "John")
            //    }
            //};

            //await _emailService.SendTestEmail(options);

            //var userId = _userService.GetUserId();
            //var isLoggedIn = _userService.IsAuthenticated();

            //bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;
            //bool isDisplay1 = _thirdPartyBookconfiguration.DisplayNewBookAlert;

            //var value = _messageRepository.GetName();

            //var newBook = configuration.GetSection("NewBookAlert");
            //var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBook.GetValue<string>("BookName");

            //var result = configuration["AppName"];
            //var key1 = configuration["infoObj:key1"];
            //var key2 = configuration["infoObj:key2"];
            //var key3 = configuration["infoObj:key3:key3obj1"];
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        // Uncomment the below line to enable roles on this action method.
        //[Authorize(Roles ="Admin,User")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
