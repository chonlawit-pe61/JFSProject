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
	public partial class ContractCaseFollowUpCollection_Base : MarshalByRefObject
	{
		public const string ContractIDColumnName = "ContractID";
		public const string CourtLocationColumnName = "CourtLocation";
		public const string CourtOrderIDColumnName = "CourtOrderID";
		public const string ResultIDColumnName = "ResultID";
		public const string CourtOrderAmountColumnName = "CourtOrderAmount";
		public const string JudgmentDateColumnName = "JudgmentDate";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ContractCaseFollowUpCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ContractCaseFollowUpRow[] GetAll()
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
			"[ContractID],"+
			"[CourtLocation],"+
			"[CourtOrderID],"+
			"[ResultID],"+
			"[CourtOrderAmount],"+
			"[JudgmentDate],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ContractCaseFollowUp]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ContractCaseFollowUp]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ContractCaseFollowUp"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ContractID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CourtLocation",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CourtOrderID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ResultID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CourtOrderAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("JudgmentDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ContractCaseFollowUpRow[] GetByContractID(int contractID)
		{
			return MapRecords(CreateGetByContractIDCommand(contractID));
		}
		public virtual DataTable GetByContractIDAsDataTable(int contractID)
		{
			return MapRecordsToDataTable(CreateGetByContractIDCommand(contractID));
		}
		protected virtual IDbCommand CreateGetByContractIDCommand(int contractID)
		{
			string whereSql = "";
			whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		public virtual ContractCaseFollowUpRow[] GetByResultID(int resultID)
		{
			return MapRecords(CreateGetByResultIDCommand(resultID));
		}
		public virtual DataTable GetByResultIDAsDataTable(int resultID)
		{
			return MapRecordsToDataTable(CreateGetByResultIDCommand(resultID));
		}
		protected virtual IDbCommand CreateGetByResultIDCommand(int resultID)
		{
			string whereSql = "";
			whereSql += "[ResultID]=" + CreateSqlParameterName("ResultID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ResultID", resultID);
			return cmd;
		}
		public ContractCaseFollowUpRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ContractCaseFollowUpRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ContractCaseFollowUpRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ContractCaseFollowUpRow"/> objects.</returns>
		public virtual ContractCaseFollowUpRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ContractCaseFollowUp]", top);
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
		public ContractCaseFollowUpRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ContractCaseFollowUpRow[] rows = null;
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
		public DataTable GetContractCaseFollowUpPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ContractID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ContractID) AS TotalRow FROM [dbo].[ContractCaseFollowUp] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ContractID,CourtLocation,CourtOrderID,ResultID,CourtOrderAmount,JudgmentDate,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ContractCaseFollowUp] " + whereSql +
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
		public ContractCaseFollowUpItemsPaging GetContractCaseFollowUpPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ContractID")
		{
		ContractCaseFollowUpItemsPaging obj = new ContractCaseFollowUpItemsPaging();
		DataTable dt = GetContractCaseFollowUpPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ContractCaseFollowUpItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ContractCaseFollowUpItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ContractID = Convert.ToInt32(dt.Rows[i]["ContractID"]);
			record.CourtLocation = dt.Rows[i]["CourtLocation"].ToString();
			if (dt.Rows[i]["CourtOrderID"] != DBNull.Value)
			record.CourtOrderID = Convert.ToInt32(dt.Rows[i]["CourtOrderID"]);
			if (dt.Rows[i]["ResultID"] != DBNull.Value)
			record.ResultID = Convert.ToInt32(dt.Rows[i]["ResultID"]);
			if (dt.Rows[i]["CourtOrderAmount"] != DBNull.Value)
			record.CourtOrderAmount = Convert.ToDouble(dt.Rows[i]["CourtOrderAmount"]);
			if (dt.Rows[i]["JudgmentDate"] != DBNull.Value)
			record.JudgmentDate = Convert.ToDateTime(dt.Rows[i]["JudgmentDate"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.contractcaseFollowUpItems = (ContractCaseFollowUpItems[])(recordList.ToArray(typeof(ContractCaseFollowUpItems)));
		return obj;
		}
		public ContractCaseFollowUpRow GetByPrimaryKey(int contractID)
		{
			string whereSql = "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ContractID", contractID);
			ContractCaseFollowUpRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ContractCaseFollowUpRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ContractCaseFollowUp] (" +
			"[ContractID], " + 
			"[CourtLocation], " + 
			"[CourtOrderID], " + 
			"[ResultID], " + 
			"[CourtOrderAmount], " + 
			"[JudgmentDate], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("CourtLocation") + ", " +
			CreateSqlParameterName("CourtOrderID") + ", " +
			CreateSqlParameterName("ResultID") + ", " +
			CreateSqlParameterName("CourtOrderAmount") + ", " +
			CreateSqlParameterName("JudgmentDate") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ContractID", value.ContractID);
			AddParameter(cmd, "CourtLocation", value.CourtLocation);
			AddParameter(cmd, "CourtOrderID", value.IsCourtOrderIDNull ? DBNull.Value : (object)value.CourtOrderID);
			AddParameter(cmd, "ResultID", value.IsResultIDNull ? DBNull.Value : (object)value.ResultID);
			AddParameter(cmd, "CourtOrderAmount", value.IsCourtOrderAmountNull ? DBNull.Value : (object)value.CourtOrderAmount);
			AddParameter(cmd, "JudgmentDate", value.IsJudgmentDateNull ? DBNull.Value : (object)value.JudgmentDate);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ContractCaseFollowUpRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ContractCaseFollowUp] (" +
			"[ContractID], " + 
			"[CourtLocation], " + 
			"[CourtOrderID], " + 
			"[ResultID], " + 
			"[CourtOrderAmount], " + 
			"[JudgmentDate], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ContractID") + ", " +
			CreateSqlParameterName("CourtLocation") + ", " +
			CreateSqlParameterName("CourtOrderID") + ", " +
			CreateSqlParameterName("ResultID") + ", " +
			CreateSqlParameterName("CourtOrderAmount") + ", " +
			CreateSqlParameterName("JudgmentDate") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ContractID", value.ContractID);
			AddParameter(cmd, "CourtLocation", Sanitizer.GetSafeHtmlFragment(value.CourtLocation));
			AddParameter(cmd, "CourtOrderID", value.IsCourtOrderIDNull ? DBNull.Value : (object)value.CourtOrderID);
			AddParameter(cmd, "ResultID", value.IsResultIDNull ? DBNull.Value : (object)value.ResultID);
			AddParameter(cmd, "CourtOrderAmount", value.IsCourtOrderAmountNull ? DBNull.Value : (object)value.CourtOrderAmount);
			AddParameter(cmd, "JudgmentDate", value.IsJudgmentDateNull ? DBNull.Value : (object)value.JudgmentDate);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ContractCaseFollowUpRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContractID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCourtLocation)
				{
					strUpdate += "[CourtLocation]=" + CreateSqlParameterName("CourtLocation") + ",";
				}
				if (value._IsSetCourtOrderID)
				{
					strUpdate += "[CourtOrderID]=" + CreateSqlParameterName("CourtOrderID") + ",";
				}
				if (value._IsSetResultID)
				{
					strUpdate += "[ResultID]=" + CreateSqlParameterName("ResultID") + ",";
				}
				if (value._IsSetCourtOrderAmount)
				{
					strUpdate += "[CourtOrderAmount]=" + CreateSqlParameterName("CourtOrderAmount") + ",";
				}
				if (value._IsSetJudgmentDate)
				{
					strUpdate += "[JudgmentDate]=" + CreateSqlParameterName("JudgmentDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ContractCaseFollowUp] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "CourtLocation", value.CourtLocation);
					AddParameter(cmd, "CourtOrderID", value.IsCourtOrderIDNull ? DBNull.Value : (object)value.CourtOrderID);
					AddParameter(cmd, "ResultID", value.IsResultIDNull ? DBNull.Value : (object)value.ResultID);
					AddParameter(cmd, "CourtOrderAmount", value.IsCourtOrderAmountNull ? DBNull.Value : (object)value.CourtOrderAmount);
					AddParameter(cmd, "JudgmentDate", value.IsJudgmentDateNull ? DBNull.Value : (object)value.JudgmentDate);
					AddParameter(cmd, "Note", value.Note);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ContractID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ContractCaseFollowUpRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetContractID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCourtLocation)
				{
					strUpdate += "[CourtLocation]=" + CreateSqlParameterName("CourtLocation") + ",";
				}
				if (value._IsSetCourtOrderID)
				{
					strUpdate += "[CourtOrderID]=" + CreateSqlParameterName("CourtOrderID") + ",";
				}
				if (value._IsSetResultID)
				{
					strUpdate += "[ResultID]=" + CreateSqlParameterName("ResultID") + ",";
				}
				if (value._IsSetCourtOrderAmount)
				{
					strUpdate += "[CourtOrderAmount]=" + CreateSqlParameterName("CourtOrderAmount") + ",";
				}
				if (value._IsSetJudgmentDate)
				{
					strUpdate += "[JudgmentDate]=" + CreateSqlParameterName("JudgmentDate") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ContractCaseFollowUp] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ContractID]=" + CreateSqlParameterName("ContractID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ContractID", value.ContractID);
					AddParameter(cmd, "CourtLocation", Sanitizer.GetSafeHtmlFragment(value.CourtLocation));
					AddParameter(cmd, "CourtOrderID", value.IsCourtOrderIDNull ? DBNull.Value : (object)value.CourtOrderID);
					AddParameter(cmd, "ResultID", value.IsResultIDNull ? DBNull.Value : (object)value.ResultID);
					AddParameter(cmd, "CourtOrderAmount", value.IsCourtOrderAmountNull ? DBNull.Value : (object)value.CourtOrderAmount);
					AddParameter(cmd, "JudgmentDate", value.IsJudgmentDateNull ? DBNull.Value : (object)value.JudgmentDate);
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ContractID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int contractID)
		{
			string whereSql = "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContractID", contractID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByContractID(int contractID)
		{
			return CreateDeleteByContractIDCommand(contractID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByContractIDCommand(int contractID)
		{
			string whereSql = "";
			whereSql += "[ContractID]=" + CreateSqlParameterName("ContractID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ContractID", contractID);
			return cmd;
		}
		public int DeleteByResultID(int resultID)
		{
			return DeleteByResultID(resultID, false);
		}
		public int DeleteByResultID(int resultID, bool resultIDNull)
		{
			return CreateDeleteByResultIDCommand(resultID, resultIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByResultIDCommand(int resultID, bool resultIDNull)
		{
			string whereSql = "";
			if (resultIDNull)
				whereSql += "[ResultID] IS NULL";
			else
				whereSql += "[ResultID]=" + CreateSqlParameterName("ResultID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!resultIDNull)
				AddParameter(cmd, "ResultID", resultID);
			return cmd;
		}
		protected ContractCaseFollowUpRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ContractCaseFollowUpRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ContractCaseFollowUpRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int contractIDColumnIndex = reader.GetOrdinal("ContractID");
			int courtLocationColumnIndex = reader.GetOrdinal("CourtLocation");
			int courtOrderIDColumnIndex = reader.GetOrdinal("CourtOrderID");
			int resultIDColumnIndex = reader.GetOrdinal("ResultID");
			int courtOrderAmountColumnIndex = reader.GetOrdinal("CourtOrderAmount");
			int judgmentDateColumnIndex = reader.GetOrdinal("JudgmentDate");
			int noteColumnIndex = reader.GetOrdinal("Note");
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
					ContractCaseFollowUpRow record = new ContractCaseFollowUpRow();
					recordList.Add(record);
					record.ContractID =  Convert.ToInt32(reader.GetValue(contractIDColumnIndex));
					if (!reader.IsDBNull(courtLocationColumnIndex)) record.CourtLocation =  Convert.ToString(reader.GetValue(courtLocationColumnIndex));

					if (!reader.IsDBNull(courtOrderIDColumnIndex)) record.CourtOrderID =  Convert.ToInt32(reader.GetValue(courtOrderIDColumnIndex));

					if (!reader.IsDBNull(resultIDColumnIndex)) record.ResultID =  Convert.ToInt32(reader.GetValue(resultIDColumnIndex));

					if (!reader.IsDBNull(courtOrderAmountColumnIndex)) record.CourtOrderAmount =  Convert.ToDouble(reader.GetValue(courtOrderAmountColumnIndex));

					if (!reader.IsDBNull(judgmentDateColumnIndex)) record.JudgmentDate =  Convert.ToDateTime(reader.GetValue(judgmentDateColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ContractCaseFollowUpRow[])(recordList.ToArray(typeof(ContractCaseFollowUpRow)));
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
				case "ContractID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourtLocation":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CourtOrderID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ResultID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourtOrderAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "JudgmentDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Note":
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

