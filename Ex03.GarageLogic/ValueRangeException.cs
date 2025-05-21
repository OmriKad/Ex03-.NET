using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private float MaxValue { get; set; }
        private float MinValue { get; set; }

        public ValueRangeException(float i_MinValue, float i_MaxValue)
            : base($"Value must be between {i_MinValue} and {i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
