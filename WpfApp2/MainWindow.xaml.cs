using Microsoft.Win32;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsersEntities db;
        users usa;
        List<int> ils = new List<int>()
        {
            1
        };


        public MainWindow()
        {
            InitializeComponent();
            db = new UsersEntities();
            dg.ItemsSource = db.users.ToList();
            List<Items> ls = db.Items.ToList();
            for (int i = 0; i < ls.Count; i++)
            {
                if (!combooo.Items.Contains(ls[i].color_item))
                {
                    combooo.Items.Add(ls[i].color_item);
                    ils.Add(ls[i].ID_user);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users u = new users();
            u.id_user = int.Parse(idtxt.Text);
            u.role = roletxt.Text;
            u.name = nametxt.Text;
            u.login_user = logintxt.Text;
            u.password_user = passwordtxt.Text;
            db.users.Add(u);
            db.SaveChanges();
            dg.ItemsSource = db.users.ToList();
        }


        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            users usa = (users)dg.SelectedItem;
            db.users.Remove(usa);
            db.SaveChanges();
            dg.ItemsSource = db.users.ToList();
            MessageBox.Show(usa.id_user.ToString());

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            users usa = (users)dg.SelectedItem;
            usa.id_user = int.Parse(idtxt.Text);
            usa.role = roletxt.Text;
            usa.name = nametxt.Text;
            usa.login_user = logintxt.Text;
            usa.password_user = passwordtxt.Text;
            db.SaveChanges();
            dg.ItemsSource = db.users.ToList();
            OpenFileDialog ds = new OpenFileDialog();
            ds.ShowDialog();
        }
        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            users usa = (users)dg.SelectedItem;
            if (usa != null)
            {
                idtxt.Text = usa.id_user.ToString();
                nametxt.Text = usa.name.ToString();
                logintxt.Text = usa.login_user.ToString();
                passwordtxt.Text = usa.password_user.ToString();
                roletxt.Text = usa.role.ToString();
            }
        }

        private void combooo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = ils[0];
            dg.ItemsSource = db.users.Where(w => w.id_user == i).ToList();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = db.users.Where(w => w.role == searchtxt.Text).ToList();
        }
    }
}
