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
	public partial class View_ApplicantCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CaseIDColumnName = "CaseID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string RequestAmountColumnName = "RequestAmount";
		public const string HasProxyColumnName = "HasProxy";
		public const string GenderColumnName = "Gender";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string RaceIDColumnName = "RaceID";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string CardIDColumnName = "CardID";
		public const string CardTypeColumnName = "CardType";
		public const string ScoreColumnName = "Score";
		public const string AgeColumnName = "Age";
		public const string DeletedFlagColumnName = "DeletedFlag";
		private int _processID;
		public SqlCommand cmd = null;
		public View_ApplicantCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_ApplicantRow[] GetAll()
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
			"[ApplicantID],"+
			"[CaseID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[RequestAmount],"+
			"[HasProxy],"+
			"[Gender],"+
			"[DateOfBirth],"+
			"[RaceID],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[CardID],"+
			"[CardType],"+
			"[Score],"+
			"[Age],"+
			"[DeletedFlag]"+
			" FROM [dbo].[View_Applicant]";
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
				TableName = "View_Applicant"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("RequestAmount",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("HasProxy",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CardType",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Score",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DeletedFlag",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public View_ApplicantRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_ApplicantRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_ApplicantRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_ApplicantRow"/> objects.</returns>
		public virtual View_ApplicantRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Applicant]", top);
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
		public View_ApplicantRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_ApplicantRow[] rows = null;
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
		public DataTable GetView_ApplicantPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_Applicant] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,CaseID,Title,FirstName,LastName,RequestAmount,HasProxy,Gender,DateOfBirth,RaceID,ReligionID,NationalityID,CardID,CardType,Score,Age,DeletedFlag," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_Applicant].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Applicant] " + whereSql +
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
		public View_ApplicantItemsPaging GetView_ApplicantPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		View_ApplicantItemsPaging obj = new View_ApplicantItemsPaging();
		DataTable dt = GetView_ApplicantPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_ApplicantItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_ApplicantItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["CaseID"] != DBNull.Value)
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["RequestAmount"] != DBNull.Value)
			record.RequestAmount = Convert.ToDouble(dt.Rows[i]["RequestAmount"]);
			if (dt.Rows[i]["HasProxy"] != DBNull.Value)
			record.HasProxy = Convert.ToBoolean(dt.Rows[i]["HasProxy"]);
			record.Gender = dt.Rows[i]["Gender"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			record.CardID = dt.Rows[i]["CardID"].ToString();
			if (dt.Rows[i]["CardType"] != DBNull.Value)
			record.CardType = Convert.ToInt32(dt.Rows[i]["CardType"]);
			record.Score = Convert.ToInt32(dt.Rows[i]["Score"]);
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			if (dt.Rows[i]["DeletedFlag"] != DBNull.Value)
			record.DeletedFlag = Convert.ToBoolean(dt.Rows[i]["DeletedFlag"]);
			recordList.Add(record);
		}
		obj.view_ApplicantItems = (View_ApplicantItems[])(recordList.ToArray(typeof(View_ApplicantItems)));
		return obj;
		}
		protected View_ApplicantRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_ApplicantRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_ApplicantRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int requestAmountColumnIndex = reader.GetOrdinal("RequestAmount");
			int hasProxyColumnIndex = reader.GetOrdinal("HasProxy");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int cardTypeColumnIndex = reader.GetOrdinal("CardType");
			int scoreColumnIndex = reader.GetOrdinal("Score");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int deletedFlagColumnIndex = reader.GetOrdinal("DeletedFlag");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_ApplicantRow record = new View_ApplicantRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(caseIDColumnIndex)) record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));

					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(requestAmountColumnIndex)) record.RequestAmount =  Convert.ToDouble(reader.GetValue(requestAmountColumnIndex));

					if (!reader.IsDBNull(hasProxyColumnIndex)) record.HasProxy =  Convert.ToBoolean(reader.GetValue(hasProxyColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToString(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(cardTypeColumnIndex)) record.CardType =  Convert.ToInt32(reader.GetValue(cardTypeColumnIndex));

					record.Score =  Convert.ToInt32(reader.GetValue(scoreColumnIndex));
					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(deletedFlagColumnIndex)) record.DeletedFlag =  Convert.ToBoolean(reader.GetValue(deletedFlagColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_ApplicantRow[])(recordList.ToArray(typeof(View_ApplicantRow)));
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
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RequestAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "HasProxy":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "CardType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Score":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DeletedFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

