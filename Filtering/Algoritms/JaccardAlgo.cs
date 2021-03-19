using System;
using System.Collections.Generic;
using System.Linq;

namespace Filtering
{
    class JaccardAlgo
    {
        private List<double[]> _table;
        private List<double[]> _transponsedTable;
        public JaccardAlgo( List<double[]> table)
        {
            _table = table;
            _transponsedTable = TransposeTable();
        }

        public List<double[]> FindSimilarItems()
        {
            return FindSimilar(_transponsedTable);
        }

        public List<double[]> FindSimilarUsers()
        {
            return FindSimilar(_table);
        }

        public List<double[]> FindSimilar(List<double[]> table)
        {
            List<double[]> similarities = new List<double[]>();
            for (int i = 0; i < table.Count-1; i++)
            {
                double[] relations = new double[table.First().Length];
                for (int j = i+1; j < table.Count; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < table.First().Length; k++)
                    {
                        if (table[i][k] == table[j][k])
                        {
                            sum++;
                        }
                    }
                    relations[j] = sum / (double)table.First().Length;
                }
                similarities.Add(relations);
            }
            return similarities;
        }

        public List<double[]> TransposeTable()
        {
            List<double[]> transponsedTable = new List<double[]>();

            for (int i = 0; i < _table.First().Length; i++)
            {
                double[] users = new double[_table.Count];

                for (int j = 0; j < _table.Count; j++)
                {
                    users[j] = _table[j][i];
                }
                transponsedTable.Add(users);
            }
            return transponsedTable;
        }

        

    }
}
