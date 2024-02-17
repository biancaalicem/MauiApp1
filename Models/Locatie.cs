using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Locatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pensiune { get; set; }
        public string Adress { get; set; }
        public string DetaliiPensiune { get { return Pensiune+ " " + Adress; } }
        [OneToMany]
        public List<Pensiune> Pensiuni { get; set; }
    }
}
