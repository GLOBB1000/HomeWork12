using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork12.DataBases;

namespace HomeWork12.Behaviours
{
    public class CreateUserBeh
    {
        private ClientDB clientDB;

        public CreateUserBeh()
        {
            clientDB = new ClientDB();
        }

        public bool IsPassEquals(string fPass, string sPass)
        {
            if(fPass == sPass) return true;

            return false;
        }

        private bool IsClientNameExist(string name)
        {
            var cls = clientDB.dB_Values();

            if (cls != null && cls.Exists(x => x.Name == name)) return true;

            return false;
        }

        public void SaveClient(string name, string pass)
        {
            if(!IsClientNameExist(name))
                clientDB.AddClient(name, pass);
        }

    }
}
