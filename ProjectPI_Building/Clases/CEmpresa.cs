using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPI_Building.Clases
{
    public class CEmpresa
    {
        string ruc, name, webpage, facebook, youtube;

        public string Ruc { get => ruc; set => ruc = value; }
        public string Name { get => name; set => name = value; }
        public string Webpage { get => webpage; set => webpage = value; }
        public string Facebook { get => facebook; set => facebook = value; }
        public string Youtube { get => youtube; set => youtube = value; }
    }
}
