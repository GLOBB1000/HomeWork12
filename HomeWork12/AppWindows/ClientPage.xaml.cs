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
using HomeWork12.Bills;
using HomeWork12.Clients;

namespace HomeWork12.AppWindows
{
    public partial class ClientPage : Page
    {
        private Window mainWindow;

        private SenderBeh senderBeh;
        private BillsInfoBeh billsInfo;

        public ClientPage(Window mainWindow, Client client)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
            billsInfo = new BillsInfoBeh(client);
            senderBeh = new SenderBeh();

            UserName.Content = client.Name;
        }

        private void BillButton_Click(object sender, RoutedEventArgs e)
        {
            SenderInformation.Visibility = Visibility.Hidden;

            Bills.Visibility = Visibility.Visible;

            InitBillsList();
        }

        private void SenderButton_Click(object sender, RoutedEventArgs e)
        {
            SenderInformation.Visibility = Visibility.Visible;

            Bills.Visibility = Visibility.Hidden;
            BillsInformation.Visibility = Visibility.Hidden;
        }

        private void InitBillsList()
        {
            BillsList.Items.Clear();
            var bs = billsInfo.BillList();
            if (bs == null || bs.Count == 0)
                return;

            foreach (var item in bs)
            {
                if(item != null)
                    BillsList.Items.Add(item.BillNumber);
            }
        }

        private void BillsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var b = billsInfo.ShowInfo((sender as ListBox).SelectedIndex);
            BillsInformation.Visibility = Visibility.Visible;

            if (b == null) return;

            Number.Text = b.BillNumber.ToString();
            Money.Text = b.MoneyCount.ToString();
            BillType.Text = b.BillType.ToString();
        }

        private void CreateNDep(object sender, RoutedEventArgs e)
        {
            billsInfo.CreateN_DepBill();
        }

        private void CreateDep(object sender, RoutedEventArgs e)
        {
            billsInfo.CreateDepBill();
        }
    }
}
