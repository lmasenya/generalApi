using generalapi.Models;
using generalapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generalapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase 
    {

        private readonly ILogger<CustomerController> _logger;
        customerservice Custobj = new customerservice();
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Customer> getallcustomers()
        {
           
            return Custobj.getallcustomers();
        }
        [HttpGet("{id:int}")]
        public Customer getallcustomerbyid(int id)
        {
            //
            return Custobj.GetcustomerAsync(id).Result;

        }
        [HttpPost]
        public void setincustomer(Customer cust)
        {
            string val = Custobj.setcustomerAsync(cust).Result;
        }
        [HttpPut]
        public void updatecustomerd(Customer cust)
        {
            string val = Custobj.updatecustomer(cust).Result;
        }
        [HttpDelete("{id:int}")]
        public void deletecustomerwithid(int id)
        {
            string val = Custobj.deletecustomer(id).Result;
        }
     
        // GET: CustomerController
        /*    public ActionResult Index()
            {
               customerservice Custobj = new customerservice();
            Custobj.getallcustomers();
            }

            // GET: CustomerController/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }

            // GET: CustomerController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: CustomerController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: CustomerController/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: CustomerController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: CustomerController/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: CustomerController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }*/
    }
}
