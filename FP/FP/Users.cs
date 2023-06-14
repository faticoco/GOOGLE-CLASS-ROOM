using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP
{

    internal class Users
    {

        private string user_role;
        private static Users instance;
        public static Users Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Users();
                }
                return instance;
            }
        }

        public bool IsDisposed { get; private set; }

        public void set_user_role(string role)
        {
            user_role= role;

        }

        public string get_user_role()
        {
            return user_role;

        }
    }
}
