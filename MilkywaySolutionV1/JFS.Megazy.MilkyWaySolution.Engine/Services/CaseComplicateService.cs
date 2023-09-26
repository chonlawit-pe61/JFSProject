using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
  public  class CaseComplicateService
    {
        public CaseComplicateRow[] CaseComplicate(int applicantID) {
            CaseComplicateRow[] res = null;
            CaseComplicateCollection_Base caseComplicate = new CaseComplicateCollection_Base(CSystems.ProcessID);
            res = caseComplicate.GetByApplicantID(applicantID);
            caseComplicate.Dispose();
            return res;
        }

        public bool InsertCaseComplicate(CaseComplicateData[] data, int applicantID,int caseID)
        {
            bool status = false;
            if (data != null)
            {
                DalBase dal = new DalBase();
                CaseComplicateCollection_Base caseComplicate = new CaseComplicateCollection_Base(CSystems.ProcessID);
                caseComplicate.DeleteByApplicantID(applicantID);
                caseComplicate.Dispose();
                if (data.Length > 0)
                {
                    foreach (var item in data)
                    {
                        CaseComplicateRow complicateRow = new CaseComplicateRow
                        {
                            ApplicantID = applicantID,
                            CaseID = caseID,
                            ComplicateID = item.ComplicateID
                        };
                        if (!string.IsNullOrWhiteSpace(item.ComplicateOtherNote))
                        {
                            complicateRow.ComplicateOtherNote = item.ComplicateOtherNote;
                        }
                        complicateRow.CreateDate = dal.GetSqlNow(CSystems.ProcessID);
                        complicateRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
                        caseComplicate = new CaseComplicateCollection_Base(CSystems.ProcessID);
                        caseComplicate.InsertOnlyPlainText(complicateRow);
                        caseComplicate.Dispose();
                        status = true;
                    }
                   
                }
            }

            return status;

        }



        //public bool UpateCaseComplicate(CaseComplicateData data, int applicantID, CaseComplicateCollection_Base caseComplicate)
        //{

        //    bool status = false;

        //    if (data != null)
        //    {

        //        DalBase dal = new DalBase();
        //        CaseComplicateRow complicateRow = new CaseComplicateRow();
        //        complicateRow.ApplicantID = applicantID;
        //        complicateRow.ComplicateID = data.ComplicateID;
        //        if (!string.IsNullOrWhiteSpace(data.ComplicateOtherNote))
        //        {
        //            complicateRow.ComplicateOtherNote = data.ComplicateOtherNote;
        //        }
        //        complicateRow.ModifiedDate = dal.GetSqlNow(CSystems.ProcessID);
        //        caseComplicate.UpdateOnlyPlainText(complicateRow);
        //        status = true;
        //    }

        //    return status;

        //}




    }
}
