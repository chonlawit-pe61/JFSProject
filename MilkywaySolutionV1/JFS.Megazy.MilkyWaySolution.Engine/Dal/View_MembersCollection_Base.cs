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
	public partial class View_MembersCollection_Base : MarshalByRefObject
	{
		public const string MemberIDColumnName = "MemberID";
		public const string MemberNameColumnName = "MemberName";
		public const string OrgNameColumnName = "OrgName";
		public const string PasswordColumnName = "Password";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string GenderColumnName = "Gender";
		public const string UpdateDateColumnName = "UpdateDate";
		public const string RegistDateColumnName = "RegistDate";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string EmailColumnName = "Email";
		public const string IsVerifyByEmailColumnName = "IsVerifyByEmail";
		public const string VerifyEmailCodeColumnName = "VerifyEmailCode";
		public const string MemberStatusIDColumnName = "MemberStatusID";
		public const string LastLoginDateColumnName = "LastLoginDate";
		public const string PhoneNumberColumnName = "PhoneNumber";
		public const string MemberTypeIDColumnName = "MemberTypeID";
		public const string MemberTypeNameColumnName = "MemberTypeName";
		public const string ShortDescColumnName = "ShortDesc";
		public const string MemberStatusNameColumnName = "MemberStatusName";
		private int _processID;
		public SqlCommand cmd = null;
		public View_MembersCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_MembersRow[] GetAll()
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
			"[MemberID],"+
			"[MemberName],"+
			"[OrgName],"+
			"[Password],"+
			"[FirstName],"+
			"[LastName],"+
			"[Gender],"+
			"[UpdateDate],"+
			"[RegistDate],"+
			"[DateOfBirth],"+
			"[Email],"+
			"[IsVerifyByEmail],"+
			"[VerifyEmailCode],"+
			"[MemberStatusID],"+
			"[LastLoginDate],"+
			"[PhoneNumber],"+
			"[MemberTypeID],"+
			"[MemberTypeName],"+
			"[ShortDesc],"+
			"[MemberStatusName]"+
			" FROM [dbo].[View_Members]";
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
				TableName = "View_Members"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("MemberID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OrgName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("Password",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("UpdateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RegistDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsVerifyByEmail",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VerifyEmailCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("MemberStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LastLoginDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("PhoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MemberTypeID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ShortDesc",Type.GetType("System.String"));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("MemberStatusName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public View_MembersRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_MembersRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_MembersRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_MembersRow"/> objects.</returns>
		public virtual View_MembersRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_Members]", top);
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
		public View_MembersRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_MembersRow[] rows = null;
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
		public DataTable GetView_MembersPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MemberID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "MemberID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_Members] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MemberID,MemberName,OrgName,Password,FirstName,LastName,Gender,UpdateDate,RegistDate,DateOfBirth,Email,IsVerifyByEmail,VerifyEmailCode,MemberStatusID,LastLoginDate,PhoneNumber,MemberTypeID,MemberTypeName,ShortDesc,MemberStatusName," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_Members].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_Members] " + whereSql +
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
		public View_MembersItemsPaging GetView_MembersPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MemberID")
		{
		View_MembersItemsPaging obj = new View_MembersItemsPaging();
		DataTable dt = GetView_MembersPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_MembersItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_MembersItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.MemberID = Convert.ToInt32(dt.Rows[i]["MemberID"]);
			record.MemberName = dt.Rows[i]["MemberName"].ToString();
			record.OrgName = dt.Rows[i]["OrgName"].ToString();
			record.Password = dt.Rows[i]["Password"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["Gender"] != DBNull.Value)
			record.Gender = Convert.ToInt32(dt.Rows[i]["Gender"]);
			if (dt.Rows[i]["UpdateDate"] != DBNull.Value)
			record.UpdateDate = Convert.ToDateTime(dt.Rows[i]["UpdateDate"]);
			record.RegistDate = Convert.ToDateTime(dt.Rows[i]["RegistDate"]);
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.IsVerifyByEmail = Convert.ToBoolean(dt.Rows[i]["IsVerifyByEmail"]);
			record.VerifyEmailCode = dt.Rows[i]["VerifyEmailCode"].ToString();
			record.MemberStatusID = Convert.ToInt32(dt.Rows[i]["MemberStatusID"]);
			if (dt.Rows[i]["LastLoginDate"] != DBNull.Value)
			record.LastLoginDate = Convert.ToDateTime(dt.Rows[i]["LastLoginDate"]);
			record.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
			record.MemberTypeID = dt.Rows[i]["MemberTypeID"].ToString();
			record.MemberTypeName = dt.Rows[i]["MemberTypeName"].ToString();
			record.ShortDesc = dt.Rows[i]["ShortDesc"].ToString();
			record.MemberStatusName = dt.Rows[i]["MemberStatusName"].ToString();
			recordList.Add(record);
		}
		obj.view_MembersItems = (View_MembersItems[])(recordList.ToArray(typeof(View_MembersItems)));
		return obj;
		}
		protected View_MembersRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_MembersRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_MembersRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int memberIDColumnIndex = reader.GetOrdinal("MemberID");
			int memberNameColumnIndex = reader.GetOrdinal("MemberName");
			int orgNameColumnIndex = reader.GetOrdinal("OrgName");
			int passwordColumnIndex = reader.GetOrdinal("Password");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int updateDateColumnIndex = reader.GetOrdinal("UpdateDate");
			int registDateColumnIndex = reader.GetOrdinal("RegistDate");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int isVerifyByEmailColumnIndex = reader.GetOrdinal("IsVerifyByEmail");
			int verifyEmailCodeColumnIndex = reader.GetOrdinal("VerifyEmailCode");
			int memberStatusIDColumnIndex = reader.GetOrdinal("MemberStatusID");
			int lastloginDateColumnIndex = reader.GetOrdinal("LastLoginDate");
			int phoneNumberColumnIndex = reader.GetOrdinal("PhoneNumber");
			int memberTypeIDColumnIndex = reader.GetOrdinal("MemberTypeID");
			int memberTypeNameColumnIndex = reader.GetOrdinal("MemberTypeName");
			int shortDescColumnIndex = reader.GetOrdinal("ShortDesc");
			int memberStatusNameColumnIndex = reader.GetOrdinal("MemberStatusName");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_MembersRow record = new View_MembersRow();
					recordList.Add(record);
					record.MemberID =  Convert.ToInt32(reader.GetValue(memberIDColumnIndex));
					record.MemberName =  Convert.ToString(reader.GetValue(memberNameColumnIndex));
					if (!reader.IsDBNull(orgNameColumnIndex)) record.OrgName =  Convert.ToString(reader.GetValue(orgNameColumnIndex));

					record.Password =  Convert.ToString(reader.GetValue(passwordColumnIndex));
					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(genderColumnIndex)) record.Gender =  Convert.ToInt32(reader.GetValue(genderColumnIndex));

					if (!reader.IsDBNull(updateDateColumnIndex)) record.UpdateDate =  Convert.ToDateTime(reader.GetValue(updateDateColumnIndex));

					record.RegistDate =  Convert.ToDateTime(reader.GetValue(registDateColumnIndex));
					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));
					record.IsVerifyByEmail =  Convert.ToBoolean(reader.GetValue(isVerifyByEmailColumnIndex));
					if (!reader.IsDBNull(verifyEmailCodeColumnIndex)) record.VerifyEmailCode =  Convert.ToString(reader.GetValue(verifyEmailCodeColumnIndex));

					record.MemberStatusID =  Convert.ToInt32(reader.GetValue(memberStatusIDColumnIndex));
					if (!reader.IsDBNull(lastloginDateColumnIndex)) record.LastLoginDate =  Convert.ToDateTime(reader.GetValue(lastloginDateColumnIndex));

					if (!reader.IsDBNull(phoneNumberColumnIndex)) record.PhoneNumber =  Convert.ToString(reader.GetValue(phoneNumberColumnIndex));

					record.MemberTypeID =  Convert.ToString(reader.GetValue(memberTypeIDColumnIndex));
					if (!reader.IsDBNull(memberTypeNameColumnIndex)) record.MemberTypeName =  Convert.ToString(reader.GetValue(memberTypeNameColumnIndex));

					if (!reader.IsDBNull(shortDescColumnIndex)) record.ShortDesc =  Convert.ToString(reader.GetValue(shortDescColumnIndex));

					if (!reader.IsDBNull(memberStatusNameColumnIndex)) record.MemberStatusName =  Convert.ToString(reader.GetValue(memberStatusNameColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_MembersRow[])(recordList.ToArray(typeof(View_MembersRow)));
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
				case "MemberID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "MemberName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "OrgName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Password":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UpdateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RegistDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsVerifyByEmail":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "VerifyEmailCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LastLoginDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "PhoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberTypeID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ShortDesc":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "MemberStatusName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

