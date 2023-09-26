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
	public partial class View_UsersLoginCollection_Base : MarshalByRefObject
	{
		public const string UserIDColumnName = "UserID";
		public const string UserNameColumnName = "UserName";
		public const string AliasNameColumnName = "AliasName";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string GenderColumnName = "Gender";
		public const string PhoneNumberColumnName = "PhoneNumber";
		public const string EmailColumnName = "Email";
		public const string IsRenewAccountColumnName = "IsRenewAccount";
		public const string UserStatusIDColumnName = "UserStatusID";
		public const string UserTypeIDColumnName = "UserTypeID";
		public const string RenewTicketIDColumnName = "RenewTicketID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string IsAdministratorColumnName = "IsAdministrator";
		public const string ProvinceIDColumnName = "ProvinceID";
		public const string DepartmentNameColumnName = "DepartmentName";
		public const string DepartmentNameAbbrColumnName = "DepartmentNameAbbr";
		public const string RoleIDColumnName = "RoleID";
		public const string RoleNameColumnName = "RoleName";
		public const string DescriptionColumnName = "Description";
		public const string IPColumnName = "IP";
		public const string DeviceTypeColumnName = "DeviceType";
		public const string LoginDateColumnName = "LoginDate";
		private int _processID;
		public SqlCommand cmd = null;
		public View_UsersLoginCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual View_UsersLoginRow[] GetAll()
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
			"[UserID],"+
			"[UserName],"+
			"[AliasName],"+
			"[FirstName],"+
			"[LastName],"+
			"[Gender],"+
			"[PhoneNumber],"+
			"[Email],"+
			"[IsRenewAccount],"+
			"[UserStatusID],"+
			"[UserTypeID],"+
			"[RenewTicketID],"+
			"[DepartmentID],"+
			"[IsAdministrator],"+
			"[ProvinceID],"+
			"[DepartmentName],"+
			"[DepartmentNameAbbr],"+
			"[RoleID],"+
			"[RoleName],"+
			"[Description],"+
			"[IP],"+
			"[DeviceType],"+
			"[LoginDate]"+
			" FROM [dbo].[View_UsersLogin]";
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
				TableName = "View_UsersLogin"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AliasName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PhoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("IsRenewAccount",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserTypeID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RenewTicketID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IsAdministrator",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ProvinceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("DepartmentName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DepartmentNameAbbr",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RoleID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RoleName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Description",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IP",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DeviceType",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LoginDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public View_UsersLoginRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual View_UsersLoginRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="View_UsersLoginRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="View_UsersLoginRow"/> objects.</returns>
		public virtual View_UsersLoginRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[View_UsersLogin]", top);
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
		public View_UsersLoginRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			View_UsersLoginRow[] rows = null;
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
		public DataTable GetView_UsersLoginPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "UserID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[View_UsersLogin] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,UserID,UserName,AliasName,FirstName,LastName,Gender,PhoneNumber,Email,IsRenewAccount,UserStatusID,UserTypeID,RenewTicketID,DepartmentID,IsAdministrator,ProvinceID,DepartmentName,DepartmentNameAbbr,RoleID,RoleName,Description,IP,DeviceType,LoginDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [View_UsersLogin].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[View_UsersLogin] " + whereSql +
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
		public View_UsersLoginItemsPaging GetView_UsersLoginPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
		View_UsersLoginItemsPaging obj = new View_UsersLoginItemsPaging();
		DataTable dt = GetView_UsersLoginPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		View_UsersLoginItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new View_UsersLoginItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.UserName = dt.Rows[i]["UserName"].ToString();
			record.AliasName = dt.Rows[i]["AliasName"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.Gender = Convert.ToInt32(dt.Rows[i]["Gender"]);
			record.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
			record.Email = dt.Rows[i]["Email"].ToString();
			record.IsRenewAccount = Convert.ToBoolean(dt.Rows[i]["IsRenewAccount"]);
			record.UserStatusID = Convert.ToInt32(dt.Rows[i]["UserStatusID"]);
			record.UserTypeID = dt.Rows[i]["UserTypeID"].ToString();
			record.RenewTicketID = Convert.ToInt32(dt.Rows[i]["RenewTicketID"]);
			if (dt.Rows[i]["DepartmentID"] != DBNull.Value)
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			if (dt.Rows[i]["IsAdministrator"] != DBNull.Value)
			record.IsAdministrator = Convert.ToBoolean(dt.Rows[i]["IsAdministrator"]);
			if (dt.Rows[i]["ProvinceID"] != DBNull.Value)
			record.ProvinceID = Convert.ToInt32(dt.Rows[i]["ProvinceID"]);
			record.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
			record.DepartmentNameAbbr = dt.Rows[i]["DepartmentNameAbbr"].ToString();
			if (dt.Rows[i]["RoleID"] != DBNull.Value)
			record.RoleID = Convert.ToInt32(dt.Rows[i]["RoleID"]);
			record.RoleName = dt.Rows[i]["RoleName"].ToString();
			record.Description = dt.Rows[i]["Description"].ToString();
			record.IP = dt.Rows[i]["IP"].ToString();
			record.DeviceType = dt.Rows[i]["DeviceType"].ToString();
			if (dt.Rows[i]["LoginDate"] != DBNull.Value)
			record.LoginDate = Convert.ToDateTime(dt.Rows[i]["LoginDate"]);
			recordList.Add(record);
		}
		obj.view_UsersLoginItems = (View_UsersLoginItems[])(recordList.ToArray(typeof(View_UsersLoginItems)));
		return obj;
		}
		protected View_UsersLoginRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected View_UsersLoginRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected View_UsersLoginRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int userNameColumnIndex = reader.GetOrdinal("UserName");
			int aliasNameColumnIndex = reader.GetOrdinal("AliasName");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int phoneNumberColumnIndex = reader.GetOrdinal("PhoneNumber");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int isRenewAccountColumnIndex = reader.GetOrdinal("IsRenewAccount");
			int userStatusIDColumnIndex = reader.GetOrdinal("UserStatusID");
			int userTypeIDColumnIndex = reader.GetOrdinal("UserTypeID");
			int renewTicketIDColumnIndex = reader.GetOrdinal("RenewTicketID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int isAdministratorColumnIndex = reader.GetOrdinal("IsAdministrator");
			int provinceIDColumnIndex = reader.GetOrdinal("ProvinceID");
			int departmentNameColumnIndex = reader.GetOrdinal("DepartmentName");
			int departmentNameAbbrColumnIndex = reader.GetOrdinal("DepartmentNameAbbr");
			int roleIDColumnIndex = reader.GetOrdinal("RoleID");
			int roleNameColumnIndex = reader.GetOrdinal("RoleName");
			int descriptionColumnIndex = reader.GetOrdinal("Description");
			int iPColumnIndex = reader.GetOrdinal("IP");
			int deviceTypeColumnIndex = reader.GetOrdinal("DeviceType");
			int loginDateColumnIndex = reader.GetOrdinal("LoginDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					View_UsersLoginRow record = new View_UsersLoginRow();
					recordList.Add(record);
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.UserName =  Convert.ToString(reader.GetValue(userNameColumnIndex));
					record.AliasName =  Convert.ToString(reader.GetValue(aliasNameColumnIndex));
					record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));
					record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));
					record.Gender =  Convert.ToInt32(reader.GetValue(genderColumnIndex));
					if (!reader.IsDBNull(phoneNumberColumnIndex)) record.PhoneNumber =  Convert.ToString(reader.GetValue(phoneNumberColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					record.IsRenewAccount =  Convert.ToBoolean(reader.GetValue(isRenewAccountColumnIndex));
					record.UserStatusID =  Convert.ToInt32(reader.GetValue(userStatusIDColumnIndex));
					record.UserTypeID =  Convert.ToString(reader.GetValue(userTypeIDColumnIndex));
					record.RenewTicketID =  Convert.ToInt32(reader.GetValue(renewTicketIDColumnIndex));
					if (!reader.IsDBNull(departmentIdColumnIndex)) record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));

					if (!reader.IsDBNull(isAdministratorColumnIndex)) record.IsAdministrator =  Convert.ToBoolean(reader.GetValue(isAdministratorColumnIndex));

					if (!reader.IsDBNull(provinceIDColumnIndex)) record.ProvinceID =  Convert.ToInt32(reader.GetValue(provinceIDColumnIndex));

					if (!reader.IsDBNull(departmentNameColumnIndex)) record.DepartmentName =  Convert.ToString(reader.GetValue(departmentNameColumnIndex));

					if (!reader.IsDBNull(departmentNameAbbrColumnIndex)) record.DepartmentNameAbbr =  Convert.ToString(reader.GetValue(departmentNameAbbrColumnIndex));

					if (!reader.IsDBNull(roleIDColumnIndex)) record.RoleID =  Convert.ToInt32(reader.GetValue(roleIDColumnIndex));

					if (!reader.IsDBNull(roleNameColumnIndex)) record.RoleName =  Convert.ToString(reader.GetValue(roleNameColumnIndex));

					if (!reader.IsDBNull(descriptionColumnIndex)) record.Description =  Convert.ToString(reader.GetValue(descriptionColumnIndex));

					if (!reader.IsDBNull(iPColumnIndex)) record.IP =  Convert.ToString(reader.GetValue(iPColumnIndex));

					if (!reader.IsDBNull(deviceTypeColumnIndex)) record.DeviceType =  Convert.ToString(reader.GetValue(deviceTypeColumnIndex));

					if (!reader.IsDBNull(loginDateColumnIndex)) record.LoginDate =  Convert.ToDateTime(reader.GetValue(loginDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (View_UsersLoginRow[])(recordList.ToArray(typeof(View_UsersLoginRow)));
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
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AliasName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				case "PhoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsRenewAccount":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "UserStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserTypeID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RenewTicketID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsAdministrator":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "ProvinceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DepartmentNameAbbr":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RoleName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Description":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IP":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DeviceType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LoginDate":
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
