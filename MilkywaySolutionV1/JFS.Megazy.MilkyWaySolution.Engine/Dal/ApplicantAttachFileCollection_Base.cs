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
	public partial class ApplicantAttachFileCollection_Base : MarshalByRefObject
	{
		public const string ArchivalCopyIDColumnName = "ArchivalCopyID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string AttachFileIDColumnName = "AttachFileID";
		public const string RemarkColumnName = "Remark";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantAttachFileCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantAttachFileRow[] GetAll()
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
			"[ArchivalCopyID],"+
			"[ApplicantID],"+
			"[AttachFileID],"+
			"[Remark],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantAttachFile]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantAttachFile]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantAttachFile"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ArchivalCopyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AttachFileID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Remark",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual ApplicantAttachFileRow[] GetByArchivalCopyID(int archivalCopyID)
		{
			return MapRecords(CreateGetByArchivalCopyIDCommand(archivalCopyID));
		}
		public virtual DataTable GetByArchivalCopyIDAsDataTable(int archivalCopyID)
		{
			return MapRecordsToDataTable(CreateGetByArchivalCopyIDCommand(archivalCopyID));
		}
		protected virtual IDbCommand CreateGetByArchivalCopyIDCommand(int archivalCopyID)
		{
			string whereSql = "";
			whereSql += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			return cmd;
		}
		public virtual ApplicantAttachFileRow[] GetByApplicantID(int applicantID)
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
		public virtual ApplicantAttachFileRow[] GetByAttachFileID(int attachFileID)
		{
			return MapRecords(CreateGetByAttachFileIDCommand(attachFileID));
		}
		public virtual DataTable GetByAttachFileIDAsDataTable(int attachFileID)
		{
			return MapRecordsToDataTable(CreateGetByAttachFileIDCommand(attachFileID));
		}
		protected virtual IDbCommand CreateGetByAttachFileIDCommand(int attachFileID)
		{
			string whereSql = "";
			whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AttachFileID", attachFileID);
			return cmd;
		}
		public ApplicantAttachFileRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantAttachFileRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantAttachFileRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantAttachFileRow"/> objects.</returns>
		public virtual ApplicantAttachFileRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantAttachFile]", top);
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
		public ApplicantAttachFileRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantAttachFileRow[] rows = null;
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
		public DataTable GetApplicantAttachFilePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ArchivalCopyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ArchivalCopyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ArchivalCopyID) AS TotalRow FROM [dbo].[ApplicantAttachFile] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ArchivalCopyID,ApplicantID,AttachFileID,Remark,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantAttachFile] " + whereSql +
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
		public ApplicantAttachFileItemsPaging GetApplicantAttachFilePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ArchivalCopyID")
		{
		ApplicantAttachFileItemsPaging obj = new ApplicantAttachFileItemsPaging();
		DataTable dt = GetApplicantAttachFilePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantAttachFileItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantAttachFileItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ArchivalCopyID = Convert.ToInt32(dt.Rows[i]["ArchivalCopyID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["AttachFileID"] != DBNull.Value)
			record.AttachFileID = Convert.ToInt32(dt.Rows[i]["AttachFileID"]);
			record.Remark = dt.Rows[i]["Remark"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantattachFileItems = (ApplicantAttachFileItems[])(recordList.ToArray(typeof(ApplicantAttachFileItems)));
		return obj;
		}
		public ApplicantAttachFileRow GetByPrimaryKey(int archivalCopyID, int applicantID)
		{
			string whereSql = "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			AddParameter(cmd, "ApplicantID", applicantID);
			ApplicantAttachFileRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantAttachFileRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantAttachFile] (" +
			"[ArchivalCopyID], " + 
			"[ApplicantID], " + 
			"[AttachFileID], " + 
			"[Remark], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ArchivalCopyID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
			AddParameter(cmd, "Remark", value.Remark);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantAttachFileRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantAttachFile] (" +
			"[ArchivalCopyID], " + 
			"[ApplicantID], " + 
			"[AttachFileID], " + 
			"[Remark], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ArchivalCopyID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("AttachFileID") + ", " +
			CreateSqlParameterName("Remark") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
			AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantAttachFileRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetArchivalCopyID == true && value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAttachFileID)
				{
					strUpdate += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantAttachFile] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
					AddParameter(cmd, "Remark", value.Remark);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ArchivalCopyID,ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantAttachFileRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetArchivalCopyID == true && value._IsSetApplicantID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAttachFileID)
				{
					strUpdate += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID") + ",";
				}
				if (value._IsSetRemark)
				{
					strUpdate += "[Remark]=" + CreateSqlParameterName("Remark") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantAttachFile] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ArchivalCopyID", value.ArchivalCopyID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "AttachFileID", value.IsAttachFileIDNull ? DBNull.Value : (object)value.AttachFileID);
					AddParameter(cmd, "Remark", Sanitizer.GetSafeHtmlFragment(value.Remark));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ArchivalCopyID,ApplicantID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int archivalCopyID, int applicantID)
		{
			string whereSql = "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			AddParameter(cmd, "ApplicantID", applicantID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByArchivalCopyID(int archivalCopyID)
		{
			return CreateDeleteByArchivalCopyIDCommand(archivalCopyID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByArchivalCopyIDCommand(int archivalCopyID)
		{
			string whereSql = "";
			whereSql += "[ArchivalCopyID]=" + CreateSqlParameterName("ArchivalCopyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ArchivalCopyID", archivalCopyID);
			return cmd;
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
		public int DeleteByAttachFileID(int attachFileID)
		{
			return DeleteByAttachFileID(attachFileID, false);
		}
		public int DeleteByAttachFileID(int attachFileID, bool attachFileIDNull)
		{
			return CreateDeleteByAttachFileIDCommand(attachFileID, attachFileIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAttachFileIDCommand(int attachFileID, bool attachFileIDNull)
		{
			string whereSql = "";
			if (attachFileIDNull)
				whereSql += "[AttachFileID] IS NULL";
			else
				whereSql += "[AttachFileID]=" + CreateSqlParameterName("AttachFileID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!attachFileIDNull)
				AddParameter(cmd, "AttachFileID", attachFileID);
			return cmd;
		}
		protected ApplicantAttachFileRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantAttachFileRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantAttachFileRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int archivalCopyIDColumnIndex = reader.GetOrdinal("ArchivalCopyID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int attachFileIDColumnIndex = reader.GetOrdinal("AttachFileID");
			int remarkColumnIndex = reader.GetOrdinal("Remark");
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
					ApplicantAttachFileRow record = new ApplicantAttachFileRow();
					recordList.Add(record);
					record.ArchivalCopyID =  Convert.ToInt32(reader.GetValue(archivalCopyIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(attachFileIDColumnIndex)) record.AttachFileID =  Convert.ToInt32(reader.GetValue(attachFileIDColumnIndex));

					if (!reader.IsDBNull(remarkColumnIndex)) record.Remark =  Convert.ToString(reader.GetValue(remarkColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantAttachFileRow[])(recordList.ToArray(typeof(ApplicantAttachFileRow)));
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
				case "ArchivalCopyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AttachFileID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Remark":
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

