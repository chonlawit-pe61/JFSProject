using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class Guarantee
    {
        public CaseGuaranteeRow CaseGuarantee { get; set; }
        public AddressRow Address { get; set; }
        public GuaranteeFormData GuaranteeForm { get; set; }
        public WitnessRow Witness { get; set; }

    }
    public class ContractFormPerson
    {
        public int[] PersonID { get; set; }
        public PersonData[] Garrantee { get; set; }
        public AddressRow ShelterAddress { get; set; }
        public PersonData Shelter { get; set; }
       

    }
}
