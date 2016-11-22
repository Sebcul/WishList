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
            if (value.Length < 40)
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("Text cannot be longer than 40 characters.");
            }
        }

        public Text()
        {
        }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
