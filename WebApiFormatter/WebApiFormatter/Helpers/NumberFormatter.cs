using System;
using WebApiFormatter.Helpers.Interfaces;

namespace WebApiFormatter.Helpers
{
    public class NumberFormatter : IFormatter
    {
        public string Format(string data)
        {
            double d = double.Parse(data);

            if (d == 0)
                return 0.ToString();

            if (d < 0)
                return (Math.Sqrt((d * (-1))) * (-1)).ToString();
            else
                return Math.Sqrt(d).ToString();
        }
    }
}
