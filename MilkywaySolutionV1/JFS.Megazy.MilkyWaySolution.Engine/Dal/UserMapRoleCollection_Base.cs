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
	public partial class UserMapRoleCollection_Base : MarshalByRefObject
	{
		public const string UserIDColumnName = "UserID";
		public const string RoleIDColumnName = "RoleID";
		public const string AssignIDColumnName = "AssignID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public UserMapRoleCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual UserMapRoleRow[] GetAll()
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
			"[RoleID],"+
			"[AssignID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[UserMapRole]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[UserMapRole]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "UserMapRole"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AssignID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual UserMapRoleRow[] GetByUserID(int userID)
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
		public virtual UserMapRoleRow[] GetByRoleID(int roleID)
		{
			return MapRecords(CreateGetByRoleIDCommand(roleID));
		}
		public virtual DataTable GetByRoleIDAsDataTable(int roleID)
		{
			return MapRecordsToDataTable(CreateGetByRoleIDCommand(roleID));
		}
		protected virtual IDbCommand CreateGetByRoleIDCommand(int roleID)
		{
			string whereSql = "";
			whereSql += "[RoleID]=" + CreateSqlParameterName("RoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RoleID", roleID);
			return cmd;
		}
		public virtual UserMapRoleRow[] GetByAssignID(int assignID)
		{
			return MapRecords(CreateGetByAssignIDCommand(assignID));
		}
		public virtual DataTable GetByAssignIDAsDataTable(int assignID)
		{
			return MapRecordsToDataTable(CreateGetByAssignIDCommand(assignID));
		}
		protected virtual IDbCommand CreateGetByAssignIDCommand(int assignID)
		{
			string whereSql = "";
			whereSql += "[AssignID]=" + CreateSqlParameterName("AssignID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AssignID", assignID);
			return cmd;
		}
		public UserMapRoleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual UserMapRoleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="UserMapRoleRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="UserMapRoleRow"/> objects.</returns>
		public virtual UserMapRoleRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[UserMapRole]", top);
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
		public UserMapRoleRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			UserMapRoleRow[] rows = null;
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
		public DataTable GetUserMapRolePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
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
		string sql = "SELECT COUNT(UserID) AS TotalRow FROM [dbo].[UserMapRole] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,UserID,RoleID,AssignID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[UserMapRole] " + whereSql +
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
		public UserMapRoleItemsPaging GetUserMapRolePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
		UserMapRoleItemsPaging obj = new UserMapRoleItemsPaging();
		DataTable dt = GetUserMapRolePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		UserMapRoleItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new UserMapRoleItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"]);
			if (dt.Rows[i]["AssignID"] != DBNull.Value)
			record.AssignID = Convert.ToInt32(dt.Rows[i]["AssignID"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.userMapRoleItems = (UserMapRoleItems[])(recordList.ToArray(typeof(UserMapRoleItems)));
		return obj;
		}
		public UserMapRoleRow GetByPrimaryKey(int userID, int roleID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID") + " AND [RoleID]=" + CreateSqlParameterName("RoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			AddParameter(cmd, "RoleID", roleID);
			UserMapRoleRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(UserMapRoleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserMapRole] (" +
			"[UserID], " + 
			"[RoleID], " + 
			"[AssignID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("RoleID") + ", " +
			CreateSqlParameterName("AssignID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "RoleID", value.RoleID);
			AddParameter(cmd, "AssignID", value.IsAssignIDNull ? DBNull.Value : (object)value.AssignID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(UserMapRoleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserMapRole] (" +
			"[UserID], " + 
			"[RoleID], " + 
			"[AssignID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("RoleID") + ", " +
			CreateSqlParameterName("AssignID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "RoleID", value.RoleID);
			AddParameter(cmd, "AssignID", value.IsAssignIDNull ? DBNull.Value : (object)value.AssignID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(UserMapRoleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true && value._IsSetRoleID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAssignID)
				{
					strUpdate += "[AssignID]=" + CreateSqlParameterName("AssignID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserMapRole] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID")+ " AND [RoleID]=" + CreateSqlParameterName("RoleID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "RoleID", value.RoleID);
					AddParameter(cmd, "AssignID", value.IsAssignIDNull ? DBNull.Value : (object)value.AssignID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(UserID,RoleID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(UserMapRoleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true && value._IsSetRoleID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAssignID)
				{
					strUpdate += "[AssignID]=" + CreateSqlParameterName("AssignID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserMapRole] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID")+ " AND [RoleID]=" + CreateSqlParameterName("RoleID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "RoleID", value.RoleID);
					AddParameter(cmd, "AssignID", value.IsAssignIDNull ? DBNull.Value : (object)value.AssignID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(UserID,RoleID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int userID, int roleID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID") + " AND [RoleID]=" + CreateSqlParameterName("RoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			AddParameter(cmd, "RoleID", roleID);
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
		public int DeleteByRoleID(int roleID)
		{
			return CreateDeleteByRoleIDCommand(roleID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByRoleIDCommand(int roleID)
		{
			string whereSql = "";
			whereSql += "[RoleID]=" + CreateSqlParameterName("RoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RoleID", roleID);
			return cmd;
		}
		public int DeleteByAssignID(int assignID)
		{
			return DeleteByAssignID(assignID, false);
		}
		public int DeleteByAssignID(int assignID, bool assignIDNull)
		{
			return CreateDeleteByAssignIDCommand(assignID, assignIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAssignIDCommand(int assignID, bool assignIDNull)
		{
			string whereSql = "";
			if (assignIDNull)
				whereSql += "[AssignID] IS NULL";
			else
				whereSql += "[AssignID]=" + CreateSqlParameterName("AssignID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!assignIDNull)
				AddParameter(cmd, "AssignID", assignID);
			return cmd;
		}
		protected UserMapRoleRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected UserMapRoleRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected UserMapRoleRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int roleIDColumnIndex = reader.GetOrdinal("RoleID");
			int assignIDColumnIndex = reader.GetOrdinal("AssignID");
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
					UserMapRoleRow record = new UserMapRoleRow();
					recordList.Add(record);
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.RoleID =  Convert.ToInt32(reader.GetValue(roleIDColumnIndex));
					if (!reader.IsDBNull(assignIDColumnIndex)) record.AssignID =  Convert.ToInt32(reader.GetValue(assignIDColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (UserMapRoleRow[])(recordList.ToArray(typeof(UserMapRoleRow)));
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
				case "RoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AssignID":
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

