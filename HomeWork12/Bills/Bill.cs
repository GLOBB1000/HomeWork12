using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Bills
{
    public enum BillType
    {
        Dep,
        NDep
    }
    public abstract class Bill : IMoney, IBank
    {
        protected Bill(int billNumber, float moneyCount)
        {
            BillNumber = billNumber;
            MoneyCount = moneyCount;
        }
        public abstract BillType BillType { get; protected set; }
        public abstract int BillNumber { get; protected set; } 
        public abstract float MoneyCount { get; protected set; }
        public int Bik 
        {
            get 
            {
                return 00443322;
            }
        }
        public string BankName 
        {
            get 
            {
                return "Bank";
            }
        }

        public abstract void GetMoney(float amount);

        public abstract void SendMoney(Bill bill, float amount);
    }
}
