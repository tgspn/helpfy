using System;

namespace Helpfy
{
    public static class IntExtension
    {
        public static int ToNegative(this int value)
        {
            if (value > 0)
                return value * -1;
            else
                return value;
        }
    }
}
