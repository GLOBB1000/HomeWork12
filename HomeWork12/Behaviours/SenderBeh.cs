using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork12.DataBases;

namespace HomeWork12.Behaviours
{
    public class SenderBeh
    {
        private ClientDB clientDB;

        public SenderBeh() 
        {
            clientDB = new ClientDB();
        }
    }
}
