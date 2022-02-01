using AutoMapper;
using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.DataAccess.Entities;

namespace ManufacturerManagerTS.BusinessLogic.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Colour

            CreateMap<ColourEntity, Colour>()
                .ForMember(opt => opt.ColourId, opt => opt.MapFrom(o => o.ColourId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name));

            CreateMap<Colour, ColourEntity>()
                .ForMember(opt => opt.ColourId, opt => opt.MapFrom(o => o.ColourId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name));

            #endregion

            #region ColourJustification

            CreateMap<ColourJustificationEntity, ColourJustification>()
                .ForMember(opt => opt.ColourJustificationId, opt => opt.MapFrom(o => o.ColourJustificationId))
                .ForMember(opt => opt.Justification, opt => opt.MapFrom(o => o.Justification));

            CreateMap<ColourJustification, ColourJustificationEntity>()
                .ForMember(opt => opt.ColourJustificationId, opt => opt.MapFrom(o => o.ColourJustificationId))
                .ForMember(opt => opt.Justification, opt => opt.MapFrom(o => o.Justification));

            #endregion

            #region Manufacturer

            CreateMap<ManufacturerEntity, Manufacturer>()
                .ForMember(opt => opt.ManufacturerId, opt => opt.MapFrom(o => o.ManufacturerId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.Created, opt => opt.MapFrom(o => o.Created))
                .ForMember(opt => opt.CreatedById, opt => opt.MapFrom(o => o.CreatedById))
                .ForMember(opt => opt.LastUpdated, opt => opt.MapFrom(o => o.LastUpdated))
                .ForMember(opt => opt.LastUpdatedById, opt => opt.MapFrom(o => o.LastUpdatedById))
                .ForMember(opt => opt.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(opt => opt.StaffMemberCreated, opt => opt.MapFrom(o => o.StaffMemberCreated))
                .ForMember(opt => opt.StaffMemberUpdated, opt => opt.MapFrom(o => o.StaffMemberUpdated))
                .ForMember(opt => opt.Widgets, opt => opt.MapFrom(o => o.Widgets));

            CreateMap<Manufacturer, ManufacturerEntity>()
                .ForMember(opt => opt.ManufacturerId, opt => opt.MapFrom(o => o.ManufacturerId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.Created, opt => opt.MapFrom(o => o.Created))
                .ForMember(opt => opt.CreatedById, opt => opt.MapFrom(o => o.CreatedById))
                .ForMember(opt => opt.LastUpdated, opt => opt.MapFrom(o => o.LastUpdated))
                .ForMember(opt => opt.LastUpdatedById, opt => opt.MapFrom(o => o.LastUpdatedById))
                .ForMember(opt => opt.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(opt => opt.StaffMemberCreated, opt => opt.MapFrom(o => o.StaffMemberCreated))
                .ForMember(opt => opt.StaffMemberUpdated, opt => opt.MapFrom(o => o.StaffMemberUpdated))
                .ForMember(opt => opt.Widgets, opt => opt.MapFrom(o => o.Widgets));

            #endregion

            #region ManufacturerStatus

            CreateMap<ManufacturerStatusEntity, ManufacturerStatus>()
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.StatusName, opt => opt.MapFrom(o => o.StatusName));

            CreateMap<ManufacturerStatus, ManufacturerStatusEntity>()
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.StatusName, opt => opt.MapFrom(o => o.StatusName));

            #endregion

            #region StaffMember

            CreateMap<StaffMemberEntity, StaffMember>()
                .ForMember(opt => opt.StaffMemberId, opt => opt.MapFrom(o => o.StaffMemberId))
                .ForMember(opt => opt.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(opt => opt.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(opt => opt.ManufacturerCreated, opt => opt.MapFrom(o => o.ManufacturerCreated))
                .ForMember(opt => opt.ManufacturerUpdated, opt => opt.MapFrom(o => o.ManufacturerUpdated))
                .ForMember(opt => opt.WidgetCreated, opt => opt.MapFrom(o => o.WidgetCreated))
                .ForMember(opt => opt.WidgetUpdated, opt => opt.MapFrom(o => o.WidgetUpdated));

            CreateMap<StaffMember, StaffMemberEntity>()
                .ForMember(opt => opt.StaffMemberId, opt => opt.MapFrom(o => o.StaffMemberId))
                .ForMember(opt => opt.FirstName, opt => opt.MapFrom(o => o.FirstName))
                .ForMember(opt => opt.LastName, opt => opt.MapFrom(o => o.LastName))
                .ForMember(opt => opt.ManufacturerCreated, opt => opt.MapFrom(o => o.ManufacturerCreated))
                .ForMember(opt => opt.ManufacturerUpdated, opt => opt.MapFrom(o => o.ManufacturerUpdated))
                .ForMember(opt => opt.WidgetCreated, opt => opt.MapFrom(o => o.WidgetCreated))
                .ForMember(opt => opt.WidgetUpdated, opt => opt.MapFrom(o => o.WidgetUpdated));

            #endregion

            #region Widget

            CreateMap<WidgetEntity, Widget>()
                .ForMember(opt => opt.WidgetId, opt => opt.MapFrom(o => o.WidgetId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(opt => opt.ManufacturerId, opt => opt.MapFrom(o => o.ManufacturerId))
                .ForMember(opt => opt.ColourId, opt => opt.MapFrom(o => o.ColourId))
                .ForMember(opt => opt.ColourJustificationId, opt => opt.MapFrom(o => o.ColourJustificationId))
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.Created, opt => opt.MapFrom(o => o.Created))
                .ForMember(opt => opt.CreatedById, opt => opt.MapFrom(o => o.CreatedById))
                .ForMember(opt => opt.LastUpdated, opt => opt.MapFrom(o => o.LastUpdated))
                .ForMember(opt => opt.LastUpdatedById, opt => opt.MapFrom(o => o.LastUpdatedById))
                .ForMember(opt => opt.Manufacturer, opt => opt.MapFrom(o => o.Manufacturer))
                .ForMember(opt => opt.Colour, opt => opt.MapFrom(o => o.Colour))
                .ForMember(opt => opt.ColourJustification, opt => opt.MapFrom(o => o.ColourJustification))
                .ForMember(opt => opt.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(opt => opt.StaffMemberCreated, opt => opt.MapFrom(o => o.StaffMemberCreated))
                .ForMember(opt => opt.StaffMemberUpdated, opt => opt.MapFrom(o => o.StaffMemberUpdated));

            CreateMap<Widget, WidgetEntity>()
                .ForMember(opt => opt.WidgetId, opt => opt.MapFrom(o => o.WidgetId))
                .ForMember(opt => opt.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(opt => opt.ManufacturerId, opt => opt.MapFrom(o => o.ManufacturerId))
                .ForMember(opt => opt.ColourId, opt => opt.MapFrom(o => o.ColourId))
                .ForMember(opt => opt.ColourJustificationId, opt => opt.MapFrom(o => o.ColourJustificationId))
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.Created, opt => opt.MapFrom(o => o.Created))
                .ForMember(opt => opt.CreatedById, opt => opt.MapFrom(o => o.CreatedById))
                .ForMember(opt => opt.LastUpdated, opt => opt.MapFrom(o => o.LastUpdated))
                .ForMember(opt => opt.LastUpdatedById, opt => opt.MapFrom(o => o.LastUpdatedById))
                .ForMember(opt => opt.Manufacturer, opt => opt.MapFrom(o => o.Manufacturer))
                .ForMember(opt => opt.Colour, opt => opt.MapFrom(o => o.Colour))
                .ForMember(opt => opt.ColourJustification, opt => opt.MapFrom(o => o.ColourJustification))
                .ForMember(opt => opt.Status, opt => opt.MapFrom(o => o.Status))
                .ForMember(opt => opt.StaffMemberCreated, opt => opt.MapFrom(o => o.StaffMemberCreated))
                .ForMember(opt => opt.StaffMemberUpdated, opt => opt.MapFrom(o => o.StaffMemberUpdated));

            #endregion

            #region WidgetStatus

            CreateMap<WidgetStatusEntity, WidgetStatus>()
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.StatusName, opt => opt.MapFrom(o => o.StatusName));

            CreateMap<WidgetStatus, WidgetStatusEntity>()
                .ForMember(opt => opt.StatusId, opt => opt.MapFrom(o => o.StatusId))
                .ForMember(opt => opt.StatusName, opt => opt.MapFrom(o => o.StatusName));

            #endregion
        }
    }
}
