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
	public partial class InboxDetailCollection_Base : MarshalByRefObject
	{
		public const string DetailIDColumnName = "DetailID";
		public const string InboxIDColumnName = "InboxID";
		public const string KeyNameColumnName = "KeyName";
		public const string ValueColumnName = "Value";
		public const string CaptionColumnName = "Caption";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActiveColumnName = "IsActive";
		public const string IsShowColumnName = "IsShow";
		private int _processID;
		public SqlCommand cmd = null;
		public InboxDetailCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual InboxDetailRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual InboxDetailPaging GetPagingRelyOnDetailIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			InboxDetailPaging inboxDetailPaging = new InboxDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(DetailID) as TotalRow from [dbo].[InboxDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			inboxDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			inboxDetailPaging.totalPage = (int)Math.Ceiling((double) inboxDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			inboxDetailPaging.inboxDetailRow = MapRecords(command);
			return inboxDetailPaging;
		}
		public virtual InboxDetailPaging GetPagingRelyOnDetailIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			InboxDetailPaging inboxDetailPaging = new InboxDetailPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(DetailID) as TotalRow from [dbo].[InboxDetail]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			inboxDetailPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			inboxDetailPaging.totalPage = (int)Math.Ceiling((double)inboxDetailPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			inboxDetailPaging.inboxDetailRow = MapRecords(command);
			return inboxDetailPaging;
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And DetailID < " + minDetailID.ToString();
			}
			else
			{
				whereSql = "DetailID < " + minDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And DetailID > " + minDetailID.ToString();
			}
			else
			{
				whereSql = "DetailID > " + minDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And DetailID < " + maxDetailID.ToString();
			}
			else
			{
				whereSql = "DetailID < " + maxDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxDetailID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And DetailID > " + maxDetailID.ToString();
			}
			else
			{
				whereSql = "DetailID > " + maxDetailID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, "DetailID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "DetailID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			InboxDetailRow[] inboxDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnDetailIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxDetailRow = MapRecords(command);
			}
			return inboxDetailRow;
		}
		public virtual InboxDetailRow[] GetPagingRelyOnDetailIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "DetailID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			InboxDetailRow[] inboxDetailRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnDetailID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxDetailRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnDetailIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				inboxDetailRow = MapRecords(command);
			}
			return inboxDetailRow;
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
			"[DetailID],"+
			"[InboxID],"+
			"[KeyName],"+
			"[Value],"+
			"[Caption],"+
			"[SortOrder],"+
			"[IsActive],"+
			"[IsShow]"+
			" FROM [dbo].[InboxDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnDetailID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[InboxDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnDetailIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "DetailID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[InboxDetail] where DetailID < (select min(minDetailID) from(select top " + (rowPerPage * pageNumber).ToString() + " DetailID as minDetailID from [dbo].[InboxDetail]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[InboxDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnDetailIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "DetailID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[InboxDetail] where DetailID > (select max(maxDetailID) from(select top " + (rowPerPage * pageNumber).ToString() + " DetailID as maxDetailID from [dbo].[InboxDetail]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[InboxDetail]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[InboxDetail]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "InboxDetail"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("DetailID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InboxID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("KeyName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Value",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Caption",Type.GetType("System.String"));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsShow",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public virtual InboxDetailRow[] GetByInboxID(int inboxiD)
		{
			return MapRecords(CreateGetByInboxIDCommand(inboxiD));
		}
		public virtual DataTable GetByInboxIDAsDataTable(int inboxiD)
		{
			return MapRecordsToDataTable(CreateGetByInboxIDCommand(inboxiD));
		}
		protected virtual IDbCommand CreateGetByInboxIDCommand(int inboxiD)
		{
			string whereSql = "";
			whereSql += "[InboxID]=" + CreateSqlParameterName("InboxID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InboxID", inboxiD);
			return cmd;
		}
		public InboxDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual InboxDetailRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="InboxDetailRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="InboxDetailRow"/> objects.</returns>
		public virtual InboxDetailRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[InboxDetail]", top);
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
		public InboxDetailRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			InboxDetailRow[] rows = null;
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
		public DataTable GetInboxDetailPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DetailID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "DetailID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(DetailID) AS TotalRow FROM [dbo].[InboxDetail] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,DetailID,InboxID,KeyName,Value,Caption,SortOrder,IsActive,IsShow," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[InboxDetail] " + whereSql +
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
		public InboxDetailItemsPaging GetInboxDetailPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "DetailID")
		{
		InboxDetailItemsPaging obj = new InboxDetailItemsPaging();
		DataTable dt = GetInboxDetailPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		InboxDetailItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new InboxDetailItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.DetailID = Convert.ToInt32(dt.Rows[i]["DetailID"]);
			record.InboxID = Convert.ToInt32(dt.Rows[i]["InboxID"]);
			record.KeyName = dt.Rows[i]["KeyName"].ToString();
			record.Value = dt.Rows[i]["Value"].ToString();
			record.Caption = dt.Rows[i]["Caption"].ToString();
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["IsShow"] != DBNull.Value)
			record.IsShow = Convert.ToBoolean(dt.Rows[i]["IsShow"]);
			recordList.Add(record);
		}
		obj.inboxDetailItems = (InboxDetailItems[])(recordList.ToArray(typeof(InboxDetailItems)));
		return obj;
		}
		public InboxDetailRow GetByPrimaryKey(int detailId)
		{
			string whereSql = "[DetailID]=" + CreateSqlParameterName("DetailID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DetailID", detailId);
			InboxDetailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(InboxDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InboxDetail] (" +
			"[InboxID], " + 
			"[KeyName], " + 
			"[Value], " + 
			"[Caption], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[IsShow]			" + 
			") VALUES (" +
			CreateSqlParameterName("InboxID") + ", " +
			CreateSqlParameterName("KeyName") + ", " +
			CreateSqlParameterName("Value") + ", " +
			CreateSqlParameterName("Caption") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsShow") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InboxID", value.InboxID);
			AddParameter(cmd, "KeyName",value.KeyName);
			AddParameter(cmd, "Value",value.Value);
			AddParameter(cmd, "Caption", value.Caption);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "IsShow", value.IsIsShowNull ? DBNull.Value : (object)value.IsShow);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(InboxDetailRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InboxDetail] (" +
			"[InboxID], " + 
			"[KeyName], " + 
			"[Value], " + 
			"[Caption], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[IsShow]			" + 
			") VALUES (" +
			CreateSqlParameterName("InboxID") + ", " +
			CreateSqlParameterName("KeyName") + ", " +
			CreateSqlParameterName("Value") + ", " +
			CreateSqlParameterName("Caption") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("IsShow") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InboxID", value.InboxID);
			AddParameter(cmd, "KeyName", Sanitizer.GetSafeHtmlFragment(value.KeyName));
			AddParameter(cmd, "Value", Sanitizer.GetSafeHtmlFragment(value.Value));
			AddParameter(cmd, "Caption", Sanitizer.GetSafeHtmlFragment(value.Caption));
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "IsShow", value.IsIsShowNull ? DBNull.Value : (object)value.IsShow);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(InboxDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDetailID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInboxID)
				{
					strUpdate += "[InboxID]=" + CreateSqlParameterName("InboxID") + ",";
				}
				if (value._IsSetKeyName)
				{
					strUpdate += "[KeyName]=" + CreateSqlParameterName("KeyName") + ",";
				}
				if (value._IsSetValue)
				{
					strUpdate += "[Value]=" + CreateSqlParameterName("Value") + ",";
				}
				if (value._IsSetCaption)
				{
					strUpdate += "[Caption]=" + CreateSqlParameterName("Caption") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsShow)
				{
					strUpdate += "[IsShow]=" + CreateSqlParameterName("IsShow") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[InboxDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DetailID]=" + CreateSqlParameterName("DetailID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DetailID", value.DetailID);
					AddParameter(cmd, "InboxID", value.InboxID);
					AddParameter(cmd, "KeyName",value.KeyName);
					AddParameter(cmd, "Value",value.Value);
					AddParameter(cmd, "Caption", value.Caption);
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "IsShow", value.IsIsShowNull ? DBNull.Value : (object)value.IsShow);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(DetailID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(InboxDetailRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetDetailID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInboxID)
				{
					strUpdate += "[InboxID]=" + CreateSqlParameterName("InboxID") + ",";
				}
				if (value._IsSetKeyName)
				{
					strUpdate += "[KeyName]=" + CreateSqlParameterName("KeyName") + ",";
				}
				if (value._IsSetValue)
				{
					strUpdate += "[Value]=" + CreateSqlParameterName("Value") + ",";
				}
				if (value._IsSetCaption)
				{
					strUpdate += "[Caption]=" + CreateSqlParameterName("Caption") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetIsShow)
				{
					strUpdate += "[IsShow]=" + CreateSqlParameterName("IsShow") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[InboxDetail] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[DetailID]=" + CreateSqlParameterName("DetailID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "DetailID", value.DetailID);
					AddParameter(cmd, "InboxID", value.InboxID);
					AddParameter(cmd, "KeyName", Sanitizer.GetSafeHtmlFragment(value.KeyName));
					AddParameter(cmd, "Value", Sanitizer.GetSafeHtmlFragment(value.Value));
					AddParameter(cmd, "Caption", Sanitizer.GetSafeHtmlFragment(value.Caption));
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "IsShow", value.IsIsShowNull ? DBNull.Value : (object)value.IsShow);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(DetailID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int detailId)
		{
			string whereSql = "[DetailID]=" + CreateSqlParameterName("DetailID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DetailID", detailId);
			return 0 < cmd.ExecuteNonQuery();
		}
		public InboxDetailRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			InboxDetailRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByInboxID(int inboxiD)
		{
			return CreateDeleteByInboxIDCommand(inboxiD).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByInboxIDCommand(int inboxiD)
		{
			string whereSql = "";
			whereSql += "[InboxID]=" + CreateSqlParameterName("InboxID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InboxID", inboxiD);
			return cmd;
		}
		protected InboxDetailRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected InboxDetailRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected InboxDetailRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int detailIdColumnIndex = reader.GetOrdinal("DetailID");
			int inboxiDColumnIndex = reader.GetOrdinal("InboxID");
			int keyNameColumnIndex = reader.GetOrdinal("KeyName");
			int valueColumnIndex = reader.GetOrdinal("Value");
			int captionColumnIndex = reader.GetOrdinal("Caption");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int isShowColumnIndex = reader.GetOrdinal("IsShow");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					InboxDetailRow record = new InboxDetailRow();
					recordList.Add(record);
					record.DetailID =  Convert.ToInt32(reader.GetValue(detailIdColumnIndex));
					record.InboxID =  Convert.ToInt32(reader.GetValue(inboxiDColumnIndex));
					record.KeyName =  Convert.ToString(reader.GetValue(keyNameColumnIndex));
					record.Value =  Convert.ToString(reader.GetValue(valueColumnIndex));
					if (!reader.IsDBNull(captionColumnIndex)) record.Caption =  Convert.ToString(reader.GetValue(captionColumnIndex));

					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					if (!reader.IsDBNull(isShowColumnIndex)) record.IsShow =  Convert.ToBoolean(reader.GetValue(isShowColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (InboxDetailRow[])(recordList.ToArray(typeof(InboxDetailRow)));
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
				case "DetailID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InboxID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "KeyName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Value":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Caption":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsShow":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

