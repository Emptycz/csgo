using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_app
{
    public class Event
    {
        private int _id;
        private string _name;
        private string _map;
        private DateTime _cas;
        private bool _ucast;
        private string _description;
        private bool _edit;

        public Event(string Name, string Map, DateTime Cas, bool Ucast, string Description)
        {
            _name = Name;
            _map = Map;
            _cas = Cas;
            _ucast = Ucast;
            _description = Description;

        }

        public Event(int id, string Name, string Map, DateTime Cas, bool Ucast, string Description, bool Edit)
        {
            _name = Name;
            _map = Map;
            _cas = Cas;
            _ucast = Ucast;
            _description = Description;
            _edit = Edit;
            _id = id;
        }

        public int ID { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string map { get { return _map; } set { _map = value; } }
        public DateTime cas { get { return _cas; } set { _cas = value; } }
        public bool ucast { get { return _ucast; } set { _ucast = value; } }
        public string description { get { return _description; } set { _description = value; } }
        public bool edit { get { return _edit; } set { _edit = value; } }
    }


}
