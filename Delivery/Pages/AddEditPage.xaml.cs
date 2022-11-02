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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Edition _currentEdition = new Edition();
        public AddEditPage(Edition selectedEdition)
        {
            InitializeComponent();

            if (selectedEdition != null)
                _currentEdition = selectedEdition;

            DataContext = _currentEdition;            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEdition.name))
                errors.AppendLine("Укажите название издания");
            if (string.IsNullOrWhiteSpace(_currentEdition.number))
                errors.AppendLine("Укажите номер издания");
            if (_currentEdition.type == null)
                errors.AppendLine("Укажите тип издания");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentEdition.editionId == 0)
                EditionsCatalogEntities.GetContext().Edition.Add(_currentEdition);

            try
            {
                EditionsCatalogEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно сохранена!");
                Manager.MainFrame.Navigate(new EditionsPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
