using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
   public  class Experienta
    {
            [PrimaryKey, AutoIncrement] public int ID { get; set; }
            public string Description { get; set; }
            [OneToMany] public List<ListExperienta> ListExperiente { get; set; }
        
    }
}
