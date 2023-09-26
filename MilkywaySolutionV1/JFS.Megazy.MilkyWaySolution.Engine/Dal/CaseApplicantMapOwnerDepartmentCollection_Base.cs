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
	public partial class CaseApplicantMapOwnerDepartmentCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string JFCaseNoColumnName = "JFCaseNo";
		public const string DateCreatedCaseNoColumnName = "DateCreatedCaseNo";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseApplicantMapOwnerDepartmentCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseApplicantMapOwnerDepartmentRow[] GetAll()
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
			"[DepartmentID],"+
			"[JFCaseNo],"+
			"[DateCreatedCaseNo],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseApplicantMapOwnerDepartment]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseApplicantMapOwnerDepartment]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseApplicantMapOwnerDepartment"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JFCaseNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DateCreatedCaseNo",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual CaseApplicantMapOwnerDepartmentRow[] GetByApplicantID(int applicantID)
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
		public virtual CaseApplicantMapOwnerDepartmentRow[] GetByDepartmentID(int departmentId)
		{
			return MapRecords(CreateGetByDepartmentIDCommand(departmentId));
		}
		public virtual DataTable GetByDepartmentIDAsDataTable(int departmentId)
		{
			return MapRecordsToDataTable(CreateGetByDepartmentIDCommand(departmentId));
		}
		protected virtual IDbCommand CreateGetByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public CaseApplicantMapOwnerDepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseApplicantMapOwnerDepartmentRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseApplicantMapOwnerDepartmentRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseApplicantMapOwnerDepartmentRow"/> objects.</returns>
		public virtual CaseApplicantMapOwnerDepartmentRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseApplicantMapOwnerDepartment]", top);
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
		public CaseApplicantMapOwnerDepartmentRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseApplicantMapOwnerDepartmentRow[] rows = null;
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
		public DataTable GetCaseApplicantMapOwnerDepartmentPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[CaseApplicantMapOwnerDepartment] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,DepartmentID,JFCaseNo,DateCreatedCaseNo,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CaseApplicantMapOwnerDepartment].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseApplicantMapOwnerDepartment] " + whereSql +
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
		public CaseApplicantMapOwnerDepartmentItemsPaging GetCaseApplicantMapOwnerDepartmentPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		CaseApplicantMapOwnerDepartmentItemsPaging obj = new CaseApplicantMapOwnerDepartmentItemsPaging();
		DataTable dt = GetCaseApplicantMapOwnerDepartmentPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseApplicantMapOwnerDepartmentItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseApplicantMapOwnerDepartmentItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.JFCaseNo = dt.Rows[i]["JFCaseNo"].ToString();
			if (dt.Rows[i]["DateCreatedCaseNo"] != DBNull.Value)
			record.DateCreatedCaseNo = Convert.ToDateTime(dt.Rows[i]["DateCreatedCaseNo"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseApplicantMapOwnerDepartmentItems = (CaseApplicantMapOwnerDepartmentItems[])(recordList.ToArray(typeof(CaseApplicantMapOwnerDepartmentItems)));
		return obj;
		}
		public CaseApplicantMapOwnerDepartmentRow GetByPrimaryKey(int applicantID, int departmentId)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
			CaseApplicantMapOwnerDepartmentRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseApplicantMapOwnerDepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantMapOwnerDepartment] (" +
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[JFCaseNo], " + 
			"[DateCreatedCaseNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("JFCaseNo") + ", " +
			CreateSqlParameterName("DateCreatedCaseNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "JFCaseNo", value.JFCaseNo);
			AddParameter(cmd, "DateCreatedCaseNo", value.IsDateCreatedCaseNoNull ? DBNull.Value : (object)value.DateCreatedCaseNo);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseApplicantMapOwnerDepartmentRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseApplicantMapOwnerDepartment] (" +
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[JFCaseNo], " + 
			"[DateCreatedCaseNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("JFCaseNo") + ", " +
			CreateSqlParameterName("DateCreatedCaseNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "JFCaseNo", Sanitizer.GetSafeHtmlFragment(value.JFCaseNo));
			AddParameter(cmd, "DateCreatedCaseNo", value.IsDateCreatedCaseNoNull ? DBNull.Value : (object)value.DateCreatedCaseNo);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseApplicantMapOwnerDepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetJFCaseNo)
				{
					strUpdate += "[JFCaseNo]=" + CreateSqlParameterName("JFCaseNo") + ",";
				}
				if (value._IsSetDateCreatedCaseNo)
				{
					strUpdate += "[DateCreatedCaseNo]=" + CreateSqlParameterName("DateCreatedCaseNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantMapOwnerDepartment] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "JFCaseNo", value.JFCaseNo);
					AddParameter(cmd, "DateCreatedCaseNo", value.IsDateCreatedCaseNoNull ? DBNull.Value : (object)value.DateCreatedCaseNo);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseApplicantMapOwnerDepartmentRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetJFCaseNo)
				{
					strUpdate += "[JFCaseNo]=" + CreateSqlParameterName("JFCaseNo") + ",";
				}
				if (value._IsSetDateCreatedCaseNo)
				{
					strUpdate += "[DateCreatedCaseNo]=" + CreateSqlParameterName("DateCreatedCaseNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseApplicantMapOwnerDepartment] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "JFCaseNo", Sanitizer.GetSafeHtmlFragment(value.JFCaseNo));
					AddParameter(cmd, "DateCreatedCaseNo", value.IsDateCreatedCaseNoNull ? DBNull.Value : (object)value.DateCreatedCaseNo);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID, int departmentId)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
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
		public int DeleteByDepartmentID(int departmentId)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		protected CaseApplicantMapOwnerDepartmentRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseApplicantMapOwnerDepartmentRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseApplicantMapOwnerDepartmentRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int jFCaseNoColumnIndex = reader.GetOrdinal("JFCaseNo");
			int dateCreatedCaseNoColumnIndex = reader.GetOrdinal("DateCreatedCaseNo");
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
					CaseApplicantMapOwnerDepartmentRow record = new CaseApplicantMapOwnerDepartmentRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					if (!reader.IsDBNull(jFCaseNoColumnIndex)) record.JFCaseNo =  Convert.ToString(reader.GetValue(jFCaseNoColumnIndex));

					if (!reader.IsDBNull(dateCreatedCaseNoColumnIndex)) record.DateCreatedCaseNo =  Convert.ToDateTime(reader.GetValue(dateCreatedCaseNoColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseApplicantMapOwnerDepartmentRow[])(recordList.ToArray(typeof(CaseApplicantMapOwnerDepartmentRow)));
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
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "JFCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DateCreatedCaseNo":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
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

