namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public class PageValues
    {
        public const string ManufacturerManagerContext = "ManufacturerManagerContext";
        public const string IndexPage = "./Index";
        public const string ManufacturerIndexPage = "/ManufacturerPages/Index";
        public const string ManufacturerCreatePage = "/ManufacturerPages/Create";
        public const string ManufacturerDetailsPage = "/ManufacturerPages/Details";
        public const string ManufacturerEditPage = "/ManufacturerPages/Edit";
        public const string WidgetIndexPage = "/WidgetPages/Index";
        public const string WidgetCreatePage = "/WidgetPages/Create";
        public const string WidgetDetailsPage = "/WidgetPages/Details";
        public const string WidgetEditPage = "/WidgetPages/Edit";

        public const string ManufacturerName = "Manufacturer.Name";
        public const string DuplicateManufacturer = "A Manufacturer with this name already exists";

        public const string WidgetName = "Widget.Name";
        public const string WidgetDuplicateValidation = "WidgetDuplicateValidation";
        public const string DuplicateWidget = "A Widget with this name already exists for the selected Manufacturer";

        public const int MinusOne = -1;
        public const string PleaseSelect = "Please select";

        public const string WidgetColourJustificationId = "Widget.ColourJustificationId";
        public const string ColourJustificationValidation = "ColourJustificationValidation";
        public const string WidgetColourJustificationMissing = "If Pink is chosen a justification must be supplied";
    }
}
