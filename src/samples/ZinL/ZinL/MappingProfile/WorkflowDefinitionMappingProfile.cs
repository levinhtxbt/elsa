using AutoMapper;
using Elsa.Dashboard.Areas.Elsa.ViewModels;
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
            CreateMap<WorkflowDefinitionEditModel, WorkflowDefinitionDetailResponse>();
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionCreateResponse>();
            CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionEditResponse>();

            CreateMap<WorkflowDefinitionListViewModel, WorkflowDefinitionListResponse1>()
                .ForMember(x => x.WorkflowDefinitions, 
                    opt => opt.MapFrom(y => y.WorkflowDefinitions));

            //CreateMap<WorkflowDefinitionListViewModel, WorkflowDefinitionListResponse1>()
            //    .ForMember(x => x.WorkflowDefinitions,
            //        opt => opt.MapFrom(y =>
            //            Mapper.Map<IList<IGrouping<string, WorkflowDefinitionListItemModel>>, IList<IGrouping<string, WorkflowDefinitionResponse>>>(y).ToArray()));

            //CreateMap<WorkflowDefinitionListItemModel, WorkflowDefinitionResponse>()
            //    .ForMember(x => x.WorkflowDefinition, opt => opt.MapFrom(x => x.WorkflowDefinition));

            //CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionVersionResponse>();
        }
    }
}
