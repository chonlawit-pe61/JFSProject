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
	public partial class GuaranteeFormCollection_Base : MarshalByRefObject
	{
		public const string GuaranteeFormIDColumnName = "GuaranteeFormID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string FormIDColumnName = "FormID";
		public const string SigningPlaceColumnName = "SigningPlace";
		public const string FormDateColumnName = "FormDate";
		public const string GuaranteeNoteColumnName = "GuaranteeNote";
		public const string RalateAsColumnName = "RalateAs";
		public const string GuranteeCareerColumnName = "GuranteeCareer";
		public const string IncomeAmountColumnName = "IncomeAmount";
		public const string IncomePerUnitColumnName = "IncomePerUnit";
		public const string WitnessIDColumnName = "WitnessID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public GuaranteeFormCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual GuaranteeFormRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual GuaranteeFormPaging GetPagingRelyOnGuaranteeFormIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			GuaranteeFormPaging guaranteeFormPaging = new GuaranteeFormPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(GuaranteeFormID) as TotalRow from [dbo].[GuaranteeForm]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			guaranteeFormPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			guaranteeFormPaging.totalPage = (int)Math.Ceiling((double) guaranteeFormPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			guaranteeFormPaging.guaranteeFormRow = MapRecords(command);
			return guaranteeFormPaging;
		}
		public virtual GuaranteeFormPaging GetPagingRelyOnGuaranteeFormIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			GuaranteeFormPaging guaranteeFormPaging = new GuaranteeFormPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(GuaranteeFormID) as TotalRow from [dbo].[GuaranteeForm]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			guaranteeFormPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			guaranteeFormPaging.totalPage = (int)Math.Ceiling((double)guaranteeFormPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			guaranteeFormPaging.guaranteeFormRow = MapRecords(command);
			return guaranteeFormPaging;
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minGuaranteeFormID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GuaranteeFormID < " + minGuaranteeFormID.ToString();
			}
			else
			{
				whereSql = "GuaranteeFormID < " + minGuaranteeFormID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minGuaranteeFormID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GuaranteeFormID > " + minGuaranteeFormID.ToString();
			}
			else
			{
				whereSql = "GuaranteeFormID > " + minGuaranteeFormID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxGuaranteeFormID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GuaranteeFormID < " + maxGuaranteeFormID.ToString();
			}
			else
			{
				whereSql = "GuaranteeFormID < " + maxGuaranteeFormID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxGuaranteeFormID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And GuaranteeFormID > " + maxGuaranteeFormID.ToString();
			}
			else
			{
				whereSql = "GuaranteeFormID > " + maxGuaranteeFormID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, "GuaranteeFormID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "GuaranteeFormID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			GuaranteeFormRow[] guaranteeFormRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				guaranteeFormRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnGuaranteeFormIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				guaranteeFormRow = MapRecords(command);
			}
			return guaranteeFormRow;
		}
		public virtual GuaranteeFormRow[] GetPagingRelyOnGuaranteeFormIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "GuaranteeFormID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			GuaranteeFormRow[] guaranteeFormRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnGuaranteeFormID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				guaranteeFormRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnGuaranteeFormIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				guaranteeFormRow = MapRecords(command);
			}
			return guaranteeFormRow;
		}
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[GuaranteeFormID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[FormID],"+
			"[SigningPlace],"+
			"[FormDate],"+
			"[GuaranteeNote],"+
			"[RalateAs],"+
			"[GuranteeCareer],"+
			"[IncomeAmount],"+
			"[IncomePerUnit],"+
			"[WitnessID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[GuaranteeForm]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGuaranteeFormID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GuaranteeForm]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGuaranteeFormIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "GuaranteeFormID Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GuaranteeForm] where GuaranteeFormID < (select min(minGuaranteeFormID) from(select top " + (rowPerPage * pageNumber).ToString() + " GuaranteeFormID as minGuaranteeFormID from [dbo].[GuaranteeForm]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[GuaranteeForm]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnGuaranteeFormIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "GuaranteeFormID Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[GuaranteeForm] where GuaranteeFormID > (select max(maxGuaranteeFormID) from(select top " + (rowPerPage * pageNumber).ToString() + " GuaranteeFormID as maxGuaranteeFormID from [dbo].[GuaranteeForm]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[GuaranteeForm]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[GuaranteeForm]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "GuaranteeForm"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("GuaranteeFormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("SigningPlace",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FormDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("GuaranteeNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("RalateAs",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("GuranteeCareer",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("IncomeAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("IncomePerUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("WitnessID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual GuaranteeFormRow[] GetByCaseID(int caseID)
		{
			return MapRecords(CreateGetByCaseIDCommand(caseID));
		}
		public virtual DataTable GetByCaseIDAsDataTable(int caseID)
		{
			return MapRecordsToDataTable(CreateGetByCaseIDCommand(caseID));
		}
		protected virtual IDbCommand CreateGetByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public virtual GuaranteeFormRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public virtual GuaranteeFormRow[] GetByFormID(int formID)
		{
			return MapRecords(CreateGetByFormIDCommand(formID));
		}
		public virtual DataTable GetByFormIDAsDataTable(int formID)
		{
			return MapRecordsToDataTable(CreateGetByFormIDCommand(formID));
		}
		protected virtual IDbCommand CreateGetByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		public virtual GuaranteeFormRow[] GetByWitnessID(int witnessID)
		{
			return MapRecords(CreateGetByWitnessIDCommand(witnessID));
		}
		public virtual DataTable GetByWitnessIDAsDataTable(int witnessID)
		{
			return MapRecordsToDataTable(CreateGetByWitnessIDCommand(witnessID));
		}
		protected virtual IDbCommand CreateGetByWitnessIDCommand(int witnessID)
		{
			string whereSql = "";
			whereSql += "[WitnessID]=" + CreateSqlParameterName("WitnessID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "WitnessID", witnessID);
			return cmd;
		}
		public GuaranteeFormRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual GuaranteeFormRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="GuaranteeFormRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GuaranteeFormRow"/> objects.</returns>
		public virtual GuaranteeFormRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[GuaranteeForm]", top);
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
		public GuaranteeFormRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			GuaranteeFormRow[] rows = null;
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
		public DataTable GetGuaranteeFormPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GuaranteeFormID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "GuaranteeFormID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(GuaranteeFormID) AS TotalRow FROM [dbo].[GuaranteeForm] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,GuaranteeFormID,CaseID,ApplicantID,FormID,SigningPlace,FormDate,GuaranteeNote,RalateAs,GuranteeCareer,IncomeAmount,IncomePerUnit,WitnessID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[GuaranteeForm] " + whereSql +
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
		public GuaranteeFormItemsPaging GetGuaranteeFormPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GuaranteeFormID")
		{
		GuaranteeFormItemsPaging obj = new GuaranteeFormItemsPaging();
		DataTable dt = GetGuaranteeFormPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		GuaranteeFormItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new GuaranteeFormItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.GuaranteeFormID = Convert.ToInt32(dt.Rows[i]["GuaranteeFormID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["FormID"] != DBNull.Value)
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.SigningPlace = dt.Rows[i]["SigningPlace"].ToString();
			if (dt.Rows[i]["FormDate"] != DBNull.Value)
			record.FormDate = Convert.ToDateTime(dt.Rows[i]["FormDate"]);
			record.GuaranteeNote = dt.Rows[i]["GuaranteeNote"].ToString();
			record.RalateAs = dt.Rows[i]["RalateAs"].ToString();
			record.GuranteeCareer = dt.Rows[i]["GuranteeCareer"].ToString();
			if (dt.Rows[i]["IncomeAmount"] != DBNull.Value)
			record.IncomeAmount = Convert.ToDouble(dt.Rows[i]["IncomeAmount"]);
			record.IncomePerUnit = dt.Rows[i]["IncomePerUnit"].ToString();
			if (dt.Rows[i]["WitnessID"] != DBNull.Value)
			record.WitnessID = Convert.ToInt32(dt.Rows[i]["WitnessID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.guaranteeFormItems = (GuaranteeFormItems[])(recordList.ToArray(typeof(GuaranteeFormItems)));
		return obj;
		}
		public GuaranteeFormRow GetByPrimaryKey(int guaranteeFormID)
		{
			string whereSql = "[GuaranteeFormID]=" + CreateSqlParameterName("GuaranteeFormID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GuaranteeFormID", guaranteeFormID);
			GuaranteeFormRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(GuaranteeFormRow value)		{
			string sqlStr = "INSERT INTO [dbo].[GuaranteeForm] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[FormID], " + 
			"[SigningPlace], " + 
			"[FormDate], " + 
			"[GuaranteeNote], " + 
			"[RalateAs], " + 
			"[GuranteeCareer], " + 
			"[IncomeAmount], " + 
			"[IncomePerUnit], " + 
			"[WitnessID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SigningPlace") + ", " +
			CreateSqlParameterName("FormDate") + ", " +
			CreateSqlParameterName("GuaranteeNote") + ", " +
			CreateSqlParameterName("RalateAs") + ", " +
			CreateSqlParameterName("GuranteeCareer") + ", " +
			CreateSqlParameterName("IncomeAmount") + ", " +
			CreateSqlParameterName("IncomePerUnit") + ", " +
			CreateSqlParameterName("WitnessID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
			AddParameter(cmd, "SigningPlace", value.SigningPlace);
			AddParameter(cmd, "FormDate", value.IsFormDateNull ? DBNull.Value : (object)value.FormDate);
			AddParameter(cmd, "GuaranteeNote", value.GuaranteeNote);
			AddParameter(cmd, "RalateAs", value.RalateAs);
			AddParameter(cmd, "GuranteeCareer", value.GuranteeCareer);
			AddParameter(cmd, "IncomeAmount", value.IsIncomeAmountNull ? DBNull.Value : (object)value.IncomeAmount);
			AddParameter(cmd, "IncomePerUnit", value.IncomePerUnit);
			AddParameter(cmd, "WitnessID", value.IsWitnessIDNull ? DBNull.Value : (object)value.WitnessID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(GuaranteeFormRow value)		{
			string sqlStr = "INSERT INTO [dbo].[GuaranteeForm] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[FormID], " + 
			"[SigningPlace], " + 
			"[FormDate], " + 
			"[GuaranteeNote], " + 
			"[RalateAs], " + 
			"[GuranteeCareer], " + 
			"[IncomeAmount], " + 
			"[IncomePerUnit], " + 
			"[WitnessID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("SigningPlace") + ", " +
			CreateSqlParameterName("FormDate") + ", " +
			CreateSqlParameterName("GuaranteeNote") + ", " +
			CreateSqlParameterName("RalateAs") + ", " +
			CreateSqlParameterName("GuranteeCareer") + ", " +
			CreateSqlParameterName("IncomeAmount") + ", " +
			CreateSqlParameterName("IncomePerUnit") + ", " +
			CreateSqlParameterName("WitnessID") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
			AddParameter(cmd, "SigningPlace", Sanitizer.GetSafeHtmlFragment(value.SigningPlace));
			AddParameter(cmd, "FormDate", value.IsFormDateNull ? DBNull.Value : (object)value.FormDate);
			AddParameter(cmd, "GuaranteeNote", Sanitizer.GetSafeHtmlFragment(value.GuaranteeNote));
			AddParameter(cmd, "RalateAs", Sanitizer.GetSafeHtmlFragment(value.RalateAs));
			AddParameter(cmd, "GuranteeCareer", Sanitizer.GetSafeHtmlFragment(value.GuranteeCareer));
			AddParameter(cmd, "IncomeAmount", value.IsIncomeAmountNull ? DBNull.Value : (object)value.IncomeAmount);
			AddParameter(cmd, "IncomePerUnit", Sanitizer.GetSafeHtmlFragment(value.IncomePerUnit));
			AddParameter(cmd, "WitnessID", value.IsWitnessIDNull ? DBNull.Value : (object)value.WitnessID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(GuaranteeFormRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGuaranteeFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetSigningPlace)
				{
					strUpdate += "[SigningPlace]=" + CreateSqlParameterName("SigningPlace") + ",";
				}
				if (value._IsSetFormDate)
				{
					strUpdate += "[FormDate]=" + CreateSqlParameterName("FormDate") + ",";
				}
				if (value._IsSetGuaranteeNote)
				{
					strUpdate += "[GuaranteeNote]=" + CreateSqlParameterName("GuaranteeNote") + ",";
				}
				if (value._IsSetRalateAs)
				{
					strUpdate += "[RalateAs]=" + CreateSqlParameterName("RalateAs") + ",";
				}
				if (value._IsSetGuranteeCareer)
				{
					strUpdate += "[GuranteeCareer]=" + CreateSqlParameterName("GuranteeCareer") + ",";
				}
				if (value._IsSetIncomeAmount)
				{
					strUpdate += "[IncomeAmount]=" + CreateSqlParameterName("IncomeAmount") + ",";
				}
				if (value._IsSetIncomePerUnit)
				{
					strUpdate += "[IncomePerUnit]=" + CreateSqlParameterName("IncomePerUnit") + ",";
				}
				if (value._IsSetWitnessID)
				{
					strUpdate += "[WitnessID]=" + CreateSqlParameterName("WitnessID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[GuaranteeForm] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GuaranteeFormID]=" + CreateSqlParameterName("GuaranteeFormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GuaranteeFormID", value.GuaranteeFormID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
					AddParameter(cmd, "SigningPlace", value.SigningPlace);
					AddParameter(cmd, "FormDate", value.IsFormDateNull ? DBNull.Value : (object)value.FormDate);
					AddParameter(cmd, "GuaranteeNote", value.GuaranteeNote);
					AddParameter(cmd, "RalateAs", value.RalateAs);
					AddParameter(cmd, "GuranteeCareer", value.GuranteeCareer);
					AddParameter(cmd, "IncomeAmount", value.IsIncomeAmountNull ? DBNull.Value : (object)value.IncomeAmount);
					AddParameter(cmd, "IncomePerUnit", value.IncomePerUnit);
					AddParameter(cmd, "WitnessID", value.IsWitnessIDNull ? DBNull.Value : (object)value.WitnessID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(GuaranteeFormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(GuaranteeFormRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGuaranteeFormID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetSigningPlace)
				{
					strUpdate += "[SigningPlace]=" + CreateSqlParameterName("SigningPlace") + ",";
				}
				if (value._IsSetFormDate)
				{
					strUpdate += "[FormDate]=" + CreateSqlParameterName("FormDate") + ",";
				}
				if (value._IsSetGuaranteeNote)
				{
					strUpdate += "[GuaranteeNote]=" + CreateSqlParameterName("GuaranteeNote") + ",";
				}
				if (value._IsSetRalateAs)
				{
					strUpdate += "[RalateAs]=" + CreateSqlParameterName("RalateAs") + ",";
				}
				if (value._IsSetGuranteeCareer)
				{
					strUpdate += "[GuranteeCareer]=" + CreateSqlParameterName("GuranteeCareer") + ",";
				}
				if (value._IsSetIncomeAmount)
				{
					strUpdate += "[IncomeAmount]=" + CreateSqlParameterName("IncomeAmount") + ",";
				}
				if (value._IsSetIncomePerUnit)
				{
					strUpdate += "[IncomePerUnit]=" + CreateSqlParameterName("IncomePerUnit") + ",";
				}
				if (value._IsSetWitnessID)
				{
					strUpdate += "[WitnessID]=" + CreateSqlParameterName("WitnessID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[GuaranteeForm] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GuaranteeFormID]=" + CreateSqlParameterName("GuaranteeFormID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GuaranteeFormID", value.GuaranteeFormID);
					AddParameter(cmd, "CaseID", value.IsCaseIDNull ? DBNull.Value : (object)value.CaseID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "FormID", value.IsFormIDNull ? DBNull.Value : (object)value.FormID);
					AddParameter(cmd, "SigningPlace", Sanitizer.GetSafeHtmlFragment(value.SigningPlace));
					AddParameter(cmd, "FormDate", value.IsFormDateNull ? DBNull.Value : (object)value.FormDate);
					AddParameter(cmd, "GuaranteeNote", Sanitizer.GetSafeHtmlFragment(value.GuaranteeNote));
					AddParameter(cmd, "RalateAs", Sanitizer.GetSafeHtmlFragment(value.RalateAs));
					AddParameter(cmd, "GuranteeCareer", Sanitizer.GetSafeHtmlFragment(value.GuranteeCareer));
					AddParameter(cmd, "IncomeAmount", value.IsIncomeAmountNull ? DBNull.Value : (object)value.IncomeAmount);
					AddParameter(cmd, "IncomePerUnit", Sanitizer.GetSafeHtmlFragment(value.IncomePerUnit));
					AddParameter(cmd, "WitnessID", value.IsWitnessIDNull ? DBNull.Value : (object)value.WitnessID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(GuaranteeFormID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int guaranteeFormID)
		{
			string whereSql = "[GuaranteeFormID]=" + CreateSqlParameterName("GuaranteeFormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GuaranteeFormID", guaranteeFormID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return DeleteByCaseID(caseID, false);
		}
		public int DeleteByCaseID(int caseID, bool caseIDNull)
		{
			return CreateDeleteByCaseIDCommand(caseID, caseIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID, bool caseIDNull)
		{
			string whereSql = "";
			if (caseIDNull)
				whereSql += "[CaseID] IS NULL";
			else
				whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!caseIDNull)
				AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return DeleteByApplicantID(applicantID, false);
		}
		public int DeleteByApplicantID(int applicantID, bool applicantIDNull)
		{
			return CreateDeleteByApplicantIDCommand(applicantID, applicantIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID, bool applicantIDNull)
		{
			string whereSql = "";
			if (applicantIDNull)
				whereSql += "[ApplicantID] IS NULL";
			else
				whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!applicantIDNull)
				AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public int DeleteByFormID(int formID)
		{
			return DeleteByFormID(formID, false);
		}
		public int DeleteByFormID(int formID, bool formIDNull)
		{
			return CreateDeleteByFormIDCommand(formID, formIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormIDCommand(int formID, bool formIDNull)
		{
			string whereSql = "";
			if (formIDNull)
				whereSql += "[FormID] IS NULL";
			else
				whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!formIDNull)
				AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		public int DeleteByWitnessID(int witnessID)
		{
			return DeleteByWitnessID(witnessID, false);
		}
		public int DeleteByWitnessID(int witnessID, bool witnessIDNull)
		{
			return CreateDeleteByWitnessIDCommand(witnessID, witnessIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByWitnessIDCommand(int witnessID, bool witnessIDNull)
		{
			string whereSql = "";
			if (witnessIDNull)
				whereSql += "[WitnessID] IS NULL";
			else
				whereSql += "[WitnessID]=" + CreateSqlParameterName("WitnessID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!witnessIDNull)
				AddParameter(cmd, "WitnessID", witnessID);
			return cmd;
		}
		protected GuaranteeFormRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected GuaranteeFormRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected GuaranteeFormRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int guaranteeFormIDColumnIndex = reader.GetOrdinal("GuaranteeFormID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int signingPlaceColumnIndex = reader.GetOrdinal("SigningPlace");
			int formDateColumnIndex = reader.GetOrdinal("FormDate");
			int guaranteeNoteColumnIndex = reader.GetOrdinal("GuaranteeNote");
			int ralateAsColumnIndex = reader.GetOrdinal("RalateAs");
			int guranteeCareerColumnIndex = reader.GetOrdinal("GuranteeCareer");
			int incomeAmountColumnIndex = reader.GetOrdinal("IncomeAmount");
			int incomePerUnitColumnIndex = reader.GetOrdinal("IncomePerUnit");
			int witnessIDColumnIndex = reader.GetOrdinal("WitnessID");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					GuaranteeFormRow record = new GuaranteeFormRow();
					recordList.Add(record);
					record.GuaranteeFormID =  Convert.ToInt32(reader.GetValue(guaranteeFormIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(formIDColumnIndex)) record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));

					if (!reader.IsDBNull(signingPlaceColumnIndex)) record.SigningPlace =  Convert.ToString(reader.GetValue(signingPlaceColumnIndex));

					if (!reader.IsDBNull(formDateColumnIndex)) record.FormDate =  Convert.ToDateTime(reader.GetValue(formDateColumnIndex));

					if (!reader.IsDBNull(guaranteeNoteColumnIndex)) record.GuaranteeNote =  Convert.ToString(reader.GetValue(guaranteeNoteColumnIndex));

					if (!reader.IsDBNull(ralateAsColumnIndex)) record.RalateAs =  Convert.ToString(reader.GetValue(ralateAsColumnIndex));

					if (!reader.IsDBNull(guranteeCareerColumnIndex)) record.GuranteeCareer =  Convert.ToString(reader.GetValue(guranteeCareerColumnIndex));

					if (!reader.IsDBNull(incomeAmountColumnIndex)) record.IncomeAmount =  Convert.ToDouble(reader.GetValue(incomeAmountColumnIndex));

					if (!reader.IsDBNull(incomePerUnitColumnIndex)) record.IncomePerUnit =  Convert.ToString(reader.GetValue(incomePerUnitColumnIndex));

					if (!reader.IsDBNull(witnessIDColumnIndex)) record.WitnessID =  Convert.ToInt32(reader.GetValue(witnessIDColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GuaranteeFormRow[])(recordList.ToArray(typeof(GuaranteeFormRow)));
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
				case "GuaranteeFormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SigningPlace":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FormDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "GuaranteeNote":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RalateAs":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "GuranteeCareer":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IncomeAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "IncomePerUnit":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "WitnessID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

