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
using HomeWork12.Behaviours;

namespace HomeWork12.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateClientPage.xaml
    /// </summary>
    public partial class CreateClientPage : Page
    {
        private Window mainWindow;
        private CreateUserBeh createUser;

        private bool isPass = false;

        public CreateClientPage(Window mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            createUser = new CreateUserBeh();
        }

        private void PassChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(Login.Text) && isPass)
            {
                createUser.SaveClient(Login.Text, Pass.Password);
                mainWindow.Content = new MainPage(mainWindow);
            }
        }

        private void RepeatPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPass = createUser.IsPassEquals(Pass.Password, RepeatPass.Password);

            if (!isPass)
                Warning.Content = "Passwords not equals";

            else
                Warning.Content = "";
        }
    }
}
