using System;

namespace Filtering
{
    class JaccardLab
    {
        public void Run()
        {

            Console.WriteLine("\t\t\t\tJaccardAlgoritm");
            Console.WriteLine("\tDatabase");

            Utilities.CreateTable(10, 10, 0, 1);
            Utilities.DisplayTable(null, "user", "item");
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(user, user)\n");
            JaccardAlgo jc = new JaccardAlgo(Utilities._table);
            Utilities.DisplayTable(jc.FindSimilarUsers(), "user", "user", true);
            Console.WriteLine("\n");

            Console.WriteLine("\t\t\tSim(item, item)\n");
            Utilities.DisplayTable(jc.FindSimilarItems(), "item", "item", true);
            Console.WriteLine("____________________________________________________________________________________");

        }

    }
}
