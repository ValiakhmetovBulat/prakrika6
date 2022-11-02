using Delivery.Classes;
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

namespace Delivery.Windows
{
    /// <summary>
    /// Логика взаимодействия для StatringWindow.xaml
    /// </summary>
    public partial class StatringWindow : Window
    {
        public StatringWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.EditionsPage());
            Manager.MainFrame = MainFrame;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }
    }
}
