using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Domain.Entities;

namespace WishListApp
{
    /// <summary>
    /// Interaction logic for AddList.xaml
    /// </summary>
    public partial class AddList : Window
    {
        public WishList NewList { get; set; }
        public string ListName { get; set; }

        public AddList()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void addListButton_Click(object sender, RoutedEventArgs e)
        {
            NewList = new WishList(ListName);
            DialogResult = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
