using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartFleet.Entities;

namespace SmartFleet.WebApi.Models
{
    public class ModelFactory
    {
        public DriverModel Create(Driver entity)
        {
            return new DriverModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public TruckModel Create(Truck entity)
        {
            return new TruckModel()
            {
                Id = entity.Id,
                Plate = entity.Plate
            };
        }

        public DispatchItemModel Create(DispatchItem entity)
        {
            return new DispatchItemModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Quantity = entity.Quantity
            };
        }

        public DispatchModel Create(Dispatch entity)
        {
            return new DispatchModel()
            {
               Id = entity.Id,
               ContactName = entity.ContactName,
               ContactAddress = entity.ContactAddress,
               ContactPhone = entity.ContactPhone,
               ContactEmail = entity.ContactEmail,
               ArrivedAt = entity.ArrivedAt,
               Identifier = entity.Identifier,
               Latitude = entity.Latitude,
               Longitude=entity.Longitude,
               Items = entity.Items.Select( Create)
            };
        }

        public RouteModel Create(Route entity)
        {
            return new RouteModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                DriverId = entity.DriverId,
                TruckId = entity.TruckId,
                Truck = Create(entity.Truck),
                Driver = Create(entity.Driver),
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Dispatches = entity.Dispatches.Select(Create)
            };
        }

        public Route Parse(RouteModel model)
        {
            try
            {
                var entity = new Route
                {
                    Id = model.Id,
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    DriverId = model.DriverId,
                    TruckId = model.TruckId,
                    Dispatches = model.Dispatches.Select(Parse).ToList()
                };

                if (model.Driver != null)
                    entity.Driver = Parse(model.Driver);

                if (model.Truck != null)
                    entity.Truck = Parse(model.Truck);
                

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        private Dispatch Parse(DispatchModel model)
        {
            var entity = new Dispatch
            {
                Identifier = model.Identifier,
                ArrivedAt = model.ArrivedAt,
                Id = model.Id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Items = model.Items.Select(Parse).ToList()
            };
            return entity;
        }

        private DispatchItem Parse(DispatchItemModel model)
        {
            var entity = new DispatchItem
            {
                Id = model.Id, 
                Name = model.Name, 
                Quantity = model.Quantity
            };
            return entity;
        }

        private Driver Parse(DriverModel model)
        {
            var entity = new Driver
            {
                Id = model.Id,
                Name = model.Name
            };
            return entity;
        }

        private Truck Parse(TruckModel model)
        {
            var entity = new Truck
            {
                Id = model.Id,
                Plate = model.Plate
            };
            return entity;
        }
       
    }
}