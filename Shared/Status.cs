using System;

namespace Shared
{
    class Status
    {
        enum UserAccess { Valid, Invalid, StubError };

        private static Status instance;
        
        public static Status Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Status();
                }
                return instance;
            }
        }
    }
}
