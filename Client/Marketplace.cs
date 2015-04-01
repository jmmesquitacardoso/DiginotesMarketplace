using System;

namespace Client
{
    public class Marketplace : MarshalByRefObject
    {
        public Marketplace()
        {
            Console.WriteLine("Client side");
        }

        public void Register(string username, string password)
        {
        }

        public int Login(string username, string password)
        {
            return 0;
        }

        public void Logout(string username)
        {
        }
    }
}
