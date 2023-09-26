using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	[Serializable]
	public partial class View_CaseDetailCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string SubjectColumnName = "Subject";
		public const string JFCaseTypeIDColumnName = "JFCaseTypeID";
		public const string ChannelIDColumnName = "ChannelID";
		public const string ReferenceCaseIDColumnName = "ReferenceCaseID";
		public const string ReferenceMSCIDColumnName = "ReferenceMSCID";
		public const string ReferenceMSCCODEColumnName = "ReferenceMSCCODE";
		public const string CreateDateColumnName = "CreateDate";
		public const string RegisterDateColumnName = "RegisterDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string CaseTypeNameColumnName = "CaseTypeName";
		public const string CaseTypeNameAbbrColumnName = "CaseTypeNameAbbr";
		public const string SrcDepartmentIDColumnName = "SrcDepartmentID";
		public const string SrcDepartmentNameColumnName = "SrcDepartmentName";
		public const string SrcDepartmentNameAbbrColumnName = "SrcDepartmentNameAbbr";
		public const string ReferenceDepartmentIDColumnName = "ReferenceDepartmentID";
		public const string OwnProvinceIDColumnName = "OwnProvinceID";
		public const string OwnDepartmentNameColumnName = "OwnDepartmentName";
		public const string OwnDepartmentNameAbbrColumnName = "OwnDepartmentNameAbbr";
		public const string DepartmentCodeColumnName = "DepartmentCode";
		public const string SrcProvinceNameColumnName = "SrcProvinceName";
		public const string StatusIDColumnName = "StatusID";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string WorkStepNameColumnName = "WorkStepName";
		public const string ChannelNameColumnName = "ChannelName";
		public const string CaseCategoryIDColumnName = "CaseCategoryID";
		public const string CaseSubCategoryIDColumnName = "CaseSubCategoryID";
		public const string OtherCategoryColumnName = "OtherCategory";
		public const string CategoryNameColumnName = "CategoryName";
		public const string CaseSubCategoryNameColumnName = "CaseSubCategoryName";
		public const string CaseApplicationStatusNameColumnName = "CaseApplicationStatusName";
		public const string OwnProvinceNameColumnName = "OwnProvinceName";
		public const string OwnDepartmentIDColumnName = "OwnDepartmentID";
		public const string SrcProvinceIDColumnName = "SrcProvinceID";
		private int _processID;
		public SqlCommand cmd = null;
		public View_CaseDetailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_CaseDetailRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[CaseID],"+
			"[Subject],"+
			"[JFCaseTypeID],"+
			"[ChannelID],"+
			"[ReferenceCaseID],"+
			"[ReferenceMSCID],"+
			"[ReferenceMSCCODE],"+
			"[CreateDate],"+
			"[RegisterDate],"+
			"[ModifiedDate],"+
			"[CaseTypeName],"+
			"[CaseTypeNameAbbr],"+
			"[SrcDepartmentID],"+
			"[SrcDepartmentName],"+
			"[SrcDepartmentNameAbbr],"+
			"[ReferenceDepartmentID],"+
			"[OwnProvinceID],"+
			"[OwnDepartmentName],"+
			"[OwnDepartmentNameAbbr],"+
			"[DepartmentCode],"+
			"[SrcProvinceName],"+
			"[StatusID],"+
			"[WorkStepID],"+
			"[WorkStepName],"+
			"[ChannelName],"+
			"[CaseCategoryID],"+
			"[CaseSubCategoryID],"+
			"[OtherCategory],"+
			"[CategoryName],"+
			"[CaseSubCategoryName],"+
			"[CaseApplicationStatusName],"+
			"[OwnProvinceName],"+
			"[OwnDepartmentID],"+
			"[SrcProvinceID]"+
			" FROM [dbo].[View_CaseDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_CaseDetail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Subject",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("JFCaseTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ChannelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceCaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReferenceMSCCODE",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RegisterDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("CaseTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CaseTypeNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SrcDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SrcDepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("SrcDepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ReferenceDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OwnProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OwnDepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("OwnDepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DepartmentCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("SrcProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("StatusID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("WorkStepName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ChannelName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CaseCategoryID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseSubCategoryID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("OtherCategory",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CategoryName",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("CaseSubCategoryName",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("CaseApplicationStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("OwnProvinceName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("OwnDepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SrcProvinceID",Type.GetType("System.Int32"));
			return dataTable;
		}
		public View_CaseDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_CaseDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_CaseDetailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_CaseDetailRow"/> objects.</returns>
		public virtual View_CaseDetailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_CaseDetail]", top);
			if (null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, 0, top, ref totalRecordCount);
			}
		}
		public View_CaseDetailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_CaseDetailRow[] rows = null;
			SqlCommand command = CreateGetCommand(whereSql, "");
			command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				rows = MapRecords(reader, 0, 1, ref totalRecordCount);
			}
			return 0 == rows.Length ? null : rows[0];
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsDataTable(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
		/// </summary>
		/// <param name="whereSql"></param>
		/// <param name="startRowIndex"></param>
		/// <param name="rowPerPage"></param>
		/// <param name="orderBySql"></param>
		/// <returns></returns>
		public DataTable GetView_CaseDetailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_CaseDetail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,Subject,JFCaseTypeID,ChannelID,ReferenceCaseID,ReferenceMSCID,ReferenceMSCCODE,CreateDate,RegisterDate,ModifiedDate,CaseTypeName,CaseTypeNameAbbr,SrcDepartmentID,SrcDepartmentName,SrcDepartmentNameAbbr,ReferenceDepartmentID,OwnProvinceID,OwnDepartmentName,OwnDepartmentNameAbbr,DepartmentCode,SrcProvinceName,StatusID,WorkStepID,WorkStepName,ChannelName,CaseCategoryID,CaseSubCategoryID,OtherCategory,CategoryName,CaseSubCategoryName,CaseApplicationStatusName,OwnProvinceName,OwnDepartmentID,SrcProvinceID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_CaseDetail].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_CaseDetail] " + whereSql +
		" ) AS AllWithRowRank " +
		"  WHERE RowRank >" + startRowIndex + "  AND RowRank  <= " + (startRowIndex + rowPerPage) + wherePaging;
		 command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		dt = CreateDataTable(command);
		return dt;
		}
		/// <summary>
		/// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
		/// </summary>
		/// <param name="whereSql"></param>
		/// <param name="startRowIndex"></param>
		/// <param name="rowPerPage"></param>
		/// <param name="orderBySql"></param>
		/// <returns></returns>
		public View_CaseDetailItemsPaging GetView_CaseDetailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		View_CaseDetailItemsPaging obj = new View_CaseDetailItemsPaging();
		DataTable dt = GetView_CaseDetailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_CaseDetailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_CaseDetailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.Subject = dt.Rows[i]["Subject"].ToString();
			if (dt.Rows[i]["JFCaseTypeID"] != DBNull.Value)
			record.JFCaseTypeID = Convert.ToInt32(dt.Rows[i]["JFCaseTypeID"]);
			if (dt.Rows[i]["ChannelID"] != DBNull.Value)
			record.ChannelID = Convert.ToInt32(dt.Rows[i]["ChannelID"]);
			if (dt.Rows[i]["ReferenceCaseID"] != DBNull.Value)
			record.ReferenceCaseID = Convert.ToInt32(dt.Rows[i]["ReferenceCaseID"]);
			if (dt.Rows[i]["ReferenceMSCID"] != DBNull.Value)
			record.ReferenceMSCID = Convert.ToInt32(dt.Rows[i]["ReferenceMSCID"]);
			record.ReferenceMSCCODE = dt.Rows[i]["ReferenceMSCCODE"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["RegisterDate"] != DBNull.Value)
			record.RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.CaseTypeName = dt.Rows[i]["CaseTypeName"].ToString();
			record.CaseTypeNameAbbr = dt.Rows[i]["CaseTypeNameAbbr"].ToString();
			if (dt.Rows[i]["SrcDepartmentID"] != DBNull.Value)
			record.SrcDepartmentID = Convert.ToInt32(dt.Rows[i]["SrcDepartmentID"]);
			record.SrcDepartmentName = dt.Rows[i]["SrcDepartmentName"].ToString();
			record.SrcDepartmentNameAbbr = dt.Rows[i]["SrcDepartmentNameAbbr"].ToString();
			if (dt.Rows[i]["ReferenceDepartmentID"] != DBNull.Value)
			record.ReferenceDepartmentID = Convert.ToInt32(dt.Rows[i]["ReferenceDepartmentID"]);
			if (dt.Rows[i]["OwnProvinceID"] != DBNull.Value)
			record.OwnProvinceID = Convert.ToInt32(dt.Rows[i]["OwnProvinceID"]);
			record.OwnDepartmentName = dt.Rows[i]["OwnDepartmentName"].ToString();
			record.OwnDepartmentNameAbbr = dt.Rows[i]["OwnDepartmentNameAbbr"].ToString();
			record.DepartmentCode = dt.Rows[i]["DepartmentCode"].ToString();
			record.SrcProvinceName = dt.Rows[i]["SrcProvinceName"].ToString();
			if (dt.Rows[i]["StatusID"] != DBNull.Value)
			record.StatusID = Convert.ToInt32(dt.Rows[i]["StatusID"]);
			if (dt.Rows[i]["WorkStepID"] != DBNull.Value)
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.WorkStepName = dt.Rows[i]["WorkStepName"].ToString();
			record.ChannelName = dt.Rows[i]["ChannelName"].ToString();
			if (dt.Rows[i]["CaseCategoryID"] != DBNull.Value)
			record.CaseCategoryID = Convert.ToInt32(dt.Rows[i]["CaseCategoryID"]);
			if (dt.Rows[i]["CaseSubCategoryID"] != DBNull.Value)
			record.CaseSubCategoryID = Convert.ToInt32(dt.Rows[i]["CaseSubCategoryID"]);
			record.OtherCategory = dt.Rows[i]["OtherCategory"].ToString();
			record.CategoryName = dt.Rows[i]["CategoryName"].ToString();
			record.CaseSubCategoryName = dt.Rows[i]["CaseSubCategoryName"].ToString();
			record.CaseApplicationStatusName = dt.Rows[i]["CaseApplicationStatusName"].ToString();
			record.OwnProvinceName = dt.Rows[i]["OwnProvinceName"].ToString();
			if (dt.Rows[i]["OwnDepartmentID"] != DBNull.Value)
			record.OwnDepartmentID = Convert.ToInt32(dt.Rows[i]["OwnDepartmentID"]);
			if (dt.Rows[i]["SrcProvinceID"] != DBNull.Value)
			record.SrcProvinceID = Convert.ToInt32(dt.Rows[i]["SrcProvinceID"]);
			recordList.Add(record);
		}
		obj.view_CaseDetailItems = (View_CaseDetailItems[])(recordList.ToArray(typeof(View_CaseDetailItems)));
		return obj;
		}
		protected View_CaseDetailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_CaseDetailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_CaseDetailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int subjectColumnIndex = reader.GetOrdinal("Subject");
			int jFCaseTypeIDColumnIndex = reader.GetOrdinal("JFCaseTypeID");
			int channelIDColumnIndex = reader.GetOrdinal("ChannelID");
			int referenceCaseIDColumnIndex = reader.GetOrdinal("ReferenceCaseID");
			int referenceMSCIDColumnIndex = reader.GetOrdinal("ReferenceMSCID");
			int referenceMSCCODEColumnIndex = reader.GetOrdinal("ReferenceMSCCODE");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
			int registerDateColumnIndex = reader.GetOrdinal("RegisterDate");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int caseTypeNameColumnIndex = reader.GetOrdinal("CaseTypeName");
			int caseTypeNameAbbrColumnIndex = reader.GetOrdinal("CaseTypeNameAbbr");
			int srcDepartmentIDColumnIndex = reader.GetOrdinal("SrcDepartmentID");
			int srcDepartmentNameColumnIndex = reader.GetOrdinal("SrcDepartmentName");
			int srcDepartmentNameAbbrColumnIndex = reader.GetOrdinal("SrcDepartmentNameAbbr");
			int referenceDepartmentIDColumnIndex = reader.GetOrdinal("ReferenceDepartmentID");
			int ownProvinceIDColumnIndex = reader.GetOrdinal("OwnProvinceID");
			int ownDepartmentNameColumnIndex = reader.GetOrdinal("OwnDepartmentName");
			int ownDepartmentNameAbbrColumnIndex = reader.GetOrdinal("OwnDepartmentNameAbbr");
			int departmentCodeColumnIndex = reader.GetOrdinal("DepartmentCode");
			int srcProvinceNameColumnIndex = reader.GetOrdinal("SrcProvinceName");
			int statusIDColumnIndex = reader.GetOrdinal("StatusID");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int workStepNameColumnIndex = reader.GetOrdinal("WorkStepName");
			int channelNameColumnIndex = reader.GetOrdinal("ChannelName");
			int casecategoryIDColumnIndex = reader.GetOrdinal("CaseCategoryID");
			int caseSubcategoryIDColumnIndex = reader.GetOrdinal("CaseSubCategoryID");
			int otherCategoryColumnIndex = reader.GetOrdinal("OtherCategory");
			int categoryNameColumnIndex = reader.GetOrdinal("CategoryName");
			int caseSubcategoryNameColumnIndex = reader.GetOrdinal("CaseSubCategoryName");
			int caseApplicationStatusNameColumnIndex = reader.GetOrdinal("CaseApplicationStatusName");
			int ownProvinceNameColumnIndex = reader.GetOrdinal("OwnProvinceName");
			int ownDepartmentIDColumnIndex = reader.GetOrdinal("OwnDepartmentID");
			int srcProvinceIDColumnIndex = reader.GetOrdinal("SrcProvinceID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_CaseDetailRow record = new View_CaseDetailRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(subjectColumnIndex)) record.Subject =  Convert.ToString(reader.GetValue(subjectColumnIndex));

					if (!reader.IsDBNull(jFCaseTypeIDColumnIndex)) record.JFCaseTypeID =  Convert.ToInt32(reader.GetValue(jFCaseTypeIDColumnIndex));

					if (!reader.IsDBNull(channelIDColumnIndex)) record.ChannelID =  Convert.ToInt32(reader.GetValue(channelIDColumnIndex));

					if (!reader.IsDBNull(referenceCaseIDColumnIndex)) record.ReferenceCaseID =  Convert.ToInt32(reader.GetValue(referenceCaseIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCIDColumnIndex)) record.ReferenceMSCID =  Convert.ToInt32(reader.GetValue(referenceMSCIDColumnIndex));

					if (!reader.IsDBNull(referenceMSCCODEColumnIndex)) record.ReferenceMSCCODE =  Convert.ToString(reader.GetValue(referenceMSCCODEColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(registerDateColumnIndex)) record.RegisterDate =  Convert.ToDateTime(reader.GetValue(registerDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(caseTypeNameColumnIndex)) record.CaseTypeName =  Convert.ToString(reader.GetValue(caseTypeNameColumnIndex));

					if (!reader.IsDBNull(caseTypeNameAbbrColumnIndex)) record.CaseTypeNameAbbr =  Convert.ToString(reader.GetValue(caseTypeNameAbbrColumnIndex));

					if (!reader.IsDBNull(srcDepartmentIDColumnIndex)) record.SrcDepartmentID =  Convert.ToInt32(reader.GetValue(srcDepartmentIDColumnIndex));

					if (!reader.IsDBNull(srcDepartmentNameColumnIndex)) record.SrcDepartmentName =  Convert.ToString(reader.GetValue(srcDepartmentNameColumnIndex));

					if (!reader.IsDBNull(srcDepartmentNameAbbrColumnIndex)) record.SrcDepartmentNameAbbr =  Convert.ToString(reader.GetValue(srcDepartmentNameAbbrColumnIndex));

					if (!reader.IsDBNull(referenceDepartmentIDColumnIndex)) record.ReferenceDepartmentID =  Convert.ToInt32(reader.GetValue(referenceDepartmentIDColumnIndex));

					if (!reader.IsDBNull(ownProvinceIDColumnIndex)) record.OwnProvinceID =  Convert.ToInt32(reader.GetValue(ownProvinceIDColumnIndex));

					if (!reader.IsDBNull(ownDepartmentNameColumnIndex)) record.OwnDepartmentName =  Convert.ToString(reader.GetValue(ownDepartmentNameColumnIndex));

					if (!reader.IsDBNull(ownDepartmentNameAbbrColumnIndex)) record.OwnDepartmentNameAbbr =  Convert.ToString(reader.GetValue(ownDepartmentNameAbbrColumnIndex));

					if (!reader.IsDBNull(departmentCodeColumnIndex)) record.DepartmentCode =  Convert.ToString(reader.GetValue(departmentCodeColumnIndex));

					if (!reader.IsDBNull(srcProvinceNameColumnIndex)) record.SrcProvinceName =  Convert.ToString(reader.GetValue(srcProvinceNameColumnIndex));

					if (!reader.IsDBNull(statusIDColumnIndex)) record.StatusID =  Convert.ToInt32(reader.GetValue(statusIDColumnIndex));

					if (!reader.IsDBNull(workStepIDColumnIndex)) record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));

					if (!reader.IsDBNull(workStepNameColumnIndex)) record.WorkStepName =  Convert.ToString(reader.GetValue(workStepNameColumnIndex));

					if (!reader.IsDBNull(channelNameColumnIndex)) record.ChannelName =  Convert.ToString(reader.GetValue(channelNameColumnIndex));

					if (!reader.IsDBNull(casecategoryIDColumnIndex)) record.CaseCategoryID =  Convert.ToInt32(reader.GetValue(casecategoryIDColumnIndex));

					if (!reader.IsDBNull(caseSubcategoryIDColumnIndex)) record.CaseSubCategoryID =  Convert.ToInt32(reader.GetValue(caseSubcategoryIDColumnIndex));

					if (!reader.IsDBNull(otherCategoryColumnIndex)) record.OtherCategory =  Convert.ToString(reader.GetValue(otherCategoryColumnIndex));

					if (!reader.IsDBNull(categoryNameColumnIndex)) record.CategoryName =  Convert.ToString(reader.GetValue(categoryNameColumnIndex));

					if (!reader.IsDBNull(caseSubcategoryNameColumnIndex)) record.CaseSubCategoryName =  Convert.ToString(reader.GetValue(caseSubcategoryNameColumnIndex));

					if (!reader.IsDBNull(caseApplicationStatusNameColumnIndex)) record.CaseApplicationStatusName =  Convert.ToString(reader.GetValue(caseApplicationStatusNameColumnIndex));

					if (!reader.IsDBNull(ownProvinceNameColumnIndex)) record.OwnProvinceName =  Convert.ToString(reader.GetValue(ownProvinceNameColumnIndex));

					if (!reader.IsDBNull(ownDepartmentIDColumnIndex)) record.OwnDepartmentID =  Convert.ToInt32(reader.GetValue(ownDepartmentIDColumnIndex));

					if (!reader.IsDBNull(srcProvinceIDColumnIndex)) record.SrcProvinceID =  Convert.ToInt32(reader.GetValue(srcProvinceIDColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_CaseDetailRow[])(recordList.ToArray(typeof(View_CaseDetailRow)));
		}
		protected DataTable MapRecordsToDataTable(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader);
			}
		}
		protected DataTable MapRecordsToDataTable(IDataReader reader)
		{
			int totalRecordCount = 0;
			return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected virtual DataTable MapRecordsToDataTable(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int columnCount = reader.FieldCount;
			int ri = -startIndex;
			DataTable dataTable = CreateDataTable();
			dataTable.BeginLoadData();
			object[] values = new object[columnCount];
			while (reader.Read())
			{
				ri++;
				if (ri > 0 && ri <= length)
				{
					reader.GetValues(values);
					dataTable.LoadDataRow(values, true);
					if (ri == length && 0 != totalRecordCount)
					break;
				}
			}
			dataTable.EndLoadData();
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return dataTable;
		}
		protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
		{
			IDbDataParameter parameter;
			switch (paramName)
			{
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Subject":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "JFCaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChannelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReferenceMSCCODE":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RegisterDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "CaseTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SrcDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SrcDepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SrcDepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReferenceDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OwnProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OwnDepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OwnDepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SrcProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "StatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ChannelName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseSubCategoryID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OtherCategory":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CategoryName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseSubCategoryName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseApplicationStatusName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OwnProvinceName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "OwnDepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SrcProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
		public IDataReader ExecuteReader(IDbCommand command)
		{
			return command.ExecuteReader();
		}
		public SqlCommand CreateCommand(string sqlText)
		{
			return CreateCommand(sqlText, false);
		}
		private SqlCommand CreateCommand(string sqlText, bool procedure)
		{
			DalBase dal = new DalBase();
			cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sqlText;
			if (_processID != 0)
			{
				dal.InitCommand(_processID, cmd);
			}
			else
			{
				_processID = CSystems.ProcessID;
				dal.InitCommand(_processID, cmd);
			}
			if (procedure)
			{
				cmd.CommandType = CommandType.StoredProcedure;
			}
			return cmd;
		}
		private void Close()
		{
			DalBase dal = new DalBase();
			if (_processID != 0)
			{
				dal.Close(_processID, cmd);
				}
			else
			{
				dal.Close(cmd);
			}
		}
		public DataTable CreateDataTable(IDbCommand command)
		{
			DataTable dataTable = new DataTable();
			new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
			return dataTable;
		}
		private string CreateSqlParameterName(string paramName)
		{
			return "@" + paramName;
		}
		private string CreateCollectionParameterName(string baseParamName)
		{
			return "@" + baseParamName;
		}
		private string CreateGEOMETRYSqlParameterName(string paramName, string gemetry = "geometry::STGeomFromText({0},4326)")
		{
			return string.Format(gemetry, "@" + paramName);
		}
		private IDbDataParameter AddParameter(IDbCommand cmd, string paramName, DbType dbType, object value)
		{
			IDbDataParameter parameter = cmd.CreateParameter();
			parameter.ParameterName = CreateCollectionParameterName(paramName);
			parameter.DbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}
		private IDbDataParameter AddParameters(IDbCommand cmd, string paramName, SqlDbType dbType, object value)
		{
			SqlParameter parameter = new SqlParameter();
			parameter.ParameterName = CreateCollectionParameterName(paramName);
			parameter.SqlDbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}
	}
}

