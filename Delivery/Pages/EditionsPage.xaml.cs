using Delivery.Classes;
using Delivery.Entities;
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

namespace Delivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditionsPage.xaml
    /// </summary>   
    public partial class EditionsPage : Page
    {
        public EditionsPage()
        {
            InitializeComponent();
            DGridEditions.ItemsSource = EditionsCatalogEntities.GetContext().Edition.ToList();
        }

        private void btnDeleteEdition_Click(object sender, RoutedEventArgs e)
        {
            var editionsToRemove = DGridEditions.SelectedItems.Cast<Edition>().ToList();

            if (MessageBox.Show($"Вы собираетесь удалить выбранные {editionsToRemove.Count()} элементов. Продолжить ?", "Внимание!!!", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EditionsCatalogEntities.GetContext().Edition.RemoveRange(editionsToRemove);
                    EditionsCatalogEntities.GetContext().SaveChanges();
                    MessageBox.Show($"{editionsToRemove.Count} элементов были успешно удалены.");

                    DGridEditions.ItemsSource = EditionsCatalogEntities.GetContext().Edition.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddEdition_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void btnGoToEmployee_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeePage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Edition));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DGridEditions.ItemsSource = EditionsCatalogEntities.GetContext().Edition.ToList();
            }
        }
    }
}
