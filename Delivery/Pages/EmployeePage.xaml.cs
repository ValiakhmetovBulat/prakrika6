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
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using iTextSharp.text.html;

namespace Delivery.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            DGridEmployee.ItemsSource = EditionsCatalogEntities.GetContext().Employee.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DGridEmployee.ItemsSource = EditionsCatalogEntities.GetContext().Employee.ToList();
        }

        private void btnSaveToPdf_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF *.pdf|*.pdf";
            saveFileDialog.FileName = "Result";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                    BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                    PdfPTable pdfTable = new PdfPTable(DGridEmployee.Columns.Count);
                    pdfTable.DefaultCell.Padding = 2;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                    foreach (var item in DGridEmployee.Columns)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(item.Header.ToString(), font));
                        pdfTable.AddCell(pdfCell);
                    }

                    DGridEmployee.SelectAll();
                    var selectedItems = DGridEmployee.SelectedItems.Cast<Employee>().ToList();

                    foreach (var item in selectedItems)
                    {
                        pdfTable.AddCell(new Phrase(item.employeeId.ToString(), font));
                        pdfTable.AddCell(new Phrase(item.fullName, font));
                        pdfTable.AddCell(new Phrase(item.position, font));
                        pdfTable.AddCell(new Phrase(item.address, font));
                        pdfTable.AddCell(new Phrase(item.postCode.ToString(), font));
                    }                    

                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {    
                        Document document = new Document(PageSize.A4);

                        PdfWriter.GetInstance(document, fileStream);
                        document.Open();

                        document.Add(pdfTable);
                        document.Close();
                        fileStream.Close();
                    }

                    MessageBox.Show("Успешный экспорт!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Экспорт был отменен пользователем.");
            }
        }
    }
}
