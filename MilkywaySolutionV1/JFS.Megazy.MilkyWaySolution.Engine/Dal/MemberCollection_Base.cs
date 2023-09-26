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
	public partial class MemberCollection_Base : MarshalByRefObject
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
		public const string IsVerifyPhoneColumnName = "IsVerifyPhone";
		public const string SecretKeyColumnName = "SecretKey";
		public const string SessionIDColumnName = "SessionID";
		public const string KeyColumnName = "Key";
		public const string MemberStatusIDColumnName = "MemberStatusID";
		public const string TokenDeviceIDColumnName = "TokenDeviceID";
		public const string DeviceTypeColumnName = "DeviceType";
		public const string LastLoginDateColumnName = "LastLoginDate";
		public const string SocialIDColumnName = "SocialID";
		public const string SocialNameColumnName = "SocialName";
		public const string PhoneNumberColumnName = "PhoneNumber";
		public const string MemberTypeIDColumnName = "MemberTypeID";
		public const string MemberTokenColumnName = "MemberToken";
		public const string MemberTokenExpireColumnName = "MemberTokenExpire";
		public const string ShortDescColumnName = "ShortDesc";
		private int _processID;
		public SqlCommand cmd = null;
		public MemberCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual MemberRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual MemberPaging GetPagingRelyOnMemberIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			MemberPaging memberPaging = new MemberPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MemberID) as TotalRow from [dbo].[Member]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			memberPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			memberPaging.totalPage = (int)Math.Ceiling((double) memberPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			memberPaging.memberRow = MapRecords(command);
			return memberPaging;
		}
		public virtual MemberPaging GetPagingRelyOnMemberIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			MemberPaging memberPaging = new MemberPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(MemberID) as TotalRow from [dbo].[Member]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			memberPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			memberPaging.totalPage = (int)Math.Ceiling((double)memberPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			memberPaging.memberRow = MapRecords(command);
			return memberPaging;
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMemberID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MemberID < " + minMemberID.ToString();
			}
			else
			{
				whereSql = "MemberID < " + minMemberID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minMemberID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MemberID > " + minMemberID.ToString();
			}
			else
			{
				whereSql = "MemberID > " + minMemberID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMemberID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MemberID < " + maxMemberID.ToString();
			}
			else
			{
				whereSql = "MemberID < " + maxMemberID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxMemberID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And MemberID > " + maxMemberID.ToString();
			}
			else
			{
				whereSql = "MemberID > " + maxMemberID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, "MemberID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MemberID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			MemberRow[] memberRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				memberRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMemberIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				memberRow = MapRecords(command);
			}
			return memberRow;
		}
		public virtual MemberRow[] GetPagingRelyOnMemberIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "MemberID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			MemberRow[] memberRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnMemberID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				memberRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnMemberIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				memberRow = MapRecords(command);
			}
			return memberRow;
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
			"[IsVerifyPhone],"+
			"[SecretKey],"+
			"[SessionID],"+
			"[Key],"+
			"[MemberStatusID],"+
			"[TokenDeviceID],"+
			"[DeviceType],"+
			"[LastLoginDate],"+
			"[SocialID],"+
			"[SocialName],"+
			"[PhoneNumber],"+
			"[MemberTypeID],"+
			"[MemberToken],"+
			"[MemberTokenExpire],"+
			"[ShortDesc]"+
			" FROM [dbo].[Member]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMemberID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Member]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMemberIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MemberID Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Member] where MemberID < (select min(minMemberID) from(select top " + (rowPerPage * pageNumber).ToString() + " MemberID as minMemberID from [dbo].[Member]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Member]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnMemberIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "MemberID Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Member] where MemberID > (select max(maxMemberID) from(select top " + (rowPerPage * pageNumber).ToString() + " MemberID as maxMemberID from [dbo].[Member]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Member]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Member]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Member"
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
			dataColumn = dataTable.Columns.Add("IsVerifyPhone",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("SecretKey",Type.GetType("System.String"));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("SessionID",Type.GetType("System.String"));
			dataColumn.MaxLength = 88;
			dataColumn = dataTable.Columns.Add("Key",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("MemberStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TokenDeviceID",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("DeviceType",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LastLoginDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("SocialID",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("SocialName",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("PhoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("MemberTypeID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MemberToken",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("MemberTokenExpire",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ShortDesc",Type.GetType("System.String"));
			dataColumn.MaxLength = 300;
			return dataTable;
		}
		public virtual MemberRow[] GetByMemberStatusID(int memberStatusID)
		{
			return MapRecords(CreateGetByMemberStatusIDCommand(memberStatusID));
		}
		public virtual DataTable GetByMemberStatusIDAsDataTable(int memberStatusID)
		{
			return MapRecordsToDataTable(CreateGetByMemberStatusIDCommand(memberStatusID));
		}
		protected virtual IDbCommand CreateGetByMemberStatusIDCommand(int memberStatusID)
		{
			string whereSql = "";
			whereSql += "[MemberStatusID]=" + CreateSqlParameterName("MemberStatusID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MemberStatusID", memberStatusID);
			return cmd;
		}
		public MemberRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual MemberRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="MemberRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MemberRow"/> objects.</returns>
		public virtual MemberRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Member]", top);
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
		public MemberRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			MemberRow[] rows = null;
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
		public DataTable GetMemberPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MemberID")
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
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[Member] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,MemberID,MemberName,OrgName,Password,FirstName,LastName,Gender,UpdateDate,RegistDate,DateOfBirth,Email,IsVerifyByEmail,VerifyEmailCode,IsVerifyPhone,SecretKey,SessionID,Key,MemberStatusID,TokenDeviceID,DeviceType,LastLoginDate,SocialID,SocialName,PhoneNumber,MemberTypeID,MemberToken,MemberTokenExpire,ShortDesc," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [Member].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Member] " + whereSql +
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
		public MemberItemsPaging GetMemberPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "MemberID")
		{
		MemberItemsPaging obj = new MemberItemsPaging();
		DataTable dt = GetMemberPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		MemberItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new MemberItems();
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
			if (dt.Rows[i]["IsVerifyPhone"] != DBNull.Value)
			record.IsVerifyPhone = Convert.ToBoolean(dt.Rows[i]["IsVerifyPhone"]);
			record.SecretKey = dt.Rows[i]["SecretKey"].ToString();
			record.SessionID = dt.Rows[i]["SessionID"].ToString();
			record.Key = dt.Rows[i]["Key"].ToString();
			record.MemberStatusID = Convert.ToInt32(dt.Rows[i]["MemberStatusID"]);
			record.TokenDeviceID = dt.Rows[i]["TokenDeviceID"].ToString();
			record.DeviceType = dt.Rows[i]["DeviceType"].ToString();
			if (dt.Rows[i]["LastLoginDate"] != DBNull.Value)
			record.LastLoginDate = Convert.ToDateTime(dt.Rows[i]["LastLoginDate"]);
			record.SocialID = dt.Rows[i]["SocialID"].ToString();
			record.SocialName = dt.Rows[i]["SocialName"].ToString();
			record.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
			record.MemberTypeID = dt.Rows[i]["MemberTypeID"].ToString();
			record.MemberToken = dt.Rows[i]["MemberToken"].ToString();
			if (dt.Rows[i]["MemberTokenExpire"] != DBNull.Value)
			record.MemberTokenExpire = Convert.ToDateTime(dt.Rows[i]["MemberTokenExpire"]);
			record.ShortDesc = dt.Rows[i]["ShortDesc"].ToString();
			recordList.Add(record);
		}
		obj.memberItems = (MemberItems[])(recordList.ToArray(typeof(MemberItems)));
		return obj;
		}
		public MemberRow GetByPrimaryKey(int memberID)
		{
			string whereSql = "[MemberID]=" + CreateSqlParameterName("MemberID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MemberID", memberID);
			MemberRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(MemberRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Member] (" +
			"[MemberName], " + 
			"[OrgName], " + 
			"[Password], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Gender], " + 
			"[UpdateDate], " + 
			"[RegistDate], " + 
			"[DateOfBirth], " + 
			"[Email], " + 
			"[IsVerifyByEmail], " + 
			"[VerifyEmailCode], " + 
			"[IsVerifyPhone], " + 
			"[SecretKey], " + 
			"[SessionID], " + 
			"[Key], " + 
			"[MemberStatusID], " + 
			"[TokenDeviceID], " + 
			"[DeviceType], " + 
			"[LastLoginDate], " + 
			"[SocialID], " + 
			"[SocialName], " + 
			"[PhoneNumber], " + 
			"[MemberTypeID], " + 
			"[MemberToken], " + 
			"[MemberTokenExpire], " + 
			"[ShortDesc]			" + 
			") VALUES (" +
			CreateSqlParameterName("MemberName") + ", " +
			CreateSqlParameterName("OrgName") + ", " +
			CreateSqlParameterName("Password") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("UpdateDate") + ", " +
			CreateSqlParameterName("RegistDate") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("IsVerifyByEmail") + ", " +
			CreateSqlParameterName("VerifyEmailCode") + ", " +
			CreateSqlParameterName("IsVerifyPhone") + ", " +
			CreateSqlParameterName("SecretKey") + ", " +
			CreateSqlParameterName("SessionID") + ", " +
			CreateSqlParameterName("Key") + ", " +
			CreateSqlParameterName("MemberStatusID") + ", " +
			CreateSqlParameterName("TokenDeviceID") + ", " +
			CreateSqlParameterName("DeviceType") + ", " +
			CreateSqlParameterName("LastLoginDate") + ", " +
			CreateSqlParameterName("SocialID") + ", " +
			CreateSqlParameterName("SocialName") + ", " +
			CreateSqlParameterName("PhoneNumber") + ", " +
			CreateSqlParameterName("MemberTypeID") + ", " +
			CreateSqlParameterName("MemberToken") + ", " +
			CreateSqlParameterName("MemberTokenExpire") + ", " +
			CreateSqlParameterName("ShortDesc") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MemberName",value.MemberName);
			AddParameter(cmd, "OrgName", value.OrgName);
			AddParameter(cmd, "Password",value.Password);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
			AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "Email",value.Email);
			AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
			AddParameter(cmd, "VerifyEmailCode", value.VerifyEmailCode);
			AddParameter(cmd, "IsVerifyPhone", value.IsIsVerifyPhoneNull ? DBNull.Value : (object)value.IsVerifyPhone);
			AddParameter(cmd, "SecretKey", value.SecretKey);
			AddParameter(cmd, "SessionID", value.SessionID);
			AddParameter(cmd, "Key", value.Key);
			AddParameter(cmd, "MemberStatusID", value.MemberStatusID);
			AddParameter(cmd, "TokenDeviceID", value.TokenDeviceID);
			AddParameter(cmd, "DeviceType", value.DeviceType);
			AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
			AddParameter(cmd, "SocialID", value.SocialID);
			AddParameter(cmd, "SocialName", value.SocialName);
			AddParameter(cmd, "PhoneNumber", value.PhoneNumber);
			AddParameter(cmd, "MemberTypeID",value.MemberTypeID);
			AddParameter(cmd, "MemberToken", value.MemberToken);
			AddParameter(cmd, "MemberTokenExpire", value.IsMemberTokenExpireNull ? DBNull.Value : (object)value.MemberTokenExpire);
			AddParameter(cmd, "ShortDesc", value.ShortDesc);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(MemberRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Member] (" +
			"[MemberName], " + 
			"[OrgName], " + 
			"[Password], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[Gender], " + 
			"[UpdateDate], " + 
			"[RegistDate], " + 
			"[DateOfBirth], " + 
			"[Email], " + 
			"[IsVerifyByEmail], " + 
			"[VerifyEmailCode], " + 
			"[IsVerifyPhone], " + 
			"[SecretKey], " + 
			"[SessionID], " + 
			"[Key], " + 
			"[MemberStatusID], " + 
			"[TokenDeviceID], " + 
			"[DeviceType], " + 
			"[LastLoginDate], " + 
			"[SocialID], " + 
			"[SocialName], " + 
			"[PhoneNumber], " + 
			"[MemberTypeID], " + 
			"[MemberToken], " + 
			"[MemberTokenExpire], " + 
			"[ShortDesc]			" + 
			") VALUES (" +
			CreateSqlParameterName("MemberName") + ", " +
			CreateSqlParameterName("OrgName") + ", " +
			CreateSqlParameterName("Password") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("UpdateDate") + ", " +
			CreateSqlParameterName("RegistDate") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("IsVerifyByEmail") + ", " +
			CreateSqlParameterName("VerifyEmailCode") + ", " +
			CreateSqlParameterName("IsVerifyPhone") + ", " +
			CreateSqlParameterName("SecretKey") + ", " +
			CreateSqlParameterName("SessionID") + ", " +
			CreateSqlParameterName("Key") + ", " +
			CreateSqlParameterName("MemberStatusID") + ", " +
			CreateSqlParameterName("TokenDeviceID") + ", " +
			CreateSqlParameterName("DeviceType") + ", " +
			CreateSqlParameterName("LastLoginDate") + ", " +
			CreateSqlParameterName("SocialID") + ", " +
			CreateSqlParameterName("SocialName") + ", " +
			CreateSqlParameterName("PhoneNumber") + ", " +
			CreateSqlParameterName("MemberTypeID") + ", " +
			CreateSqlParameterName("MemberToken") + ", " +
			CreateSqlParameterName("MemberTokenExpire") + ", " +
			CreateSqlParameterName("ShortDesc") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "MemberName", Sanitizer.GetSafeHtmlFragment(value.MemberName));
			AddParameter(cmd, "OrgName", Sanitizer.GetSafeHtmlFragment(value.OrgName));
			AddParameter(cmd, "Password", Sanitizer.GetSafeHtmlFragment(value.Password));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
			AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
			AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
			AddParameter(cmd, "VerifyEmailCode", Sanitizer.GetSafeHtmlFragment(value.VerifyEmailCode));
			AddParameter(cmd, "IsVerifyPhone", value.IsIsVerifyPhoneNull ? DBNull.Value : (object)value.IsVerifyPhone);
			AddParameter(cmd, "SecretKey", Sanitizer.GetSafeHtmlFragment(value.SecretKey));
			AddParameter(cmd, "SessionID", Sanitizer.GetSafeHtmlFragment(value.SessionID));
			AddParameter(cmd, "Key", Sanitizer.GetSafeHtmlFragment(value.Key));
			AddParameter(cmd, "MemberStatusID", value.MemberStatusID);
			AddParameter(cmd, "TokenDeviceID", Sanitizer.GetSafeHtmlFragment(value.TokenDeviceID));
			AddParameter(cmd, "DeviceType", Sanitizer.GetSafeHtmlFragment(value.DeviceType));
			AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
			AddParameter(cmd, "SocialID", Sanitizer.GetSafeHtmlFragment(value.SocialID));
			AddParameter(cmd, "SocialName", Sanitizer.GetSafeHtmlFragment(value.SocialName));
			AddParameter(cmd, "PhoneNumber", Sanitizer.GetSafeHtmlFragment(value.PhoneNumber));
			AddParameter(cmd, "MemberTypeID", Sanitizer.GetSafeHtmlFragment(value.MemberTypeID));
			AddParameter(cmd, "MemberToken", Sanitizer.GetSafeHtmlFragment(value.MemberToken));
			AddParameter(cmd, "MemberTokenExpire", value.IsMemberTokenExpireNull ? DBNull.Value : (object)value.MemberTokenExpire);
			AddParameter(cmd, "ShortDesc", Sanitizer.GetSafeHtmlFragment(value.ShortDesc));
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(MemberRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMemberID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMemberName)
				{
					strUpdate += "[MemberName]=" + CreateSqlParameterName("MemberName") + ",";
				}
				if (value._IsSetOrgName)
				{
					strUpdate += "[OrgName]=" + CreateSqlParameterName("OrgName") + ",";
				}
				if (value._IsSetPassword)
				{
					strUpdate += "[Password]=" + CreateSqlParameterName("Password") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetUpdateDate)
				{
					strUpdate += "[UpdateDate]=" + CreateSqlParameterName("UpdateDate") + ",";
				}
				if (value._IsSetRegistDate)
				{
					strUpdate += "[RegistDate]=" + CreateSqlParameterName("RegistDate") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetIsVerifyByEmail)
				{
					strUpdate += "[IsVerifyByEmail]=" + CreateSqlParameterName("IsVerifyByEmail") + ",";
				}
				if (value._IsSetVerifyEmailCode)
				{
					strUpdate += "[VerifyEmailCode]=" + CreateSqlParameterName("VerifyEmailCode") + ",";
				}
				if (value._IsSetIsVerifyPhone)
				{
					strUpdate += "[IsVerifyPhone]=" + CreateSqlParameterName("IsVerifyPhone") + ",";
				}
				if (value._IsSetSecretKey)
				{
					strUpdate += "[SecretKey]=" + CreateSqlParameterName("SecretKey") + ",";
				}
				if (value._IsSetSessionID)
				{
					strUpdate += "[SessionID]=" + CreateSqlParameterName("SessionID") + ",";
				}
				if (value._IsSetKey)
				{
					strUpdate += "[Key]=" + CreateSqlParameterName("Key") + ",";
				}
				if (value._IsSetMemberStatusID)
				{
					strUpdate += "[MemberStatusID]=" + CreateSqlParameterName("MemberStatusID") + ",";
				}
				if (value._IsSetTokenDeviceID)
				{
					strUpdate += "[TokenDeviceID]=" + CreateSqlParameterName("TokenDeviceID") + ",";
				}
				if (value._IsSetDeviceType)
				{
					strUpdate += "[DeviceType]=" + CreateSqlParameterName("DeviceType") + ",";
				}
				if (value._IsSetLastLoginDate)
				{
					strUpdate += "[LastLoginDate]=" + CreateSqlParameterName("LastLoginDate") + ",";
				}
				if (value._IsSetSocialID)
				{
					strUpdate += "[SocialID]=" + CreateSqlParameterName("SocialID") + ",";
				}
				if (value._IsSetSocialName)
				{
					strUpdate += "[SocialName]=" + CreateSqlParameterName("SocialName") + ",";
				}
				if (value._IsSetPhoneNumber)
				{
					strUpdate += "[PhoneNumber]=" + CreateSqlParameterName("PhoneNumber") + ",";
				}
				if (value._IsSetMemberTypeID)
				{
					strUpdate += "[MemberTypeID]=" + CreateSqlParameterName("MemberTypeID") + ",";
				}
				if (value._IsSetMemberToken)
				{
					strUpdate += "[MemberToken]=" + CreateSqlParameterName("MemberToken") + ",";
				}
				if (value._IsSetMemberTokenExpire)
				{
					strUpdate += "[MemberTokenExpire]=" + CreateSqlParameterName("MemberTokenExpire") + ",";
				}
				if (value._IsSetShortDesc)
				{
					strUpdate += "[ShortDesc]=" + CreateSqlParameterName("ShortDesc") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Member] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "MemberName",value.MemberName);
					AddParameter(cmd, "OrgName", value.OrgName);
					AddParameter(cmd, "Password",value.Password);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
					AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
					AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "Email",value.Email);
					AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
					AddParameter(cmd, "VerifyEmailCode", value.VerifyEmailCode);
					AddParameter(cmd, "IsVerifyPhone", value.IsIsVerifyPhoneNull ? DBNull.Value : (object)value.IsVerifyPhone);
					AddParameter(cmd, "SecretKey", value.SecretKey);
					AddParameter(cmd, "SessionID", value.SessionID);
					AddParameter(cmd, "Key", value.Key);
					AddParameter(cmd, "MemberStatusID", value.MemberStatusID);
					AddParameter(cmd, "TokenDeviceID", value.TokenDeviceID);
					AddParameter(cmd, "DeviceType", value.DeviceType);
					AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
					AddParameter(cmd, "SocialID", value.SocialID);
					AddParameter(cmd, "SocialName", value.SocialName);
					AddParameter(cmd, "PhoneNumber", value.PhoneNumber);
					AddParameter(cmd, "MemberTypeID",value.MemberTypeID);
					AddParameter(cmd, "MemberToken", value.MemberToken);
					AddParameter(cmd, "MemberTokenExpire", value.IsMemberTokenExpireNull ? DBNull.Value : (object)value.MemberTokenExpire);
					AddParameter(cmd, "ShortDesc", value.ShortDesc);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MemberID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(MemberRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetMemberID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetMemberName)
				{
					strUpdate += "[MemberName]=" + CreateSqlParameterName("MemberName") + ",";
				}
				if (value._IsSetOrgName)
				{
					strUpdate += "[OrgName]=" + CreateSqlParameterName("OrgName") + ",";
				}
				if (value._IsSetPassword)
				{
					strUpdate += "[Password]=" + CreateSqlParameterName("Password") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetUpdateDate)
				{
					strUpdate += "[UpdateDate]=" + CreateSqlParameterName("UpdateDate") + ",";
				}
				if (value._IsSetRegistDate)
				{
					strUpdate += "[RegistDate]=" + CreateSqlParameterName("RegistDate") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetIsVerifyByEmail)
				{
					strUpdate += "[IsVerifyByEmail]=" + CreateSqlParameterName("IsVerifyByEmail") + ",";
				}
				if (value._IsSetVerifyEmailCode)
				{
					strUpdate += "[VerifyEmailCode]=" + CreateSqlParameterName("VerifyEmailCode") + ",";
				}
				if (value._IsSetIsVerifyPhone)
				{
					strUpdate += "[IsVerifyPhone]=" + CreateSqlParameterName("IsVerifyPhone") + ",";
				}
				if (value._IsSetSecretKey)
				{
					strUpdate += "[SecretKey]=" + CreateSqlParameterName("SecretKey") + ",";
				}
				if (value._IsSetSessionID)
				{
					strUpdate += "[SessionID]=" + CreateSqlParameterName("SessionID") + ",";
				}
				if (value._IsSetKey)
				{
					strUpdate += "[Key]=" + CreateSqlParameterName("Key") + ",";
				}
				if (value._IsSetMemberStatusID)
				{
					strUpdate += "[MemberStatusID]=" + CreateSqlParameterName("MemberStatusID") + ",";
				}
				if (value._IsSetTokenDeviceID)
				{
					strUpdate += "[TokenDeviceID]=" + CreateSqlParameterName("TokenDeviceID") + ",";
				}
				if (value._IsSetDeviceType)
				{
					strUpdate += "[DeviceType]=" + CreateSqlParameterName("DeviceType") + ",";
				}
				if (value._IsSetLastLoginDate)
				{
					strUpdate += "[LastLoginDate]=" + CreateSqlParameterName("LastLoginDate") + ",";
				}
				if (value._IsSetSocialID)
				{
					strUpdate += "[SocialID]=" + CreateSqlParameterName("SocialID") + ",";
				}
				if (value._IsSetSocialName)
				{
					strUpdate += "[SocialName]=" + CreateSqlParameterName("SocialName") + ",";
				}
				if (value._IsSetPhoneNumber)
				{
					strUpdate += "[PhoneNumber]=" + CreateSqlParameterName("PhoneNumber") + ",";
				}
				if (value._IsSetMemberTypeID)
				{
					strUpdate += "[MemberTypeID]=" + CreateSqlParameterName("MemberTypeID") + ",";
				}
				if (value._IsSetMemberToken)
				{
					strUpdate += "[MemberToken]=" + CreateSqlParameterName("MemberToken") + ",";
				}
				if (value._IsSetMemberTokenExpire)
				{
					strUpdate += "[MemberTokenExpire]=" + CreateSqlParameterName("MemberTokenExpire") + ",";
				}
				if (value._IsSetShortDesc)
				{
					strUpdate += "[ShortDesc]=" + CreateSqlParameterName("ShortDesc") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Member] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[MemberID]=" + CreateSqlParameterName("MemberID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "MemberID", value.MemberID);
					AddParameter(cmd, "MemberName", Sanitizer.GetSafeHtmlFragment(value.MemberName));
					AddParameter(cmd, "OrgName", Sanitizer.GetSafeHtmlFragment(value.OrgName));
					AddParameter(cmd, "Password", Sanitizer.GetSafeHtmlFragment(value.Password));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "Gender", value.IsGenderNull ? DBNull.Value : (object)value.Gender);
					AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
					AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
					AddParameter(cmd, "VerifyEmailCode", Sanitizer.GetSafeHtmlFragment(value.VerifyEmailCode));
					AddParameter(cmd, "IsVerifyPhone", value.IsIsVerifyPhoneNull ? DBNull.Value : (object)value.IsVerifyPhone);
					AddParameter(cmd, "SecretKey", Sanitizer.GetSafeHtmlFragment(value.SecretKey));
					AddParameter(cmd, "SessionID", Sanitizer.GetSafeHtmlFragment(value.SessionID));
					AddParameter(cmd, "Key", Sanitizer.GetSafeHtmlFragment(value.Key));
					AddParameter(cmd, "MemberStatusID", value.MemberStatusID);
					AddParameter(cmd, "TokenDeviceID", Sanitizer.GetSafeHtmlFragment(value.TokenDeviceID));
					AddParameter(cmd, "DeviceType", Sanitizer.GetSafeHtmlFragment(value.DeviceType));
					AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
					AddParameter(cmd, "SocialID", Sanitizer.GetSafeHtmlFragment(value.SocialID));
					AddParameter(cmd, "SocialName", Sanitizer.GetSafeHtmlFragment(value.SocialName));
					AddParameter(cmd, "PhoneNumber", Sanitizer.GetSafeHtmlFragment(value.PhoneNumber));
					AddParameter(cmd, "MemberTypeID", Sanitizer.GetSafeHtmlFragment(value.MemberTypeID));
					AddParameter(cmd, "MemberToken", Sanitizer.GetSafeHtmlFragment(value.MemberToken));
					AddParameter(cmd, "MemberTokenExpire", value.IsMemberTokenExpireNull ? DBNull.Value : (object)value.MemberTokenExpire);
					AddParameter(cmd, "ShortDesc", Sanitizer.GetSafeHtmlFragment(value.ShortDesc));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(MemberID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int memberID)
		{
			string whereSql = "[MemberID]=" + CreateSqlParameterName("MemberID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MemberID", memberID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByMemberStatusID(int memberStatusID)
		{
			return CreateDeleteByMemberStatusIDCommand(memberStatusID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByMemberStatusIDCommand(int memberStatusID)
		{
			string whereSql = "";
			whereSql += "[MemberStatusID]=" + CreateSqlParameterName("MemberStatusID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MemberStatusID", memberStatusID);
			return cmd;
		}
		protected MemberRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected MemberRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected MemberRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
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
			int isVerifyPhoneColumnIndex = reader.GetOrdinal("IsVerifyPhone");
			int secretKeyColumnIndex = reader.GetOrdinal("SecretKey");
			int sessionIDColumnIndex = reader.GetOrdinal("SessionID");
			int keyColumnIndex = reader.GetOrdinal("Key");
			int memberStatusIDColumnIndex = reader.GetOrdinal("MemberStatusID");
			int tokenDeviceIDColumnIndex = reader.GetOrdinal("TokenDeviceID");
			int deviceTypeColumnIndex = reader.GetOrdinal("DeviceType");
			int lastloginDateColumnIndex = reader.GetOrdinal("LastLoginDate");
			int socialIDColumnIndex = reader.GetOrdinal("SocialID");
			int socialNameColumnIndex = reader.GetOrdinal("SocialName");
			int phoneNumberColumnIndex = reader.GetOrdinal("PhoneNumber");
			int memberTypeIDColumnIndex = reader.GetOrdinal("MemberTypeID");
			int memberTokenColumnIndex = reader.GetOrdinal("MemberToken");
			int memberTokenExpireColumnIndex = reader.GetOrdinal("MemberTokenExpire");
			int shortDescColumnIndex = reader.GetOrdinal("ShortDesc");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					MemberRow record = new MemberRow();
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

					if (!reader.IsDBNull(isVerifyPhoneColumnIndex)) record.IsVerifyPhone =  Convert.ToBoolean(reader.GetValue(isVerifyPhoneColumnIndex));

					if (!reader.IsDBNull(secretKeyColumnIndex)) record.SecretKey =  Convert.ToString(reader.GetValue(secretKeyColumnIndex));

					if (!reader.IsDBNull(sessionIDColumnIndex)) record.SessionID =  Convert.ToString(reader.GetValue(sessionIDColumnIndex));

					if (!reader.IsDBNull(keyColumnIndex)) record.Key =  Convert.ToString(reader.GetValue(keyColumnIndex));

					record.MemberStatusID =  Convert.ToInt32(reader.GetValue(memberStatusIDColumnIndex));
					if (!reader.IsDBNull(tokenDeviceIDColumnIndex)) record.TokenDeviceID =  Convert.ToString(reader.GetValue(tokenDeviceIDColumnIndex));

					if (!reader.IsDBNull(deviceTypeColumnIndex)) record.DeviceType =  Convert.ToString(reader.GetValue(deviceTypeColumnIndex));

					if (!reader.IsDBNull(lastloginDateColumnIndex)) record.LastLoginDate =  Convert.ToDateTime(reader.GetValue(lastloginDateColumnIndex));

					if (!reader.IsDBNull(socialIDColumnIndex)) record.SocialID =  Convert.ToString(reader.GetValue(socialIDColumnIndex));

					if (!reader.IsDBNull(socialNameColumnIndex)) record.SocialName =  Convert.ToString(reader.GetValue(socialNameColumnIndex));

					if (!reader.IsDBNull(phoneNumberColumnIndex)) record.PhoneNumber =  Convert.ToString(reader.GetValue(phoneNumberColumnIndex));

					record.MemberTypeID =  Convert.ToString(reader.GetValue(memberTypeIDColumnIndex));
					if (!reader.IsDBNull(memberTokenColumnIndex)) record.MemberToken =  Convert.ToString(reader.GetValue(memberTokenColumnIndex));

					if (!reader.IsDBNull(memberTokenExpireColumnIndex)) record.MemberTokenExpire =  Convert.ToDateTime(reader.GetValue(memberTokenExpireColumnIndex));

					if (!reader.IsDBNull(shortDescColumnIndex)) record.ShortDesc =  Convert.ToString(reader.GetValue(shortDescColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MemberRow[])(recordList.ToArray(typeof(MemberRow)));
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
				case "IsVerifyPhone":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SecretKey":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SessionID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "Key":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TokenDeviceID":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "DeviceType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastLoginDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "SocialID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "SocialName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "PhoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberTypeID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberToken":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "MemberTokenExpire":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "ShortDesc":
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

