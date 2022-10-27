using ExamTest2.ToolsForms;
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

namespace ExamTest2.MyForms
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void bntExitClick_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnGoToAddProductWindow_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AddProductWindow addProductWindow = new MyForms.AddProductWindow();
            addProductWindow.Show();
            Close();

        }

        private void btnGoToDeleteWindow_Click(object sender, RoutedEventArgs e)
        {
            ToolsForms.DeleteProductWindow deleteProductWindow = new DeleteProductWindow();
            deleteProductWindow.Show();
            Close();

        }

        private void btnGoToChangeProduct_Click(object sender, RoutedEventArgs e)
        {
            MyForms.ChangeProductWindow changeProductWindow = new ChangeProductWindow();
            changeProductWindow.Show();
            Close();

        }

        private void btnGoToProductList_Click(object sender, RoutedEventArgs e)
        {
            MyForms.ProductListWindow productListWindow = new ProductListWindow();
            productListWindow.Show();
            Close();

        }
    }
}
