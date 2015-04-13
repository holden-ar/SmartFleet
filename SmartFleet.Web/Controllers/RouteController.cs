using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SmartFleet.Core.DataContracts;
using SmartFleet.Entities;

namespace SmartFleet.Web.Controllers
{
    public class RouteController : Controller
    {
        private IRouteRepository _db;
        public RouteController(IRouteRepository db)
        {
            _db = db;
        }

        // GET: Route
        public ActionResult Index()
        {

            return View(_db.GetRoutes().ToList());
        }

        public ActionResult Add()
        {
            #region Route
            var r = new Entities.Route();
            r.Name = "Route001_1234";
            r.StartDate = DateTime.Now;
            r.EndDate = DateTime.Now.AddHours(7);
            r.TruckId = 1;
            r.DriverId = 1; 
            #endregion

            #region Dispatchs

            var d1 = new Entities.Dispatch();
            d1.ArrivedAt = DateTime.Now.AddHours(2);
            //d1.Latitude = -100;
            //d1.Longitude = -76;
            d1.Identifier = "263762";
            d1.Items.Add(new DispatchItem() { Name="Motorola X1", Quantity = 1});
            d1.Items.Add(new DispatchItem() { Name = "Simcard 351", Quantity = 1 });
            r.Dispatches.Add(d1);

            var d2 = new Entities.Dispatch();
            d2.ArrivedAt = DateTime.Now.AddHours(2);
            //d2.Latitude = -100;
            //d2.Longitude = -76;
            d2.Identifier = "263769";
            d2.Items.Add(new DispatchItem() { Name = "Motorola X2", Quantity = 2 });
            d2.Items.Add(new DispatchItem() { Name = "Simcard 352", Quantity = 2 });
            r.Dispatches.Add(d2);


            #endregion

            _db.Add(r);
            _db.Save();










            return View();
        }
    }
}