using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace octgnPicTest
{
    public class ProxyList
    {
        private string _GUID;
        private string _Quantity;

        public ProxyList(string GUID, string Quantity)
        {
            _GUID = GUID;
            _Quantity = Quantity;
        }

        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
    }
}
