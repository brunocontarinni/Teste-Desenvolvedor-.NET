using DatabaseConnectionSpace;

namespace DeleterSpace
{
    class Deleter
    {
        public static void Delete( string query)
        {
            Connector.Operator(query);
        }
    }
}