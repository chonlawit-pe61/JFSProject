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
	public partial class CaseProjectMetaCollection_Base : MarshalByRefObject
	{
		public const string MetaIDColumnName = "MetaID";
		public const string CaseIDColumnName = "CaseID";
		public const string MetaKeyColumnName = "MetaKey";
		public const string MetaValueColumnName = "MetaValue";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseProjectMetaCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseProjectMetaRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CaseProjectMetaPaging GetPagingRelyOnMetaIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectMetaPaging caseProjectMetaPaging = new CaseProjectMetaPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MetaID) as TotalRow from [dbo].[CaseProjectMeta]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectMetaPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectMetaPaging.totalPage = (int)Math.Ceiling((double) caseProjectMetaPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectMetaPaging.caseProjectMetaRow = MapRecords(command);
			return caseProjectMetaPaging;
		}
		public virtual CaseProjectMetaPaging GetPagingRelyOnMetaIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CaseProjectMetaPaging caseProjectMetaPaging = new CaseProjectMetaPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MetaID) as TotalRow from [dbo].[CaseProjectMeta]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			caseProjectMetaPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			caseProjectMetaPaging.totalPage = (int)Math.Ceiling((double)caseProjectMetaPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			caseProjectMetaPaging.caseProjectMetaRow = MapRecords(command);
			return caseProjectMetaPaging;
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID < " + minMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID < " + minMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID > " + minMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID > " + minMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID < " + maxMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID < " + maxMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMetaID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MetaID > " + maxMetaID.ToString();
			}
			else
			{
				whereSql = "MetaID > " + maxMetaID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, "MetaID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MetaID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CaseProjectMetaRow[] caseProjectMetaRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectMetaRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMetaIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectMetaRow = MapRecords(command);
			}
			return caseProjectMetaRow;
		}
		public virtual CaseProjectMetaRow[] GetPagingRelyOnMetaIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MetaID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CaseProjectMetaRow[] caseProjectMetaRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMetaID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectMetaRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMetaIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				caseProjectMetaRow = MapRecords(command);
			}
			return caseProjectMetaRow;
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
			"[MetaID],"+
			"[CaseID],"+
			"[MetaKey],"+
			"[MetaValue]"+
			" FROM [dbo].[CaseProjectMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MetaID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectMeta] where MetaID < (select min(minMetaID) from(select top " + (rowPerPage * pageNumber).ToString() + " MetaID as minMetaID from [dbo].[CaseProjectMeta]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[CaseProjectMeta]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMetaIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MetaID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CaseProjectMeta] where MetaID > (select max(maxMetaID) from(select top " + (rowPerPage * pageNumber).ToString() + " MetaID as maxMetaID from [dbo].[CaseProjectMeta]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[CaseProjectMeta]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseProjectMeta]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseProjectMeta"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MetaID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MetaKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MetaValue",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			return dataTable;
		}
		public virtual CaseProjectMetaRow[] GetByCaseID(int caseID)
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
		public CaseProjectMetaRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseProjectMetaRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseProjectMetaRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseProjectMetaRow"/> objects.</returns>
		public virtual CaseProjectMetaRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseProjectMeta]", top);
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
		public CaseProjectMetaRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseProjectMetaRow[] rows = null;
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
		public DataTable GetCaseProjectMetaPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MetaID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MetaID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(MetaID) AS TotalRow FROM [dbo].[CaseProjectMeta] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MetaID,CaseID,MetaKey,MetaValue," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseProjectMeta] " + whereSql +
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
		public CaseProjectMetaItemsPaging GetCaseProjectMetaPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MetaID")
		{
		CaseProjectMetaItemsPaging obj = new CaseProjectMetaItemsPaging();
		DataTable dt = GetCaseProjectMetaPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseProjectMetaItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseProjectMetaItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MetaID = Convert.ToInt32(dt.Rows[i]["MetaID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.MetaKey = dt.Rows[i]["MetaKey"].ToString();
			record.MetaValue = dt.Rows[i]["MetaValue"].ToString();
			recordList.Add(record);
		}
		obj.caseProjectMetaItems = (CaseProjectMetaItems[])(recordList.ToArray(typeof(CaseProjectMetaItems)));
		return obj;
		}
		public CaseProjectMetaRow GetByPrimaryKey(int metaID, int caseID)
		{
			string whereSql = "[MetaID]=" + CreateSqlParameterName("MetaID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MetaID", metaID);
			AddParameter(cmd, "CaseID", caseID);
			CaseProjectMetaRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CaseProjectMetaRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectMeta] (" +
			"[CaseID], " + 
			"[MetaKey], " + 
			"[MetaValue]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("MetaKey") + ", " +
			CreateSqlParameterName("MetaValue") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "MetaKey", value.IsMetaKeyNull ? DBNull.Value : (object)value.MetaKey);
			AddParameter(cmd, "MetaValue", value.IsMetaValueNull ? DBNull.Value : (object)value.MetaValue);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CaseProjectMetaRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseProjectMeta] (" +
			"[CaseID], " + 
			"[MetaKey], " + 
			"[MetaValue]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("MetaKey") + ", " +
			CreateSqlParameterName("MetaValue") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "MetaKey", value.IsMetaKeyNull ? DBNull.Value : (object)value.MetaKey);
			AddParameter(cmd, "MetaValue", value.IsMetaValueNull ? DBNull.Value : (object)value.MetaValue);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CaseProjectMetaRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMetaID == true && value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMetaKey)
				{
					strUpdate += "[MetaKey]=" + CreateSqlParameterName("MetaKey") + ",";
				}
				if (value._IsSetMetaValue)
				{
					strUpdate += "[MetaValue]=" + CreateSqlParameterName("MetaValue") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectMeta] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MetaID]=" + CreateSqlParameterName("MetaID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MetaID", value.MetaID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "MetaKey", value.MetaKey);
					AddParameter(cmd, "MetaValue", value.MetaValue);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MetaID,CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseProjectMetaRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMetaID == true && value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMetaKey)
				{
					strUpdate += "[MetaKey]=" + CreateSqlParameterName("MetaKey") + ",";
				}
				if (value._IsSetMetaValue)
				{
					strUpdate += "[MetaValue]=" + CreateSqlParameterName("MetaValue") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseProjectMeta] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MetaID]=" + CreateSqlParameterName("MetaID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MetaID", value.MetaID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "MetaKey", Sanitizer.GetSafeHtmlFragment(value.MetaKey));
					AddParameter(cmd, "MetaValue", Sanitizer.GetSafeHtmlFragment(value.MetaValue));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MetaID,CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int metaID, int caseID)
		{
			string whereSql = "[MetaID]=" + CreateSqlParameterName("MetaID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MetaID", metaID);
			AddParameter(cmd, "CaseID", caseID);
			return 0 < cmd.ExecuteNonQuery();
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
		protected CaseProjectMetaRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseProjectMetaRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseProjectMetaRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int metaIDColumnIndex = reader.GetOrdinal("MetaID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int metaKeyColumnIndex = reader.GetOrdinal("MetaKey");
			int metaValueColumnIndex = reader.GetOrdinal("MetaValue");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseProjectMetaRow record = new CaseProjectMetaRow();
					recordList.Add(record);
					record.MetaID =  Convert.ToInt32(reader.GetValue(metaIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					if (!reader.IsDBNull(metaKeyColumnIndex)) record.MetaKey =  Convert.ToString(reader.GetValue(metaKeyColumnIndex));

					if (!reader.IsDBNull(metaValueColumnIndex)) record.MetaValue =  Convert.ToString(reader.GetValue(metaValueColumnIndex));

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
			return (CaseProjectMetaRow[])(recordList.ToArray(typeof(CaseProjectMetaRow)));
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
				case "MetaID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MetaKey":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MetaValue":
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

