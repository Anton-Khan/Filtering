using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Environment
{
    abstract class Algoritm
    {
        public abstract void SetTable(List<double[]> table);
        public abstract List<double[]> FindSimilarUsers();
        public abstract Algoritm Create();
    }
}
