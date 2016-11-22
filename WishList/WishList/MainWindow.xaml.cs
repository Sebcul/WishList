using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Services;
using Domain.Entities;
using Domain.Value_Objects;

namespace WishListApp
{
    public partial class MainWindow : Window
    {
        public Text TextItem { get; set; }
        public string WishListString { get; set; }

        WishListService service;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            service = new WishListService();
            wishLists.ItemsSource = service.GetAll();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var addListDialog = new AddList();
            addListDialog.Owner = this;
            bool? retVal = addListDialog.ShowDialog();
            if (retVal.HasValue)
            {
                bool returnValue = (bool) retVal;
                if (returnValue)
                {
                    service.AddList(addListDialog.NewList);
                    wishLists.ItemsSource = new ObservableCollection<WishList>(service.GetAll());
                }
            }
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            var selectedList = (WishList) wishLists.SelectedValue;
            var result = MessageBox.Show($"Are you sure you want to remove the list {selectedList.Name}?",
                "Removing list", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.Yes))
            {
                service.RemoveList(selectedList);
                wishLists.ItemsSource = new ObservableCollection<WishList>(service.GetAll());
            }
        }

        private void Button_Click_AddItemToList(object sender, RoutedEventArgs e)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                if (wishLists.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an Item first!");
                    break;
                }
                else
                {
                    TextItem = new Text(WishListString);
                    keepRunning = false;
                }  
                var wishList = (WishList) wishLists.SelectedItem;
                service.AddTextItemToList(wishList, TextItem);
                wishListTextBox.ItemsSource =
                    new ObservableCollection<Text>(service.GetAll().ToList().Find(x => x.Id == wishList.Id).ListItems);
                addItemsToListBox.Text = "";
            }
        }

        private void Button_Click_RemoveItemFromList(object sender, RoutedEventArgs e)
        {
                var wishList = (WishList)wishLists.SelectedItem;
                var itemOfWishList = (Text)wishListTextBox.SelectedItem;
                service.RemoveListItem(wishList, itemOfWishList);
                wishListTextBox.ItemsSource = new ObservableCollection<Text>(service.GetAll().ToList().Find(x => x.Id == wishList.Id).ListItems);
        }


    }
}
