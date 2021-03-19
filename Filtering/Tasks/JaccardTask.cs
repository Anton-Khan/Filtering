using System;
using System.Collections.Generic;

namespace Filtering
{
    class JaccardTask
    {
        private List<double[]> _table;
        public void Run()
        {
            
            Console.WriteLine("\n\t\t\t\tJaccardAlgoritm");
            Console.WriteLine("\tDatabase");

            _table = Utilities.CreateTable(10, 10, 0, 1);
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            JaccardAlgo jc = new JaccardAlgo(_table);
            Utilities.DisplayTable(jc.FindSimilarUsers(), "user", "user", true);
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(item, item)\n");
            Utilities.DisplayTable(jc.FindSimilarItems(), "item", "item", true);
            Console.WriteLine("____________________________________________________________________________________");

        }

    }
}
