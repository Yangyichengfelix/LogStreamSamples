using AutoMapper;
using Mac2sAPI.Data;
using Mac2sAPI.Dtos.ActivityReport;
using Mac2sAPI.Dtos.ApiUser;
using Mac2sAPI.Dtos.Gauge;
using Mac2sAPI.Dtos.Image;
using Mac2sAPI.Dtos.Log;
using Mac2sAPI.Dtos.LogDuration;
using Mac2sAPI.Dtos.Mold;
using Mac2sAPI.Dtos.Product;
using Mac2sAPI.Dtos.ProductionOrder;
using Mac2sAPI.Dtos.Schedule;
using Mac2sAPI.Dtos.Sensor;
using Mac2sAPI.Dtos.Status;
using Mac2sAPI.Dtos.StatusDuration;
using Mac2sAPI.Dtos.StatusGroup;
using Mac2sAPI.Dtos.StatusGroupDuration;

namespace Mac2sAPI.Configurations
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {

            CreateMap<ApiUser, UserDto>().ReverseMap();
            CreateMap<LogDuration, LogDurationDto>()
                .ForMember(a => a.StatusName, d => d.MapFrom(map => $"{map.Status.Name}"))
                .ForMember(a=>a.Ref_S1, d=>d.MapFrom(map=>$"{map.ProductionOrder.Product.Mold.Ref_S1}"))
                .ForMember(a => a.Ref_S2, d => d.MapFrom(map => $"{map.ProductionOrder.Product.Mold.Ref_S2}"))
                .ForMember(a => a.Ref_S3, d => d.MapFrom(map => $"{map.ProductionOrder.Product.Mold.Ref_S3}"))
                .ForMember(a => a.Ref_S4, d => d.MapFrom(map => $"{map.ProductionOrder.Product.Mold.Ref_S4}"))
                .ForMember(a => a.Ref_S5, d => d.MapFrom(map => $"{map.ProductionOrder.Product.Mold.Ref_S5}"))

                .ReverseMap()                
                ;
            CreateMap<Status, StatusDto>()
                .ForMember(a => a.StatusGroupName, d => d.MapFrom(map => $"{map.StatusGroup.Name}"))
                .ReverseMap();

            CreateMap<Status, StatusSimpleDto>()
                .ForMember(a => a.StatusGroupName, d => d.MapFrom(map => $"{map.StatusGroup.Name}"))
                .ReverseMap()                
                ;
            CreateMap<StatusGroup, StatusGroupDto>()
                //.ForMember(a => a.StatusGroup, d => d.MapFrom(map => $"{map.StatusGroup.Name}"))
                .ReverseMap();

            CreateMap<ActivityReport, ActivityReportDto>().ReverseMap();
            CreateMap<StatusDuration, StatusDurationDto>().ReverseMap();
            CreateMap<StatusGroupDuration, StatusGroupDurationDto>().ReverseMap();

            CreateMap<SensorGlobal, SensorGlobalDto>().ReverseMap();
            CreateMap<SensorPl, SensorPlDto>().ReverseMap();
            CreateMap<SensorUnique, SensorUniqueDto>().ReverseMap();

            CreateMap<GaugeParameter, GaugeParameterDto>().ReverseMap();
            CreateMap<ScheduleParameter, ScheduleParameterDto>().ReverseMap();
            CreateMap<ScheduleParameter, ScheduleParameterCreateDto>().ReverseMap();
            CreateMap<ScheduleParameter, ScheduleParameterUpdateDto>().ReverseMap();


            CreateMap<Image, ImageCreateDto>().ReverseMap();
            CreateMap<Log, LogDetailsDto>()
                .ReverseMap();
            CreateMap<Log, LogCreateDto>()
                .ReverseMap(); 
            CreateMap<Log, LogDto>()
                .ReverseMap();
            CreateMap<Image, ImageDto>()
                .ReverseMap();
            CreateMap<Mold, MoldDto>()
            .ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductPhotoUpdateDto>().ReverseMap();

            CreateMap<ProductionOrder, ProductionOrderDto>().ReverseMap();

        }
    }
}
