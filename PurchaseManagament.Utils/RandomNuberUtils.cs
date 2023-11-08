using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Utils
{
    public static class RandomNuberUtils
    {
        public static string CreateRandom(int startNumber, int EndNumber)
        {
            Random Random = new Random();
            var result = Random.Next(startNumber, EndNumber);
            return result.ToString();
        }
    }
}
