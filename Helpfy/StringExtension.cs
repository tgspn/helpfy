using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpfy
{
    public static class StringExtension
    {
        public static string ToRepeat(this string charToRepeat,int times)
        {
            var range = Enumerable.Range(0, times);
            StringBuilder sb = new StringBuilder();
            foreach (var item in range)            
                sb.Append(charToRepeat);

            return sb.ToString();
        }
    }
}
