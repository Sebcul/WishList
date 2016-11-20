using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Value_Objects;

namespace Domain.Repositories
{
    public sealed class WishListRepository
    {
        private static WishListRepository instance;
        private List<WishList> lists;

        internal static WishListRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WishListRepository();
                }
                return instance;
            }
        }

        private WishListRepository()
        {
            lists = new List<WishList>();
            Load();
            
        }

        public IEnumerable<WishList> GetAll()
        {
            return this.lists;
        }

        public void AddList(WishList list)
        {
            lists.Add(list);
        }



        public void Load()
        {
            var wishListOne = new WishList("Testlista");
            wishListOne.ListItems.Add(new Text("Bajskorv"));
            wishListOne.ListItems.Add(new Text("Toapapper"));
            wishListOne.ListItems.Add(new Text("Toasits"));
            lists.Add(wishListOne);
        }
    }
}
