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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain.Services;

namespace WishList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WishListService service;
        public MainWindow()
        {
            InitializeComponent();
            service = new WishListService();
            wishLists.ItemsSource = service.GetAll();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {

        }
    }
}
