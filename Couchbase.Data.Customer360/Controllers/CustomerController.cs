using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Couchbase.Data.Customer360.Models;
using Couchbase.Data.Customer360.Models.Repositories;

namespace Couchbase.Data.Customer360.Controllers
{
    public class CustomerController : Controller
    {
          private CustomerRepository _repository;

          public CustomerController()
            : this(new CustomerRepository(ClusterHelper.GetBucket("customer360")))
        {
        }

        public CustomerController(CustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_repository.SelectAllCustomers(0, 10));
        }

        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            return View(_repository.Find(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public JsonResult Create(Customer customer)
        {
       
            try
            {
                _repository.Save(customer);
                return Json("success");
            }
            catch
            {
                return Json("Error");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_repository.Find(id));
        }
        // PUT: Customer/Edit/5
        [HttpPut]
        public JsonResult Edit(Customer customer)
        {
            try
            {
                var results = _repository.EditWithReply(customer);

                return Json(results);
            }
            catch
            {
                return Json("failed");
            }
        }
        // POST: Customer/Edit/5
 /*       [HttpPost]
        public JsonResult Edit(Customer customer)
        {
            try
            {
                var results = _repository.EditWithReply(customer);

                return Json(results);
            }
            catch
            {
                return Json("failed");
            }
        }
  * */

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // DELETE: Customer/Delete/5
        [HttpDelete]
        public JsonResult Delete(Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
               var result= _repository.RemoveWithReply(customer);
               return Json(result);
            }
            catch
            {
                return Json("failed");
            }
        }
    }
}
