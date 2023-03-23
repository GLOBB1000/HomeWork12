using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Bills
{
    public class NotDepositBill : Bill
    {
        public NotDepositBill(int billNumber, float moneyCount) : base(billNumber, moneyCount)
        {

        }

        public override BillType BillType
        {
            get
            {
                return BillType.NDep;
            }

            protected set
            {
                value = BillType.NDep;
            }
        }

        public override int BillNumber { get; protected set; }
        public override float MoneyCount { get; protected set; }

        public override void GetMoney(float amount)
        {
            throw new NotImplementedException();
        }

        public override void SendMoney(Bill bill, float amount)
        {
            throw new NotImplementedException();
        }
    }
}
