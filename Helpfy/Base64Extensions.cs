using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpfy
{
    public static class Base64Extensions
    {
        public static string ToBase64(string plainText) => new Base64Code().Encode(plainText);
        public static string FromBase64(string encodedText) => new Base64Code().Decode(encodedText);
    }
    public class Base64Code
    {
        private const string Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789/+";
        public string Encode(string plainText)
        {
            var bytes = Encoding.UTF8.GetBytes(plainText);
            StringBuilder sb = new StringBuilder();
            var binaries = GetBinaries(bytes);
            foreach (var item in binaries)
            {
                var split = Regex.Split(item, @"(\d{6})").Where(r => !string.IsNullOrEmpty(r)).ToArray();
                if (split.Length == 4)
                {
                    foreach (var binary in split)
                    {
                        var value = '=';
                        if (binary != "000000")
                        {
                            var index = Convert.ToInt32(binary, 2);
                            value = Base64[index];

                        }
                        sb.Append(value);
                    }
                }
            }
            return sb.ToString();
        }

        public string Decode(string encodedText)
        {
            var binaries = new List<string>();
            StringBuilder sextets = new StringBuilder();
            foreach (var value in encodedText)
            {
                if (value != '=')
                {
                    var index = Base64.IndexOf(value);
                    var binary = Convert.ToString(index, 2).PadLeft(6, '0');
                    sextets.Append(binary);
                }
                if (sextets.Length % 24 == 0)
                {
                    binaries.Add(sextets.ToString());
                    sextets.Clear();
                }
            }
            if (sextets.Length > 0)
            {
                binaries.Add(sextets.ToString());
                sextets.Clear();
            }
            var bytes = GetBytes(binaries);
            return Encoding.UTF8.GetString(bytes);
        }

        private List<string> GetBinaries(byte[] bytes)
        {
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            bytes = fillBytes(bytes);
            for (int i = 0; i < bytes.Length; i++)
            {

                sb.Append(Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
                if ((i + 1) % 3 == 0)
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                }
            }
            return list;
        }
        private byte[] GetBytes(List<string> binaries)
        {
            var list = new List<byte>();
            for (int i = 0; i < binaries.Count; i++)
            {
                var split = Regex.Split(binaries[i], @"(\d{8})").Where(x => !string.IsNullOrEmpty(x)).ToArray();
                foreach (var item in split)
                {
                    if (item.Length == 8)
                        list.Add(Convert.ToByte(item, 2));
                    else
                    {

                    }
                }
            }
            return list.ToArray();
        }

        private byte[] fillBytes(byte[] bytes)
        {
            if (bytes.Length % 3 != 0)
            {
                var newArray = new byte[bytes.Length + (3 - (bytes.Length % 3))];
                for (int i = 0; i < newArray.Length; i++)
                {
                    var value = bytes.Length > i ? bytes[i] : (byte)0;
                    newArray[i] = value;
                }
                return newArray;
            }
            return bytes;

        }
    }
}
