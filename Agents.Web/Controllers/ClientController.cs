using People.BusinessLogic.Models;
using People.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agents.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Client
        public ActionResult Index()
        {
            var items = _clientService.GetAll<ClientListItem>();
            return View(items);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var item = _clientService.GetById<ClientModel>(id);
            return View(item);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(new ClientModel());

        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                _clientService.Insert(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _clientService.GetById<ClientModel>(id);
            return View(item);
        }

        // POST: Client/Edit
        [HttpPost]
        public ActionResult Edit(ClientModel model)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                _clientService.Update(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientModel model)
        {
            // TODO: Add delete logic here
            _clientService.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
