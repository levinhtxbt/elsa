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
    public class AWFDefinitionMappingProfile : Profile
    {
        public AWFDefinitionMappingProfile()
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
            CreateMap<WorkflowDefinitionVersion, AWFDefinitionListResponse>();
            CreateMap<WorkflowDefinitionEditModel, AWFDefinitionDetailResponse>();
            CreateMap<WorkflowDefinitionVersion, AWFDefinitionCreateResponse>();
            CreateMap<WorkflowDefinitionVersion, AWFDefinitionEditResponse>();

            //CreateMap<WorkflowDefinitionVersion, WorkflowDefinitionVersionResponse>();
            //CreateMap<WorkflowDefinitionListItemModel, WorkflowDefinitionResponse>();
            //CreateMap<WorkflowDefinitionListViewModel, WorkflowDefinitionListResponse1>();


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
