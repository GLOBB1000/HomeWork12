using HomeWork12.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HomeWork12.Bills;

namespace HomeWork12.DataBases
{
    public class ClientDB : DB<Client>
    {
        public override string PathToFile
        {
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "UsersData.json");
            }
            protected set
            {

            }
        }

        public ClientDB ()
        {
            if(!File.Exists(PathToFile))
            {
                File.Create(PathToFile);
            }
        }  

        public override List<Client> dB_Values()
        {
            var json = File.ReadAllText(PathToFile);
            return JsonConvert.DeserializeObject<List<Client>>(json);
        }

        public override void SaveDB(List<Client> clients)
        {
            var json = JsonConvert.SerializeObject(clients);

            File.WriteAllText(PathToFile, json);
        }

        public void AddClient(string name, string pass)
        {
            Random random = new Random();

            var id = random.Next(1000, 9999);
            var cls = dB_Values();

            while (cls != null && cls.Exists(x => x.Id == id))
                id = random.Next(1000, 9999);

            if(cls == null)
                cls = new List<Client>();

            Client client = new Client(id, name, pass);
            cls.Add(client);

            SaveDB(cls);
        }
    }
}
