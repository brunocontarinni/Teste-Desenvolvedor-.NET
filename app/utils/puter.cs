using DatabaseConnectionSpace;
using System;

namespace PuterSpace
{
    class Puter
    {
        public static void Put( string query)
        {
            Connector.Operator(query);
        }
    }
}