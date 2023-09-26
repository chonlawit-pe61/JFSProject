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
	public partial class SysGroupMapModuleCollection_Base : MarshalByRefObject
	{
		public const string GroupIDColumnName = "GroupID";
		public const string ModuleIDColumnName = "ModuleID";
		private int _processID;
		public SqlCommand cmd = null;
		public SysGroupMapModuleCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SysGroupMapModuleRow[] GetAll()
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
			"[GroupID],"+
			"[ModuleID]"+
			" FROM [dbo].[SysGroupMapModule]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SysGroupMapModule]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SysGroupMapModule"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("GroupID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModuleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual SysGroupMapModuleRow[] GetByGroupID(int groupID)
		{
			return MapRecords(CreateGetByGroupIDCommand(groupID));
		}
		public virtual DataTable GetByGroupIDAsDataTable(int groupID)
		{
			return MapRecordsToDataTable(CreateGetByGroupIDCommand(groupID));
		}
		protected virtual IDbCommand CreateGetByGroupIDCommand(int groupID)
		{
			string whereSql = "";
			whereSql += "[GroupID]=" + CreateSqlParameterName("GroupID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GroupID", groupID);
			return cmd;
		}
		public SysGroupMapModuleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SysGroupMapModuleRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SysGroupMapModuleRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SysGroupMapModuleRow"/> objects.</returns>
		public virtual SysGroupMapModuleRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SysGroupMapModule]", top);
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
		public SysGroupMapModuleRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SysGroupMapModuleRow[] rows = null;
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
		public DataTable GetSysGroupMapModulePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GroupID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "GroupID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(GroupID) AS TotalRow FROM [dbo].[SysGroupMapModule] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,GroupID,ModuleID," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [SysGroupMapModule].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SysGroupMapModule] " + whereSql +
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
		public SysGroupMapModuleItemsPaging GetSysGroupMapModulePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "GroupID")
		{
		SysGroupMapModuleItemsPaging obj = new SysGroupMapModuleItemsPaging();
		DataTable dt = GetSysGroupMapModulePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SysGroupMapModuleItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SysGroupMapModuleItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.GroupID = Convert.ToInt32(dt.Rows[i]["GroupID"]);
			record.ModuleID = Convert.ToInt32(dt.Rows[i]["ModuleID"]);
			recordList.Add(record);
		}
		obj.sysGroupMapModuleItems = (SysGroupMapModuleItems[])(recordList.ToArray(typeof(SysGroupMapModuleItems)));
		return obj;
		}
		public SysGroupMapModuleRow GetByPrimaryKey(int groupID, int moduleID)
		{
			string whereSql = "[GroupID]=" + CreateSqlParameterName("GroupID") + " AND [ModuleID]=" + CreateSqlParameterName("ModuleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GroupID", groupID);
			AddParameter(cmd, "ModuleID", moduleID);
			SysGroupMapModuleRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(SysGroupMapModuleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysGroupMapModule] (" +
			"[GroupID], " + 
			"[ModuleID]			" + 
			") VALUES (" +
			CreateSqlParameterName("GroupID") + ", " +
			CreateSqlParameterName("ModuleID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "GroupID", value.GroupID);
			AddParameter(cmd, "ModuleID", value.ModuleID);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(SysGroupMapModuleRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SysGroupMapModule] (" +
			"[GroupID], " + 
			"[ModuleID]			" + 
			") VALUES (" +
			CreateSqlParameterName("GroupID") + ", " +
			CreateSqlParameterName("ModuleID") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "GroupID", value.GroupID);
			AddParameter(cmd, "ModuleID", value.ModuleID);
			cmd.ExecuteNonQuery();
		}
		public bool Update(SysGroupMapModuleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGroupID == true && value._IsSetModuleID == true )
			{
				string strUpdate = string.Empty;
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysGroupMapModule] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GroupID]=" + CreateSqlParameterName("GroupID")+ " AND [ModuleID]=" + CreateSqlParameterName("ModuleID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GroupID", value.GroupID);
					AddParameter(cmd, "ModuleID", value.ModuleID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(GroupID,ModuleID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SysGroupMapModuleRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetGroupID == true && value._IsSetModuleID == true )
			{
				string strUpdate = string.Empty;
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SysGroupMapModule] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[GroupID]=" + CreateSqlParameterName("GroupID")+ " AND [ModuleID]=" + CreateSqlParameterName("ModuleID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "GroupID", value.GroupID);
					AddParameter(cmd, "ModuleID", value.ModuleID);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(GroupID,ModuleID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int groupID, int moduleID)
		{
			string whereSql = "[GroupID]=" + CreateSqlParameterName("GroupID") + " AND [ModuleID]=" + CreateSqlParameterName("ModuleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GroupID", groupID);
			AddParameter(cmd, "ModuleID", moduleID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByGroupID(int groupID)
		{
			return CreateDeleteByGroupIDCommand(groupID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByGroupIDCommand(int groupID)
		{
			string whereSql = "";
			whereSql += "[GroupID]=" + CreateSqlParameterName("GroupID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GroupID", groupID);
			return cmd;
		}
		protected SysGroupMapModuleRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SysGroupMapModuleRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SysGroupMapModuleRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int groupIDColumnIndex = reader.GetOrdinal("GroupID");
			int moduleIDColumnIndex = reader.GetOrdinal("ModuleID");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SysGroupMapModuleRow record = new SysGroupMapModuleRow();
					recordList.Add(record);
					record.GroupID =  Convert.ToInt32(reader.GetValue(groupIDColumnIndex));
					record.ModuleID =  Convert.ToInt32(reader.GetValue(moduleIDColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SysGroupMapModuleRow[])(recordList.ToArray(typeof(SysGroupMapModuleRow)));
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
				case "GroupID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ModuleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

