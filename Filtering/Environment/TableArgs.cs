using System;
using System.Collections.Generic;
using System.Text;

namespace Filtering.Environment
{
    class TableArgs
    {
        public TableArgs(int maxUsers, int maxItems, int minGrade, int maxGrade)
        {
            MaxUsers = maxUsers;
            MaxItems = maxItems;
            MinGrade = minGrade;
            MaxGrade = maxGrade;
        }

        public int MaxUsers { get; set; }
        public int MaxItems { get; set; }
        public int MinGrade { get; set; }
        public int MaxGrade { get; set; }
    }
}
