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
	public partial class CaseTermCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string TemIDColumnName = "TemID";
		public const string FinalApproveIDColumnName = "FinalApproveID";
		public const string SubcommitteeIDColumnName = "SubcommitteeID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseTermCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseTermRow[] GetAll()
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
			"[CaseID],"+
			"[TemID],"+
			"[FinalApproveID],"+
			"[SubcommitteeID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseTerm]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseTerm]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseTerm"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TemID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FinalApproveID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SubcommitteeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseTermRow[] GetByCaseID(int caseID)
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
		public virtual CaseTermRow[] GetByTemID(int temID)
		{
			return MapRecords(CreateGetByTemIDCommand(temID));
		}
		public virtual DataTable GetByTemIDAsDataTable(int temID)
		{
			return MapRecordsToDataTable(CreateGetByTemIDCommand(temID));
		}
		protected virtual IDbCommand CreateGetByTemIDCommand(int temID)
		{
			string whereSql = "";
			whereSql += "[TemID]=" + CreateSqlParameterName("TemID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TemID", temID);
			return cmd;
		}
		public virtual CaseTermRow[] GetByFinalApproveID(int finalApproveID)
		{
			return MapRecords(CreateGetByFinalApproveIDCommand(finalApproveID));
		}
		public virtual DataTable GetByFinalApproveIDAsDataTable(int finalApproveID)
		{
			return MapRecordsToDataTable(CreateGetByFinalApproveIDCommand(finalApproveID));
		}
		protected virtual IDbCommand CreateGetByFinalApproveIDCommand(int finalApproveID)
		{
			string whereSql = "";
			whereSql += "[FinalApproveID]=" + CreateSqlParameterName("FinalApproveID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FinalApproveID", finalApproveID);
			return cmd;
		}
		public virtual CaseTermRow[] GetBySubcommitteeID(int subcommitteeID)
		{
			return MapRecords(CreateGetBySubcommitteeIDCommand(subcommitteeID));
		}
		public virtual DataTable GetBySubcommitteeIDAsDataTable(int subcommitteeID)
		{
			return MapRecordsToDataTable(CreateGetBySubcommitteeIDCommand(subcommitteeID));
		}
		protected virtual IDbCommand CreateGetBySubcommitteeIDCommand(int subcommitteeID)
		{
			string whereSql = "";
			whereSql += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			return cmd;
		}
		public CaseTermRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseTermRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseTermRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseTermRow"/> objects.</returns>
		public virtual CaseTermRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseTerm]", top);
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
		public CaseTermRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseTermRow[] rows = null;
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
		public DataTable GetCaseTermPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseTerm] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,TemID,FinalApproveID,SubcommitteeID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseTerm] " + whereSql +
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
		public CaseTermItemsPaging GetCaseTermPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseTermItemsPaging obj = new CaseTermItemsPaging();
		DataTable dt = GetCaseTermPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseTermItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseTermItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.TemID = Convert.ToInt32(dt.Rows[i]["TemID"]);
			record.FinalApproveID = Convert.ToInt32(dt.Rows[i]["FinalApproveID"]);
			if (dt.Rows[i]["SubcommitteeID"] != DBNull.Value)
			record.SubcommitteeID = Convert.ToInt32(dt.Rows[i]["SubcommitteeID"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseTermItems = (CaseTermItems[])(recordList.ToArray(typeof(CaseTermItems)));
		return obj;
		}
		public CaseTermRow GetByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			CaseTermRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseTermRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseTerm] (" +
			"[CaseID], " + 
			"[TemID], " + 
			"[FinalApproveID], " + 
			"[SubcommitteeID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("TemID") + ", " +
			CreateSqlParameterName("FinalApproveID") + ", " +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "TemID", value.TemID);
			AddParameter(cmd, "FinalApproveID", value.FinalApproveID);
			AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseTermRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseTerm] (" +
			"[CaseID], " + 
			"[TemID], " + 
			"[FinalApproveID], " + 
			"[SubcommitteeID], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("TemID") + ", " +
			CreateSqlParameterName("FinalApproveID") + ", " +
			CreateSqlParameterName("SubcommitteeID") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "TemID", value.TemID);
			AddParameter(cmd, "FinalApproveID", value.FinalApproveID);
			AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseTermRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTemID)
				{
					strUpdate += "[TemID]=" + CreateSqlParameterName("TemID") + ",";
				}
				if (value._IsSetFinalApproveID)
				{
					strUpdate += "[FinalApproveID]=" + CreateSqlParameterName("FinalApproveID") + ",";
				}
				if (value._IsSetSubcommitteeID)
				{
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseTerm] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "TemID", value.TemID);
					AddParameter(cmd, "FinalApproveID", value.FinalApproveID);
					AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseTermRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTemID)
				{
					strUpdate += "[TemID]=" + CreateSqlParameterName("TemID") + ",";
				}
				if (value._IsSetFinalApproveID)
				{
					strUpdate += "[FinalApproveID]=" + CreateSqlParameterName("FinalApproveID") + ",";
				}
				if (value._IsSetSubcommitteeID)
				{
					strUpdate += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseTerm] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "TemID", value.TemID);
					AddParameter(cmd, "FinalApproveID", value.FinalApproveID);
					AddParameter(cmd, "SubcommitteeID", value.IsSubcommitteeIDNull ? DBNull.Value : (object)value.SubcommitteeID);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return 0 < cmd.ExecuteNonQuery();
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
		public int DeleteByTemID(int temID)
		{
			return CreateDeleteByTemIDCommand(temID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByTemIDCommand(int temID)
		{
			string whereSql = "";
			whereSql += "[TemID]=" + CreateSqlParameterName("TemID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TemID", temID);
			return cmd;
		}
		public int DeleteByFinalApproveID(int finalApproveID)
		{
			return CreateDeleteByFinalApproveIDCommand(finalApproveID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByFinalApproveIDCommand(int finalApproveID)
		{
			string whereSql = "";
			whereSql += "[FinalApproveID]=" + CreateSqlParameterName("FinalApproveID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FinalApproveID", finalApproveID);
			return cmd;
		}
		public int DeleteBySubcommitteeID(int subcommitteeID)
		{
			return DeleteBySubcommitteeID(subcommitteeID, false);
		}
		public int DeleteBySubcommitteeID(int subcommitteeID, bool subcommitteeIDNull)
		{
			return CreateDeleteBySubcommitteeIDCommand(subcommitteeID, subcommitteeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteBySubcommitteeIDCommand(int subcommitteeID, bool subcommitteeIDNull)
		{
			string whereSql = "";
			if (subcommitteeIDNull)
				whereSql += "[SubcommitteeID] IS NULL";
			else
				whereSql += "[SubcommitteeID]=" + CreateSqlParameterName("SubcommitteeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!subcommitteeIDNull)
				AddParameter(cmd, "SubcommitteeID", subcommitteeID);
			return cmd;
		}
		protected CaseTermRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseTermRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseTermRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int temIDColumnIndex = reader.GetOrdinal("TemID");
			int finalApproveIDColumnIndex = reader.GetOrdinal("FinalApproveID");
			int subcommitteeIDColumnIndex = reader.GetOrdinal("SubcommitteeID");
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
					CaseTermRow record = new CaseTermRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.TemID =  Convert.ToInt32(reader.GetValue(temIDColumnIndex));
					record.FinalApproveID =  Convert.ToInt32(reader.GetValue(finalApproveIDColumnIndex));
					if (!reader.IsDBNull(subcommitteeIDColumnIndex)) record.SubcommitteeID =  Convert.ToInt32(reader.GetValue(subcommitteeIDColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseTermRow[])(recordList.ToArray(typeof(CaseTermRow)));
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
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TemID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FinalApproveID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SubcommitteeID":
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

