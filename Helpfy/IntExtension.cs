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

        public static int Abs(this int value)
        {
            if (value > 0)
                return value;
            else
                return value * -1;
        }
    }
}
