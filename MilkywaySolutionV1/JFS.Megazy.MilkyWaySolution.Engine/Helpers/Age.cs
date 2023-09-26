using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Helpers
{
 /**
* C# Age Calculation Library
* https://github.com/faisalman/age-calc-cs
*
* Copyright 2012-2013, Faisalman <fyzlman@gmail.com>
* Licensed under The MIT License
* http://www.opensource.org/licenses/mit-license
*/
    /**
    * Usage example:
    * ==============
    * DateTime bday = new DateTime(1987, 11, 27);
    * DateTime cday = DateTime.Today;
    * Age age = new Age(bday, cday);
    * Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday", age.Years, age.Months, age.Days);
    */
    public class Age
    {
        public int Years;
        public int Months;
        public int Days;

        public Age(DateTime Bday)
        {
            this.Count(Bday);
        }

        public Age(DateTime Bday, DateTime Cday)
        {
            this.Count(Bday, Cday);
        }

        public Age Count(DateTime Bday)
        {
            return this.Count(Bday, DateTime.Today);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    this.Years = Cday.Year - Bday.Year;
                    this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = 0;
                        this.Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    this.Years = (Cday.Year - 1) - Bday.Year;
                    this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                this.Years = 0;
                this.Months = 0;
                this.Days = 0;
                //throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }
        public string AgeString
        {
            get
            {
                string ageString = string.Empty;

                if (Years >= 1)
                {
                    if (Years == 1)
                    {
                        ageString = string.Format("{0} ปี", Years);
                    }
                    else
                    {
                        ageString = string.Format("{0} ปี", Years);
                    }

                    if (Months >= 1)
                    {
                        if (Months == 1)
                        {
                            ageString += string.Format(" {0} เดือน", Months);
                        }
                        else
                        {
                            ageString += string.Format(" {0} เดือน", Months);
                        }

                        if (Days >= 1)
                        {
                            if (Days == 1)
                            {
                                ageString += string.Format(" {0} วัน", Days);
                            }
                            else
                            {
                                ageString += string.Format(" {0} วัน", Days);
                            }
                        }
                    }
                }
                return ageString;
            }
        }

    }
}
