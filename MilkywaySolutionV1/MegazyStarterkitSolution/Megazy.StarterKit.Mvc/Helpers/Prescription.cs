using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megazy.StarterKit.Mvc.Helpers
{
    /// <summary>
    /// อายุความ
    /// </summary>
    public static class Prescription
    {
        public static int Calculate(DateTime endDate, DateTime startDate)
        {
            int days = 0;
            if (DateValidateInput(startDate) && DateValidateInput(endDate))
            {
                return (startDate - endDate).Days - 1;
            }
            return days;
        }
        private static bool DateValidateInput(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
