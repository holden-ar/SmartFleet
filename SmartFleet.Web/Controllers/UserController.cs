using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartFleet.Business;
using SmartFleet.Entities.Security;
using SmartFleet.Web.Models;

namespace SmartFleet.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_service.GetPaged(0,25));
        }

        public ActionResult Create()
        {
            var user = _service.Find(1);


            return View(new UserAddEditModel());
        }

        [HttpPost]
        public ActionResult Create(UserAddEditModel model)
        {
            try
            {
                //todo: map with automapper
                var entity = new User()
                {
                    Id = model.Id,
                    Username = model.Username,
                    Passwd = model.Passwd,
                    Email = model.Email,
                    IsBuiltInUser = model.IsBuiltInUser,
                    Enabled = model.Enabled
                };
                _service.Add(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _service.Find(id);
            var model = new UserAddEditModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Passwd = entity.Passwd,
                Email = entity.Email,
                IsBuiltInUser = entity.IsBuiltInUser,
                Enabled = entity.Enabled
            };
            return View(model);
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(UserAddEditModel model)
        {
            try
            {
                //todo: map with automapper
                var entity = new User()
                {
                    Id = model.Id,
                    Username = model.Username,
                    Passwd = model.Passwd,
                    Email = model.Email,
                    IsBuiltInUser = model.IsBuiltInUser,
                    Enabled = model.Enabled
                };
                _service.Edit(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}