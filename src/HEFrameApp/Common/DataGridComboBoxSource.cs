using HEFrameApp.Models;
using System;
using System.Collections.Generic;

namespace HEFrameApp.Common
{
    public class DataGridComboBoxSource
    {
        public static  readonly List<Sex> Sexes = new List<Sex>();
        static DataGridComboBoxSource()
        {
            foreach (Sex item in Enum.GetValues(typeof(Sex)))
            {
                Sexes.Add(item);
            }
        }
    }
}
