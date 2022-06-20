using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProdInsideProj.Services;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ProdInsideProj
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CreateButtons();
            this.DataContext = new OperationDatabaseService();

        }

       private void CreateButtons()
        {
            NavigationPart.MenuItems.Add(CreateMenuViewItem("MainButton", "Счёт"));
            NavigationPart.MenuItems.Add(CreateMenuViewItem("MakeOperationButton", "Операции"));
            NavigationPart.MenuItems.Add(CreateMenuViewItem("AccountHistoryButton", "История"));
        }

        private NavigationViewItem CreateMenuViewItem(string name, string text)
        {
            NavigationViewItem item = new NavigationViewItem();
            item.Content = text;
            item.FontSize = 16;
            item.Name = name;
            return item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
