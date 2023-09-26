using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
using JFS.Megazy.MilkyWaySolution.Engine.DataRepository;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Services
{
    public static class SubcommitteeService
    {
        //public static SubcommitteeDataResponse GetFinalApprove(int departmentID)
        //{

        //    DalBase dal = new DalBase();
        //    try
        //    {
        //        dal.DbBeginTransaction(CSystems.ProcessID);
        //        bool IsHeadquarter = false;
        //        if (departmentID == 2)
        //        {
        //            IsHeadquarter = true;
        //        }
        //        SubcommitteeCollection_Base obj = new SubcommitteeCollection_Base(CSystems.ProcessID);
        //        List<SqlParameter> parameter = new List<SqlParameter>();
        //        SqlParameter sqlpara = new SqlParameter("@IsHeadquarter", System.Data.SqlDbType.Int) { Value = IsHeadquarter };
        //        parameter.Add(sqlpara);
        //        string whereSql = "[IsHeadquarter] = @IsHeadquarter";
        //        string orderbySql = "SubcommitteeID Asc";
        //        var row = obj.GetAsArray(parameter, whereSql, orderbySql);
        //        obj.Dispose();
        //        if (row.Length != 0)
        //        {
        //            foreach (var item in row)
        //            {
        //                ChairmanSubcommitteeCollection_Base objChair = new ChairmanSubcommitteeCollection_Base(CSystems.ProcessID);
        //                parameter = new List<SqlParameter>();
        //                sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = departmentID };
        //                parameter.Add(sqlpara);
        //                sqlpara = new SqlParameter("@SubcommitteeID", System.Data.SqlDbType.Int) { Value = item.SubcommitteeID };
        //                parameter.Add(sqlpara);
        //                whereSql = "[IsHeadquarter] = @IsHeadquarter";
        //                orderbySql = "SubcommitteeID Asc";
        //                var rowchair = objChair.GetAsArray(parameter, whereSql, orderbySql);
        //                objChair.Dispose();
        //            }
        //        }

        //        dal.DbCommit(CSystems.ProcessID);

        //    }
        //    catch (Exception ex)
        //    {
        //        dal.DbRollBack(CSystems.ProcessID);
        //        DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
        //    }

        //}
        public static SubcommitteeDataResponse[] GetFinalApproveList(int departmentID)
        {
            List<SubcommitteeDataResponse> list = new List<SubcommitteeDataResponse>();
            try
            {
                bool IsHeadquarter = false;
                if (departmentID == 2)
                {
                    IsHeadquarter = true;
                }
                View_SubcommitteeCollection_Base obj = new View_SubcommitteeCollection_Base(CSystems.ProcessID);
                List<SqlParameter> parameter = new List<SqlParameter>();
                SqlParameter sqlpara = new SqlParameter("@IsHeadquarter", System.Data.SqlDbType.Bit) { Value = IsHeadquarter };
                parameter.Add(sqlpara);
                string whereSql = "[IsHeadquarter] = @IsHeadquarter";
                string orderbySql = "SubcommitteeID Asc";
                var row = obj.GetAsArray(parameter, whereSql, orderbySql);
                obj.Dispose();
                if (row.Length != 0)
                {

                    foreach (var item in row)
                    {
                        SubcommitteeDataResponse record = new SubcommitteeDataResponse();
                        record.SubcommiteeID = item.SubcommitteeID;
                        record.SubcommitteeName = item.SubcommitteeName;
                        record.SubcommitteeGroupID = item.SubcommitteeGroupID;
                        record.SubcommitteeGroupName = item.SubcommitteeGroupName;
                        record.AppointmentNo = item.AppointmentNo;

                        ChairmanSubcommitteeCollection_Base objChair = new ChairmanSubcommitteeCollection_Base(CSystems.ProcessID);
                        parameter = new List<SqlParameter>();
                        sqlpara = new SqlParameter("@DepartmentID", System.Data.SqlDbType.Int) { Value = departmentID };
                        parameter.Add(sqlpara);
                        sqlpara = new SqlParameter("@SubcommitteeID", System.Data.SqlDbType.Int) { Value = item.SubcommitteeID };
                        parameter.Add(sqlpara);
                        whereSql = "[DepartmentID] = @DepartmentID AND SubcommitteeID=@SubcommitteeID";
                        var rowchair = objChair.GetRow(parameter, whereSql);
                        objChair.Dispose();
                        if (rowchair != null)
                        {
                            record.ChairmanFirstName = rowchair.FirstName;
                            record.ChairmanFirstName = rowchair.LastName;
                            record.ChairmanTitle = rowchair.Title;
                            record.ChairmanPosition = rowchair.Position;
                        }
                        list.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                DalBase.ExceptEngine.ThrowException(CSystems.ProcessID, ex);
            }
            return list.ToArray();

        }

        public static int SubmitCaseSubcommitteeConsideration(CaseSubcommitteeConsiderationData req)
        {

            CaseSubcommitteeConsiderationCollection_Base obj = new CaseSubcommitteeConsiderationCollection_Base(CSystems.ProcessID);
            var row = obj.GetByPrimaryKey(req.CaseID);
            if (row == null)
            {
                row = new CaseSubcommitteeConsiderationRow
                {
                    CaseID = req.CaseID,                  
                    TermID = req.TermID,
                    IsAppeal = req.IsAppeal,
                    ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID)
                };
                //if (req.OfficerRoleID != 7)//7:คณะอนุกรรมการ
                //{
                //    row.IsSubcommitteeIDNull = true;
                //}
                //else
                //{
                //    row.SubcommitteeID = req.SubcommitteeID;
                //}
                if (req.SubcommitteeID > 0)
                {
                    row.SubcommitteeID = req.SubcommitteeID;
                }
                else
                {
                    row.IsSubcommitteeIDNull = true;
                }
                obj.InsertOnlyPlainText(row);
            }
            else
            {
                //if (req.OfficerRoleID != 7)//7:คณะอนุกรรมการ
                //{
                //    row.IsSubcommitteeIDNull = true;

                //}
                //else
                //{
                //    row.SubcommitteeID = req.SubcommitteeID;
                //}
                if (req.SubcommitteeID > 0)
                {
                    row.SubcommitteeID = req.SubcommitteeID;
                }
                else
                {
                    row.IsSubcommitteeIDNull = true;
                }
                row.OfficerRoleID = req.OfficerRoleID;
                row.TermID = req.TermID;
                row.IsAppeal = req.IsAppeal;
                row.ModifiedDate = DalBase.SqlNowIncludePd(CSystems.ProcessID);
                obj.UpdateOnlyPlainText(row);
            }
            obj.Dispose();
            return req.CaseID;

        }

    }
}
