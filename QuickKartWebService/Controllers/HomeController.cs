using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickKart_BusinessLayer;
using QuickKart_DataAccessLayer;
using QuickKart_DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace QuickKartWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public HomeLogic homeLogic;
        private readonly ILogger<CustomerRepository> logger;

        public HomeController(ILogger<CustomerRepository> _logger)
        {
            logger= _logger;
            homeLogic = new HomeLogic(logger);
        }
        


        [HttpGet]
        public List<Product> GetProducts()
        {
            List<Product> prodList = null;
            try
            {
                prodList = homeLogic.FetchProductsLogic();
            }
            catch (Exception e)
            {

                logger.LogError("Exception thrown in HomeController "+e.Message);
            }
            return prodList;

        }


    }
}
