using ExamTest2.DataBase;
using ExamTest2.MyForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ExamTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Capch capch = null;

        public List<Capch> capches = new List<Capch>
        {
            new Capch {IsTrue="153" , path = "/ImageCapch/153.png"} ,
            new Capch {IsTrue="197" , path = "/ImageCapch/197.png"} ,
            new Capch {IsTrue="351" , path = "/ImageCapch/351.png"} ,
        };

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RandomCapch();
        }

        private void RandomCapch()
        {
            Random random = new Random();
            var newcapch = capches[random.Next(capches.Count)];

            if(capch == null)
            {
                capch = newcapch;
                imageCapch.Source = new BitmapImage(new Uri(capch.path, UriKind.Relative));
                return;
            }
            if(capch.IsTrue != newcapch.IsTrue)
            {
                capch = newcapch;
                imageCapch.Source = new BitmapImage(new Uri(capch.path, UriKind.Relative));
                return;
            }
            if(capch.IsTrue == newcapch.IsTrue)
            {
                RandomCapch();
            }
        }
        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (tbCapch.Text != capch.IsTrue)
            {
                MessageBox.Show("Вы ввели неправильную капчу! - Попробуйте снова через 5 секунд");
                for (int i = 5; i > 0; i--)
                {
                    this.Title = $"Блокровка {i} секунд";
                    Thread.Sleep(1000);

                }
                RandomCapch();
                tbCapch.Clear();
                return;

            }
            Authorization();
            ////////if (tbLogin.Text == "admin" && pbPassword.Password == "admin1")
            ////////{
            ////////    MyForms.AdminWindow adminWindow = new MyForms.AdminWindow();
            ////////    adminWindow.Show();
            ////////    Close();
            ////////}
            ////////else
            ////////{
            ////////    MessageBox.Show("Неправильный пароль или логин");
            ////////}
        }
        private void Authorization()
        {
            try
            {
                DataBase.MyContext myContext = new DataBase.MyContext();
                if (myContext.users.Any(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password))
                {
                    var user = myContext.users.SingleOrDefault(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password);

                    switch (user.Role)
                    {
                        case "admin":
                            MessageBox.Show($"{user.UserName}, добро пожаловать!");
                            MyForms.AdminWindow adminWindow = new MyForms.AdminWindow();
                            adminWindow.Show();
                            Close();
                            break;

                        case "client":
                            MessageBox.Show($"{user.UserName}, добро пожаловать!");
                            MyForms.ClientWindow clientWindow = new MyForms.ClientWindow();
                            clientWindow.Show();
                            Close();
                            break;

                        case "Menager":
                            MessageBox.Show($"{user.UserName}, добро пожаловать!");
                            UsersForms.MenagerWindow menagerWindow = new UsersForms.MenagerWindow();
                            menagerWindow.Show();
                            Close();
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        public class Capch
        {
            public string path { get; set; }
            public string IsTrue { get; set; }
        }

        private void btnRefreshCapch_Click(object sender, RoutedEventArgs e)
        {
            RandomCapch();
        }
    }
}