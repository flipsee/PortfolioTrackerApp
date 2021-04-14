using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Sessions
{
    public class Session
    {
        public string UserName { get; set; }

        public string Email { get; set; } 
    }

    public class SessionProvider
    {
        public Session session;

        public SessionProvider()
        {
            session = new Session();
        }

        public void Initialise(string userName, string email)
        {
            session.UserName = userName;
            session.Email = email;  
        }
    }
}
