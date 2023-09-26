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
	public partial class UsersMapMessagesCollection_Base : MarshalByRefObject
	{
		public const string MessageIDColumnName = "MessageID";
		public const string UserIDColumnName = "UserID";
		public const string PlaceHolderIDColumnName = "PlaceHolderID";
		public const string IsReadColumnName = "IsRead";
		public const string IsSyncColumnName = "IsSync";
		private int _processID;
		public SqlCommand cmd = null;
		public UsersMapMessagesCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual UsersMapMessagesRow[] GetAll()
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
			"[MessageID],"+
			"[UserID],"+
			"[PlaceHolderID],"+
			"[IsRead],"+
			"[IsSync]"+
			" FROM [dbo].[UsersMapMessages]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[UsersMapMessages]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "UsersMapMessages"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MessageID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PlaceHolderID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsRead",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsSync",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual UsersMapMessagesRow[] GetByMessageID(int messageID)
		{
			return MapRecords(CreateGetByMessageIDCommand(messageID));
		}
		public virtual DataTable GetByMessageIDAsDataTable(int messageID)
		{
			return MapRecordsToDataTable(CreateGetByMessageIDCommand(messageID));
		}
		protected virtual IDbCommand CreateGetByMessageIDCommand(int messageID)
		{
			string whereSql = "";
			whereSql += "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MessageID", messageID);
			return cmd;
		}
		public virtual UsersMapMessagesRow[] GetByUserID(int userID)
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
		public virtual UsersMapMessagesRow[] GetByPlaceHolderID(int placeHolderID)
		{
			return MapRecords(CreateGetByPlaceHolderIDCommand(placeHolderID));
		}
		public virtual DataTable GetByPlaceHolderIDAsDataTable(int placeHolderID)
		{
			return MapRecordsToDataTable(CreateGetByPlaceHolderIDCommand(placeHolderID));
		}
		protected virtual IDbCommand CreateGetByPlaceHolderIDCommand(int placeHolderID)
		{
			string whereSql = "";
			whereSql += "[PlaceHolderID]=" + CreateSqlParameterName("PlaceHolderID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PlaceHolderID", placeHolderID);
			return cmd;
		}
		public UsersMapMessagesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual UsersMapMessagesRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="UsersMapMessagesRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="UsersMapMessagesRow"/> objects.</returns>
		public virtual UsersMapMessagesRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[UsersMapMessages]", top);
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
		public UsersMapMessagesRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			UsersMapMessagesRow[] rows = null;
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
		public DataTable GetUsersMapMessagesPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MessageID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(MessageID) AS TotalRow FROM [dbo].[UsersMapMessages] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MessageID,UserID,PlaceHolderID,IsRead,IsSync," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[UsersMapMessages] " + whereSql +
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
		public UsersMapMessagesItemsPaging GetUsersMapMessagesPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MessageID")
		{
		UsersMapMessagesItemsPaging obj = new UsersMapMessagesItemsPaging();
		DataTable dt = GetUsersMapMessagesPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		UsersMapMessagesItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new UsersMapMessagesItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MessageID = Convert.ToInt32(dt.Rows[i]["MessageID"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			if (dt.Rows[i]["PlaceHolderID"] != DBNull.Value)
			record.PlaceHolderID = Convert.ToInt32(dt.Rows[i]["PlaceHolderID"]);
			record.IsRead = Convert.ToBoolean(dt.Rows[i]["IsRead"]);
			record.IsSync = Convert.ToBoolean(dt.Rows[i]["IsSync"]);
			recordList.Add(record);
		}
		obj.usersMapMessagesItems = (UsersMapMessagesItems[])(recordList.ToArray(typeof(UsersMapMessagesItems)));
		return obj;
		}
		public UsersMapMessagesRow GetByPrimaryKey(int messageID, int userID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID") + " AND [UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MessageID", messageID);
			AddParameter(cmd, "UserID", userID);
			UsersMapMessagesRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(UsersMapMessagesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UsersMapMessages] (" +
			"[MessageID], " + 
			"[UserID], " + 
			"[PlaceHolderID], " + 
			"[IsRead], " + 
			"[IsSync]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("PlaceHolderID") + ", " +
			CreateSqlParameterName("IsRead") + ", " +
			CreateSqlParameterName("IsSync") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID", value.MessageID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "PlaceHolderID", value.IsPlaceHolderIDNull ? DBNull.Value : (object)value.PlaceHolderID);
			AddParameter(cmd, "IsRead", value.IsRead);
			AddParameter(cmd, "IsSync", value.IsSync);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(UsersMapMessagesRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UsersMapMessages] (" +
			"[MessageID], " + 
			"[UserID], " + 
			"[PlaceHolderID], " + 
			"[IsRead], " + 
			"[IsSync]			" + 
			") VALUES (" +
			CreateSqlParameterName("MessageID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("PlaceHolderID") + ", " +
			CreateSqlParameterName("IsRead") + ", " +
			CreateSqlParameterName("IsSync") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MessageID", value.MessageID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "PlaceHolderID", value.IsPlaceHolderIDNull ? DBNull.Value : (object)value.PlaceHolderID);
			AddParameter(cmd, "IsRead", value.IsRead);
			AddParameter(cmd, "IsSync", value.IsSync);
			cmd.ExecuteNonQuery();
		}
		public bool Update(UsersMapMessagesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true && value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPlaceHolderID)
				{
					strUpdate += "[PlaceHolderID]=" + CreateSqlParameterName("PlaceHolderID") + ",";
				}
				if (value._IsSetIsRead)
				{
					strUpdate += "[IsRead]=" + CreateSqlParameterName("IsRead") + ",";
				}
				if (value._IsSetIsSync)
				{
					strUpdate += "[IsSync]=" + CreateSqlParameterName("IsSync") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UsersMapMessages] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID")+ " AND [UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", value.MessageID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "PlaceHolderID", value.IsPlaceHolderIDNull ? DBNull.Value : (object)value.PlaceHolderID);
					AddParameter(cmd, "IsRead", value.IsRead);
					AddParameter(cmd, "IsSync", value.IsSync);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID,UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(UsersMapMessagesRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMessageID == true && value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetPlaceHolderID)
				{
					strUpdate += "[PlaceHolderID]=" + CreateSqlParameterName("PlaceHolderID") + ",";
				}
				if (value._IsSetIsRead)
				{
					strUpdate += "[IsRead]=" + CreateSqlParameterName("IsRead") + ",";
				}
				if (value._IsSetIsSync)
				{
					strUpdate += "[IsSync]=" + CreateSqlParameterName("IsSync") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UsersMapMessages] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MessageID]=" + CreateSqlParameterName("MessageID")+ " AND [UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MessageID", value.MessageID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "PlaceHolderID", value.IsPlaceHolderIDNull ? DBNull.Value : (object)value.PlaceHolderID);
					AddParameter(cmd, "IsRead", value.IsRead);
					AddParameter(cmd, "IsSync", value.IsSync);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MessageID,UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int messageID, int userID)
		{
			string whereSql = "[MessageID]=" + CreateSqlParameterName("MessageID") + " AND [UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MessageID", messageID);
			AddParameter(cmd, "UserID", userID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByMessageID(int messageID)
		{
			return CreateDeleteByMessageIDCommand(messageID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMessageIDCommand(int messageID)
		{
			string whereSql = "";
			whereSql += "[MessageID]=" + CreateSqlParameterName("MessageID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MessageID", messageID);
			return cmd;
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
		public int DeleteByPlaceHolderID(int placeHolderID)
		{
			return DeleteByPlaceHolderID(placeHolderID, false);
		}
		public int DeleteByPlaceHolderID(int placeHolderID, bool placeHolderIDNull)
		{
			return CreateDeleteByPlaceHolderIDCommand(placeHolderID, placeHolderIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByPlaceHolderIDCommand(int placeHolderID, bool placeHolderIDNull)
		{
			string whereSql = "";
			if (placeHolderIDNull)
				whereSql += "[PlaceHolderID] IS NULL";
			else
				whereSql += "[PlaceHolderID]=" + CreateSqlParameterName("PlaceHolderID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!placeHolderIDNull)
				AddParameter(cmd, "PlaceHolderID", placeHolderID);
			return cmd;
		}
		protected UsersMapMessagesRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected UsersMapMessagesRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected UsersMapMessagesRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int messageIDColumnIndex = reader.GetOrdinal("MessageID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int placeHolderIDColumnIndex = reader.GetOrdinal("PlaceHolderID");
			int isReadColumnIndex = reader.GetOrdinal("IsRead");
			int isSyncColumnIndex = reader.GetOrdinal("IsSync");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					UsersMapMessagesRow record = new UsersMapMessagesRow();
					recordList.Add(record);
					record.MessageID =  Convert.ToInt32(reader.GetValue(messageIDColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					if (!reader.IsDBNull(placeHolderIDColumnIndex)) record.PlaceHolderID =  Convert.ToInt32(reader.GetValue(placeHolderIDColumnIndex));

					record.IsRead =  Convert.ToBoolean(reader.GetValue(isReadColumnIndex));
					record.IsSync =  Convert.ToBoolean(reader.GetValue(isSyncColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (UsersMapMessagesRow[])(recordList.ToArray(typeof(UsersMapMessagesRow)));
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
				case "MessageID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PlaceHolderID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsRead":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsSync":
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

