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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {
        UsersEntities db;
        public auth()
        {
            db = new UsersEntities();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var us = db.users.Where(w => w.login_user == login_txt.Text && w.password_user == password_txt.Text).FirstOrDefault();
            if(us != null && us.role == "admin")
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            } else if(us != null)
            {
                MessageBox.Show("Ты клиент!");
            }
        }
    }
}
