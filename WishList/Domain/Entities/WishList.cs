using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Value_Objects;

namespace Domain.Entities
{
    public class WishList
    {
        public Guid Id { get; }
        public string Name { get; }
        public Text ListText { get; set; }
        public List<Text> ListItems { get; set; }

        public WishList(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            ListItems = new List<Text>();
        }

        public WishList()
        {
            
        }
    }
}
