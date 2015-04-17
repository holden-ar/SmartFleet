using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SmartFleet.Entities.Security;
using SmartFleet.Web.Models;

namespace SmartFleet.Web.App_Start
{
    public class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.CreateMap<User, UserAddEditViewModel>();
            Mapper.CreateMap<UserAddEditViewModel, User>();


            Mapper.CreateMap<Role, RoleViewModel>();




        

            //Mapper.CreateMap<ObjectiveAssessmentConfigEntity, ObjectiveAssessmentConfigAddEditViewModel>();
            //Mapper.CreateMap<ObjectiveAssessmentConfigAddEditViewModel, ObjectiveAssessmentConfigEntity>();
            //Mapper.CreateMap<ObjectivesAssessmentEntity, ObjectivesAssessmentAddEditViewModel>();
            //Mapper.CreateMap<ObjectivesAssessmentValuesEntity, ObjectivesAssessmentValuesAddEditViewModel>();

            //Mapper.CreateMap<ObjectiveAssessmentConfigEntity, ObjectiveAssessmentConfigDetailsViewModel>();
            //Mapper.CreateMap<ObjectivesAssessmentEntity, ObjectivesAssessmentDetailsViewModel>();
            //Mapper.CreateMap<ObjectivesAssessmentValuesEntity, ObjectivesAssessmentValuesDetailsViewModel>();

        }
    }
}