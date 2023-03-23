using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12.DataBases
{
    public abstract class DB<T> where T : class
    {
        public abstract List<T> dB_Values();

        public abstract string PathToFile { get; protected set; }

        public abstract void SaveDB(List<T> values);
    }
}
