using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork12.DataBases;
using HomeWork12.Clients;
using HomeWork12.Bills;

namespace HomeWork12.Behaviours
{
    public class BillsInfoBeh
    {
        private ClientDB clientDB;
        private Client authorizedClient;

        public BillsInfoBeh(Client client) 
        {
            clientDB = new ClientDB();
            authorizedClient = client;
        }

        public Bill ShowInfo(int index)
        {
            if(index < 0) return null;
            return authorizedClient.bills[index];
        }

        public List<Bill> BillList() 
        {
            return authorizedClient.bills;
        }

        public void SetBillChanged(int index, DepositBill bill)
        {
            authorizedClient.bills[index] = bill;
        }

        public void CreateDepBill()
        {
            CreateBill(BillType.Dep);
        }

        public void CreateN_DepBill()
        {
            CreateBill(BillType.NDep);
        }

        private void CreateBill(BillType billType)
        {
            Random random = new Random();
            var new_num = random.Next(10000, 99999);

            var cls = clientDB.dB_Values();
            var all_bills = new List<Bill>();

            foreach (var cl in cls)
            {
                all_bills.Add(cl.deposit);
                all_bills.Add(cl.n_deposit);
            }

            while (all_bills.Exists(x => x != null && x.BillNumber == new_num))
                new_num = random.Next(10000, 99999);

            if (billType == BillType.Dep)
                authorizedClient.CreateDepBil(new_num);
            else
                authorizedClient.Create_N_Dep_Bil(new_num);

            var c = cls.FindIndex(x => x.Name == authorizedClient.Name && x.Password == authorizedClient.Password);
            cls[c] = authorizedClient;

            clientDB.SaveDB(cls);
        }
    }
}
