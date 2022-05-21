using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Server.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public DateTime Data_nast { get; set; }
        public string Adresa { get; set; }
    }
}
