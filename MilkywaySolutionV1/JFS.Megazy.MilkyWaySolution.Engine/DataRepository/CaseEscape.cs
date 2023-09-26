using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class CaseEscape
    {
        public int CaseID { get; set; }
        public int ApplicantID { get; set; }       
    }
    public class EscapeSupport
    {
        public int EscapeSupportID { get; set; }
    }
    public class CaseEscapeSupport : CaseEscape
    {
        public int EscapeSupportID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Relation { get; set; }
    }
    public class Escape : EscapeSupport
    {
        public bool EscapeStatus { get; set; }
        public string Detail { get; set; }
    }
    public class OffenseHistory : EscapeSupport
    {
        public string ConductDetail { get; set; }
        public string OffenseDetail { get; set; }
        public bool HistoryStatus { get; set; }
    }
    public class CaseEscapeDataRespon
    {
        public CaseGuaranteeRow CaseEscapeSupportRow { get; set; }
        public AbscondingReleasedOnBailRow EscapeRow { get; set; }
        public OffenseHistoryRow OffenseHistoryRow { get; set; }
    }
    public class CaseExpense : CaseEscape
    {
        public CaseExpenseRow[] ExpenseRow { get; set; }
        public CaseExpenseOtherRow CaseExpenseOtherRow { get; set; }
    }
    public class CaseApplicantLaw
    {
        public CaseApplicantOfficerOpinionRow CaseApplicantOpinionRow { get; set; }
        public CaseMattersOfLawRow[] CaseMattersOfLawRow { get; set; }
        //public CaseTermRow CaseTermRow { get; set; }
    }
    public class CausesOfTerminate
    {
        public CaseRepositoryRow CaseRepositoryRow { get; set; }
        public CaseTerminateRow CaseTerminateRow { get; set; }
        //public CaseCeaseRow CaseCeaseRow { get; set; }
        public bool statussave { get; set; }
    }
    
    public class OfficerApprovedExpenseList
    {
        public OfficerApprovedExpenseRow Row { get; set; }
        public OfficerApprovedExpenseListRow[] Old { get; set; }
        public OfficerApprovedExpenseListRow[] New { get; set; }
    }
    public class CaseconsiderationRespon
    {
        public CaseApplicantOfficerOpinionData OfficerOpinionRow { get; set; }
        public CaseTermRow CaseTermRow { get; set; }
    }
    public class VictimRespon
    {
        public CaseVictimRow victim { get; set; }
        public AddressRow address { get; set; }
    }
    public class CaseEscapeSupportRespon
    {
        public CaseEscapeSupportRow EscapeSupport { get; set; }
        public AddressRow Address { get; set; }
    }
    public class GuaranteeRespon
    {
        public CaseGuaranteeRow Guarantee { get; set; }
        public GuaranteeFormData GuaranteeForm { get; set; }
    }
}
