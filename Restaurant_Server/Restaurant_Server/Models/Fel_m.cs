using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Server.Models
{
    public class Fel_m
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public float Durata { get; set; }
        public bool InStoc { get; set; }
        public float Pret { get; set; }
    }
}
