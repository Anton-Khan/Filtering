using Filtering.Algoritms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Tasks
{
    class PearsonCorrelationCoefficientTask
    {
        private List<double[]> _table;
        public void Run()
        {
            Console.WriteLine("\n\t\t\t\tL_1 Algoritm");
            Console.WriteLine("\tDatabase");

            _table = Utilities.CreateTable(5, 6, 0, 5);
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            PearsonCorrelationCoefficientAlgo pk = new PearsonCorrelationCoefficientAlgo(_table);
            Utilities.DisplayTable(pk.FindSimilarUsers(), "user", "user", false);


            Console.WriteLine("____________________________________________________________________________________");
        }
    }
}
