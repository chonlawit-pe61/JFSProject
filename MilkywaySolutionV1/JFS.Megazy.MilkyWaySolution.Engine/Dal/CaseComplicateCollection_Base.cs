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
	public partial class CaseComplicateCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CaseIDColumnName = "CaseID";
		public const string ComplicateIDColumnName = "ComplicateID";
		public const string ComplicateOtherNoteColumnName = "ComplicateOtherNote";
		public const string CreateDateColumnName = "CreateDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseComplicateCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseComplicateRow[] GetAll()
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
			"[ApplicantID],"+
			"[CaseID],"+
			"[ComplicateID],"+
			"[ComplicateOtherNote],"+
			"[CreateDate],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseComplicate]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseComplicate]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseComplicate"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ComplicateID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ComplicateOtherNote",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CreateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseComplicateRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public virtual CaseComplicateRow[] GetByCaseID(int caseID)
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
		public virtual CaseComplicateRow[] GetByComplicateID(int complicateID)
		{
			return MapRecords(CreateGetByComplicateIDCommand(complicateID));
		}
		public virtual DataTable GetByComplicateIDAsDataTable(int complicateID)
		{
			return MapRecordsToDataTable(CreateGetByComplicateIDCommand(complicateID));
		}
		protected virtual IDbCommand CreateGetByComplicateIDCommand(int complicateID)
		{
			string whereSql = "";
			whereSql += "[ComplicateID]=" + CreateSqlParameterName("ComplicateID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ComplicateID", complicateID);
			return cmd;
		}
		public CaseComplicateRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseComplicateRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseComplicateRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseComplicateRow"/> objects.</returns>
		public virtual CaseComplicateRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseComplicate]", top);
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
		public CaseComplicateRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseComplicateRow[] rows = null;
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
		public DataTable GetCaseComplicatePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApplicantID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[CaseComplicate] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,CaseID,ComplicateID,ComplicateOtherNote,CreateDate,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseComplicate] " + whereSql +
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
		public CaseComplicateItemsPaging GetCaseComplicatePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		CaseComplicateItemsPaging obj = new CaseComplicateItemsPaging();
		DataTable dt = GetCaseComplicatePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseComplicateItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseComplicateItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ComplicateID = Convert.ToInt32(dt.Rows[i]["ComplicateID"]);
			record.ComplicateOtherNote = dt.Rows[i]["ComplicateOtherNote"].ToString();
			if (dt.Rows[i]["CreateDate"] != DBNull.Value)
			record.CreateDate = Convert.ToDateTime(dt.Rows[i]["CreateDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.casecomplicateItems = (CaseComplicateItems[])(recordList.ToArray(typeof(CaseComplicateItems)));
		return obj;
		}
		public CaseComplicateRow GetByPrimaryKey(int applicantID, int caseID, int complicateID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ComplicateID]=" + CreateSqlParameterName("ComplicateID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ComplicateID", complicateID);
			CaseComplicateRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseComplicateRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseComplicate] (" +
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[ComplicateID], " + 
			"[ComplicateOtherNote], " + 
			"[CreateDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ComplicateID") + ", " +
			CreateSqlParameterName("ComplicateOtherNote") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ComplicateID", value.ComplicateID);
			AddParameter(cmd, "ComplicateOtherNote", value.ComplicateOtherNote);
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseComplicateRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseComplicate] (" +
			"[ApplicantID], " + 
			"[CaseID], " + 
			"[ComplicateID], " + 
			"[ComplicateOtherNote], " + 
			"[CreateDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ComplicateID") + ", " +
			CreateSqlParameterName("ComplicateOtherNote") + ", " +
			CreateSqlParameterName("CreateDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ComplicateID", value.ComplicateID);
			AddParameter(cmd, "ComplicateOtherNote", Sanitizer.GetSafeHtmlFragment(value.ComplicateOtherNote));
			AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseComplicateRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetCaseID == true && value._IsSetComplicateID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetComplicateOtherNote)
				{
					strUpdate += "[ComplicateOtherNote]=" + CreateSqlParameterName("ComplicateOtherNote") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseComplicate] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ComplicateID]=" + CreateSqlParameterName("ComplicateID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ComplicateID", value.ComplicateID);
					AddParameter(cmd, "ComplicateOtherNote", value.ComplicateOtherNote);
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,CaseID,ComplicateID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseComplicateRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetCaseID == true && value._IsSetComplicateID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetComplicateOtherNote)
				{
					strUpdate += "[ComplicateOtherNote]=" + CreateSqlParameterName("ComplicateOtherNote") + ",";
				}
				if (value._IsSetCreateDate)
				{
					strUpdate += "[CreateDate]=" + CreateSqlParameterName("CreateDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseComplicate] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ComplicateID]=" + CreateSqlParameterName("ComplicateID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ComplicateID", value.ComplicateID);
					AddParameter(cmd, "ComplicateOtherNote", Sanitizer.GetSafeHtmlFragment(value.ComplicateOtherNote));
					AddParameter(cmd, "CreateDate", value.IsCreateDateNull ? DBNull.Value : (object)value.CreateDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,CaseID,ComplicateID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID, int caseID, int complicateID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ComplicateID]=" + CreateSqlParameterName("ComplicateID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ComplicateID", complicateID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
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
		public int DeleteByComplicateID(int complicateID)
		{
			return CreateDeleteByComplicateIDCommand(complicateID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByComplicateIDCommand(int complicateID)
		{
			string whereSql = "";
			whereSql += "[ComplicateID]=" + CreateSqlParameterName("ComplicateID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ComplicateID", complicateID);
			return cmd;
		}
		protected CaseComplicateRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseComplicateRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseComplicateRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int complicateIDColumnIndex = reader.GetOrdinal("ComplicateID");
			int complicateOtherNoteColumnIndex = reader.GetOrdinal("ComplicateOtherNote");
			int createDateColumnIndex = reader.GetOrdinal("CreateDate");
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
					CaseComplicateRow record = new CaseComplicateRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ComplicateID =  Convert.ToInt32(reader.GetValue(complicateIDColumnIndex));
					if (!reader.IsDBNull(complicateOtherNoteColumnIndex)) record.ComplicateOtherNote =  Convert.ToString(reader.GetValue(complicateOtherNoteColumnIndex));

					if (!reader.IsDBNull(createDateColumnIndex)) record.CreateDate =  Convert.ToDateTime(reader.GetValue(createDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseComplicateRow[])(recordList.ToArray(typeof(CaseComplicateRow)));
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
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ComplicateID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ComplicateOtherNote":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CreateDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
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

