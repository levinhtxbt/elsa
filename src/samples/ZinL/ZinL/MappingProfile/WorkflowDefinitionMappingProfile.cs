using AutoMapper;
using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZinL.Models;

namespace ZinL.MappingProfile
{
    public class WorkflowDefinitionMappingProfile : Profile
    {
        public WorkflowDefinitionMappingProfile()
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
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionListResponse>();
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionDetailResponse>();
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionCreateResponse>();
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionEditResponse>();
        }
    }
}
