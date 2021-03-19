using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filtering.Algoritms
{
    class L_OneAlgo
    {
        private List<double[]> _table;
        
        public L_OneAlgo(List<double[]> table)
        {
            _table = table;
        }

        public List<double[]> FindSimilarUsers()
        {
            return FindSimilar(_table);
        }

        private List<double[]> FindSimilar(List<double[]> table)
        {
            List<double[]> similarities = new List<double[]>();
            for (int i = 0; i < table.Count - 1; i++)
            {
                double[] relations = new double[table.Count];
                for (int j = i + 1; j < table.Count; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < table.First().Length; k++)
                    {
                        sum += Math.Abs(table[i][k] - table[j][k]);
                    }
                    relations[j] = sum;
                }
                similarities.Add(relations);
            }
            return similarities;
        }
    }
}
