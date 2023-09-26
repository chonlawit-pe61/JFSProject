using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
using System.Text.RegularExpressions;

namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	public partial class View_LawyerCollection_Base
	{
		/// <summary>
		/// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
		/// </summary>
		/// <param name="whereSql"></param>
		/// <param name="startRowIndex"></param>
		/// <param name="rowPerPage"></param>
		/// <param name="joinSql"> INNER JOIN Tb1 ON Tb1.ID = View_Lawyer.LawyerID AND Tb1.Year = 2020</param>
		/// <param name="orderBySql"></param>
		/// <returns></returns>
		public DataTable GetView_LawyerPagingAsDataTable(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage,string joinSql, string orderBySql = "LawyerID")
		{
			AntiSqlInjection.CheckInput(whereSql);
			if (startRowIndex < 0)
				startRowIndex = 0;
			if (rowPerPage < 0)
				rowPerPage = 1;
			if (string.IsNullOrWhiteSpace(orderBySql))
				orderBySql = "LawyerID";
			string whereCount = string.Empty;
			string wherePaging = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				wherePaging = " AND " + Regex.Replace( whereSql, @"\[View_Lawyer]\.", "");//important: Replace ค่า [View_lawyer]. ออกเพื่อให้ Query paging ได้
				whereSql = " WHERE " + whereSql;
			}
			string sql = "SELECT COUNT([View_Lawyer].LawyerID) AS TotalRow FROM [dbo].[View_Lawyer] " + joinSql + whereSql;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
			sql = " SELECT RowRank,LawyerID,LawyerTypeID,Title,FirstName,LastName,CardID,Gender,LicenseNo,LicenseType,IssueDate,ExprieDate,Email,MobileNo,Education,Remark,NumberOfConductCase,YearsExperience,RegisterDate,DateOfBirth,ModifiedDate,LawyerStatusID,LawyerStatusName,AddressID,AddressTypeID,FaxNo,TelephoneNo,IsPrimary,IsActive,Address1,HouseNo,VillageNo,Street,ProvinceID,LawyerProvinceName,DisctrictID,SubdistrictID,PostCode,LawyerOfficeID,LawyerFirmName,FirmelephoneNo,FirmFaxNo,FirmEmail,FirmIsActive,LawyerTypeName,Territory,EnrollmentYear," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
			" FROM (SELECT [View_Lawyer].*, " +
			" ROW_NUMBER() OVER(ORDER BY [View_Lawyer]." + orderBySql + ") AS RowRank " +
			" FROM [dbo].[View_Lawyer] "+ joinSql + whereSql +
			" ) AS AllWithRowRank " +
			"  WHERE RowRank >" + startRowIndex + "  AND RowRank  <= " + (startRowIndex + rowPerPage) + wherePaging;
			command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			dt = CreateDataTable(command);
			return dt;
		}
		public View_LawyerItemsPaging GetView_LawyerPagingAsArray(List<SqlParameter> sqlParameter, string whereSql, int startRowIndex, int rowPerPage,string joinSql, string orderBySql = "LawyerID")
		{
			View_LawyerItemsPaging obj = new View_LawyerItemsPaging();
			DataTable dt = GetView_LawyerPagingAsDataTable(sqlParameter, whereSql, startRowIndex, rowPerPage, joinSql, orderBySql);
			if (dt.Rows.Count != 0)
			{
				obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
				obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
			}
			View_LawyerItems record;
			ArrayList recordList = new ArrayList();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				record = new View_LawyerItems();
				record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
				record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
				if (dt.Rows[i]["LawyerTypeID"] != DBNull.Value)
					record.LawyerTypeID = Convert.ToInt32(dt.Rows[i]["LawyerTypeID"]);
				record.Title = dt.Rows[i]["Title"].ToString();
				record.FirstName = dt.Rows[i]["FirstName"].ToString();
				record.LastName = dt.Rows[i]["LastName"].ToString();
				record.CardID = dt.Rows[i]["CardID"].ToString();
				record.Gender = dt.Rows[i]["Gender"].ToString();
				record.LicenseNo = dt.Rows[i]["LicenseNo"].ToString();
				record.LicenseType = dt.Rows[i]["LicenseType"].ToString();
				if (dt.Rows[i]["IssueDate"] != DBNull.Value)
					record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
				if (dt.Rows[i]["ExprieDate"] != DBNull.Value)
					record.ExprieDate = Convert.ToDateTime(dt.Rows[i]["ExprieDate"]);
				record.Email = dt.Rows[i]["Email"].ToString();
				record.MobileNo = dt.Rows[i]["MobileNo"].ToString();
				record.Education = dt.Rows[i]["Education"].ToString();
				record.Remark = dt.Rows[i]["Remark"].ToString();
				if (dt.Rows[i]["NumberOfConductCase"] != DBNull.Value)
					record.NumberOfConductCase = Convert.ToInt32(dt.Rows[i]["NumberOfConductCase"]);
				if (dt.Rows[i]["YearsExperience"] != DBNull.Value)
					record.YearsExperience = Convert.ToInt32(dt.Rows[i]["YearsExperience"]);
				if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
					record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
				if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
					record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
				if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
					record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
				if (dt.Rows[i]["LawyerStatusID"] != DBNull.Value)
					record.LawyerStatusID = Convert.ToInt32(dt.Rows[i]["LawyerStatusID"]);
				record.LawyerStatusName = dt.Rows[i]["LawyerStatusName"].ToString();
				if (dt.Rows[i]["AddressID"] != DBNull.Value)
					record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
				if (dt.Rows[i]["AddressTypeID"] != DBNull.Value)
					record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
				record.FaxNo = dt.Rows[i]["FaxNo"].ToString();
				record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
				if (dt.Rows[i]["IsPrimary"] != DBNull.Value)
					record.IsPrimary = Convert.ToBoolean(dt.Rows[i]["IsPrimary"]);
				if (dt.Rows[i]["IsActive"] != DBNull.Value)
					record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
				record.Address1 = dt.Rows[i]["Address1"].ToString();
				record.HouseNo = dt.Rows[i]["HouseNo"].ToString();
				record.VillageNo = dt.Rows[i]["VillageNo"].ToString();
				record.Street = dt.Rows[i]["Street"].ToString();
				if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
					record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
				record.LawyerProvinceName = dt.Rows[i]["LawyerProvinceName"].ToString();
				if (dt.Rows[i]["DisctrictID"] != DBNull.Value)
					record.DisctrictID = Convert.ToInt32(dt.Rows[i]["DisctrictID"]);
				if (dt.Rows[i]["SubdistrictID"] != DBNull.Value)
					record.SubdistrictID = Convert.ToInt32(dt.Rows[i]["SubdistrictID"]);
				record.PostCode = dt.Rows[i]["PostCode"].ToString();
				if (dt.Rows[i]["LawyerOfficeID"] != DBNull.Value)
					record.LawyerOfficeID = Convert.ToInt32(dt.Rows[i]["LawyerOfficeID"]);
				record.LawyerFirmName = dt.Rows[i]["LawyerFirmName"].ToString();
				record.FirmelephoneNo = dt.Rows[i]["FirmelephoneNo"].ToString();
				record.FirmFaxNo = dt.Rows[i]["FirmFaxNo"].ToString();
				record.FirmEmail = dt.Rows[i]["FirmEmail"].ToString();
				if (dt.Rows[i]["FirmIsActive"] != DBNull.Value)
					record.FirmIsActive = Convert.ToBoolean(dt.Rows[i]["FirmIsActive"]);
				record.LawyerTypeName = dt.Rows[i]["LawyerTypeName"].ToString();
				record.Territory = dt.Rows[i]["Territory"].ToString();
				record.EnrollmentYear = dt.Rows[i]["EnrollmentYear"].ToString();
				recordList.Add(record);
			}
			obj.view_LawyerItems = (View_LawyerItems[])(recordList.ToArray(typeof(View_LawyerItems)));
			return obj;
		}


	}
}
