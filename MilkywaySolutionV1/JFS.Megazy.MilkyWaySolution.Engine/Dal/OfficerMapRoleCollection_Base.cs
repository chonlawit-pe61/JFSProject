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
	public partial class OfficerMapRoleCollection_Base : MarshalByRefObject
	{
		public const string OfficeRoleIDColumnName = "OfficeRoleID";
		public const string UserIDColumnName = "UserID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public OfficerMapRoleCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual OfficerMapRoleRow[] GetAll()
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
			"[OfficeRoleID],"+
			"[UserID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[OfficerMapRole]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[OfficerMapRole]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "OfficerMapRole"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("OfficeRoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual OfficerMapRoleRow[] GetByOfficeRoleID(int officeRoleID)
		{
			return MapRecords(CreateGetByOfficeRoleIDCommand(officeRoleID));
		}
		public virtual DataTable GetByOfficeRoleIDAsDataTable(int officeRoleID)
		{
			return MapRecordsToDataTable(CreateGetByOfficeRoleIDCommand(officeRoleID));
		}
		protected virtual IDbCommand CreateGetByOfficeRoleIDCommand(int officeRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OfficeRoleID", officeRoleID);
			return cmd;
		}
		public virtual OfficerMapRoleRow[] GetByUserID(int userID)
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
		public OfficerMapRoleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual OfficerMapRoleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="OfficerMapRoleRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OfficerMapRoleRow"/> objects.</returns>
		public virtual OfficerMapRoleRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[OfficerMapRole]", top);
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
		public OfficerMapRoleRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			OfficerMapRoleRow[] rows = null;
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
		public DataTable GetOfficerMapRolePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OfficeRoleID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "OfficeRoleID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(OfficeRoleID) AS TotalRow FROM [dbo].[OfficerMapRole] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,OfficeRoleID,UserID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[OfficerMapRole] " + whereSql +
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
		public OfficerMapRoleItemsPaging GetOfficerMapRolePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "OfficeRoleID")
		{
		OfficerMapRoleItemsPaging obj = new OfficerMapRoleItemsPaging();
		DataTable dt = GetOfficerMapRolePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		OfficerMapRoleItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new OfficerMapRoleItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.OfficeRoleID = Convert.ToInt32(dt.Rows[i]["OfficeRoleID"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.officerMapRoleItems = (OfficerMapRoleItems[])(recordList.ToArray(typeof(OfficerMapRoleItems)));
		return obj;
		}
		public OfficerMapRoleRow GetByPrimaryKey(int officeRoleID, int userID)
		{
			string whereSql = "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID") + " AND [UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OfficeRoleID", officeRoleID);
			AddParameter(cmd, "UserID", userID);
			OfficerMapRoleRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(OfficerMapRoleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerMapRole] (" +
			"[OfficeRoleID], " + 
			"[UserID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("OfficeRoleID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "OfficeRoleID", value.OfficeRoleID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(OfficerMapRoleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerMapRole] (" +
			"[OfficeRoleID], " + 
			"[UserID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("OfficeRoleID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "OfficeRoleID", value.OfficeRoleID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(OfficerMapRoleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOfficeRoleID == true && value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerMapRole] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID")+ " AND [UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OfficeRoleID", value.OfficeRoleID);
					AddParameter(cmd, "UserID", value.UserID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(OfficeRoleID,UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(OfficerMapRoleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetOfficeRoleID == true && value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerMapRole] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID")+ " AND [UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "OfficeRoleID", value.OfficeRoleID);
					AddParameter(cmd, "UserID", value.UserID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(OfficeRoleID,UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int officeRoleID, int userID)
		{
			string whereSql = "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID") + " AND [UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OfficeRoleID", officeRoleID);
			AddParameter(cmd, "UserID", userID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByOfficeRoleID(int officeRoleID)
		{
			return CreateDeleteByOfficeRoleIDCommand(officeRoleID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByOfficeRoleIDCommand(int officeRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficeRoleID]=" + CreateSqlParameterName("OfficeRoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OfficeRoleID", officeRoleID);
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
		protected OfficerMapRoleRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected OfficerMapRoleRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected OfficerMapRoleRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int officeRoleIDColumnIndex = reader.GetOrdinal("OfficeRoleID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
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
					OfficerMapRoleRow record = new OfficerMapRoleRow();
					recordList.Add(record);
					record.OfficeRoleID =  Convert.ToInt32(reader.GetValue(officeRoleIDColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OfficerMapRoleRow[])(recordList.ToArray(typeof(OfficerMapRoleRow)));
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
				case "OfficeRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
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
