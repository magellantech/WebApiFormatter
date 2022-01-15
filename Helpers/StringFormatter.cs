using System;
using System.Linq;
using WebApiFormatter.Helpers.Interfaces;

namespace WebApiFormatter.Helpers
{
    public class StringFormatter : IFormatter
    {
        public string Format(string data)
        {   //reverse it by using LINQ
            return new string(data.ToCharArray().Reverse().ToArray());
        }
    }
}
