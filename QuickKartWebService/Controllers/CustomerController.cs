using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickKart_BusinessLayer;
using QuickKart_DataAccessLayer;
using System;

namespace QuickKartWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        //added comment-second commit
        public CustomerLogic custLogic;
        private readonly ILogger<CustomerRepository> logger;

        public CustomerController(ILogger<CustomerRepository> _logger)
        {
            logger = _logger;
            custLogic = new CustomerLogic(logger);
        }


        //deployment slot feature
        [HttpGet]
        public bool AddNewSubscriber(string emailID)
        {
            bool result = false;
            try
            {
                result=custLogic.AddSubscriberBL(emailID);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }





    }
}
