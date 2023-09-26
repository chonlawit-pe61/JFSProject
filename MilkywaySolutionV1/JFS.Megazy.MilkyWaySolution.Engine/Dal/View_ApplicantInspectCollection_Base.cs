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
	public partial class View_ApplicantInspectCollection_Base : MarshalByRefObject
	{
		public const string InspectIDColumnName = "InspectID";
		public const string InspectNameColumnName = "InspectName";
		public const string IsThaiCitizenColumnName = "IsThaiCitizen";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActiveColumnName = "IsActive";
		public const string InspectValueTypeColumnName = "InspectValueType";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string ResultColumnName = "Result";
		public const string StatusColumnName = "Status";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string InspectValueListIDColumnName = "InspectValueListID";
		public const string InspectValueTypeIDColumnName = "InspectValueTypeID";
		public const string InspectValueListNameColumnName = "InspectValueListName";
		public const string ServiceCodeColumnName = "ServiceCode";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ApplicantInspectCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ApplicantInspectRow[] GetAll()
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
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[InspectID],"+
			"[InspectName],"+
			"[IsThaiCitizen],"+
			"[SortOrder],"+
			"[IsActive],"+
			"[InspectValueType],"+
			"[ApplicantID],"+
			"[Result],"+
			"[Status],"+
			"[ModifiedDate],"+
			"[InspectValueListID],"+
			"[InspectValueTypeID],"+
			"[InspectValueListName],"+
			"[ServiceCode]"+
			" FROM [dbo].[View_ApplicantInspect]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "View_ApplicantInspect"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("InspectID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsThaiCitizen",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectValueType",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Result",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Status",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectValueListID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("InspectValueTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("InspectValueListName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ServiceCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			return dataTable;
		}
		public View_ApplicantInspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ApplicantInspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ApplicantInspectRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ApplicantInspectRow"/> objects.</returns>
		public virtual View_ApplicantInspectRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_ApplicantInspect]", top);
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
		public View_ApplicantInspectRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ApplicantInspectRow[] rows = null;
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
		public DataTable GetView_ApplicantInspectPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_ApplicantInspect] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,InspectID,InspectName,IsThaiCitizen,SortOrder,IsActive,InspectValueType,ApplicantID,Result,Status,ModifiedDate,InspectValueListID,InspectValueTypeID,InspectValueListName,ServiceCode," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_ApplicantInspect].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_ApplicantInspect] " + whereSql +
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
		public View_ApplicantInspectItemsPaging GetView_ApplicantInspectPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
		{
		View_ApplicantInspectItemsPaging obj = new View_ApplicantInspectItemsPaging();
		DataTable dt = GetView_ApplicantInspectPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ApplicantInspectItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ApplicantInspectItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.InspectID = Convert.ToInt32(dt.Rows[i]["InspectID"]);
			record.InspectName = dt.Rows[i]["InspectName"].ToString();
			record.IsThaiCitizen = Convert.ToBoolean(dt.Rows[i]["IsThaiCitizen"]);
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["InspectValueType"] != DBNull.Value)
			record.InspectValueType = Convert.ToInt32(dt.Rows[i]["InspectValueType"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.Result = dt.Rows[i]["Result"].ToString();
			if (dt.Rows[i]["Status"] != DBNull.Value)
			record.Status = Convert.ToBoolean(dt.Rows[i]["Status"]);
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			if (dt.Rows[i]["InspectValueListID"] != DBNull.Value)
			record.InspectValueListID = Convert.ToInt32(dt.Rows[i]["InspectValueListID"]);
			if (dt.Rows[i]["InspectValueTypeID"] != DBNull.Value)
			record.InspectValueTypeID = Convert.ToInt32(dt.Rows[i]["InspectValueTypeID"]);
			record.InspectValueListName = dt.Rows[i]["InspectValueListName"].ToString();
			record.ServiceCode = dt.Rows[i]["ServiceCode"].ToString();
			recordList.Add(record);
		}
		obj.view_ApplicantInspectItems = (View_ApplicantInspectItems[])(recordList.ToArray(typeof(View_ApplicantInspectItems)));
		return obj;
		}
		public View_ApplicantInspectRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			View_ApplicantInspectRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		protected View_ApplicantInspectRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ApplicantInspectRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ApplicantInspectRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int inspectiDColumnIndex = reader.GetOrdinal("InspectID");
			int inspectNameColumnIndex = reader.GetOrdinal("InspectName");
			int isThaiCitizenColumnIndex = reader.GetOrdinal("IsThaiCitizen");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int inspectValueTypeColumnIndex = reader.GetOrdinal("InspectValueType");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int resultColumnIndex = reader.GetOrdinal("Result");
			int statusColumnIndex = reader.GetOrdinal("Status");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int inspectValueListiDColumnIndex = reader.GetOrdinal("InspectValueListID");
			int inspectValueTypeiDColumnIndex = reader.GetOrdinal("InspectValueTypeID");
			int inspectValueListNameColumnIndex = reader.GetOrdinal("InspectValueListName");
			int serviceCodeColumnIndex = reader.GetOrdinal("ServiceCode");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ApplicantInspectRow record = new View_ApplicantInspectRow();
					recordList.Add(record);
					record.InspectID =  Convert.ToInt32(reader.GetValue(inspectiDColumnIndex));
					record.InspectName =  Convert.ToString(reader.GetValue(inspectNameColumnIndex));
					record.IsThaiCitizen =  Convert.ToBoolean(reader.GetValue(isThaiCitizenColumnIndex));
					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					if (!reader.IsDBNull(inspectValueTypeColumnIndex)) record.InspectValueType =  Convert.ToInt32(reader.GetValue(inspectValueTypeColumnIndex));

					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(resultColumnIndex)) record.Result =  Convert.ToString(reader.GetValue(resultColumnIndex));

					if (!reader.IsDBNull(statusColumnIndex)) record.Status =  Convert.ToBoolean(reader.GetValue(statusColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (!reader.IsDBNull(inspectValueListiDColumnIndex)) record.InspectValueListID =  Convert.ToInt32(reader.GetValue(inspectValueListiDColumnIndex));

					if (!reader.IsDBNull(inspectValueTypeiDColumnIndex)) record.InspectValueTypeID =  Convert.ToInt32(reader.GetValue(inspectValueTypeiDColumnIndex));

					if (!reader.IsDBNull(inspectValueListNameColumnIndex)) record.InspectValueListName =  Convert.ToString(reader.GetValue(inspectValueListNameColumnIndex));

					if (!reader.IsDBNull(serviceCodeColumnIndex)) record.ServiceCode =  Convert.ToString(reader.GetValue(serviceCodeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ApplicantInspectRow[])(recordList.ToArray(typeof(View_ApplicantInspectRow)));
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
				case "InspectName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsThaiCitizen":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "InspectValueType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Result":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Status":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "InspectValueListID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectValueTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectValueListName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ServiceCode":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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

