using AutoMapper;
using ManufacturerManagerTS.BusinessLogic.Handlers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Managers.Interfaces;
using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.BusinessLogic.Validations.Interfaces;
using ManufacturerManagerTS.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ManufacturerManagerTS.BusinessLogic.Managers
{
    public class WidgetPagesManager : IWidgetPagesManager
    {
        private readonly IWidgetHandler _widgetHandler;
        private readonly IWidgetStatusHandler _widgetStatusHandler;
        private readonly IWidgetValidator _widgetValidator;
        private readonly IColourHandler _colourHandler;
        private readonly IColourJustificationHandler _colourJustificationHandler;
        private readonly IManufacturerHandler _manufacturerHandler;
        private readonly IMapper _mapper;

        public WidgetPagesManager(IWidgetHandler widgetHandler,
            IWidgetStatusHandler widgetStatusHandler,
            IWidgetValidator widgetValidator,
            IColourHandler colourHandler,
            IColourJustificationHandler colourJustificationHandler,
            IManufacturerHandler manufacturerHandler,
            IMapper mapper)
        {
            _widgetHandler = widgetHandler;
            _widgetStatusHandler = widgetStatusHandler;
            _widgetValidator = widgetValidator;
            _colourHandler = colourHandler;
            _colourJustificationHandler = colourJustificationHandler;
            _manufacturerHandler = manufacturerHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Widget>> GetWidgets() =>
            _mapper.Map<IEnumerable<Widget>>(await _widgetHandler.GetWidgets());

        public async Task<Results<Widget>> GetWidgetById(int id)
        {
            var widget = _mapper.Map<Widget>(await _widgetHandler.GetWidgetById(id));

            return widget == null
                ? new Results<Widget> { HttpStatusCode = HttpStatusCode.NotFound }
                : new Results<Widget> { Entity = widget, HttpStatusCode = HttpStatusCode.OK };
        }

        public async Task<IEnumerable<string>> SaveWidget(Widget widget)
        {
            var validationList = _widgetValidator.ValidateWidget(widget).ToList();
            var widgetEntity = _mapper.Map<WidgetEntity>(widget);
            if (await _widgetHandler.IsDuplicate(widgetEntity))
                validationList.Add(PageValues.WidgetDuplicateValidation);

            if (validationList.Count == 0)
            {
                widgetEntity = NullifyValues(widgetEntity);
                await _widgetHandler.SaveWidget(widgetEntity);
            }

            return validationList;
        }

        public async Task<IEnumerable<string>> UpdateWidget(Widget widget)
        {
            var validationList = _widgetValidator.ValidateWidget(widget).ToList();

            if (await _widgetHandler.IsDuplicate(_mapper.Map<WidgetEntity>(widget)))
                validationList.Add(PageValues.WidgetDuplicateValidation);

            if (validationList.Count != 0) return validationList;

            var widgetEntity = await _widgetHandler.GetWidgetById(widget.WidgetId);

            widgetEntity = _mapper.Map(widget, widgetEntity);

            widgetEntity = NullifyValues(widgetEntity);

            await _widgetHandler.UpdateWidget(widgetEntity);

            return validationList;
        }

        public async Task<WidgetPagesValues> GetWidgetPagesDropDownValues(bool isCreate = true)
        {
            var widgetPagesValues = new WidgetPagesValues
            {
                Manufacturers = isCreate
                    ? _mapper.Map<List<Manufacturer>> (await _manufacturerHandler.GetManufacturers())
                                                                                            .Where(m => m.StatusId == ManufacturerStatus.Active)
                                                                                            .OrderBy(m => m.Name)
                                                                                            .ToList()
                    : _mapper.Map<List<Manufacturer>>(await _manufacturerHandler.GetManufacturers())
                                                                                            .OrderBy(m => m.Name)
                                                                                            .ToList(),
                Statuses = _mapper.Map<List<WidgetStatus>>(await _widgetStatusHandler.GetWidgetStatuses()).ToList(),
                Colours = _mapper.Map<List<Colour>>(await _colourHandler.GetColours())
                                                                        .OrderBy(c => c.Name)
                                                                        .ToList(),
                ColourJustifications = _mapper.Map<List<ColourJustification>>(await _colourJustificationHandler.GetColourJustifications())
                                                                                                                .OrderBy(c => c.Justification)
                                                                                                                .ToList()
            };

            widgetPagesValues.Manufacturers.Insert(0, new Manufacturer
            {
                ManufacturerId = PageValues.MinusOne,
                Name = PageValues.PleaseSelect
            });
            widgetPagesValues.Colours.Insert(0, new Colour
            {
                ColourId = PageValues.MinusOne,
                Name = PageValues.PleaseSelect
            });
            widgetPagesValues.ColourJustifications.Insert(0, new ColourJustification
            {
                ColourJustificationId = PageValues.MinusOne,
                Justification = PageValues.PleaseSelect
            });

            return widgetPagesValues;
        }

        public WidgetEntity NullifyValues(WidgetEntity widgetEntity)
        {
            if (widgetEntity.ColourId == PageValues.MinusOne)
            {
                widgetEntity.ColourId = null;
            }
            if (widgetEntity.ColourJustificationId == PageValues.MinusOne)
            {
                widgetEntity.ColourJustificationId = null;
            }
            return widgetEntity;
        }
    }
}
