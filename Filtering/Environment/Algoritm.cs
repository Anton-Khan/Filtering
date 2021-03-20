using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Environment
{
    abstract class Algoritm
    {
        protected List<double[]> _table;
        public void SetTable(List<double[]> table)
        {
            _table = table;
        }

        public abstract List<double[]> FindSimilarUsers();
        public abstract Algoritm Create();
    }
}
