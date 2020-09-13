using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration, IMessageRepository messageRepository)
        {
            _newBookAlertconfiguration = newBookAlertconfiguration.Value;
            _messageRepository = messageRepository;
        }

        public ViewResult Index()
        {
            bool isDisplay = _newBookAlertconfiguration.DisplayNewBookAlert;

            var value = _messageRepository.GetName();

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

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
