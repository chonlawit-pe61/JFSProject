namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.FinanceApi
{
    public class Contract
    {
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string ContractNo { get; set; }
        public double Amount { get; set; }
        public string ContractDate { get; set; }
        public string SigningPlace { get; set; }
        //public int PowerOfAttorney { get; set; }
        public string ContractNote { get; set; }
        public string ContractorTitle { get; set; }
        public string ContractorName { get; set; }
        public string ContractorLastName { get; set; }
        public string ContractorBirthDate { get; set; }
        public string ContractRequestCertificate { get; set; }
        public bool IsActive { get; set; } = true;
        // public string URL { get; set; }
        public Lawyer Lawyer { get; set; }

    }



}
