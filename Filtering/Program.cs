using Filtering.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            JaccardTask jcIndex = new JaccardTask();
            jcIndex.Run();

            L_OneTask ln = new L_OneTask();
            ln.Run();

            L_TwoTask lt = new L_TwoTask();
            lt.Run();

            CosineSimilarityTask cs = new CosineSimilarityTask();
            cs.Run();
        }
    }
}
