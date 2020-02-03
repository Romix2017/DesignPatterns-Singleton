using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonRealWorld
{
    public class LoadBalancer
    {
        private static LoadBalancer instance;
        private List<string> servers = new List<string>();
        private Random random = new Random();
        private static object syncLock = new object();
        protected LoadBalancer()
        {
            servers.Add("Server1");
            servers.Add("Server2");
            servers.Add("Server3");
            servers.Add("Server4");
            servers.Add("server5");
        }
        public static LoadBalancer GetLoadBalancer()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }
            }
            return instance;
        }
        public string Server
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            }
        }
    }
}
