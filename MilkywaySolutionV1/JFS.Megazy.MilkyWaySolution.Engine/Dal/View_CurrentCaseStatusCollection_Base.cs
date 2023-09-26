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
	public partial class View_CurrentCaseStatusCollection_Base : MarshalByRefObject
	{
		public const string CurrentStatusCaseIDColumnName = "CurrentStatusCaseID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CourIDColumnName = "CourID";
		public const string CourtNameColumnName = "CourtName";
		public const string HelpCaseLevelIDColumnName = "HelpCaseLevelID";
		public const string HelpCaseLevelNameColumnName = "HelpCaseLevelName";
		public const string IsOtherHelpCaseLevelColumnName = "IsOtherHelpCaseLevel";
		public const string HelpCaseLevelOtherColumnName = "HelpCaseLevelOther";
		public const string CaseTypeIDColumnName = "CaseTypeID";
		public const string CaseTypeOtherColumnName = "CaseTypeOther";
		public const string CaseRedNoColumnName = "CaseRedNo";
		public const string CaseBlackNoColumnName = "CaseBlackNo";
		public const string LitigantTitleColumnName = "LitigantTitle";
		public const string LitigantNameColumnName = "LitigantName";
		public const string JudgementColumnName = "Judgement";
		public const string ApplicantStatusColumnName = "ApplicantStatus";
		public const string ChargeColumnName = "Charge";
		private int _processID;
		public SqlCommand cmd = null;
		public View_CurrentCaseStatusCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_CurrentCaseStatusRow[] GetAll()
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
			"[CurrentStatusCaseID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[CourID],"+
			"[CourtName],"+
			"[HelpCaseLevelID],"+
			"[HelpCaseLevelName],"+
			"[IsOtherHelpCaseLevel],"+
			"[HelpCaseLevelOther],"+
			"[CaseTypeID],"+
			"[CaseTypeOther],"+
			"[CaseRedNo],"+
			"[CaseBlackNo],"+
			"[LitigantTitle],"+
			"[LitigantName],"+
			"[Judgement],"+
			"[ApplicantStatus],"+
			"[Charge]"+
			" FROM [dbo].[View_CurrentCaseStatus]";
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
				TableName = "View_CurrentCaseStatus"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CurrentStatusCaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CourID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CourtName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("HelpCaseLevelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("HelpCaseLevelName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsOtherHelpCaseLevel",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("HelpCaseLevelOther",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CaseTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseTypeOther",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CaseRedNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CaseBlackNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("LitigantTitle",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LitigantName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Judgement",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ApplicantStatus",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn = dataTable.Columns.Add("Charge",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public View_CurrentCaseStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_CurrentCaseStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_CurrentCaseStatusRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_CurrentCaseStatusRow"/> objects.</returns>
		public virtual View_CurrentCaseStatusRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_CurrentCaseStatus]", top);
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
		public View_CurrentCaseStatusRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_CurrentCaseStatusRow[] rows = null;
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
		public DataTable GetView_CurrentCaseStatusPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CurrentStatusCaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CurrentStatusCaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_CurrentCaseStatus] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CurrentStatusCaseID,CaseID,ApplicantID,CourID,CourtName,HelpCaseLevelID,HelpCaseLevelName,IsOtherHelpCaseLevel,HelpCaseLevelOther,CaseTypeID,CaseTypeOther,CaseRedNo,CaseBlackNo,LitigantTitle,LitigantName,Judgement,ApplicantStatus,Charge," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_CurrentCaseStatus].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_CurrentCaseStatus] " + whereSql +
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
		public View_CurrentCaseStatusItemsPaging GetView_CurrentCaseStatusPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CurrentStatusCaseID")
		{
		View_CurrentCaseStatusItemsPaging obj = new View_CurrentCaseStatusItemsPaging();
		DataTable dt = GetView_CurrentCaseStatusPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_CurrentCaseStatusItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_CurrentCaseStatusItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CurrentStatusCaseID = Convert.ToInt32(dt.Rows[i]["CurrentStatusCaseID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["CourID"] != DBNull.Value)
			record.CourID = Convert.ToInt32(dt.Rows[i]["CourID"]);
			record.CourtName = dt.Rows[i]["CourtName"].ToString();
			if (dt.Rows[i]["HelpCaseLevelID"] != DBNull.Value)
			record.HelpCaseLevelID = Convert.ToInt32(dt.Rows[i]["HelpCaseLevelID"]);
			record.HelpCaseLevelName = dt.Rows[i]["HelpCaseLevelName"].ToString();
			if (dt.Rows[i]["IsOtherHelpCaseLevel"] != DBNull.Value)
			record.IsOtherHelpCaseLevel = Convert.ToBoolean(dt.Rows[i]["IsOtherHelpCaseLevel"]);
			record.HelpCaseLevelOther = dt.Rows[i]["HelpCaseLevelOther"].ToString();
			if (dt.Rows[i]["CaseTypeID"] != DBNull.Value)
			record.CaseTypeID = Convert.ToInt32(dt.Rows[i]["CaseTypeID"]);
			record.CaseTypeOther = dt.Rows[i]["CaseTypeOther"].ToString();
			record.CaseRedNo = dt.Rows[i]["CaseRedNo"].ToString();
			record.CaseBlackNo = dt.Rows[i]["CaseBlackNo"].ToString();
			record.LitigantTitle = dt.Rows[i]["LitigantTitle"].ToString();
			record.LitigantName = dt.Rows[i]["LitigantName"].ToString();
			record.Judgement = dt.Rows[i]["Judgement"].ToString();
			record.ApplicantStatus = dt.Rows[i]["ApplicantStatus"].ToString();
			record.Charge = dt.Rows[i]["Charge"].ToString();
			recordList.Add(record);
		}
		obj.view_CurrentCaseStatusItems = (View_CurrentCaseStatusItems[])(recordList.ToArray(typeof(View_CurrentCaseStatusItems)));
		return obj;
		}
		protected View_CurrentCaseStatusRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_CurrentCaseStatusRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_CurrentCaseStatusRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int currentStatuscaseIDColumnIndex = reader.GetOrdinal("CurrentStatusCaseID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int courIDColumnIndex = reader.GetOrdinal("CourID");
			int courtNameColumnIndex = reader.GetOrdinal("CourtName");
			int helpCaseLevelIDColumnIndex = reader.GetOrdinal("HelpCaseLevelID");
			int helpCaseLevelNameColumnIndex = reader.GetOrdinal("HelpCaseLevelName");
			int isOtherHelpCaseLevelColumnIndex = reader.GetOrdinal("IsOtherHelpCaseLevel");
			int helpCaseLevelOtherColumnIndex = reader.GetOrdinal("HelpCaseLevelOther");
			int caseTypeIDColumnIndex = reader.GetOrdinal("CaseTypeID");
			int caseTypeOtherColumnIndex = reader.GetOrdinal("CaseTypeOther");
			int caseRedNoColumnIndex = reader.GetOrdinal("CaseRedNo");
			int caseBlackNoColumnIndex = reader.GetOrdinal("CaseBlackNo");
			int litigantTitleColumnIndex = reader.GetOrdinal("LitigantTitle");
			int litigantNameColumnIndex = reader.GetOrdinal("LitigantName");
			int judgementColumnIndex = reader.GetOrdinal("Judgement");
			int applicantStatusColumnIndex = reader.GetOrdinal("ApplicantStatus");
			int chargeColumnIndex = reader.GetOrdinal("Charge");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_CurrentCaseStatusRow record = new View_CurrentCaseStatusRow();
					recordList.Add(record);
					record.CurrentStatusCaseID =  Convert.ToInt32(reader.GetValue(currentStatuscaseIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(courIDColumnIndex)) record.CourID =  Convert.ToInt32(reader.GetValue(courIDColumnIndex));

					if (!reader.IsDBNull(courtNameColumnIndex)) record.CourtName =  Convert.ToString(reader.GetValue(courtNameColumnIndex));

					if (!reader.IsDBNull(helpCaseLevelIDColumnIndex)) record.HelpCaseLevelID =  Convert.ToInt32(reader.GetValue(helpCaseLevelIDColumnIndex));

					if (!reader.IsDBNull(helpCaseLevelNameColumnIndex)) record.HelpCaseLevelName =  Convert.ToString(reader.GetValue(helpCaseLevelNameColumnIndex));

					if (!reader.IsDBNull(isOtherHelpCaseLevelColumnIndex)) record.IsOtherHelpCaseLevel =  Convert.ToBoolean(reader.GetValue(isOtherHelpCaseLevelColumnIndex));

					if (!reader.IsDBNull(helpCaseLevelOtherColumnIndex)) record.HelpCaseLevelOther =  Convert.ToString(reader.GetValue(helpCaseLevelOtherColumnIndex));

					if (!reader.IsDBNull(caseTypeIDColumnIndex)) record.CaseTypeID =  Convert.ToInt32(reader.GetValue(caseTypeIDColumnIndex));

					if (!reader.IsDBNull(caseTypeOtherColumnIndex)) record.CaseTypeOther =  Convert.ToString(reader.GetValue(caseTypeOtherColumnIndex));

					if (!reader.IsDBNull(caseRedNoColumnIndex)) record.CaseRedNo =  Convert.ToString(reader.GetValue(caseRedNoColumnIndex));

					if (!reader.IsDBNull(caseBlackNoColumnIndex)) record.CaseBlackNo =  Convert.ToString(reader.GetValue(caseBlackNoColumnIndex));

					if (!reader.IsDBNull(litigantTitleColumnIndex)) record.LitigantTitle =  Convert.ToString(reader.GetValue(litigantTitleColumnIndex));

					if (!reader.IsDBNull(litigantNameColumnIndex)) record.LitigantName =  Convert.ToString(reader.GetValue(litigantNameColumnIndex));

					if (!reader.IsDBNull(judgementColumnIndex)) record.Judgement =  Convert.ToString(reader.GetValue(judgementColumnIndex));

					if (!reader.IsDBNull(applicantStatusColumnIndex)) record.ApplicantStatus =  Convert.ToString(reader.GetValue(applicantStatusColumnIndex));

					if (!reader.IsDBNull(chargeColumnIndex)) record.Charge =  Convert.ToString(reader.GetValue(chargeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_CurrentCaseStatusRow[])(recordList.ToArray(typeof(View_CurrentCaseStatusRow)));
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
				case "CurrentStatusCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourtName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "HelpCaseLevelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HelpCaseLevelName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "IsOtherHelpCaseLevel":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "HelpCaseLevelOther":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseTypeOther":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseRedNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CaseBlackNo":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LitigantTitle":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LitigantName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Judgement":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ApplicantStatus":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Charge":
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

