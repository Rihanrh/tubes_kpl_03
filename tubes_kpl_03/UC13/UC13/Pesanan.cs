using System;
namespace UC13
{
    public class Pesanan
    {
        public string IdCus { get; set; }
        public string Name { get; set; }
        public List<string> Makanan { get; set; }
        public string status { get; set; }

        
        public Pesanan(string idCus, string name, List<string>Makanan, string status)
        {
            this.IdCus = idCus;
            this.Name = name;
            this.Makanan = Makanan;
            this.status = status;
        }
    }
}


