using System.ServiceModel;
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
	public partial class ContractCollection_Base : MarshalByRefObject
	{
		public const string ContractIDColumnName = "ContractID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string FormIDColumnName = "FormID";
		public const string ContractNoColumnName = "ContractNo";
		public const string AmountColumnName = "Amount";
		public const string ContractDateColumnName = "ContractDate";
		public const string SigningPlaceColumnName = "SigningPlace";
		public const string SigningDateColumnName = "SigningDate";
		public const string PowerOfAttorneyColumnName = "PowerOfAttorney";
		public const string ContractNoteColumnName = "ContractNote";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string RemarkColumnName = "Remark";
		private int _processID;
		public SqlCommand cmd = null;
		public ContractCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ContractRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual ContractPaging GetPagingRelyOnContractIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ContractPaging contractPaging = new ContractPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ContractID) as TotalRow from [dbo].[Contract]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			contractPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			contractPaging.totalPage = (int)Math.Ceiling((double) contractPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnContractID(whereSql, "ContractID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			contractPaging.contractRow = MapRecords(command);
			return contractPaging;
		}
		public virtual ContractPaging GetPagingRelyOnContractIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			ContractPaging contractPaging = new ContractPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ContractID) as TotalRow from [dbo].[Contract]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			contractPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			contractPaging.totalPage = (int)Math.Ceiling((double)contractPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnContractID(whereSql, "ContractID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			contractPaging.contractRow = MapRecords(command);
			return contractPaging;
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minContractID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ContractID < " + minContractID.ToString();
			}
			else
			{
				whereSql = "ContractID < " + minContractID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, "ContractID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minContractID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ContractID > " + minContractID.ToString();
			}
			else
			{
				whereSql = "ContractID > " + minContractID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, "ContractID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxContractID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ContractID < " + maxContractID.ToString();
			}
			else
			{
				whereSql = "ContractID < " + maxContractID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, "ContractID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxContractID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ContractID > " + maxContractID.ToString();
			}
			else
			{
				whereSql = "ContractID > " + maxContractID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, "ContractID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ContractID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			ContractRow[] contractRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				contractRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnContractIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				contractRow = MapRecords(command);
			}
			return contractRow;
		}
		public virtual ContractRow[] GetPagingRelyOnContractIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ContractID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			ContractRow[] contractRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnContractID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				contractRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnContractIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				contractRow = MapRecords(command);
			}
			return contractRow;
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
			"[ContractID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[DepartmentID],"+
			"[FormID],"+
			"[ContractNo],"+
			"[Amount],"+
			"[ContractDate],"+
			"[SigningPlace],"+
			"[SigningDate],"+
			"[PowerOfAttorney],"+
			"[ContractNote],"+
			"[IsActive],"+
			"[ModifiedDate],"+
			"[Remark]"+
			" FROM [dbo].[Contract]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnContractID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Contract]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnContractIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ContractID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Contract] where ContractID < (select min(minContractID) from(select top " + (rowPerPage * pageNumber).ToString() + " ContractID as minContractID from [dbo].[Contract]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[Contract]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnContractIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ContractID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Contract] where ContractID > (select max(maxContractID) from(select top " + (rowPerPage * pageNumber).ToString() + " ContractID as maxContractID from [dbo].[Contract]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[Contract]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Contract]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Contract"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ContractNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Amount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("ContractDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("SigningPlace",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("SigningDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PowerOfAttorney",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ContractNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			return dataTable;
		}
		public virtual ContractRow[] GetByCaseID(int caseID)
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
		public virtual ContractRow[] GetByApplicantID(int applicantID)
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
		public virtual ContractRow[] GetByDepartmentID(int departmentId)
		{
			return MapRecords(CreateGetByDepartmentIDCommand(departmentId));
		}
		public virtual DataTable GetByDepartmentIDAsDataTable(int departmentId)
		{
			return MapRecordsToDataTable(CreateGetByDepartmentIDCommand(departmentId));
		}
		protected virtual IDbCommand CreateGetByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public virtual ContractRow[] GetByFormID(int formID)
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
		public ContractRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ContractRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ContractRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ContractRow"/> objects.</returns>
		public virtual ContractRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Contract]", top);
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
		public ContractRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ContractRow[] rows = null;
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
		public DataTable GetContractPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ContractID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ContractID) AS TotalRow FROM [dbo].[Contract] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ContractID,CaseID,ApplicantID,DepartmentID,FormID,ContractNo,Amount,ContractDate,SigningPlace,SigningDate,PowerOfAttorney,ContractNote,IsActive,ModifiedDate,Remark," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Contract] " + whereSql +
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
		public ContractItemsPaging GetContractPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
		ContractItemsPaging obj = new ContractItemsPaging();
		DataTable dt = GetContractPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ContractItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ContractItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.FormID = Convert.ToInt32(dt.Rows[i]["FormID"]);
			record.ContractNo = dt.Rows[i]["ContractNo"].ToString();
			if (dt.Rows[i]["Amount"] != DBNull.Value)
			record.Amount = Convert.ToDouble(dt.Rows[i]["Amount"]);
			if (dt.Rows[i]["ContractDate"] != DBNull.Value)
			record.ContractDate = Convert.ToDateTime(dt.Rows[i]["ContractDate"]);
			record.SigningPlace = dt.Rows[i]["SigningPlace"].ToString();
			if (dt.Rows[i]["SigningDate"] != DBNull.Value)
			record.SigningDate = Convert.ToDateTime(dt.Rows[i]["SigningDate"]);
			record.PowerOfAttorney = dt.Rows[i]["PowerOfAttorney"].ToString();
			record.ContractNote = dt.Rows[i]["ContractNote"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			recordList.Add(record);
		}
		obj.contractItems = (ContractItems[])(recordList.ToArray(typeof(ContractItems)));
		return obj;
		}
		public ContractRow GetByPrimaryKey(int contractID)
		{
			string whereSql = "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContractID", contractID);
			ContractRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(ContractRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Contract] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[FormID], " + 
			"[ContractNo], " + 
			"[Amount], " + 
			"[ContractDate], " + 
			"[SigningPlace], " + 
			"[SigningDate], " + 
			"[PowerOfAttorney], " + 
			"[ContractNote], " + 
			"[IsActive], " + 
			"[ModifiedDate], " + 
			"[Remark]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("ContractNo") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ContractDate") + ", " +
			CreateSqlParameterName("SigningPlace") + ", " +
			CreateSqlParameterName("SigningDate") + ", " +
			CreateSqlParameterName("PowerOfAttorney") + ", " +
			CreateSqlParameterName("ContractNote") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Remark") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "ContractNo", value.IsContractNoNull ? DBNull.Value : (object)value.ContractNo);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "ContractDate", value.IsContractDateNull ? DBNull.Value : (object)value.ContractDate);
			AddParameter(cmd, "SigningPlace", value.IsSigningPlaceNull ? DBNull.Value : (object)value.SigningPlace);
			AddParameter(cmd, "SigningDate", value.IsSigningDateNull ? DBNull.Value : (object)value.SigningDate);
			AddParameter(cmd, "PowerOfAttorney", value.IsPowerOfAttorneyNull ? DBNull.Value : (object)value.PowerOfAttorney);
			AddParameter(cmd, "ContractNote", value.IsContractNoteNull ? DBNull.Value : (object)value.ContractNote);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(ContractRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Contract] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[FormID], " + 
			"[ContractNo], " + 
			"[Amount], " + 
			"[ContractDate], " + 
			"[SigningPlace], " + 
			"[SigningDate], " + 
			"[PowerOfAttorney], " + 
			"[ContractNote], " + 
			"[IsActive], " + 
			"[ModifiedDate], " + 
			"[Remark]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("FormID") + ", " +
			CreateSqlParameterName("ContractNo") + ", " +
			CreateSqlParameterName("Amount") + ", " +
			CreateSqlParameterName("ContractDate") + ", " +
			CreateSqlParameterName("SigningPlace") + ", " +
			CreateSqlParameterName("SigningDate") + ", " +
			CreateSqlParameterName("PowerOfAttorney") + ", " +
			CreateSqlParameterName("ContractNote") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("Remark") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "FormID", value.FormID);
			AddParameter(cmd, "ContractNo", value.IsContractNoNull ? DBNull.Value : (object)value.ContractNo);
			AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
			AddParameter(cmd, "ContractDate", value.IsContractDateNull ? DBNull.Value : (object)value.ContractDate);
			AddParameter(cmd, "SigningPlace", value.IsSigningPlaceNull ? DBNull.Value : (object)value.SigningPlace);
			AddParameter(cmd, "SigningDate", value.IsSigningDateNull ? DBNull.Value : (object)value.SigningDate);
			AddParameter(cmd, "PowerOfAttorney", value.IsPowerOfAttorneyNull ? DBNull.Value : (object)value.PowerOfAttorney);
			AddParameter(cmd, "ContractNote", value.IsContractNoteNull ? DBNull.Value : (object)value.ContractNote);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "Remark", value.IsRemarkNull ? DBNull.Value : (object)value.Remark);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(ContractRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContractID == true )
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
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetContractNo)
				{
					strUpdate += "[ContractNo]=" + CreateSqlParameterName("ContractNo") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetContractDate)
				{
					strUpdate += "[ContractDate]=" + CreateSqlParameterName("ContractDate") + ",";
				}
				if (value._IsSetSigningPlace)
				{
					strUpdate += "[SigningPlace]=" + CreateSqlParameterName("SigningPlace") + ",";
				}
				if (value._IsSetSigningDate)
				{
					strUpdate += "[SigningDate]=" + CreateSqlParameterName("SigningDate") + ",";
				}
				if (value._IsSetPowerOfAttorney)
				{
					strUpdate += "[PowerOfAttorney]=" + CreateSqlParameterName("PowerOfAttorney") + ",";
				}
				if (value._IsSetContractNote)
				{
					strUpdate += "[ContractNote]=" + CreateSqlParameterName("ContractNote") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Contract] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "ContractNo", value.ContractNo);
				if (value._IsSetAmount)
				{
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
				}
				if (value._IsSetContractDate)
				{
					AddParameter(cmd, "ContractDate", value.IsContractDateNull ? DBNull.Value : (object)value.ContractDate);
				}
					AddParameter(cmd, "SigningPlace", value.SigningPlace);
				if (value._IsSetSigningDate)
				{
					AddParameter(cmd, "SigningDate", value.IsSigningDateNull ? DBNull.Value : (object)value.SigningDate);
				}
					AddParameter(cmd, "PowerOfAttorney", value.PowerOfAttorney);
					AddParameter(cmd, "ContractNote", value.ContractNote);
				if (value._IsSetIsActive)
				{
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
					AddParameter(cmd, "Remark", value.Remark);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ContractID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ContractRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContractID == true )
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
				if (value._IsSetDepartmentID)
				{
					strUpdate += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID") + ",";
				}
				if (value._IsSetFormID)
				{
					strUpdate += "[FormID]=" + CreateSqlParameterName("FormID") + ",";
				}
				if (value._IsSetContractNo)
				{
					strUpdate += "[ContractNo]=" + CreateSqlParameterName("ContractNo") + ",";
				}
				if (value._IsSetAmount)
				{
					strUpdate += "[Amount]=" + CreateSqlParameterName("Amount") + ",";
				}
				if (value._IsSetContractDate)
				{
					strUpdate += "[ContractDate]=" + CreateSqlParameterName("ContractDate") + ",";
				}
				if (value._IsSetSigningPlace)
				{
					strUpdate += "[SigningPlace]=" + CreateSqlParameterName("SigningPlace") + ",";
				}
				if (value._IsSetSigningDate)
				{
					strUpdate += "[SigningDate]=" + CreateSqlParameterName("SigningDate") + ",";
				}
				if (value._IsSetPowerOfAttorney)
				{
					strUpdate += "[PowerOfAttorney]=" + CreateSqlParameterName("PowerOfAttorney") + ",";
				}
				if (value._IsSetContractNote)
				{
					strUpdate += "[ContractNote]=" + CreateSqlParameterName("ContractNote") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Contract] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "FormID", value.FormID);
					AddParameter(cmd, "ContractNo", Sanitizer.GetSafeHtmlFragment(value.ContractNo));
				if (value._IsSetAmount)
				{
					AddParameter(cmd, "Amount", value.IsAmountNull ? DBNull.Value : (object)value.Amount);
				}
				if (value._IsSetContractDate)
				{
					AddParameter(cmd, "ContractDate", value.IsContractDateNull ? DBNull.Value : (object)value.ContractDate);
				}
					AddParameter(cmd, "SigningPlace", Sanitizer.GetSafeHtmlFragment(value.SigningPlace));
				if (value._IsSetSigningDate)
				{
					AddParameter(cmd, "SigningDate", value.IsSigningDateNull ? DBNull.Value : (object)value.SigningDate);
				}
					AddParameter(cmd, "PowerOfAttorney", Sanitizer.GetSafeHtmlFragment(value.PowerOfAttorney));
					AddParameter(cmd, "ContractNote", Sanitizer.GetSafeHtmlFragment(value.ContractNote));
				if (value._IsSetIsActive)
				{
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
				}
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ContractID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int contractID)
		{
			string whereSql = "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContractID", contractID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public ContractRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			ContractRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByCaseID(int caseID)
		{
			return CreateDeleteByCaseIDCommand(caseID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public int DeleteByDepartmentID(int departmentId)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public int DeleteByFormID(int formID)
		{
			return CreateDeleteByFormIDCommand(formID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFormIDCommand(int formID)
		{
			string whereSql = "";
			whereSql += "[FormID]=" + CreateSqlParameterName("FormID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormID", formID);
			return cmd;
		}
		protected ContractRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ContractRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ContractRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int formIDColumnIndex = reader.GetOrdinal("FormID");
			int contractNoColumnIndex = reader.GetOrdinal("ContractNo");
			int amountColumnIndex = reader.GetOrdinal("Amount");
			int contractDateColumnIndex = reader.GetOrdinal("ContractDate");
			int signingPlaceColumnIndex = reader.GetOrdinal("SigningPlace");
			int signingDateColumnIndex = reader.GetOrdinal("SigningDate");
			int powerOfAttorneyColumnIndex = reader.GetOrdinal("PowerOfAttorney");
			int contractNoteColumnIndex = reader.GetOrdinal("ContractNote");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ContractRow record = new ContractRow();
					recordList.Add(record);
					record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.FormID =  Convert.ToInt32(reader.GetValue(formIDColumnIndex));
					if (!reader.IsDBNull(contractNoColumnIndex)) record.ContractNo =  Convert.ToString(reader.GetValue(contractNoColumnIndex));

					if (!reader.IsDBNull(amountColumnIndex)) record.Amount =  Convert.ToDouble(reader.GetValue(amountColumnIndex));

					if (!reader.IsDBNull(contractDateColumnIndex)) record.ContractDate =  Convert.ToDateTime(reader.GetValue(contractDateColumnIndex));

					if (!reader.IsDBNull(signingPlaceColumnIndex)) record.SigningPlace =  Convert.ToString(reader.GetValue(signingPlaceColumnIndex));

					if (!reader.IsDBNull(signingDateColumnIndex)) record.SigningDate =  Convert.ToDateTime(reader.GetValue(signingDateColumnIndex));

					if (!reader.IsDBNull(powerOfAttorneyColumnIndex)) record.PowerOfAttorney =  Convert.ToString(reader.GetValue(powerOfAttorneyColumnIndex));

					if (!reader.IsDBNull(contractNoteColumnIndex)) record.ContractNote =  Convert.ToString(reader.GetValue(contractNoteColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ContractRow[])(recordList.ToArray(typeof(ContractRow)));
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
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ContractNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Amount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ContractDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "SigningPlace":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "SigningDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PowerOfAttorney":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ContractNote":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Remark":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				throw new FaultException("Zero ProcessID");
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

