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
        private int _cas;
        private bool _ucast;

        public Event(string Name, string Map, int Cas, bool Ucast)
        {
            _name = Name;
            _map = Map;
            _cas = Cas;
            _ucast = Ucast;

        }

        public string name { get { return _name; } set { _name = value; } }
        public string map { get { return _map; } set { _map = value; } }
        public int cas { get { return _cas; } set { _cas = value; } }
        public bool ucast { get { return _ucast; } set { _ucast = value; } }
    }


}
