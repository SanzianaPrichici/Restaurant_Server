using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Server.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public int Cantitate { get; set; }
        public float Pret { get; set; }
        public bool Alergen { get; set; }

    }
}
