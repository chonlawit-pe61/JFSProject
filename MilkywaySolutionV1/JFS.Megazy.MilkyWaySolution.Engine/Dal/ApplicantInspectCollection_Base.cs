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
	public partial class ApplicantInspectCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string InspectIDColumnName = "InspectID";
		public const string InspectValueListIDColumnName = "InspectValueListID";
		public const string ResultColumnName = "Result";
		public const string StatusColumnName = "Status";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantInspectCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantInspectRow[] GetAll()
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
			"[InspectID],"+
			"[InspectValueListID],"+
			"[Result],"+
			"[Status],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantInspect]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantInspect]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantInspect"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectValueListID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Result",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Status",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual ApplicantInspectRow[] GetByApplicantID(int applicantID)
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
		public virtual ApplicantInspectRow[] GetByInspectID(int inspectiD)
		{
			return MapRecords(CreateGetByInspectIDCommand(inspectiD));
		}
		public virtual DataTable GetByInspectIDAsDataTable(int inspectiD)
		{
			return MapRecordsToDataTable(CreateGetByInspectIDCommand(inspectiD));
		}
		protected virtual IDbCommand CreateGetByInspectIDCommand(int inspectiD)
		{
			string whereSql = "";
			whereSql += "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectID", inspectiD);
			return cmd;
		}
		public virtual ApplicantInspectRow[] GetByInspectValueListID(int inspectValueListiD)
		{
			return MapRecords(CreateGetByInspectValueListIDCommand(inspectValueListiD));
		}
		public virtual DataTable GetByInspectValueListIDAsDataTable(int inspectValueListiD)
		{
			return MapRecordsToDataTable(CreateGetByInspectValueListIDCommand(inspectValueListiD));
		}
		protected virtual IDbCommand CreateGetByInspectValueListIDCommand(int inspectValueListiD)
		{
			string whereSql = "";
			whereSql += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectValueListID", inspectValueListiD);
			return cmd;
		}
		public ApplicantInspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantInspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantInspectRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantInspectRow"/> objects.</returns>
		public virtual ApplicantInspectRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantInspect]", top);
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
		public ApplicantInspectRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantInspectRow[] rows = null;
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
		public DataTable GetApplicantInspectPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[ApplicantInspect] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,InspectID,InspectValueListID,Result,Status,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [ApplicantInspect].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantInspect] " + whereSql +
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
		public ApplicantInspectItemsPaging GetApplicantInspectPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		ApplicantInspectItemsPaging obj = new ApplicantInspectItemsPaging();
		DataTable dt = GetApplicantInspectPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantInspectItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantInspectItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.InspectID = Convert.ToInt32(dt.Rows[i]["InspectID"]);
			if (dt.Rows[i]["InspectValueListID"] != DBNull.Value)
			record.InspectValueListID = Convert.ToInt32(dt.Rows[i]["InspectValueListID"]);
			record.Result = dt.Rows[i]["Result"].ToString();
			if (dt.Rows[i]["Status"] != DBNull.Value)
			record.Status = Convert.ToBoolean(dt.Rows[i]["Status"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantInspectItems = (ApplicantInspectItems[])(recordList.ToArray(typeof(ApplicantInspectItems)));
		return obj;
		}
		public ApplicantInspectRow GetByPrimaryKey(int applicantID, int inspectiD)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "InspectID", inspectiD);
			ApplicantInspectRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantInspectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantInspect] (" +
			"[ApplicantID], " + 
			"[InspectID], " + 
			"[InspectValueListID], " + 
			"[Result], " + 
			"[Status], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("InspectValueListID") + ", " +
			CreateSqlParameterName("Result") + ", " +
			CreateSqlParameterName("Status") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "InspectValueListID", value.IsInspectValueListIDNull ? DBNull.Value : (object)value.InspectValueListID);
			AddParameter(cmd, "Result", value.Result);
			AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantInspectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantInspect] (" +
			"[ApplicantID], " + 
			"[InspectID], " + 
			"[InspectValueListID], " + 
			"[Result], " + 
			"[Status], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("InspectValueListID") + ", " +
			CreateSqlParameterName("Result") + ", " +
			CreateSqlParameterName("Status") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "InspectValueListID", value.IsInspectValueListIDNull ? DBNull.Value : (object)value.InspectValueListID);
			AddParameter(cmd, "Result", Sanitizer.GetSafeHtmlFragment(value.Result));
			AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantInspectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectValueListID)
				{
					strUpdate += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID") + ",";
				}
				if (value._IsSetResult)
				{
					strUpdate += "[Result]=" + CreateSqlParameterName("Result") + ",";
				}
				if (value._IsSetStatus)
				{
					strUpdate += "[Status]=" + CreateSqlParameterName("Status") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantInspect] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "InspectValueListID", value.IsInspectValueListIDNull ? DBNull.Value : (object)value.InspectValueListID);
					AddParameter(cmd, "Result", value.Result);
					AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantInspectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectValueListID)
				{
					strUpdate += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID") + ",";
				}
				if (value._IsSetResult)
				{
					strUpdate += "[Result]=" + CreateSqlParameterName("Result") + ",";
				}
				if (value._IsSetStatus)
				{
					strUpdate += "[Status]=" + CreateSqlParameterName("Status") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantInspect] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "InspectValueListID", value.IsInspectValueListIDNull ? DBNull.Value : (object)value.InspectValueListID);
					AddParameter(cmd, "Result", Sanitizer.GetSafeHtmlFragment(value.Result));
					AddParameter(cmd, "Status", value.IsStatusNull ? DBNull.Value : (object)value.Status);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID, int inspectiD)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "InspectID", inspectiD);
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
		public int DeleteByInspectID(int inspectiD)
		{
			return CreateDeleteByInspectIDCommand(inspectiD).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByInspectIDCommand(int inspectiD)
		{
			string whereSql = "";
			whereSql += "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InspectID", inspectiD);
			return cmd;
		}
		public int DeleteByInspectValueListID(int inspectValueListiD)
		{
			return DeleteByInspectValueListID(inspectValueListiD, false);
		}
		public int DeleteByInspectValueListID(int inspectValueListiD, bool inspectValueListiDNull)
		{
			return CreateDeleteByInspectValueListIDCommand(inspectValueListiD, inspectValueListiDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByInspectValueListIDCommand(int inspectValueListiD, bool inspectValueListiDNull)
		{
			string whereSql = "";
			if (inspectValueListiDNull)
				whereSql += "[InspectValueListID] IS NULL";
			else
				whereSql += "[InspectValueListID]=" + CreateSqlParameterName("InspectValueListID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!inspectValueListiDNull)
				AddParameter(cmd, "InspectValueListID", inspectValueListiD);
			return cmd;
		}
		protected ApplicantInspectRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantInspectRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantInspectRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int inspectiDColumnIndex = reader.GetOrdinal("InspectID");
			int inspectValueListiDColumnIndex = reader.GetOrdinal("InspectValueListID");
			int resultColumnIndex = reader.GetOrdinal("Result");
			int statusColumnIndex = reader.GetOrdinal("Status");
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
					ApplicantInspectRow record = new ApplicantInspectRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.InspectID =  Convert.ToInt32(reader.GetValue(inspectiDColumnIndex));
					if (!reader.IsDBNull(inspectValueListiDColumnIndex)) record.InspectValueListID =  Convert.ToInt32(reader.GetValue(inspectValueListiDColumnIndex));

					if (!reader.IsDBNull(resultColumnIndex)) record.Result =  Convert.ToString(reader.GetValue(resultColumnIndex));

					if (!reader.IsDBNull(statusColumnIndex)) record.Status =  Convert.ToBoolean(reader.GetValue(statusColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantInspectRow[])(recordList.ToArray(typeof(ApplicantInspectRow)));
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
				case "InspectID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectValueListID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Result":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Status":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

