using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace csgo_app.Database
{
    public class Item
    { 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public int Cas { get; set; }
        public bool Ucast { get; set; }
        public Item()
        {
        }
        public override string ToString()
        {
            return "Name: " + Name + " Map: " + Map + " Čas: " + Cas;
        }
    }

}
