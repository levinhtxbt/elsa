using AutoMapper;
using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZinL.Models;
using ZinL.Models.Definition;
using ZinL.Models.Instance;

namespace ZinL.MappingProfile
{
    public class AWFInstanceMappingProfile : Profile
    {
        public AWFInstanceMappingProfile()
        {
            ModelToResponse();
            RequestToModel();
        }

        private void RequestToModel()
        {
            //CreateMap<ContainerCreateRequest, Container>();
        }

        private void ModelToResponse()
        {
            CreateMap<WorkflowInstanceDetailsModel, AWFInstanceDetailResponse>();
                //.ForMember(x => x.WorkflowDefinition, opt => opt.MapFrom(src => src.WorkflowDefinition))
                //.ForMember(x => x.WorkflowInstance, opt => opt.MapFrom(src => src.WorkflowInstance));
            //CreateMap<WorkflowDefinitionEditModel, AWFDefinitionDetailResponse>();
            //CreateMap<WorkflowDefinitionVersion, AWFDefinitionCreateResponse>();
            //CreateMap<WorkflowDefinitionVersion, AWFDefinitionEditResponse>();
        }
    }
}
