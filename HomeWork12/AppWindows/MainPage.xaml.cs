using HomeWork12.Behaviours;
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

namespace HomeWork12.AppWindows
{
    public partial class MainPage : Page
    {
        private LoginBeh loginBeh;
        private Window mainWindow;

        public MainPage(Window mainWindow)
        {
            InitializeComponent();
            loginBeh = new LoginBeh();

            this.mainWindow = mainWindow;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginBeh.Login(Login.Text, Pass.Password, out var client))
                mainWindow.Content = new ClientPage(mainWindow, client);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new CreateClientPage(mainWindow);
        }
    }
}
