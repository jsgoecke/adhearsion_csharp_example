using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adhearsion
{
    class adhearsion
    {
        private string _username;
        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        private string _password;
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
    }
    class ahnparams
    {
        private string _src;
        public string src
        {
            get { return this._src; }
            set { this._src = value; }
        }

        private string _dest;
        public string dest
        {
            get { return this._dest; }
            set { this._dest = value; }
        }
    }
}
