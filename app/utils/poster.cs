using System;
using DatabaseConnectionSpace;

namespace PosterSpace
{
    class Poster
    {
        public static void Post( string query)
        {
            Connector.Operator(query);
        }
    }
}