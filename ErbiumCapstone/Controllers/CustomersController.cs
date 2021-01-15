﻿
using ErbiumCapstone.Contracts;
using ErbiumCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Controllers
{
    public class CustomersController : Controller
    {
        private IRepositoryWrapper _repo;
        public CustomersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // pass in repository in our constructor
        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _repo.Customer.GetCustomer(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _repo.Customer.Add(customer);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customerToEdit = _repo.Customer.Edit(id);
            return View(customerToEdit);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer updatedCustomer)
        {
            try
            {
                _repo.Customer.Update(updatedCustomer);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
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
        }
    }
}
