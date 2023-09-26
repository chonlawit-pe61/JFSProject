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
	public partial class DXCAccessTokenCollection_Base : MarshalByRefObject
	{
		public const string UserIDColumnName = "UserID";
		public const string CodeChallengeColumnName = "CodeChallenge";
		public const string CodeVerifierColumnName = "CodeVerifier";
		public const string AuthorizationCodeColumnName = "AuthorizationCode";
		public const string AccessTokenColumnName = "AccessToken";
		public const string ExpiresInColumnName = "ExpiresIn";
		public const string RefreshExpiresInColumnName = "RefreshExpiresIn";
		public const string RefreshTokenColumnName = "RefreshToken";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public DXCAccessTokenCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual DXCAccessTokenRow[] GetAll()
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
			"[CodeChallenge],"+
			"[CodeVerifier],"+
			"[AuthorizationCode],"+
			"[AccessToken],"+
			"[ExpiresIn],"+
			"[RefreshExpiresIn],"+
			"[RefreshToken],"+
			"[ModifiedDate]"+
			" FROM [dbo].[DXCAccessToken]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[DXCAccessToken]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "DXCAccessToken"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CodeChallenge",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("CodeVerifier",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("AuthorizationCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("AccessToken",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ExpiresIn",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RefreshExpiresIn",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RefreshToken",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public DXCAccessTokenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual DXCAccessTokenRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="DXCAccessTokenRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DXCAccessTokenRow"/> objects.</returns>
		public virtual DXCAccessTokenRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[DXCAccessToken]", top);
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
		public DXCAccessTokenRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			DXCAccessTokenRow[] rows = null;
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
		public DataTable GetDXCAccessTokenPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
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
		string sql = "SELECT COUNT(UserID) AS TotalRow FROM [dbo].[DXCAccessToken] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,UserID,CodeChallenge,CodeVerifier,AuthorizationCode,AccessToken,ExpiresIn,RefreshExpiresIn,RefreshToken,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [DXCAccessToken].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[DXCAccessToken] " + whereSql +
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
		public DXCAccessTokenItemsPaging GetDXCAccessTokenPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
		DXCAccessTokenItemsPaging obj = new DXCAccessTokenItemsPaging();
		DataTable dt = GetDXCAccessTokenPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		DXCAccessTokenItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new DXCAccessTokenItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.CodeChallenge = dt.Rows[i]["CodeChallenge"].ToString();
			record.CodeVerifier = dt.Rows[i]["CodeVerifier"].ToString();
			record.AuthorizationCode = dt.Rows[i]["AuthorizationCode"].ToString();
			record.AccessToken = dt.Rows[i]["AccessToken"].ToString();
			if (dt.Rows[i]["ExpiresIn"] != DBNull.Value)
			record.ExpiresIn = Convert.ToInt32(dt.Rows[i]["ExpiresIn"]);
			if (dt.Rows[i]["RefreshExpiresIn"] != DBNull.Value)
			record.RefreshExpiresIn = Convert.ToInt32(dt.Rows[i]["RefreshExpiresIn"]);
			record.RefreshToken = dt.Rows[i]["RefreshToken"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.dXCAccessTokenItems = (DXCAccessTokenItems[])(recordList.ToArray(typeof(DXCAccessTokenItems)));
		return obj;
		}
		public DXCAccessTokenRow GetByPrimaryKey(int userID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			DXCAccessTokenRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(DXCAccessTokenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[DXCAccessToken] (" +
			"[UserID], " + 
			"[CodeChallenge], " + 
			"[CodeVerifier], " + 
			"[AuthorizationCode], " + 
			"[AccessToken], " + 
			"[ExpiresIn], " + 
			"[RefreshExpiresIn], " + 
			"[RefreshToken], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("CodeChallenge") + ", " +
			CreateSqlParameterName("CodeVerifier") + ", " +
			CreateSqlParameterName("AuthorizationCode") + ", " +
			CreateSqlParameterName("AccessToken") + ", " +
			CreateSqlParameterName("ExpiresIn") + ", " +
			CreateSqlParameterName("RefreshExpiresIn") + ", " +
			CreateSqlParameterName("RefreshToken") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "CodeChallenge", value.CodeChallenge);
			AddParameter(cmd, "CodeVerifier", value.CodeVerifier);
			AddParameter(cmd, "AuthorizationCode", value.AuthorizationCode);
			AddParameter(cmd, "AccessToken", value.AccessToken);
			AddParameter(cmd, "ExpiresIn", value.IsExpiresInNull ? DBNull.Value : (object)value.ExpiresIn);
			AddParameter(cmd, "RefreshExpiresIn", value.IsRefreshExpiresInNull ? DBNull.Value : (object)value.RefreshExpiresIn);
			AddParameter(cmd, "RefreshToken", value.RefreshToken);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(DXCAccessTokenRow value)		{
			string sqlStr = "INSERT INTO [dbo].[DXCAccessToken] (" +
			"[UserID], " + 
			"[CodeChallenge], " + 
			"[CodeVerifier], " + 
			"[AuthorizationCode], " + 
			"[AccessToken], " + 
			"[ExpiresIn], " + 
			"[RefreshExpiresIn], " + 
			"[RefreshToken], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("CodeChallenge") + ", " +
			CreateSqlParameterName("CodeVerifier") + ", " +
			CreateSqlParameterName("AuthorizationCode") + ", " +
			CreateSqlParameterName("AccessToken") + ", " +
			CreateSqlParameterName("ExpiresIn") + ", " +
			CreateSqlParameterName("RefreshExpiresIn") + ", " +
			CreateSqlParameterName("RefreshToken") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "CodeChallenge", Sanitizer.GetSafeHtmlFragment(value.CodeChallenge));
			AddParameter(cmd, "CodeVerifier", Sanitizer.GetSafeHtmlFragment(value.CodeVerifier));
			AddParameter(cmd, "AuthorizationCode", Sanitizer.GetSafeHtmlFragment(value.AuthorizationCode));
			AddParameter(cmd, "AccessToken", Sanitizer.GetSafeHtmlFragment(value.AccessToken));
			AddParameter(cmd, "ExpiresIn", value.IsExpiresInNull ? DBNull.Value : (object)value.ExpiresIn);
			AddParameter(cmd, "RefreshExpiresIn", value.IsRefreshExpiresInNull ? DBNull.Value : (object)value.RefreshExpiresIn);
			AddParameter(cmd, "RefreshToken", Sanitizer.GetSafeHtmlFragment(value.RefreshToken));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(DXCAccessTokenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCodeChallenge)
				{
					strUpdate += "[CodeChallenge]=" + CreateSqlParameterName("CodeChallenge") + ",";
				}
				if (value._IsSetCodeVerifier)
				{
					strUpdate += "[CodeVerifier]=" + CreateSqlParameterName("CodeVerifier") + ",";
				}
				if (value._IsSetAuthorizationCode)
				{
					strUpdate += "[AuthorizationCode]=" + CreateSqlParameterName("AuthorizationCode") + ",";
				}
				if (value._IsSetAccessToken)
				{
					strUpdate += "[AccessToken]=" + CreateSqlParameterName("AccessToken") + ",";
				}
				if (value._IsSetExpiresIn)
				{
					strUpdate += "[ExpiresIn]=" + CreateSqlParameterName("ExpiresIn") + ",";
				}
				if (value._IsSetRefreshExpiresIn)
				{
					strUpdate += "[RefreshExpiresIn]=" + CreateSqlParameterName("RefreshExpiresIn") + ",";
				}
				if (value._IsSetRefreshToken)
				{
					strUpdate += "[RefreshToken]=" + CreateSqlParameterName("RefreshToken") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[DXCAccessToken] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "CodeChallenge", value.CodeChallenge);
					AddParameter(cmd, "CodeVerifier", value.CodeVerifier);
					AddParameter(cmd, "AuthorizationCode", value.AuthorizationCode);
					AddParameter(cmd, "AccessToken", value.AccessToken);
					AddParameter(cmd, "ExpiresIn", value.IsExpiresInNull ? DBNull.Value : (object)value.ExpiresIn);
					AddParameter(cmd, "RefreshExpiresIn", value.IsRefreshExpiresInNull ? DBNull.Value : (object)value.RefreshExpiresIn);
					AddParameter(cmd, "RefreshToken", value.RefreshToken);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
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
		public bool UpdateOnlyPlainText(DXCAccessTokenRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCodeChallenge)
				{
					strUpdate += "[CodeChallenge]=" + CreateSqlParameterName("CodeChallenge") + ",";
				}
				if (value._IsSetCodeVerifier)
				{
					strUpdate += "[CodeVerifier]=" + CreateSqlParameterName("CodeVerifier") + ",";
				}
				if (value._IsSetAuthorizationCode)
				{
					strUpdate += "[AuthorizationCode]=" + CreateSqlParameterName("AuthorizationCode") + ",";
				}
				if (value._IsSetAccessToken)
				{
					strUpdate += "[AccessToken]=" + CreateSqlParameterName("AccessToken") + ",";
				}
				if (value._IsSetExpiresIn)
				{
					strUpdate += "[ExpiresIn]=" + CreateSqlParameterName("ExpiresIn") + ",";
				}
				if (value._IsSetRefreshExpiresIn)
				{
					strUpdate += "[RefreshExpiresIn]=" + CreateSqlParameterName("RefreshExpiresIn") + ",";
				}
				if (value._IsSetRefreshToken)
				{
					strUpdate += "[RefreshToken]=" + CreateSqlParameterName("RefreshToken") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[DXCAccessToken] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "CodeChallenge", Sanitizer.GetSafeHtmlFragment(value.CodeChallenge));
					AddParameter(cmd, "CodeVerifier", Sanitizer.GetSafeHtmlFragment(value.CodeVerifier));
					AddParameter(cmd, "AuthorizationCode", Sanitizer.GetSafeHtmlFragment(value.AuthorizationCode));
					AddParameter(cmd, "AccessToken", Sanitizer.GetSafeHtmlFragment(value.AccessToken));
					AddParameter(cmd, "ExpiresIn", value.IsExpiresInNull ? DBNull.Value : (object)value.ExpiresIn);
					AddParameter(cmd, "RefreshExpiresIn", value.IsRefreshExpiresInNull ? DBNull.Value : (object)value.RefreshExpiresIn);
					AddParameter(cmd, "RefreshToken", Sanitizer.GetSafeHtmlFragment(value.RefreshToken));
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
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
		protected DXCAccessTokenRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected DXCAccessTokenRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected DXCAccessTokenRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int codechallengeColumnIndex = reader.GetOrdinal("CodeChallenge");
			int codeVerifierColumnIndex = reader.GetOrdinal("CodeVerifier");
			int authorizationCodeColumnIndex = reader.GetOrdinal("AuthorizationCode");
			int accessTokenColumnIndex = reader.GetOrdinal("AccessToken");
			int expiresInColumnIndex = reader.GetOrdinal("ExpiresIn");
			int refreshExpiresInColumnIndex = reader.GetOrdinal("RefreshExpiresIn");
			int refreshTokenColumnIndex = reader.GetOrdinal("RefreshToken");
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
					DXCAccessTokenRow record = new DXCAccessTokenRow();
					recordList.Add(record);
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					if (!reader.IsDBNull(codechallengeColumnIndex)) record.CodeChallenge =  Convert.ToString(reader.GetValue(codechallengeColumnIndex));

					if (!reader.IsDBNull(codeVerifierColumnIndex)) record.CodeVerifier =  Convert.ToString(reader.GetValue(codeVerifierColumnIndex));

					if (!reader.IsDBNull(authorizationCodeColumnIndex)) record.AuthorizationCode =  Convert.ToString(reader.GetValue(authorizationCodeColumnIndex));

					if (!reader.IsDBNull(accessTokenColumnIndex)) record.AccessToken =  Convert.ToString(reader.GetValue(accessTokenColumnIndex));

					if (!reader.IsDBNull(expiresInColumnIndex)) record.ExpiresIn =  Convert.ToInt32(reader.GetValue(expiresInColumnIndex));

					if (!reader.IsDBNull(refreshExpiresInColumnIndex)) record.RefreshExpiresIn =  Convert.ToInt32(reader.GetValue(refreshExpiresInColumnIndex));

					if (!reader.IsDBNull(refreshTokenColumnIndex)) record.RefreshToken =  Convert.ToString(reader.GetValue(refreshTokenColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DXCAccessTokenRow[])(recordList.ToArray(typeof(DXCAccessTokenRow)));
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
				case "CodeChallenge":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CodeVerifier":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AuthorizationCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AccessToken":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ExpiresIn":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefreshExpiresIn":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RefreshToken":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

