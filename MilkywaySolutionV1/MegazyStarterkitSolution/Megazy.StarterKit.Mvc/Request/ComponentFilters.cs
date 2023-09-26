using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megazy.StarterKit.Mvc.Request
{
    public class ComponentFilters
    {
        public string Query { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

    }
    public class AdvancedSearch
    {
        public string Office { get; set; }
        public string Channel { get; set; }
        public string CaseCategory { get; set; }
        public string SubCategory { get; set; }
        public string SceneProvince { get; set; }
        public string IssueDate { get; set; }
        public string InputDate { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardID { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string Race { get; set; }
        public string Religion { get; set; }
        public string RangeAge { get; set; }

    }
    public class ServiceCenterComponentFilters : ComponentFilters
    {
        public string CaseTransactionStatus { get; set; }
        public string ProvinceName { get; set; }
        public string OfficeID { get; set; } 
        public string ReferenceSource { get; set; } 
        public int ProvinceID { get; set; }
    }
}
