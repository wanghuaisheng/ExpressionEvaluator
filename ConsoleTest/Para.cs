
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleTest
{
    public class Para
    {
        public decimal Price { get; set; }

        public decimal Val(string paraIdentifyCode)
        {
            if (paraIdentifyCode.Equals("单价"))
            {
                return Price;
            }
            return 0M;
        }
    }
}
