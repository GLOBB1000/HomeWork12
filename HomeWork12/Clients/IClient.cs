using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork12.Bills;

namespace HomeWork12.Clients
{
    public interface IClient
    {
        string Name { get; }

        string Password { get; }

        DepositBill deposit { get; }

        NotDepositBill n_deposit { get; }
    }
}
