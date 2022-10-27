using ExamTest2.MyForms;
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

namespace ExamTest2.ToolsForms
{
    /// <summary>
    /// Логика взаимодействия для DeleteProductWindow.xaml
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        public DeleteProductWindow()
        {
            InitializeComponent();
        }
        private void bntDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bntExitClick_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
