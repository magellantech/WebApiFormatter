using System;
using WebApiFormatter.Helpers.Interfaces;

namespace WebApiFormatter.Helpers
{
    public class NumberFormatter : IFormatter
    {
        public string Format(string data)
        {
            return Math.Sqrt(double.Parse(data)).ToString();
        }
    }
}
