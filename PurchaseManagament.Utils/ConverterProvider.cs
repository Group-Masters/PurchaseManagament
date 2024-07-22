using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections;

namespace PurchaseManagament.Utils
{
    public static class ConverterProvider
    {
        public static ValueConverter<bool, BitArray> GetBoolToBitArrayConverter()
        {
            return new ValueConverter<bool, BitArray>(
                value => new BitArray(new[] { value }),
                value => value.Get(0));
        }
    }
}
