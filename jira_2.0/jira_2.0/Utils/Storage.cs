using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jira_2._0.Models;

namespace jira_2._0.Utils
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public userModel currentUser = new userModel();
        public List<userModel> registeredUsers= new List<userModel>();
        public HashCell hashTableInitialization = new HashCell();
        public List<HashCell> hashTable = new List<HashCell>();

    }
}