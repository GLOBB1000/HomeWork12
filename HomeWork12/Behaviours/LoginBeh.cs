using HomeWork12.Clients;
using HomeWork12.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.Behaviours
{
    public class LoginBeh
    {
        private ClientDB clientDB;

        public LoginBeh() 
        {
            clientDB = new ClientDB();
        }

        public bool Login(string login, string pass, out Client client)
        {
            var cls = clientDB.dB_Values();
            if (cls != null && cls.Exists(x => x.Name == login && x.Password == pass))
            {
                var cl = cls.Find(x => x.Name == login);

                client = cl;
                return true;
            }

            client = null;
            return false;
        }
    }
}
