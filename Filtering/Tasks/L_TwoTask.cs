using Filtering.Algoritms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Tasks
{
    class L_TwoTask
    {
        private List<double[]> _table;
        public void Run()
        {
            Console.WriteLine("\n\t\t\t\tL_1 Algoritm");
            Console.WriteLine("\tDatabase");

            _table = Utilities.CreateTable(10, 2, 0, 10);
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            L_TwoAlgo ln = new L_TwoAlgo(_table);
            Utilities.DisplayTable(ln.FindSimilarUsers(), "user", "user", false);


            Console.WriteLine("____________________________________________________________________________________");
        }
    }
}
