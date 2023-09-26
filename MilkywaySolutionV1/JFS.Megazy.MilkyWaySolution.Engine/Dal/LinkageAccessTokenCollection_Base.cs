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
	public partial class LinkageAccessTokenCollection_Base : MarshalByRefObject
	{
		public const string UserIDColumnName = "UserID";
		public const string PIDColumnName = "PID";
		public const string CIDColumnName = "CID";
		public const string XKeyColumnName = "XKey";
		public const string MatchKeyColumnName = "MatchKey";
		public const string EnvelopGMXsColumnName = "EnvelopGMXs";
		public const string TokenKeyColumnName = "TokenKey";
		public const string DateCreatedColumnName = "DateCreated";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public LinkageAccessTokenCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual LinkageAccessTokenRow[] GetAll()
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
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[UserID],"+
			"[PID],"+
			"[CID],"+
			"[XKey],"+
			"[MatchKey],"+
			"[EnvelopGMXs],"+
			"[TokenKey],"+
			"[DateCreated],"+
			"[ModifiedDate]"+
			" FROM [dbo].[LinkageAccessToken]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[LinkageAccessToken]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "LinkageAccessToken"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PID",Type.GetType("System.String"));
			dataColumn.MaxLength = 13;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CID",Type.GetType("System.String"));
			dataColumn.MaxLength = 16;
			dataColumn = dataTable.Columns.Add("XKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("MatchKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("EnvelopGMXs",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("TokenKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("DateCreated",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual LinkageAccessTokenRow[] GetByUserID(int userID)
		{
			return MapRecords(CreateGetByUserIDCommand(userID));
		}
		public virtual DataTable GetByUserIDAsDataTable(int userID)
		{
			return MapRecordsToDataTable(CreateGetByUserIDCommand(userID));
		}
		protected virtual IDbCommand CreateGetByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		public LinkageAccessTokenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual LinkageAccessTokenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="LinkageAccessTokenRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LinkageAccessTokenRow"/> objects.</returns>
		public virtual LinkageAccessTokenRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[LinkageAccessToken]", top);
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
		public LinkageAccessTokenRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			LinkageAccessTokenRow[] rows = null;
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
		public DataTable GetLinkageAccessTokenPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "UserID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(UserID) AS TotalRow FROM [dbo].[LinkageAccessToken] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,UserID,PID,CID,XKey,MatchKey,EnvelopGMXs,TokenKey,DateCreated,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [LinkageAccessToken].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[LinkageAccessToken] " + whereSql +
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
		public LinkageAccessTokenItemsPaging GetLinkageAccessTokenPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
		LinkageAccessTokenItemsPaging obj = new LinkageAccessTokenItemsPaging();
		DataTable dt = GetLinkageAccessTokenPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		LinkageAccessTokenItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new LinkageAccessTokenItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.PID = dt.Rows[i]["PID"].ToString();
			record.CID = dt.Rows[i]["CID"].ToString();
			record.XKey = dt.Rows[i]["XKey"].ToString();
			record.MatchKey = dt.Rows[i]["MatchKey"].ToString();
			record.EnvelopGMXs = dt.Rows[i]["EnvelopGMXs"].ToString();
			record.TokenKey = dt.Rows[i]["TokenKey"].ToString();
			if (dt.Rows[i]["DateCreated"] != DBNull.Value)
			record.DateCreated = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.linkageAccessTokenItems = (LinkageAccessTokenItems[])(recordList.ToArray(typeof(LinkageAccessTokenItems)));
		return obj;
		}
		public LinkageAccessTokenRow GetByPrimaryKey(int userID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			LinkageAccessTokenRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(LinkageAccessTokenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LinkageAccessToken] (" +
			"[UserID], " + 
			"[PID], " + 
			"[CID], " + 
			"[XKey], " + 
			"[MatchKey], " + 
			"[EnvelopGMXs], " + 
			"[TokenKey], " + 
			"[DateCreated], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("PID") + ", " +
			CreateSqlParameterName("CID") + ", " +
			CreateSqlParameterName("XKey") + ", " +
			CreateSqlParameterName("MatchKey") + ", " +
			CreateSqlParameterName("EnvelopGMXs") + ", " +
			CreateSqlParameterName("TokenKey") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "PID",value.PID);
			AddParameter(cmd, "CID", value.CID);
			AddParameter(cmd, "XKey", value.XKey);
			AddParameter(cmd, "MatchKey", value.MatchKey);
			AddParameter(cmd, "EnvelopGMXs", value.EnvelopGMXs);
			AddParameter(cmd, "TokenKey", value.TokenKey);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DBNull.Value : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(LinkageAccessTokenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LinkageAccessToken] (" +
			"[UserID], " + 
			"[PID], " + 
			"[CID], " + 
			"[XKey], " + 
			"[MatchKey], " + 
			"[EnvelopGMXs], " + 
			"[TokenKey], " + 
			"[DateCreated], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("PID") + ", " +
			CreateSqlParameterName("CID") + ", " +
			CreateSqlParameterName("XKey") + ", " +
			CreateSqlParameterName("MatchKey") + ", " +
			CreateSqlParameterName("EnvelopGMXs") + ", " +
			CreateSqlParameterName("TokenKey") + ", " +
			CreateSqlParameterName("DateCreated") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "PID", Sanitizer.GetSafeHtmlFragment(value.PID));
			AddParameter(cmd, "CID", Sanitizer.GetSafeHtmlFragment(value.CID));
			AddParameter(cmd, "XKey", Sanitizer.GetSafeHtmlFragment(value.XKey));
			AddParameter(cmd, "MatchKey", Sanitizer.GetSafeHtmlFragment(value.MatchKey));
			AddParameter(cmd, "EnvelopGMXs", Sanitizer.GetSafeHtmlFragment(value.EnvelopGMXs));
			AddParameter(cmd, "TokenKey", Sanitizer.GetSafeHtmlFragment(value.TokenKey));
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DBNull.Value : (object)value.DateCreated);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(LinkageAccessTokenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPID)
				{
					strUpdate += "[PID]=" + CreateSqlParameterName("PID") + ",";
				}
				if (value._IsSetCID)
				{
					strUpdate += "[CID]=" + CreateSqlParameterName("CID") + ",";
				}
				if (value._IsSetXKey)
				{
					strUpdate += "[XKey]=" + CreateSqlParameterName("XKey") + ",";
				}
				if (value._IsSetMatchKey)
				{
					strUpdate += "[MatchKey]=" + CreateSqlParameterName("MatchKey") + ",";
				}
				if (value._IsSetEnvelopGMXs)
				{
					strUpdate += "[EnvelopGMXs]=" + CreateSqlParameterName("EnvelopGMXs") + ",";
				}
				if (value._IsSetTokenKey)
				{
					strUpdate += "[TokenKey]=" + CreateSqlParameterName("TokenKey") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LinkageAccessToken] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "PID",value.PID);
					AddParameter(cmd, "CID", value.CID);
					AddParameter(cmd, "XKey", value.XKey);
					AddParameter(cmd, "MatchKey", value.MatchKey);
					AddParameter(cmd, "EnvelopGMXs", value.EnvelopGMXs);
					AddParameter(cmd, "TokenKey", value.TokenKey);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DBNull.Value : (object)value.DateCreated);
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
				Exception ex = new Exception("Set incorrect primarykey PK(UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(LinkageAccessTokenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPID)
				{
					strUpdate += "[PID]=" + CreateSqlParameterName("PID") + ",";
				}
				if (value._IsSetCID)
				{
					strUpdate += "[CID]=" + CreateSqlParameterName("CID") + ",";
				}
				if (value._IsSetXKey)
				{
					strUpdate += "[XKey]=" + CreateSqlParameterName("XKey") + ",";
				}
				if (value._IsSetMatchKey)
				{
					strUpdate += "[MatchKey]=" + CreateSqlParameterName("MatchKey") + ",";
				}
				if (value._IsSetEnvelopGMXs)
				{
					strUpdate += "[EnvelopGMXs]=" + CreateSqlParameterName("EnvelopGMXs") + ",";
				}
				if (value._IsSetTokenKey)
				{
					strUpdate += "[TokenKey]=" + CreateSqlParameterName("TokenKey") + ",";
				}
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LinkageAccessToken] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "PID", Sanitizer.GetSafeHtmlFragment(value.PID));
					AddParameter(cmd, "CID", Sanitizer.GetSafeHtmlFragment(value.CID));
					AddParameter(cmd, "XKey", Sanitizer.GetSafeHtmlFragment(value.XKey));
					AddParameter(cmd, "MatchKey", Sanitizer.GetSafeHtmlFragment(value.MatchKey));
					AddParameter(cmd, "EnvelopGMXs", Sanitizer.GetSafeHtmlFragment(value.EnvelopGMXs));
					AddParameter(cmd, "TokenKey", Sanitizer.GetSafeHtmlFragment(value.TokenKey));
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DBNull.Value : (object)value.DateCreated);
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
				Exception ex = new Exception("Set incorrect primarykey PK(UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int userID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByUserID(int userID)
		{
			return CreateDeleteByUserIDCommand(userID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		protected LinkageAccessTokenRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected LinkageAccessTokenRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected LinkageAccessTokenRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int pIDColumnIndex = reader.GetOrdinal("PID");
			int cIDColumnIndex = reader.GetOrdinal("CID");
			int xKeyColumnIndex = reader.GetOrdinal("XKey");
			int matchKeyColumnIndex = reader.GetOrdinal("MatchKey");
			int envelopGMXsColumnIndex = reader.GetOrdinal("EnvelopGMXs");
			int tokenKeyColumnIndex = reader.GetOrdinal("TokenKey");
			int dateCreatedColumnIndex = reader.GetOrdinal("DateCreated");
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
					LinkageAccessTokenRow record = new LinkageAccessTokenRow();
					recordList.Add(record);
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.PID =  Convert.ToString(reader.GetValue(pIDColumnIndex));
					if (!reader.IsDBNull(cIDColumnIndex)) record.CID =  Convert.ToString(reader.GetValue(cIDColumnIndex));

					if (!reader.IsDBNull(xKeyColumnIndex)) record.XKey =  Convert.ToString(reader.GetValue(xKeyColumnIndex));

					if (!reader.IsDBNull(matchKeyColumnIndex)) record.MatchKey =  Convert.ToString(reader.GetValue(matchKeyColumnIndex));

					if (!reader.IsDBNull(envelopGMXsColumnIndex)) record.EnvelopGMXs =  Convert.ToString(reader.GetValue(envelopGMXsColumnIndex));

					if (!reader.IsDBNull(tokenKeyColumnIndex)) record.TokenKey =  Convert.ToString(reader.GetValue(tokenKeyColumnIndex));

					if (!reader.IsDBNull(dateCreatedColumnIndex)) record.DateCreated =  Convert.ToDateTime(reader.GetValue(dateCreatedColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LinkageAccessTokenRow[])(recordList.ToArray(typeof(LinkageAccessTokenRow)));
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
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "XKey":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MatchKey":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "EnvelopGMXs":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TokenKey":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateCreated":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

