using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using JFS.Megazy.MilkyWaySolution.Engine.Helpers;
namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public static class RunningServices
    {

        public static string GetCaseRunning(int jfCaseType,int departmentId)
        {
            string caseNo = "";
            DalBase dal = new DalBase();
            try
            {
               JFCaseTypeCollection_Base jFCaseTypeCollection = new JFCaseTypeCollection_Base(CSystems.ProcessID);
                var rowJFCase = jFCaseTypeCollection.GetByPrimaryKey(jfCaseType);
                jFCaseTypeCollection.Dispose();
                CaseRunningCollection_Base caseRunningCollection = new CaseRunningCollection_Base(CSystems.ProcessID);
                int intYear = Convert.ToInt32(Utility.GetThaiFiscalYear(DateTime.Now).ToString().Substring(2, 2));
                var row = caseRunningCollection.GetByPrimaryKey(departmentId, intYear);
                if (row != null)
                {
                    row.MaxNo += 1;
                    row.InYear = intYear;
                    caseNo = string.Format("{0}{1}{2}/{3}", row.Prefix,rowJFCase.JFCaseTypeID, row.MaxNo.ToString().PadLeft(4, '0'), intYear);
                    caseRunningCollection.Update(row); 
                    caseRunningCollection.Dispose();
                }
                else
                {
                    //INSERT New Department Running
                    DepartmentCollection_Base departmentCollection = new DepartmentCollection_Base(CSystems.ProcessID);
                    var depRow = departmentCollection.GetByPrimaryKey(departmentId);
                    caseNo = string.Format("{0}{1}{2}/{3}", depRow.DepartmentNameAbbr, rowJFCase.JFCaseTypeID, "1".ToString().PadLeft(4, '0'), intYear);
                   // caseNo = string.Format("{0}/{1}/{2}", depRow.DepartmentNameAbbr, rowJFCase.JFCaseTypeID,"1".ToString().PadLeft(4, '0'), intYear);
                    caseRunningCollection.Insert(new CaseRunningRow
                        {
                            DepartmentID = depRow.DepartmentID,
                            InYear = intYear,
                            Prefix = depRow.DepartmentNameAbbr,
                            MaxNo = 1,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                    departmentCollection.Dispose();
                }
             
            }
            catch (Exception ex)
            {
                 DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }   

            return caseNo;
        }

        /// <summary>
        /// สร้างเลขที่สัญญา
        /// </summary>
        /// <returns></returns>
        public static string GetContractRunning(int jfCaseType, int departmentId, DateTime singingdate)
        {
            string contractNo = "";
            DalBase dal = new DalBase();
            try
            {
                int thaiFiscalYear = Convert.ToInt32(singingdate.GetThaiFiscalYear().ToString().Substring(2, 2));
                ContractRunningCollection_Base obj = new ContractRunningCollection_Base(CSystems.ProcessID);
                var row = obj.GetByPrimaryKey(departmentId, thaiFiscalYear);
                if(row != null)
                {
                    row.MaxNo += 1;
                    obj.Update(row);
                    contractNo = string.Format("{0}{1}-{2}/{3}", row.Prefix, jfCaseType, row.MaxNo.ToString().PadLeft(4, '0'), row.InYear);
                }
                else
                {
                    //INSERT New Department Running
                    DepartmentCollection_Base departmentCollection = new DepartmentCollection_Base(CSystems.ProcessID);
                    var depRow = departmentCollection.GetByPrimaryKey(departmentId);
                    departmentCollection.Dispose();
                    // caseNo = string.Format("{0}{1}{2}/{3}", depRow.DepartmentNameAbbr, rowJFCase.JFCaseTypeID, "1".ToString().PadLeft(4, '0'), intYear);
                    // caseNo = string.Format("{0}/{1}/{2}", depRow.DepartmentNameAbbr, rowJFCase.JFCaseTypeID,"1".ToString().PadLeft(4, '0'), intYear);
                    if(depRow != null)
                    {
                        obj.Insert(new ContractRunningRow
                        {
                            DepartmentID = depRow.DepartmentID,
                            InYear = thaiFiscalYear,
                            Prefix = depRow.DepartmentNameAbbr,
                            MaxNo = 1,
                            ModifiedDate = dal.GetSqlNow(CSystems.ProcessID)
                        });
                        contractNo = string.Format("{0}{1}-{2}/{3}", depRow.DepartmentNameAbbr, jfCaseType, 1.ToString().PadLeft(4, '0'), thaiFiscalYear);
                    }
                   
                }
                obj.Dispose();
           

            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }


            return contractNo;
        }
        //private static int GetYearFinances(string datestr)
        //{
        //    int year = 0;
        //    U


        //    return year;
        //}

        /// <summary>
        /// สร้างเลขธุรกรรม
        /// </summary>
        /// <returns></returns>
        public static string GetTransactionRunning()
        {
            string no = "";
            DalBase dal = new DalBase();
            try
            {
                dal.DbBeginTransaction(CSystems.ProcessID);
                RecordMaxRunNoCollection_Base recordMaxRunNo = new RecordMaxRunNoCollection_Base(CSystems.ProcessID);
                var row = recordMaxRunNo.GetByPrimaryKey(5);
                if (row != null)
                {
                    no = string.Format("{0}{1}", row.Prefix, row.MaxNo.ToString().PadLeft(8, '0'));
                    row.MaxNo += 1;
                    recordMaxRunNo.Update(row);
                    recordMaxRunNo.Dispose();

                }
                dal.DbCommit(CSystems.ProcessID);
            }
            catch (Exception ex)
            {
                dal.DbRollBack(CSystems.ProcessID);
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }

            return no;
        }
        public static string GetTransactionNoRunning()
        {
            string no = "";
            TransactionDetailCollection_Base obj = new TransactionDetailCollection_Base(CSystems.ProcessID);
            no = string.Format("JF{0}", obj.GetMaxTransactionNo().ToString().PadLeft(8, '0'));
            obj.Dispose();
            return no;
        }
    }
}
