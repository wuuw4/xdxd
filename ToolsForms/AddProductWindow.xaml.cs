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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.MyContext myContext = new DataBase.MyContext();
                DataBase.Product newProduct = new DataBase.Product()
                {
                    ProductName = tbProductName.Text,
                    Articul = tbArticul.Text,
                    Description = tbDescription.Text,
                    Manufacture = tbManufacture.Text,
                    Price = Convert.ToDouble(tbProductPrice),
                    Sale = Convert.ToDouble(tbProductSale),
                };
                try
                {
                    myContext.products.Add(newProduct);
                    myContext.SaveChanges();
                    MessageBox.Show("Продукт был добавлен");
                }
                catch
                {
                    MessageBox.Show("Ошибка, продукт небыл добавлен");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");

            }
        }

        private void bntExitClick_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();


        }
    }
}
