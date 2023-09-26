using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Mvc.Transaction.Structure;
namespace Megazy.StarterKit.Mvc.Transaction.Dal
{
	[Serializable]
	public partial class SysSettingCollection_Base : MarshalByRefObject
	{
		public const string SettingIDColumnName = "SettingID";
		public const string TagColumnName = "Tag";
		public const string KeyColumnName = "Key";
		public const string LabelColumnName = "Label";
		public const string ValueColumnName = "Value";
		private int _processID;
		public SqlCommand cmd = null;
		public SysSettingCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SysSettingRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual SysSettingPaging GetPagingRelyOnSettingIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SysSettingPaging syssettingPaging = new SysSettingPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SettingID) as TotalRow from [dbo].[SysSetting]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			syssettingPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			syssettingPaging.totalPage = (int)Math.Ceiling((double) syssettingPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			syssettingPaging.syssettingRow = MapRecords(command);
			return syssettingPaging;
		}
		public virtual SysSettingPaging GetPagingRelyOnSettingIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SysSettingPaging syssettingPaging = new SysSettingPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SettingID) as TotalRow from [dbo].[SysSetting]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			syssettingPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			syssettingPaging.totalPage = (int)Math.Ceiling((double)syssettingPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			syssettingPaging.syssettingRow = MapRecords(command);
			return syssettingPaging;
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSettingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SettingID < " + minSettingID.ToString();
			}
			else
			{
				whereSql = "SettingID < " + minSettingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSettingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SettingID > " + minSettingID.ToString();
			}
			else
			{
				whereSql = "SettingID > " + minSettingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSettingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SettingID < " + maxSettingID.ToString();
			}
			else
			{
				whereSql = "SettingID < " + maxSettingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSettingID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SettingID > " + maxSettingID.ToString();
			}
			else
			{
				whereSql = "SettingID > " + maxSettingID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, "SettingID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SettingID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			SysSettingRow[] syssettingRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				syssettingRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSettingIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				syssettingRow = MapRecords(command);
			}
			return syssettingRow;
		}
		public virtual SysSettingRow[] GetPagingRelyOnSettingIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SettingID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			SysSettingRow[] syssettingRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSettingID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				syssettingRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSettingIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				syssettingRow = MapRecords(command);
			}
			return syssettingRow;
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
			"[SettingID],"+
			"[Tag],"+
			"[Key],"+
			"[Label],"+
			"[Value]"+
			" FROM [dbo].[SysSetting]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSettingID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SysSetting]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSettingIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SettingID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SysSetting] where SettingID < (select min(minSettingID) from(select top " + (rowPerPage * pageNumber).ToString() + " SettingID as minSettingID from [dbo].[SysSetting]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[SysSetting]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSettingIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SettingID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SysSetting] where SettingID > (select max(maxSettingID) from(select top " + (rowPerPage * pageNumber).ToString() + " SettingID as maxSettingID from [dbo].[SysSetting]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[SysSetting]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SysSetting]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SysSetting"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SettingID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Tag",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Key",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Label",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Value",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			return dataTable;
		}
		public SysSettingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SysSettingRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SysSettingRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SysSettingRow"/> objects.</returns>
		public virtual SysSettingRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SysSetting]", top);
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
		public SysSettingRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SysSettingRow[] rows = null;
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
		public DataTable GetSysSettingPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SettingID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "SettingID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(SettingID) AS TotalRow FROM [dbo].[SysSetting] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,SettingID,Tag,Key,Label,Value," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [SysSetting].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SysSetting] " + whereSql +
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
		public SysSettingItemsPaging GetSysSettingPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SettingID")
		{
		SysSettingItemsPaging obj = new SysSettingItemsPaging();
		DataTable dt = GetSysSettingPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SysSettingItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SysSettingItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.SettingID = Convert.ToInt32(dt.Rows[i]["SettingID"]);
			record.Tag = dt.Rows[i]["Tag"].ToString();
			record.Key = dt.Rows[i]["Key"].ToString();
			record.Label = dt.Rows[i]["Label"].ToString();
			record.Value = dt.Rows[i]["Value"].ToString();
			recordList.Add(record);
		}
		obj.syssettingItems = (SysSettingItems[])(recordList.ToArray(typeof(SysSettingItems)));
		return obj;
		}
		public SysSettingRow GetByPrimaryKey(int settingID)
		{
			string whereSql = "[SettingID]=" + CreateSqlParameterName("SettingID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SettingID", settingID);
			SysSettingRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(SysSettingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysSetting] (" +
			"[Tag], " + 
			"[Key], " + 
			"[Label], " + 
			"[Value]			" + 
			") VALUES (" +
			CreateSqlParameterName("Tag") + ", " +
			CreateSqlParameterName("Key") + ", " +
			CreateSqlParameterName("Label") + ", " +
			CreateSqlParameterName("Value") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Tag",value.Tag);
			AddParameter(cmd, "Key",value.Key);
			AddParameter(cmd, "Label",value.Label);
			AddParameter(cmd, "Value", value.Value);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(SysSettingRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysSetting] (" +
			"[Tag], " + 
			"[Key], " + 
			"[Label], " + 
			"[Value]			" + 
			") VALUES (" +
			CreateSqlParameterName("Tag") + ", " +
			CreateSqlParameterName("Key") + ", " +
			CreateSqlParameterName("Label") + ", " +
			CreateSqlParameterName("Value") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Tag", Sanitizer.GetSafeHtmlFragment(value.Tag));
			AddParameter(cmd, "Key", Sanitizer.GetSafeHtmlFragment(value.Key));
			AddParameter(cmd, "Label", Sanitizer.GetSafeHtmlFragment(value.Label));
			AddParameter(cmd, "Value", Sanitizer.GetSafeHtmlFragment(value.Value));
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(SysSettingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSettingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTag)
				{
					strUpdate += "[Tag]=" + CreateSqlParameterName("Tag") + ",";
				}
				if (value._IsSetKey)
				{
					strUpdate += "[Key]=" + CreateSqlParameterName("Key") + ",";
				}
				if (value._IsSetLabel)
				{
					strUpdate += "[Label]=" + CreateSqlParameterName("Label") + ",";
				}
				if (value._IsSetValue)
				{
					strUpdate += "[Value]=" + CreateSqlParameterName("Value") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysSetting] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SettingID]=" + CreateSqlParameterName("SettingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SettingID", value.SettingID);
					AddParameter(cmd, "Tag",value.Tag);
					AddParameter(cmd, "Key",value.Key);
					AddParameter(cmd, "Label",value.Label);
					AddParameter(cmd, "Value", value.Value);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SettingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SysSettingRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSettingID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTag)
				{
					strUpdate += "[Tag]=" + CreateSqlParameterName("Tag") + ",";
				}
				if (value._IsSetKey)
				{
					strUpdate += "[Key]=" + CreateSqlParameterName("Key") + ",";
				}
				if (value._IsSetLabel)
				{
					strUpdate += "[Label]=" + CreateSqlParameterName("Label") + ",";
				}
				if (value._IsSetValue)
				{
					strUpdate += "[Value]=" + CreateSqlParameterName("Value") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysSetting] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SettingID]=" + CreateSqlParameterName("SettingID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SettingID", value.SettingID);
					AddParameter(cmd, "Tag", Sanitizer.GetSafeHtmlFragment(value.Tag));
					AddParameter(cmd, "Key", Sanitizer.GetSafeHtmlFragment(value.Key));
					AddParameter(cmd, "Label", Sanitizer.GetSafeHtmlFragment(value.Label));
					AddParameter(cmd, "Value", Sanitizer.GetSafeHtmlFragment(value.Value));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SettingID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int settingID)
		{
			string whereSql = "[SettingID]=" + CreateSqlParameterName("SettingID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SettingID", settingID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected SysSettingRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SysSettingRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SysSettingRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int settingIDColumnIndex = reader.GetOrdinal("SettingID");
			int tagColumnIndex = reader.GetOrdinal("Tag");
			int keyColumnIndex = reader.GetOrdinal("Key");
			int labelColumnIndex = reader.GetOrdinal("Label");
			int valueColumnIndex = reader.GetOrdinal("Value");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SysSettingRow record = new SysSettingRow();
					recordList.Add(record);
					record.SettingID =  Convert.ToInt32(reader.GetValue(settingIDColumnIndex));
					record.Tag =  Convert.ToString(reader.GetValue(tagColumnIndex));
					record.Key =  Convert.ToString(reader.GetValue(keyColumnIndex));
					record.Label =  Convert.ToString(reader.GetValue(labelColumnIndex));
					if (!reader.IsDBNull(valueColumnIndex)) record.Value =  Convert.ToString(reader.GetValue(valueColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SysSettingRow[])(recordList.ToArray(typeof(SysSettingRow)));
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
				case "SettingID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Tag":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Key":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Label":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Value":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

