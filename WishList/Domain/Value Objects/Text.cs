using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class Text
    {
        public string Value { get; }

        public Text(string value)
        {
            if (value.Length < 250)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("Text cannot be longer than 250 characters.");
            }
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
