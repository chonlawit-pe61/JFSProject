using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class Proxy
    {
        public int ProxyID { get; set; }
    }
    public class ProxyDataDetali : Proxy
    {
        public int CaseID { get; set; }
        public Person ProxyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CardID { get; set; }
        public string Gender { get; set; }
        public int ReligionID { get; set; }
        public int NationalityID { get; set; }
        public int RaceID { get; set; }
        public string RelatedAs { get; set; }
    }
    public class ProxyAddress : Proxy
    {
        public int AddressID { get; set; }
        public int AddressType { get; set; }
        public int Stay { get; set; }
        public string StayUnit { get; set; }
        public bool IsPresentAddress { get; set; }
        public bool IsPermanentAddress { get; set; }
        
    }
    public class ProxyDataRespones : Proxy
    {
        public ProxyData ProxyDetail { get; set; }
        public ProxyRow ProxyDataDetail { get; set; }
        public ProxyAddressRow[] ProxAddress { get; set; }   
        public AddressRow[] Address { get; set; }
    }
    public class ProxySaveorEdit : Proxy
    {
        public int[] AddressID { get; set; }
    }
    public class ProxyDetailRespon : Proxy
    {
        public ProxyRow ProxyDataDetail { get; set; }
        public AddressRow Address { get; set; }
    }
}
