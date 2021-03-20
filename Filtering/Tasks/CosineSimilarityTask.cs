using Filtering.Algoritms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Tasks
{
    class CosineSimilarityTask
    {
        private List<double[]> _table;
        public void Run()
        {
            Console.WriteLine("\n\t\t\t\tCosine Similarity Algoritm");
            Console.WriteLine("\tDatabase");

            _table = Utilities.CreateTable(5, 10, 0, 5);
            Utilities.DisplayTable(_table, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            CosineSimilarityAlgo ln = new CosineSimilarityAlgo(_table);
            Utilities.DisplayTable(ln.FindSimilarUsers(), "user", "user", false);


            Console.WriteLine("____________________________________________________________________________________");
        }
    }
}
