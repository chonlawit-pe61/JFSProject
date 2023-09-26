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
	public partial class ApplicantMaritalCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string MaritalStatusIDColumnName = "MaritalStatusID";
		public const string AdditionalMaritalStatusColumnName = "AdditionalMaritalStatus";
		public const string NumberOfChildColumnName = "NumberOfChild";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantMaritalCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantMaritalRow[] GetAll()
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
			"[MaritalStatusID],"+
			"[AdditionalMaritalStatus],"+
			"[NumberOfChild],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantMarital]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantMarital]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantMarital"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MaritalStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AdditionalMaritalStatus",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NumberOfChild",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantMaritalRow[] GetByApplicantID(int applicantID)
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
		public virtual ApplicantMaritalRow[] GetByMaritalStatusID(int maritalStatusID)
		{
			return MapRecords(CreateGetByMaritalStatusIDCommand(maritalStatusID));
		}
		public virtual DataTable GetByMaritalStatusIDAsDataTable(int maritalStatusID)
		{
			return MapRecordsToDataTable(CreateGetByMaritalStatusIDCommand(maritalStatusID));
		}
		protected virtual IDbCommand CreateGetByMaritalStatusIDCommand(int maritalStatusID)
		{
			string whereSql = "";
			whereSql += "[MaritalStatusID]=" + CreateSqlParameterName("MaritalStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MaritalStatusID", maritalStatusID);
			return cmd;
		}
		public virtual ApplicantMaritalRow[] GetByAdditionalMaritalStatus(int additionalMaritalStatus)
		{
			return MapRecords(CreateGetByAdditionalMaritalStatusCommand(additionalMaritalStatus));
		}
		public virtual DataTable GetByAdditionalMaritalStatusAsDataTable(int additionalMaritalStatus)
		{
			return MapRecordsToDataTable(CreateGetByAdditionalMaritalStatusCommand(additionalMaritalStatus));
		}
		protected virtual IDbCommand CreateGetByAdditionalMaritalStatusCommand(int additionalMaritalStatus)
		{
			string whereSql = "";
			whereSql += "[AdditionalMaritalStatus]=" + CreateSqlParameterName("AdditionalMaritalStatus");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AdditionalMaritalStatus", additionalMaritalStatus);
			return cmd;
		}
		public ApplicantMaritalRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantMaritalRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantMaritalRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantMaritalRow"/> objects.</returns>
		public virtual ApplicantMaritalRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantMarital]", top);
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
		public ApplicantMaritalRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantMaritalRow[] rows = null;
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
		public DataTable GetApplicantMaritalPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[ApplicantMarital] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,MaritalStatusID,AdditionalMaritalStatus,NumberOfChild,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantMarital] " + whereSql +
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
		public ApplicantMaritalItemsPaging GetApplicantMaritalPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		ApplicantMaritalItemsPaging obj = new ApplicantMaritalItemsPaging();
		DataTable dt = GetApplicantMaritalPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantMaritalItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantMaritalItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.MaritalStatusID = Convert.ToInt32(dt.Rows[i]["MaritalStatusID"]);
			if (dt.Rows[i]["AdditionalMaritalStatus"] != DBNull.Value)
			record.AdditionalMaritalStatus = Convert.ToInt32(dt.Rows[i]["AdditionalMaritalStatus"]);
			if (dt.Rows[i]["NumberOfChild"] != DBNull.Value)
			record.NumberOfChild = Convert.ToInt32(dt.Rows[i]["NumberOfChild"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantMaritalItems = (ApplicantMaritalItems[])(recordList.ToArray(typeof(ApplicantMaritalItems)));
		return obj;
		}
		public ApplicantMaritalRow GetByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			ApplicantMaritalRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantMaritalRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantMarital] (" +
			"[ApplicantID], " + 
			"[MaritalStatusID], " + 
			"[AdditionalMaritalStatus], " + 
			"[NumberOfChild], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("MaritalStatusID") + ", " +
			CreateSqlParameterName("AdditionalMaritalStatus") + ", " +
			CreateSqlParameterName("NumberOfChild") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "MaritalStatusID", value.MaritalStatusID);
			AddParameter(cmd, "AdditionalMaritalStatus", value.IsAdditionalMaritalStatusNull ? DBNull.Value : (object)value.AdditionalMaritalStatus);
			AddParameter(cmd, "NumberOfChild", value.IsNumberOfChildNull ? DBNull.Value : (object)value.NumberOfChild);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantMaritalRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantMarital] (" +
			"[ApplicantID], " + 
			"[MaritalStatusID], " + 
			"[AdditionalMaritalStatus], " + 
			"[NumberOfChild], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("MaritalStatusID") + ", " +
			CreateSqlParameterName("AdditionalMaritalStatus") + ", " +
			CreateSqlParameterName("NumberOfChild") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "MaritalStatusID", value.MaritalStatusID);
			AddParameter(cmd, "AdditionalMaritalStatus", value.IsAdditionalMaritalStatusNull ? DBNull.Value : (object)value.AdditionalMaritalStatus);
			AddParameter(cmd, "NumberOfChild", value.IsNumberOfChildNull ? DBNull.Value : (object)value.NumberOfChild);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantMaritalRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMaritalStatusID)
				{
					strUpdate += "[MaritalStatusID]=" + CreateSqlParameterName("MaritalStatusID") + ",";
				}
				if (value._IsSetAdditionalMaritalStatus)
				{
					strUpdate += "[AdditionalMaritalStatus]=" + CreateSqlParameterName("AdditionalMaritalStatus") + ",";
				}
				if (value._IsSetNumberOfChild)
				{
					strUpdate += "[NumberOfChild]=" + CreateSqlParameterName("NumberOfChild") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantMarital] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "MaritalStatusID", value.MaritalStatusID);
					AddParameter(cmd, "AdditionalMaritalStatus", value.IsAdditionalMaritalStatusNull ? DBNull.Value : (object)value.AdditionalMaritalStatus);
					AddParameter(cmd, "NumberOfChild", value.IsNumberOfChildNull ? DBNull.Value : (object)value.NumberOfChild);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantMaritalRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMaritalStatusID)
				{
					strUpdate += "[MaritalStatusID]=" + CreateSqlParameterName("MaritalStatusID") + ",";
				}
				if (value._IsSetAdditionalMaritalStatus)
				{
					strUpdate += "[AdditionalMaritalStatus]=" + CreateSqlParameterName("AdditionalMaritalStatus") + ",";
				}
				if (value._IsSetNumberOfChild)
				{
					strUpdate += "[NumberOfChild]=" + CreateSqlParameterName("NumberOfChild") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantMarital] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "MaritalStatusID", value.MaritalStatusID);
					AddParameter(cmd, "AdditionalMaritalStatus", value.IsAdditionalMaritalStatusNull ? DBNull.Value : (object)value.AdditionalMaritalStatus);
					AddParameter(cmd, "NumberOfChild", value.IsNumberOfChildNull ? DBNull.Value : (object)value.NumberOfChild);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
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
		public int DeleteByMaritalStatusID(int maritalStatusID)
		{
			return CreateDeleteByMaritalStatusIDCommand(maritalStatusID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMaritalStatusIDCommand(int maritalStatusID)
		{
			string whereSql = "";
			whereSql += "[MaritalStatusID]=" + CreateSqlParameterName("MaritalStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MaritalStatusID", maritalStatusID);
			return cmd;
		}
		public int DeleteByAdditionalMaritalStatus(int additionalMaritalStatus)
		{
			return DeleteByAdditionalMaritalStatus(additionalMaritalStatus, false);
		}
		public int DeleteByAdditionalMaritalStatus(int additionalMaritalStatus, bool additionalMaritalStatusNull)
		{
			return CreateDeleteByAdditionalMaritalStatusCommand(additionalMaritalStatus, additionalMaritalStatusNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAdditionalMaritalStatusCommand(int additionalMaritalStatus, bool additionalMaritalStatusNull)
		{
			string whereSql = "";
			if (additionalMaritalStatusNull)
				whereSql += "[AdditionalMaritalStatus] IS NULL";
			else
				whereSql += "[AdditionalMaritalStatus]=" + CreateSqlParameterName("AdditionalMaritalStatus");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!additionalMaritalStatusNull)
				AddParameter(cmd, "AdditionalMaritalStatus", additionalMaritalStatus);
			return cmd;
		}
		protected ApplicantMaritalRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantMaritalRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantMaritalRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int maritalStatusIDColumnIndex = reader.GetOrdinal("MaritalStatusID");
			int additionalMaritalStatusColumnIndex = reader.GetOrdinal("AdditionalMaritalStatus");
			int numberOfChildColumnIndex = reader.GetOrdinal("NumberOfChild");
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
					ApplicantMaritalRow record = new ApplicantMaritalRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.MaritalStatusID =  Convert.ToInt32(reader.GetValue(maritalStatusIDColumnIndex));
					if (!reader.IsDBNull(additionalMaritalStatusColumnIndex)) record.AdditionalMaritalStatus =  Convert.ToInt32(reader.GetValue(additionalMaritalStatusColumnIndex));

					if (!reader.IsDBNull(numberOfChildColumnIndex)) record.NumberOfChild =  Convert.ToInt32(reader.GetValue(numberOfChildColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantMaritalRow[])(recordList.ToArray(typeof(ApplicantMaritalRow)));
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
				case "MaritalStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AdditionalMaritalStatus":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NumberOfChild":
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

