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
	public partial class CaseMattersOfLawCollection_Base : MarshalByRefObject
	{
		public const string MattersOfLawIDColumnName = "MattersOfLawID";
		public const string CaseIDColumnName = "CaseID";
		public const string AppicantIDColumnName = "AppicantID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseMattersOfLawCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseMattersOfLawRow[] GetAll()
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
			"[MattersOfLawID],"+
			"[CaseID],"+
			"[AppicantID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseMattersOfLaw]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseMattersOfLaw]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseMattersOfLaw"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MattersOfLawID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AppicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseMattersOfLawRow[] GetByMattersOfLawID(int mattersOfLawID)
		{
			return MapRecords(CreateGetByMattersOfLawIDCommand(mattersOfLawID));
		}
		public virtual DataTable GetByMattersOfLawIDAsDataTable(int mattersOfLawID)
		{
			return MapRecordsToDataTable(CreateGetByMattersOfLawIDCommand(mattersOfLawID));
		}
		protected virtual IDbCommand CreateGetByMattersOfLawIDCommand(int mattersOfLawID)
		{
			string whereSql = "";
			whereSql += "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MattersOfLawID", mattersOfLawID);
			return cmd;
		}
		public virtual CaseMattersOfLawRow[] GetByCaseID(int caseID)
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
		public virtual CaseMattersOfLawRow[] GetByAppicantID(int appicantID)
		{
			return MapRecords(CreateGetByAppicantIDCommand(appicantID));
		}
		public virtual DataTable GetByAppicantIDAsDataTable(int appicantID)
		{
			return MapRecordsToDataTable(CreateGetByAppicantIDCommand(appicantID));
		}
		protected virtual IDbCommand CreateGetByAppicantIDCommand(int appicantID)
		{
			string whereSql = "";
			whereSql += "[AppicantID]=" + CreateSqlParameterName("AppicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AppicantID", appicantID);
			return cmd;
		}
		public CaseMattersOfLawRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseMattersOfLawRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseMattersOfLawRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseMattersOfLawRow"/> objects.</returns>
		public virtual CaseMattersOfLawRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseMattersOfLaw]", top);
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
		public CaseMattersOfLawRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseMattersOfLawRow[] rows = null;
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
		public DataTable GetCaseMattersOfLawPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MattersOfLawID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MattersOfLawID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(MattersOfLawID) AS TotalRow FROM [dbo].[CaseMattersOfLaw] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MattersOfLawID,CaseID,AppicantID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseMattersOfLaw] " + whereSql +
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
		public CaseMattersOfLawItemsPaging GetCaseMattersOfLawPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MattersOfLawID")
		{
		CaseMattersOfLawItemsPaging obj = new CaseMattersOfLawItemsPaging();
		DataTable dt = GetCaseMattersOfLawPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseMattersOfLawItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseMattersOfLawItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MattersOfLawID = Convert.ToInt32(dt.Rows[i]["MattersOfLawID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.AppicantID = Convert.ToInt32(dt.Rows[i]["AppicantID"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseMattersOfLawItems = (CaseMattersOfLawItems[])(recordList.ToArray(typeof(CaseMattersOfLawItems)));
		return obj;
		}
		public CaseMattersOfLawRow GetByPrimaryKey(int mattersOfLawID, int caseID, int appicantID)
		{
			string whereSql = "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [AppicantID]=" + CreateSqlParameterName("AppicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MattersOfLawID", mattersOfLawID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "AppicantID", appicantID);
			CaseMattersOfLawRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseMattersOfLawRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMattersOfLaw] (" +
			"[MattersOfLawID], " + 
			"[CaseID], " + 
			"[AppicantID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MattersOfLawID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("AppicantID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MattersOfLawID", value.MattersOfLawID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "AppicantID", value.AppicantID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseMattersOfLawRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseMattersOfLaw] (" +
			"[MattersOfLawID], " + 
			"[CaseID], " + 
			"[AppicantID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("MattersOfLawID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("AppicantID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MattersOfLawID", value.MattersOfLawID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "AppicantID", value.AppicantID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseMattersOfLawRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMattersOfLawID == true && value._IsSetCaseID == true && value._IsSetAppicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMattersOfLaw] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [AppicantID]=" + CreateSqlParameterName("AppicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MattersOfLawID", value.MattersOfLawID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "AppicantID", value.AppicantID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MattersOfLawID,CaseID,AppicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseMattersOfLawRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMattersOfLawID == true && value._IsSetCaseID == true && value._IsSetAppicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseMattersOfLaw] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [AppicantID]=" + CreateSqlParameterName("AppicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MattersOfLawID", value.MattersOfLawID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "AppicantID", value.AppicantID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(MattersOfLawID,CaseID,AppicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int mattersOfLawID, int caseID, int appicantID)
		{
			string whereSql = "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [AppicantID]=" + CreateSqlParameterName("AppicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MattersOfLawID", mattersOfLawID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "AppicantID", appicantID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByMattersOfLawID(int mattersOfLawID)
		{
			return CreateDeleteByMattersOfLawIDCommand(mattersOfLawID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMattersOfLawIDCommand(int mattersOfLawID)
		{
			string whereSql = "";
			whereSql += "[MattersOfLawID]=" + CreateSqlParameterName("MattersOfLawID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MattersOfLawID", mattersOfLawID);
			return cmd;
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
		public int DeleteByAppicantID(int appicantID)
		{
			return CreateDeleteByAppicantIDCommand(appicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAppicantIDCommand(int appicantID)
		{
			string whereSql = "";
			whereSql += "[AppicantID]=" + CreateSqlParameterName("AppicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AppicantID", appicantID);
			return cmd;
		}
		protected CaseMattersOfLawRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseMattersOfLawRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseMattersOfLawRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int mattersOfLawIDColumnIndex = reader.GetOrdinal("MattersOfLawID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int appicantIDColumnIndex = reader.GetOrdinal("AppicantID");
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
					CaseMattersOfLawRow record = new CaseMattersOfLawRow();
					recordList.Add(record);
					record.MattersOfLawID =  Convert.ToInt32(reader.GetValue(mattersOfLawIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.AppicantID =  Convert.ToInt32(reader.GetValue(appicantIDColumnIndex));
					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseMattersOfLawRow[])(recordList.ToArray(typeof(CaseMattersOfLawRow)));
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
				case "MattersOfLawID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AppicantID":
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

