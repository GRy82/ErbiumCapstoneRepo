using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErbiumCapstone
{
    public static class ApiKeys
    {

        private static string GeocodingKey = "AIzaSyDa6eBri2JBpz16e2RMCyNUxWN5Ay_FPis";
        private static string MessagingKey = "";

        public static string GetGeocodingKey()
        {
            return GeocodingKey;
        }

        public static string GetMessagingKey()
        {
            return MessagingKey;
        }
    }
}
