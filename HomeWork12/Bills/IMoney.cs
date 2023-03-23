using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Bills
{
    public interface IMoney
    {
        void SendMoney(Bill bill, float amount);

        void GetMoney(float amount);
    }
}
