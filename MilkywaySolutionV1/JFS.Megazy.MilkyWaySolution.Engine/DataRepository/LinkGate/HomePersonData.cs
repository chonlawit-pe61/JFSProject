using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.LinkGate
{
    public class HomePersonData
    {
        public PersonalInHouse personalInHouse { get; set; }
        public int total { get; set; }
    }
    public class PersonalInHouse
    {
        public int age { get; set; }
        public string fullName { get; set; }
        public string gender { get; set; }
        public int personalID { get; set; }
        public string statusOfPersonDesc { get; set; }
    }
}
