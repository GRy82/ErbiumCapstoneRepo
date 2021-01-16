using ErbiumCapstone.Contracts;
using ErbiumCapstone.Data;
using ErbiumCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone.Controllers
{
    public class ContractorsController : Controller
    {
        private IRepositoryWrapper _repo;
        public ContractorsController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        // GET: ContractorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContractorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContractorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contractor contractor)
        {
            try
            {
                _repo.Contractor.CreateContractor(contractor);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Edit/5
        public ActionResult Edit(int id)
        {
            Contractor contractor = _repo.Contractor.GetContractor(id);
            return View(contractor);
        }

        // POST: ContractorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contractor contractor)
        {
            try
            {
                _repo.Contractor.EditContractor(contractor);
                _repo.Save();
                return View(contractor);
            }
            catch
            {
                return View();
            }
        }

        // GET: ContractorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContractorController/Delete/5
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
