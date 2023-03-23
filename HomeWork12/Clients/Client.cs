using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HomeWork12.Bills;
using HomeWork12.DataBases;
using Newtonsoft.Json;

namespace HomeWork12.Clients
{
    public class Client : IClient
    {
        public int Id { get; private set; }

        [JsonIgnore]
        public List<Bill> bills { get; private set; }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public DepositBill deposit { get; private set; }

        public NotDepositBill n_deposit { get; private set; }

        [JsonConstructor]
        public Client(int id, string name, string password, DepositBill depositBill, NotDepositBill notDepositBill)
        {
            Id = id;
            Name = name;
            Password = password;

            deposit = depositBill;
            n_deposit = notDepositBill;

            if(bills == null)
                bills = new List<Bill>();

            bills.Add(deposit);
            bills.Add(n_deposit);
        }

        public Client(int id, string name, string password)
        {
            this.Id = id;
            this.Name = name;   
            this.Password = password;

            if (bills == null)
                bills = new List<Bill>();

            bills.Add(deposit);
            bills.Add(n_deposit);
        }

        public void CreateDepBil(int number)
        {
            if (deposit != null)
                return;

            deposit = new DepositBill(number, 200);
            
            if(bills == null) 
                bills = new List<Bill>();

            bills.Add(deposit);
        }

        public void Create_N_Dep_Bil(int number)
        {
            if (n_deposit != null)
                return;

            n_deposit = new NotDepositBill(number, 200);

            if (bills == null)
                bills = new List<Bill>();

            bills.Add(n_deposit);
        }
    }
}
