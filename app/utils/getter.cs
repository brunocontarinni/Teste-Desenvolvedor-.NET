using System;
using DatabaseConnectionSpace;

namespace GetterSpace
{
    class Getter
    {

        public string Get( string query)
        {
            return Connector.OperatorGetter(query);
        }

         public string GetMultiplesValues(string query)
        {

            string results = "";

            results = Connector.OperatorGetter(query);

            return results;
        }
    }
}