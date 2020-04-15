using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using jira_2._0.Utils;

namespace jira_2._0.Models
{
    public class userModel
    {
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public userModel SignUpUser(string userName, string userPassword, string userRole)
        {
            if (Storage.Instance.registeredUsers.Exists(user => user.name.Equals(userName)))
            {
                return null;
            }
            else
            {
                this.name = userName;
                this.password = userPassword;
                this.role = userRole;

                return this;
            }
        }

        public userModel SignInUser(string userName, string userPassword)
        {
            if (!Storage.Instance.registeredUsers.Exists(user => user.name.Equals(userName)))
            {
                return null;
            }
            else
            {
                return Storage.Instance.registeredUsers.Find(user => user.name.Equals(userName));
            }
        }

    }

  
}