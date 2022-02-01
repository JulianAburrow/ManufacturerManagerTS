using ManufacturerManagerTS.BusinessLogic.Models;

namespace ManufacturerManagerTS.BusinessLogic.Extensions
{
    public static class StringExtensions
    {
        public static StringValues ConvertToDisplayValue(this string valueToTest, int lengthRequired = 50)
        {
            if (valueToTest == null) return new StringValues();

            if (valueToTest.Length > lengthRequired)
            {
                return new StringValues
                {
                    ToolTip = valueToTest,
                    DisplayValue = $"{valueToTest.Substring(0, lengthRequired - 3)}..."
                };
            }

            return new StringValues { DisplayValue = valueToTest };
        }
    }
}
