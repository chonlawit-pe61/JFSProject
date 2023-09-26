using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{

    public partial class View_LawyerQueueCollection_Base
    {
        public View_LawyerQueueRow[] GetCustomLawyerQueueAsArray(int queueVersionID, List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "LawyerID")
        {

            string sql = @"SELECT L.LawyerID,
       L.LawyerTypeID,
       L.Title,
       L.FirstName,
       L.LastName,
       L.CardID,
       L.Gender,
       L.LicenseNo,
       L.LicenseType,
       L.IssueDate,
       L.ExprieDate,
       L.Email,
       L.MobileNo,
       L.Education,
       L.Remark,
       L.NumberOfConductCase,
       L.YearsExperience,
       L.RegisterDate,
       L.DateOfBirth,
       L.ModifiedDate,
       L.LawyerStatusID,
       Ls.LawyerStatusName,
       LA.AddressID,
       LA.AddressTypeID,
       LA.FaxNo,
       LA.TelephoneNo,
       LA.IsPrimary,
       LA.IsActive,
       Addr.Address1,
       Addr.HouseNo,
       Addr.VillageNo,
       Addr.Street,
       Addr.ProvinceID,
       LAPv.ProvinceName AS LawyerProvinceName,
       Addr.DisctrictID,
       Addr.SubdistrictID,
       Addr.PostCode,
       Lmf.LawyerOfficeID,
       Lf.LawyerFirmName,
       Lf.TelephoneNo AS FirmelephoneNo,
       Lf.FaxNo AS FirmFaxNo,
       Lf.Email AS FirmEmail,
       Lf.IsActive AS FirmIsActive,
       dbo.LawyerType.LawyerTypeName,
       ISNULL(TbLawyerContract.NumberOfContract, 0) AS NumberOfContract,
       LawyerQueue.QueueID,
       LawyerQueue.QueueNote,
       LawyerQueue.QueueRunningCode,
       LawyerQueue.QueueStatusID,
       LawyerQueue.QueueVersionID,
       LawyerQueue.Priority,
       Territory.ProvinceID AS TerritoryProvinceID,
       Territory.ProvinceName,
       TbLawyerContract.ContractDate,
       --LawyerEnrollment.EnrollmentYear,
      -- LawyerEnrollment.EnrollmentDate,
       CaseType = '[' + STUFF (
                                 (SELECT ',{\""ID\"":\""' + Convert(varchar(25), Sp.CaseTypeID)+ '\""' + ',\""Name\"":\""' + CaseType.CaseTypeName + '\""}'
                                  FROM[LawyerSpecialty] Sp
                                 INNER JOIN CaseType ON Sp.CaseTypeID = CaseType.CaseTypeID
                                  WHERE Sp.LawyerID = L.LawyerID
                                    FOR XML PATH(''), TYPE ).value('.', 'nvarchar(max)'), 1, 1, '') +']'
FROM dbo.Lawyer AS L
--INNER JOIN LawyerEnrollment ON LawyerEnrollment.LawyerID = L.LawyerID
INNER JOIN dbo.LawyerType ON L.LawyerTypeID = dbo.LawyerType.LawyerTypeID
INNER JOIN
  (SELECT Pt.ProvinceID,
          Pv.ProvinceName,
          Pt.LawyerID
   FROM dbo.LawyerTerritory AS Pt
   INNER JOIN dbo.Province AS Pv ON Pt.ProvinceID = Pv.ProvinceID) AS Territory ON Territory.LawyerID = L.LawyerID
LEFT OUTER JOIN
  (SELECT LawyerQueue.QueueID,
          LawyerQueue.QueueNote,
          LawyerQueue.QueueRunningCode,
          LawyerQueue.QueueStatusID,
          LawyerQueue.Priority,
          LawyerQueue.LawyerID,
          QueueVersion.ProvinceID,
          QueueVersion.QueueVersionID
   FROM LawyerQueue
   INNER JOIN QueueVersion ON LawyerQueue.QueueVersionID = QueueVersion.QueueVersionID
   WHERE QueueVersion.QueueVersionID = {{QueueVersionID}}) AS LawyerQueue ON L.LawyerID = LawyerQueue.LawyerID
AND Territory.ProvinceID = LawyerQueue.ProvinceID
LEFT OUTER JOIN dbo.LawyerAddress AS LA ON L.LawyerID = LA.LawyerID
LEFT OUTER JOIN
  (SELECT COUNT(dbo.LawyerContract.ContractID) AS NumberOfContract,
          dbo.LawyerContract.LawyerID,
          MAX(dbo.Contract.ContractDate) AS ContractDate
   FROM dbo.LawyerContract
   INNER JOIN dbo.Contract ON dbo.LawyerContract.ContractID = dbo.Contract.ContractID
   WHERE(dbo.LawyerContract.IsActive = 1)
   GROUP BY dbo.LawyerContract.LawyerID) AS TbLawyerContract ON L.LawyerID = TbLawyerContract.LawyerID
LEFT OUTER JOIN dbo.Address AS Addr ON LA.AddressID = Addr.AddressID
LEFT OUTER JOIN dbo.Province AS LAPv ON Addr.ProvinceID = LAPv.ProvinceID
LEFT OUTER JOIN dbo.LawyerMapOffice AS Lmf ON L.LawyerID = Lmf.LawyerID
LEFT OUTER JOIN dbo.LawyerOffice AS Lf ON Lmf.LawyerOfficeID = Lf.LawyerOfficeID
LEFT OUTER JOIN dbo.LawyerStatus AS Ls ON L.LawyerStatusID = Ls.LawyerStatusID";

            sql = sql.Replace("{{QueueVersionID}}", queueVersionID.ToString());
            if (string.IsNullOrWhiteSpace(orderBySql))
                orderBySql = "LawyerID";
            AntiSqlInjection.CheckInput(whereSql);
            if (null != whereSql && 0 < whereSql.Length)
                sql += " WHERE " + whereSql;
            if (null != orderBySql && 0 < orderBySql.Length)
                sql += " ORDER BY " + orderBySql;
            SqlCommand command = CreateCommand(sql);
            command.Parameters.AddRange(sqlParameter.ToArray());
            using (IDataReader reader = ExecuteReader(command))
            {
                return MapRecords(reader);
            }





        }

        //public View_LawyerQueueRow[] GetCustomLawyerQueueAsArray(int queueVersionID, List<SqlParameter> sqlParameter, string whereSql, string orderBySql = "LawyerID")
        //{

        //    string path = System.Web.HttpContext.Current.Server.MapPath("/Reports/lawyerqueue.txt");
        //    string sql = "";
        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        sql = sr.ReadToEnd();
        //    }
        //    sql = sql.Replace("{{QueueVersionID}}", queueVersionID.ToString());
        //    if (string.IsNullOrWhiteSpace(orderBySql))
        //        orderBySql = "LawyerID";
        //    AntiSqlInjection.CheckInput(whereSql);
        //    if (null != whereSql && 0 < whereSql.Length)
        //        sql += " WHERE " + whereSql;
        //    if (null != orderBySql && 0 < orderBySql.Length)
        //        sql += " ORDER BY " + orderBySql;
        //    SqlCommand command = CreateCommand(sql);
        //    command.Parameters.AddRange(sqlParameter.ToArray());
        //    using (IDataReader reader = ExecuteReader(command))
        //    {
        //        return MapRecords(reader);
        //    }
        //}
    }
}