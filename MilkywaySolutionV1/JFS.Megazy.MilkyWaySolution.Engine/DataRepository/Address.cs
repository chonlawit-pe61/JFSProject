using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
   public class Address
    {
        
        public string HouseNo { get; set; }
        public string VillageNo { get; set; }
        public string Street { get; set; }
        public string Soi { get; set; }
        public string AddressLine1 { get; set; }
        public string ProvinceName { get; set; }   
        public string DistrictName { get; set; }
        public string SubDistrictName { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string AddressType { get; set; }
        public virtual string ToAddressString()
        {
            var items = new List<string>();

            if (!string.IsNullOrWhiteSpace(AddressLine1))
            {
                items.Add(AddressLine1);
            }
            if (!string.IsNullOrWhiteSpace(HouseNo))
            {
                items.Add(HouseNo);
            }
            if (!string.IsNullOrWhiteSpace(VillageNo))
            {
                items.Add(VillageNo);
            }
            if (!string.IsNullOrWhiteSpace(Soi))
            {
                items.Add(Soi);
            }
            if (!string.IsNullOrWhiteSpace(Street))
            {
                items.Add(Street);
            }           
            if (!string.IsNullOrWhiteSpace(SubDistrictName))
            {
                items.Add(SubDistrictName);
            }
            if (!string.IsNullOrWhiteSpace(DistrictName))
            {
                items.Add(DistrictName);
            }
            if (!string.IsNullOrWhiteSpace(ProvinceName))
            {
                items.Add(ProvinceName);
            }
            if (!string.IsNullOrWhiteSpace(PostCode))
            {
                items.Add(PostCode);
            }
            if (!string.IsNullOrWhiteSpace(Country))
            {
                items.Add(Country);
            }
            var queryString = new StringBuilder();
            foreach (var item in items)
            {
                if (queryString.Length > 0)
                {
                    queryString.Append(",");
                }

                queryString.AppendFormat("{0}", item);
            }

            return queryString.ToString();

        }
    }
}
