using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgo_app
{
    public class Event
    {
        private string _name;
        private string _map;
        private DateTime _cas;
        private bool _ucast;
        private string _description;

        public Event(string Name, string Map, DateTime Cas, bool Ucast, string Description)
        {
            _name = Name;
            _map = Map;
            _cas = Cas;
            _ucast = Ucast;
            _description = Description;

        }

        public string name { get { return _name; } set { _name = value; } }
        public string map { get { return _map; } set { _map = value; } }
        public DateTime cas { get { return _cas; } set { _cas = value; } }
        public bool ucast { get { return _ucast; } set { _ucast = value; } }
        public string description { get { return _description; } set { _description = value; } }
    }


}
