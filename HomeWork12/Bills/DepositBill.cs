using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Bills
{
    public class DepositBill : Bill
    {
        public DepositBill(int billNumber, float moneyCount) : base(billNumber, moneyCount)
        {

        }

        public override int BillNumber { get; protected set; }
        public override float MoneyCount { get; protected set; }
        public override BillType BillType 
        {
            get
            {
                return BillType.Dep;
            }

            protected set
            {
                value = BillType.Dep;
            }
        }

        public override void GetMoney(float amount)
        {
            MoneyCount += amount;
        }

        public override void SendMoney(Bill bill, float amount)
        {
            MoneyCount -= amount;

            bill.GetMoney(amount);
        }
    }
}
