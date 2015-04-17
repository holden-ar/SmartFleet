using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SmartFleet.Business;
using SmartFleet.Core.BusinessContracts;
using SmartFleet.Entities.Security;
using SmartFleet.Web.Models;
using AutoMapper;

namespace SmartFleet.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IRoleService _roleService;
        public UserController(IUserService service, IRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_service.GetPaged(0,25));
        }

        public ActionResult Create()
        {
           
                var model = new UserAddEditViewModel();
                var r = _roleService.GetAll();
                model.Roles = Mapper.Map<List<Role>,List<RoleViewModel>>(r);
                model.SelectedRoles = new List<int>() {1,2};
     
                return View(model);

            

            
            
        }

        [HttpPost]
        public ActionResult Create(UserAddEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = Mapper.Map<UserAddEditViewModel, User>(viewModel);
                    _service.Add(entity);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }


        // GET: Demo/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _service.Find(id);
            var model = new UserAddEditViewModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Passwd = entity.Passwd,
                Email = entity.Email,
                IsBuiltInUser = entity.IsBuiltInUser,
                Enabled = entity.Enabled,
            };
            return View(model);
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(UserAddEditViewModel viewModel)
        {
            try
            {
                //todo: map with automapper
                var entity = new User()
                {
                    Id = viewModel.Id,
                    Username = viewModel.Username,
                    Passwd = viewModel.Passwd,
                    Email = viewModel.Email,
                    IsBuiltInUser = viewModel.IsBuiltInUser,
                    Enabled = viewModel.Enabled
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