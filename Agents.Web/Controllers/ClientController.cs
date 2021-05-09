using People.BusinessLogic.Services;
using People.Models;
using System.Web.Mvc;

namespace Agents.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientManager _manager;
        private readonly ClientProvider _provider;

        public ClientController(ClientManager manager, ClientProvider provider)
        {
            _manager = manager;
            _provider = provider;
        }

        // GET: Client
        public ActionResult Index()
        {
            var items = _provider.GetAll<ClientListItem>();
            return View(items);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var item = _provider.GetById<ClientModel>(id);
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
                _manager.Insert(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _provider.GetById<ClientModel>(id);
            return View(item);
        }

        // POST: Client/Edit
        [HttpPost]
        public ActionResult Edit(ClientModel model)
        {
            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                _manager.Update(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            _manager.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(ClientModel model)
        {
            // TODO: Add delete logic here
            _manager.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
