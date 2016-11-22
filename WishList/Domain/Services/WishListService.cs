using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Value_Objects;
using Domain.Repositories;

namespace Domain.Services
{
    public class WishListService
    {
        private WishListRepository repository
        {
            get { return WishListRepository.Instance; }
        }

        public IEnumerable<WishList> GetAll()
        {
            return repository.GetAll();
        }

        public void RemoveList(WishList list)
        {
            repository.RemoveList(list);
        }
        public void RemoveListItem(WishList list, Text text)
        {
            repository.RemoveListItem(list, text);
        }

        public void AddList(WishList list)
        {
            repository.AddList(list);
        }

        public void AddTextItemToList(WishList list, Text text)
        {
            repository.AddTextItemToList(list, text);
        }
    }
}
