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
	public partial class OfficerFinalApprovedMapBudgetCollection_Base : MarshalByRefObject
	{
		public const string ApprovedIDColumnName = "ApprovedID";
		public const string BudgetIDColumnName = "BudgetID";
		public const string DateCreatedColumnName = "DateCreated";
		private int _processID;
		public SqlCommand cmd = null;
		public OfficerFinalApprovedMapBudgetCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual OfficerFinalApprovedMapBudgetRow[] GetAll()
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
			"[ApprovedID],"+
			"[BudgetID],"+
			"[DateCreated]"+
			" FROM [dbo].[OfficerFinalApprovedMapBudget]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[OfficerFinalApprovedMapBudget]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "OfficerFinalApprovedMapBudget"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApprovedID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BudgetID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DateCreated",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual OfficerFinalApprovedMapBudgetRow[] GetByApprovedID(int approvedID)
		{
			return MapRecords(CreateGetByApprovedIDCommand(approvedID));
		}
		public virtual DataTable GetByApprovedIDAsDataTable(int approvedID)
		{
			return MapRecordsToDataTable(CreateGetByApprovedIDCommand(approvedID));
		}
		protected virtual IDbCommand CreateGetByApprovedIDCommand(int approvedID)
		{
			string whereSql = "";
			whereSql += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApprovedID", approvedID);
			return cmd;
		}
		public virtual OfficerFinalApprovedMapBudgetRow[] GetByBudgetID(int budgetID)
		{
			return MapRecords(CreateGetByBudgetIDCommand(budgetID));
		}
		public virtual DataTable GetByBudgetIDAsDataTable(int budgetID)
		{
			return MapRecordsToDataTable(CreateGetByBudgetIDCommand(budgetID));
		}
		protected virtual IDbCommand CreateGetByBudgetIDCommand(int budgetID)
		{
			string whereSql = "";
			whereSql += "[BudgetID]=" + CreateSqlParameterName("BudgetID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BudgetID", budgetID);
			return cmd;
		}
		public OfficerFinalApprovedMapBudgetRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual OfficerFinalApprovedMapBudgetRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="OfficerFinalApprovedMapBudgetRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OfficerFinalApprovedMapBudgetRow"/> objects.</returns>
		public virtual OfficerFinalApprovedMapBudgetRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[OfficerFinalApprovedMapBudget]", top);
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
		public OfficerFinalApprovedMapBudgetRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			OfficerFinalApprovedMapBudgetRow[] rows = null;
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
		public DataTable GetOfficerFinalApprovedMapBudgetPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApprovedID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ApprovedID) AS TotalRow FROM [dbo].[OfficerFinalApprovedMapBudget] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApprovedID,BudgetID,DateCreated," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [OfficerFinalApprovedMapBudget].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[OfficerFinalApprovedMapBudget] " + whereSql +
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
		public OfficerFinalApprovedMapBudgetItemsPaging GetOfficerFinalApprovedMapBudgetPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
		OfficerFinalApprovedMapBudgetItemsPaging obj = new OfficerFinalApprovedMapBudgetItemsPaging();
		DataTable dt = GetOfficerFinalApprovedMapBudgetPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		OfficerFinalApprovedMapBudgetItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new OfficerFinalApprovedMapBudgetItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApprovedID = Convert.ToInt32(dt.Rows[i]["ApprovedID"]);
			record.BudgetID = Convert.ToInt32(dt.Rows[i]["BudgetID"]);
			record.DateCreated = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
			recordList.Add(record);
		}
		obj.officerFinalApprovedMapBudgetItems = (OfficerFinalApprovedMapBudgetItems[])(recordList.ToArray(typeof(OfficerFinalApprovedMapBudgetItems)));
		return obj;
		}
		public OfficerFinalApprovedMapBudgetRow GetByPrimaryKey(int approvedID, int budgetID)
		{
			string whereSql = "[ApprovedID]=" + CreateSqlParameterName("ApprovedID") + " AND [BudgetID]=" + CreateSqlParameterName("BudgetID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApprovedID", approvedID);
			AddParameter(cmd, "BudgetID", budgetID);
			OfficerFinalApprovedMapBudgetRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(OfficerFinalApprovedMapBudgetRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerFinalApprovedMapBudget] (" +
			"[ApprovedID], " + 
			"[BudgetID], " + 
			"[DateCreated]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApprovedID") + ", " +
			CreateSqlParameterName("BudgetID") + ", " +
			CreateSqlParameterName("DateCreated") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApprovedID", value.ApprovedID);
			AddParameter(cmd, "BudgetID", value.BudgetID);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(OfficerFinalApprovedMapBudgetRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerFinalApprovedMapBudget] (" +
			"[ApprovedID], " + 
			"[BudgetID], " + 
			"[DateCreated]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApprovedID") + ", " +
			CreateSqlParameterName("BudgetID") + ", " +
			CreateSqlParameterName("DateCreated") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApprovedID", value.ApprovedID);
			AddParameter(cmd, "BudgetID", value.BudgetID);
			AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
			cmd.ExecuteNonQuery();
		}
		public bool Update(OfficerFinalApprovedMapBudgetRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApprovedID == true && value._IsSetBudgetID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerFinalApprovedMapBudget] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID")+ " AND [BudgetID]=" + CreateSqlParameterName("BudgetID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApprovedID", value.ApprovedID);
					AddParameter(cmd, "BudgetID", value.BudgetID);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ApprovedID,BudgetID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(OfficerFinalApprovedMapBudgetRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApprovedID == true && value._IsSetBudgetID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetDateCreated)
				{
					strUpdate += "[DateCreated]=" + CreateSqlParameterName("DateCreated") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerFinalApprovedMapBudget] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID")+ " AND [BudgetID]=" + CreateSqlParameterName("BudgetID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApprovedID", value.ApprovedID);
					AddParameter(cmd, "BudgetID", value.BudgetID);
					AddParameter(cmd, "DateCreated", value.IsDateCreatedNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.DateCreated);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ApprovedID,BudgetID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int approvedID, int budgetID)
		{
			string whereSql = "[ApprovedID]=" + CreateSqlParameterName("ApprovedID") + " AND [BudgetID]=" + CreateSqlParameterName("BudgetID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApprovedID", approvedID);
			AddParameter(cmd, "BudgetID", budgetID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByApprovedID(int approvedID)
		{
			return CreateDeleteByApprovedIDCommand(approvedID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApprovedIDCommand(int approvedID)
		{
			string whereSql = "";
			whereSql += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApprovedID", approvedID);
			return cmd;
		}
		public int DeleteByBudgetID(int budgetID)
		{
			return CreateDeleteByBudgetIDCommand(budgetID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByBudgetIDCommand(int budgetID)
		{
			string whereSql = "";
			whereSql += "[BudgetID]=" + CreateSqlParameterName("BudgetID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "BudgetID", budgetID);
			return cmd;
		}
		protected OfficerFinalApprovedMapBudgetRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected OfficerFinalApprovedMapBudgetRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected OfficerFinalApprovedMapBudgetRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int approvedIDColumnIndex = reader.GetOrdinal("ApprovedID");
			int budgetIDColumnIndex = reader.GetOrdinal("BudgetID");
			int dateCreatedColumnIndex = reader.GetOrdinal("DateCreated");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					OfficerFinalApprovedMapBudgetRow record = new OfficerFinalApprovedMapBudgetRow();
					recordList.Add(record);
					record.ApprovedID =  Convert.ToInt32(reader.GetValue(approvedIDColumnIndex));
					record.BudgetID =  Convert.ToInt32(reader.GetValue(budgetIDColumnIndex));
					record.DateCreated =  Convert.ToDateTime(reader.GetValue(dateCreatedColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OfficerFinalApprovedMapBudgetRow[])(recordList.ToArray(typeof(OfficerFinalApprovedMapBudgetRow)));
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
				case "ApprovedID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "BudgetID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DateCreated":
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

