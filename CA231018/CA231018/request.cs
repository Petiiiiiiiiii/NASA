using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231018
{
    class Request
    {
        public string Cim { get; set; }
        public string DatumIdo { get; set; }
        public string Get { get; set; }
        public string HttpKod { get; set; }
        public int Meret { get; set; }

        public Request(string sor)
        {
            var atmeneti = sor.Split('*');
            this.Cim = atmeneti[0];
            this.DatumIdo = atmeneti[1];
            this.Get = atmeneti[2];
            var atmeneti2 = atmeneti[3].Split(' ');
            this.HttpKod = atmeneti2[0];
            if (atmeneti2[1] == "-")
                this.Meret = 0;
            else
                this.Meret = int.Parse(atmeneti2[1]);
        }
    }
}
