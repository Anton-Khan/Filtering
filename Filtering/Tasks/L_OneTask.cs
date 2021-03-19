using System;
using System.Collections.Generic;
using Filtering.Algoritms;

namespace Filtering.Tasks
{
    class L_OneTask
    {
        private List<double[]> _table;
        public void Run()
        {
            Console.WriteLine("\n\t\t\t\tL_1 Algoritm");
            Console.WriteLine("\tDatabase");

            _table = Utilities.CreateTable(10, 4, 0, 10);
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            L_OneAlgo ln = new L_OneAlgo(_table);
            Utilities.DisplayTable(ln.FindSimilarUsers(), "user", "user", false);
            

            Console.WriteLine("____________________________________________________________________________________");
        }
    }
}
