using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Helpers
{
   
   public class CalculateLandArea
    {
       
        public static LandArea ConversionSqrWarToRaiNganWah(double sqrWah)
        {
            int rai = 0, ngan = 0, wah = 0;
            if (sqrWah != 0)
            {
                rai = Convert.ToInt32(Math.Floor(sqrWah / 400));
                ngan = Convert.ToInt32((Math.Floor(sqrWah - (rai * 400)) / 100));
                wah = ((int)sqrWah % 100);
            }
            return new LandArea
            {
                Rai = rai,
                Ngan = ngan,
                SqWah = wah
            };
        }
    }
}
