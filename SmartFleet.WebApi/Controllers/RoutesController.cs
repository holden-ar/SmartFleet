using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartFleet.Core.DataContracts;
using SmartFleet.Data;
using SmartFleet.Entities;
using SmartFleet.WebApi.Models;

namespace SmartFleet.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        private IRouteRepository _repository;
        public RoutesController(IRouteRepository repository)
        {
           _repository = repository;
        }
        // GET: api/Routes
        public HttpResponseMessage Get()
        {
            var mf = new Models.ModelFactory();
            var lst = _repository.GetRoutes(true).Take(25).ToList().Select(mf.Create);
            return Request.CreateResponse(HttpStatusCode.OK, lst);

        }

        // GET: api/Routes/5
        public HttpResponseMessage Get(int id)
        {
            var mf = new Models.ModelFactory();
            var route = _repository.GetRoutes(true).Where(x => x.Id == id).Select(mf.Create).FirstOrDefault();
            if (route == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, route);
        }

        // POST: api/Routes
        public HttpResponseMessage Post([FromBody]RouteModel model)
        {
            try
            {
                var mf = new ModelFactory();
                var entity = mf.Parse(model);

                //Checks if data is valid
                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is not valid!");
                }
                //Checks if route name already exist
                if (_repository.GetRoutes().Count(r => r.Name.ToUpper().Equals(entity.Name.ToUpper())) > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The route name already exist!");
                }

                //Creates the route
                _repository.Add(entity);
                _repository.Save();


                return Request.CreateResponse(HttpStatusCode.Created,entity.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        // PUT: api/Routes/5
        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Put([FromBody]RouteModel model)
        {
            try
            {
                var mf = new ModelFactory();
                var entity = mf.Parse(model);

                //Checks if data is valid
                if (entity == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is not valid!");
                }

                //Verify if exists
                if (_repository.GetRoutes().Any(r => r.Id == entity.Id) == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                //Updates the route
                _repository.Update(entity);
                _repository.Save();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Routes/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (_repository.GetRoutes().Any(r=>r.Id == id) == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                //Deletes the route
                if (_repository.Delete(id) && _repository.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
