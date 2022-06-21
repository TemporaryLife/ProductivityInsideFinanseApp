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
using ProdInsideProj.ViewModels;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ProdInsideProj
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Frame CurrentVisibleWindow;
        private Frame PreviousVisibleWindow;

        public MainPage()
        {
            this.InitializeComponent();
            CurrentVisibleWindow = PreviousVisibleWindow = MainPanel;
            this.DataContext = new OperationDatabaseService();


        }



        private void NavigationPart_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            PreviousVisibleWindow = CurrentVisibleWindow;
            PreviousVisibleWindow.Visibility = Visibility.Collapsed;
            CurrentVisibleWindow = item.Name == "MainButton" ? MainPanel :
                                   item.Name == "OperationButton" ? NewOperationPanel :
                                   item.Name == "HistoryButton"?HistoryPanel:StatisticPanel;
            CurrentVisibleWindow.Visibility = Visibility.Visible;
        }
    }
}
