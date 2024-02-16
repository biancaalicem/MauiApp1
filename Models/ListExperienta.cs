using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class ListExperienta
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [ForeignKey(typeof(Pensiune))] public int PensiuneID { get; set; }
        public int ExperientaID { get; set; }
    }
}
