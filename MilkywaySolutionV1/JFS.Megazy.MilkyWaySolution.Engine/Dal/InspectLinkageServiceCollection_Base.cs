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
	public partial class InspectLinkageServiceCollection_Base : MarshalByRefObject
	{
		public const string InspectIDColumnName = "InspectID";
		public const string SupportCodeColumnName = "SupportCode";
		public const string OfficeIDColumnName = "OfficeID";
		public const string ServiceVersionColumnName = "ServiceVersion";
		public const string ServiceIDColumnName = "ServiceID";
		public const string IsActiveColumnName = "IsActive";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public InspectLinkageServiceCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual InspectLinkageServiceRow[] GetAll()
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
			"[InspectID],"+
			"[SupportCode],"+
			"[OfficeID],"+
			"[ServiceVersion],"+
			"[ServiceID],"+
			"[IsActive],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[InspectLinkageService]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[InspectLinkageService]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "InspectLinkageService"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("InspectID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SupportCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OfficeID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ServiceVersion",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ServiceID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual InspectLinkageServiceRow[] GetByInspectID(int inspectiD)
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
		public InspectLinkageServiceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual InspectLinkageServiceRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="InspectLinkageServiceRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="InspectLinkageServiceRow"/> objects.</returns>
		public virtual InspectLinkageServiceRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[InspectLinkageService]", top);
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
		public InspectLinkageServiceRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			InspectLinkageServiceRow[] rows = null;
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
		public DataTable GetInspectLinkageServicePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "InspectID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(InspectID) AS TotalRow FROM [dbo].[InspectLinkageService] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,InspectID,SupportCode,OfficeID,ServiceVersion,ServiceID,IsActive,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [InspectLinkageService].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[InspectLinkageService] " + whereSql +
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
		public InspectLinkageServiceItemsPaging GetInspectLinkageServicePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
		{
		InspectLinkageServiceItemsPaging obj = new InspectLinkageServiceItemsPaging();
		DataTable dt = GetInspectLinkageServicePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		InspectLinkageServiceItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new InspectLinkageServiceItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.InspectID = Convert.ToInt32(dt.Rows[i]["InspectID"]);
			record.SupportCode = dt.Rows[i]["SupportCode"].ToString();
			record.OfficeID = dt.Rows[i]["OfficeID"].ToString();
			record.ServiceVersion = dt.Rows[i]["ServiceVersion"].ToString();
			record.ServiceID = dt.Rows[i]["ServiceID"].ToString();
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.inspectLinkageServiceItems = (InspectLinkageServiceItems[])(recordList.ToArray(typeof(InspectLinkageServiceItems)));
		return obj;
		}
		public InspectLinkageServiceRow GetByPrimaryKey(int inspectiD)
		{
			string whereSql = "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectID", inspectiD);
			InspectLinkageServiceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(InspectLinkageServiceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InspectLinkageService] (" +
			"[InspectID], " + 
			"[SupportCode], " + 
			"[OfficeID], " + 
			"[ServiceVersion], " + 
			"[ServiceID], " + 
			"[IsActive], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("SupportCode") + ", " +
			CreateSqlParameterName("OfficeID") + ", " +
			CreateSqlParameterName("ServiceVersion") + ", " +
			CreateSqlParameterName("ServiceID") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "SupportCode", value.SupportCode);
			AddParameter(cmd, "OfficeID", value.OfficeID);
			AddParameter(cmd, "ServiceVersion", value.ServiceVersion);
			AddParameter(cmd, "ServiceID", value.ServiceID);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(InspectLinkageServiceRow value)		{
			string sqlStr = "INSERT INTO [dbo].[InspectLinkageService] (" +
			"[InspectID], " + 
			"[SupportCode], " + 
			"[OfficeID], " + 
			"[ServiceVersion], " + 
			"[ServiceID], " + 
			"[IsActive], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("SupportCode") + ", " +
			CreateSqlParameterName("OfficeID") + ", " +
			CreateSqlParameterName("ServiceVersion") + ", " +
			CreateSqlParameterName("ServiceID") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "SupportCode", Sanitizer.GetSafeHtmlFragment(value.SupportCode));
			AddParameter(cmd, "OfficeID", Sanitizer.GetSafeHtmlFragment(value.OfficeID));
			AddParameter(cmd, "ServiceVersion", Sanitizer.GetSafeHtmlFragment(value.ServiceVersion));
			AddParameter(cmd, "ServiceID", Sanitizer.GetSafeHtmlFragment(value.ServiceID));
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(InspectLinkageServiceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSupportCode)
				{
					strUpdate += "[SupportCode]=" + CreateSqlParameterName("SupportCode") + ",";
				}
				if (value._IsSetOfficeID)
				{
					strUpdate += "[OfficeID]=" + CreateSqlParameterName("OfficeID") + ",";
				}
				if (value._IsSetServiceVersion)
				{
					strUpdate += "[ServiceVersion]=" + CreateSqlParameterName("ServiceVersion") + ",";
				}
				if (value._IsSetServiceID)
				{
					strUpdate += "[ServiceID]=" + CreateSqlParameterName("ServiceID") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
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
					strUpdate = "UPDATE [dbo].[InspectLinkageService] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "SupportCode", value.SupportCode);
					AddParameter(cmd, "OfficeID", value.OfficeID);
					AddParameter(cmd, "ServiceVersion", value.ServiceVersion);
					AddParameter(cmd, "ServiceID", value.ServiceID);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(InspectLinkageServiceRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetSupportCode)
				{
					strUpdate += "[SupportCode]=" + CreateSqlParameterName("SupportCode") + ",";
				}
				if (value._IsSetOfficeID)
				{
					strUpdate += "[OfficeID]=" + CreateSqlParameterName("OfficeID") + ",";
				}
				if (value._IsSetServiceVersion)
				{
					strUpdate += "[ServiceVersion]=" + CreateSqlParameterName("ServiceVersion") + ",";
				}
				if (value._IsSetServiceID)
				{
					strUpdate += "[ServiceID]=" + CreateSqlParameterName("ServiceID") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
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
					strUpdate = "UPDATE [dbo].[InspectLinkageService] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "SupportCode", Sanitizer.GetSafeHtmlFragment(value.SupportCode));
					AddParameter(cmd, "OfficeID", Sanitizer.GetSafeHtmlFragment(value.OfficeID));
					AddParameter(cmd, "ServiceVersion", Sanitizer.GetSafeHtmlFragment(value.ServiceVersion));
					AddParameter(cmd, "ServiceID", Sanitizer.GetSafeHtmlFragment(value.ServiceID));
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int inspectiD)
		{
			string whereSql = "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InspectID", inspectiD);
			return 0 < cmd.ExecuteNonQuery();
		}
		public InspectLinkageServiceRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			InspectLinkageServiceRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
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
		protected InspectLinkageServiceRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected InspectLinkageServiceRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected InspectLinkageServiceRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int inspectiDColumnIndex = reader.GetOrdinal("InspectID");
			int supportCodeColumnIndex = reader.GetOrdinal("SupportCode");
			int officeIDColumnIndex = reader.GetOrdinal("OfficeID");
			int serviceVersionColumnIndex = reader.GetOrdinal("ServiceVersion");
			int serviceIDColumnIndex = reader.GetOrdinal("ServiceID");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
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
					InspectLinkageServiceRow record = new InspectLinkageServiceRow();
					recordList.Add(record);
					record.InspectID =  Convert.ToInt32(reader.GetValue(inspectiDColumnIndex));
					if (!reader.IsDBNull(supportCodeColumnIndex)) record.SupportCode =  Convert.ToString(reader.GetValue(supportCodeColumnIndex));

					if (!reader.IsDBNull(officeIDColumnIndex)) record.OfficeID =  Convert.ToString(reader.GetValue(officeIDColumnIndex));

					if (!reader.IsDBNull(serviceVersionColumnIndex)) record.ServiceVersion =  Convert.ToString(reader.GetValue(serviceVersionColumnIndex));

					if (!reader.IsDBNull(serviceIDColumnIndex)) record.ServiceID =  Convert.ToString(reader.GetValue(serviceIDColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (InspectLinkageServiceRow[])(recordList.ToArray(typeof(InspectLinkageServiceRow)));
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
				case "InspectID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "SupportCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "OfficeID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ServiceVersion":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ServiceID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

