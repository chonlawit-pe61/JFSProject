using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class SMSDataResult : ApiResult
    {
        public SMSContent Result { get; set; }
    }
    public class PhoneNumberList
    {
        public string number { get; set; }
        public string message_id { get; set; }
        public int used_credit { get; set; }
    }

    public class SMSContent
    {
        public int remaining_credit { get; set; }
        public int total_use_credit { get; set; }
        public string credit_type { get; set; }
        public List<PhoneNumberList> phone_number_list { get; set; }
        public List<string> bad_phone_number_list { get; set; }
    }


    public class RemainingCreditDataResult : ApiResult
    {
        public RemainingCreditContent Result { get; set; }
    }
    public class RemainingCredit
    {
        public int standard { get; set; }
        public int corporate { get; set; }
    }

    public class RemainingCreditContent
    {
        public RemainingCredit remaining_credit { get; set; }
    }
}
