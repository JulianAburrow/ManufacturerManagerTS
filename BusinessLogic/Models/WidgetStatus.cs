namespace ManufacturerManagerTS.BusinessLogic.Models
{
    public partial class WidgetStatus
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }

    public partial class WidgetStatus
    {
        public const int Active = 1;
        public const int Inactive = 2;
    }
}
