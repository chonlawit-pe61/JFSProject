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
	public partial class PersonCollection_Base : MarshalByRefObject
	{
		public const string PersonIDColumnName = "PersonID";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string AgeColumnName = "Age";
		public const string GenderCodeColumnName = "GenderCode";
		public const string CardIDColumnName = "CardID";
		public const string PositionColumnName = "Position";
		public const string RelateColumnName = "Relate";
		public const string ReligionIDColumnName = "ReligionID";
		public const string NationalityIDColumnName = "NationalityID";
		public const string RaceIDColumnName = "RaceID";
		public const string IssuedAtColumnName = "IssuedAt";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public PersonCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual PersonRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual PersonPaging GetPagingRelyOnPersonIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			PersonPaging personPaging = new PersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(PersonID) as TotalRow from [dbo].[Person]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			personPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			personPaging.totalPage = (int)Math.Ceiling((double) personPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			personPaging.personRow = MapRecords(command);
			return personPaging;
		}
		public virtual PersonPaging GetPagingRelyOnPersonIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			PersonPaging personPaging = new PersonPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(PersonID) as TotalRow from [dbo].[Person]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			personPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			personPaging.totalPage = (int)Math.Ceiling((double)personPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			personPaging.personRow = MapRecords(command);
			return personPaging;
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And PersonID < " + minPersonID.ToString();
			}
			else
			{
				whereSql = "PersonID < " + minPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And PersonID > " + minPersonID.ToString();
			}
			else
			{
				whereSql = "PersonID > " + minPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And PersonID < " + maxPersonID.ToString();
			}
			else
			{
				whereSql = "PersonID < " + maxPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxPersonID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And PersonID > " + maxPersonID.ToString();
			}
			else
			{
				whereSql = "PersonID > " + maxPersonID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, "PersonID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "PersonID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			PersonRow[] personRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				personRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnPersonIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				personRow = MapRecords(command);
			}
			return personRow;
		}
		public virtual PersonRow[] GetPagingRelyOnPersonIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "PersonID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			PersonRow[] personRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnPersonID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				personRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnPersonIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				personRow = MapRecords(command);
			}
			return personRow;
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
			"[PersonID],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[DateOfBirth],"+
			"[Age],"+
			"[GenderCode],"+
			"[CardID],"+
			"[Position],"+
			"[Relate],"+
			"[ReligionID],"+
			"[NationalityID],"+
			"[RaceID],"+
			"[IssuedAt],"+
			"[ModifiedDate]"+
			" FROM [dbo].[Person]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnPersonID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Person]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnPersonIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "PersonID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Person] where PersonID < (select min(minPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " PersonID as minPersonID from [dbo].[Person]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Person]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnPersonIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "PersonID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[Person] where PersonID > (select max(maxPersonID) from(select top " + (rowPerPage * pageNumber).ToString() + " PersonID as maxPersonID from [dbo].[Person]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[Person]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Person]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Person"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PersonID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("Age",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("GenderCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("Position",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Relate",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReligionID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("NationalityID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("RaceID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IssuedAt",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual PersonRow[] GetByGenderCode(string genderCode)
		{
			return MapRecords(CreateGetByGenderCodeCommand(genderCode));
		}
		public virtual DataTable GetByGenderCodeAsDataTable(string genderCode)
		{
			return MapRecordsToDataTable(CreateGetByGenderCodeCommand(genderCode));
		}
		protected virtual IDbCommand CreateGetByGenderCodeCommand(string genderCode)
		{
			string whereSql = "";
			whereSql += "[GenderCode]=" + CreateSqlParameterName("GenderCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GenderCode", genderCode);
			return cmd;
		}
		public virtual PersonRow[] GetByReligionID(int religionID)
		{
			return MapRecords(CreateGetByReligionIDCommand(religionID));
		}
		public virtual DataTable GetByReligionIDAsDataTable(int religionID)
		{
			return MapRecordsToDataTable(CreateGetByReligionIDCommand(religionID));
		}
		protected virtual IDbCommand CreateGetByReligionIDCommand(int religionID)
		{
			string whereSql = "";
			whereSql += "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ReligionID", religionID);
			return cmd;
		}
		public virtual PersonRow[] GetByNationalityID(int nationalityID)
		{
			return MapRecords(CreateGetByNationalityIDCommand(nationalityID));
		}
		public virtual DataTable GetByNationalityIDAsDataTable(int nationalityID)
		{
			return MapRecordsToDataTable(CreateGetByNationalityIDCommand(nationalityID));
		}
		protected virtual IDbCommand CreateGetByNationalityIDCommand(int nationalityID)
		{
			string whereSql = "";
			whereSql += "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NationalityID", nationalityID);
			return cmd;
		}
		public virtual PersonRow[] GetByRaceID(int raceID)
		{
			return MapRecords(CreateGetByRaceIDCommand(raceID));
		}
		public virtual DataTable GetByRaceIDAsDataTable(int raceID)
		{
			return MapRecordsToDataTable(CreateGetByRaceIDCommand(raceID));
		}
		protected virtual IDbCommand CreateGetByRaceIDCommand(int raceID)
		{
			string whereSql = "";
			whereSql += "[RaceID]=" + CreateSqlParameterName("RaceID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RaceID", raceID);
			return cmd;
		}
		public PersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual PersonRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="PersonRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PersonRow"/> objects.</returns>
		public virtual PersonRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Person]", top);
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
		public PersonRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			PersonRow[] rows = null;
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
		public DataTable GetPersonPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "PersonID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "PersonID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(PersonID) AS TotalRow FROM [dbo].[Person] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,PersonID,Title,FirstName,LastName,DateOfBirth,Age,GenderCode,CardID,Position,Relate,ReligionID,NationalityID,RaceID,IssuedAt,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Person] " + whereSql +
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
		public PersonItemsPaging GetPersonPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "PersonID")
		{
		PersonItemsPaging obj = new PersonItemsPaging();
		DataTable dt = GetPersonPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		PersonItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new PersonItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.PersonID = Convert.ToInt32(dt.Rows[i]["PersonID"]);
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			if (dt.Rows[i]["Age"] != DBNull.Value)
			record.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
			record.GenderCode = dt.Rows[i]["GenderCode"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Position = dt.Rows[i]["Position"].ToString();
			record.Relate = dt.Rows[i]["Relate"].ToString();
			if (dt.Rows[i]["ReligionID"] != DBNull.Value)
			record.ReligionID = Convert.ToInt32(dt.Rows[i]["ReligionID"]);
			if (dt.Rows[i]["NationalityID"] != DBNull.Value)
			record.NationalityID = Convert.ToInt32(dt.Rows[i]["NationalityID"]);
			if (dt.Rows[i]["RaceID"] != DBNull.Value)
			record.RaceID = Convert.ToInt32(dt.Rows[i]["RaceID"]);
			record.IssuedAt = dt.Rows[i]["IssuedAt"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.personItems = (PersonItems[])(recordList.ToArray(typeof(PersonItems)));
		return obj;
		}
		public PersonRow GetByPrimaryKey(int personID)
		{
			string whereSql = "[PersonID]=" + CreateSqlParameterName("PersonID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PersonID", personID);
			PersonRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(PersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Person] (" +
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[DateOfBirth], " + 
			"[Age], " + 
			"[GenderCode], " + 
			"[CardID], " + 
			"[Position], " + 
			"[Relate], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[RaceID], " + 
			"[IssuedAt], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("GenderCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("Relate") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("IssuedAt") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName", value.FirstName);
			AddParameter(cmd, "LastName", value.LastName);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "GenderCode", value.GenderCode);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Position", value.Position);
			AddParameter(cmd, "Relate", value.Relate);
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "IssuedAt", value.IssuedAt);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(PersonRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Person] (" +
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[DateOfBirth], " + 
			"[Age], " + 
			"[GenderCode], " + 
			"[CardID], " + 
			"[Position], " + 
			"[Relate], " + 
			"[ReligionID], " + 
			"[NationalityID], " + 
			"[RaceID], " + 
			"[IssuedAt], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("Age") + ", " +
			CreateSqlParameterName("GenderCode") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Position") + ", " +
			CreateSqlParameterName("Relate") + ", " +
			CreateSqlParameterName("ReligionID") + ", " +
			CreateSqlParameterName("NationalityID") + ", " +
			CreateSqlParameterName("RaceID") + ", " +
			CreateSqlParameterName("IssuedAt") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
			AddParameter(cmd, "GenderCode", Sanitizer.GetSafeHtmlFragment(value.GenderCode));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
			AddParameter(cmd, "Relate", Sanitizer.GetSafeHtmlFragment(value.Relate));
			AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
			AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
			AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
			AddParameter(cmd, "IssuedAt", Sanitizer.GetSafeHtmlFragment(value.IssuedAt));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(PersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetGenderCode)
				{
					strUpdate += "[GenderCode]=" + CreateSqlParameterName("GenderCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetRelate)
				{
					strUpdate += "[Relate]=" + CreateSqlParameterName("Relate") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetIssuedAt)
				{
					strUpdate += "[IssuedAt]=" + CreateSqlParameterName("IssuedAt") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Person] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[PersonID]=" + CreateSqlParameterName("PersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "PersonID", value.PersonID);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName", value.FirstName);
					AddParameter(cmd, "LastName", value.LastName);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
					AddParameter(cmd, "GenderCode", value.GenderCode);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Position", value.Position);
					AddParameter(cmd, "Relate", value.Relate);
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "IssuedAt", value.IssuedAt);
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
				Exception ex = new Exception("Set incorrect primarykey PK(PersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(PersonRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetPersonID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetAge)
				{
					strUpdate += "[Age]=" + CreateSqlParameterName("Age") + ",";
				}
				if (value._IsSetGenderCode)
				{
					strUpdate += "[GenderCode]=" + CreateSqlParameterName("GenderCode") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetPosition)
				{
					strUpdate += "[Position]=" + CreateSqlParameterName("Position") + ",";
				}
				if (value._IsSetRelate)
				{
					strUpdate += "[Relate]=" + CreateSqlParameterName("Relate") + ",";
				}
				if (value._IsSetReligionID)
				{
					strUpdate += "[ReligionID]=" + CreateSqlParameterName("ReligionID") + ",";
				}
				if (value._IsSetNationalityID)
				{
					strUpdate += "[NationalityID]=" + CreateSqlParameterName("NationalityID") + ",";
				}
				if (value._IsSetRaceID)
				{
					strUpdate += "[RaceID]=" + CreateSqlParameterName("RaceID") + ",";
				}
				if (value._IsSetIssuedAt)
				{
					strUpdate += "[IssuedAt]=" + CreateSqlParameterName("IssuedAt") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Person] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[PersonID]=" + CreateSqlParameterName("PersonID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "PersonID", value.PersonID);
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "Age", value.IsAgeNull ? DBNull.Value : (object)value.Age);
					AddParameter(cmd, "GenderCode", Sanitizer.GetSafeHtmlFragment(value.GenderCode));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Position", Sanitizer.GetSafeHtmlFragment(value.Position));
					AddParameter(cmd, "Relate", Sanitizer.GetSafeHtmlFragment(value.Relate));
					AddParameter(cmd, "ReligionID", value.IsReligionIDNull ? DBNull.Value : (object)value.ReligionID);
					AddParameter(cmd, "NationalityID", value.IsNationalityIDNull ? DBNull.Value : (object)value.NationalityID);
					AddParameter(cmd, "RaceID", value.IsRaceIDNull ? DBNull.Value : (object)value.RaceID);
					AddParameter(cmd, "IssuedAt", Sanitizer.GetSafeHtmlFragment(value.IssuedAt));
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
				Exception ex = new Exception("Set incorrect primarykey PK(PersonID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int personID)
		{
			string whereSql = "[PersonID]=" + CreateSqlParameterName("PersonID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PersonID", personID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByGenderCode(string genderCode)
		{
			return DeleteByGenderCode(genderCode, false);
		}
		public int DeleteByGenderCode(string genderCode, bool genderCodeNull)
		{
			return CreateDeleteByGenderCodeCommand(genderCode, genderCodeNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByGenderCodeCommand(string genderCode, bool genderCodeNull)
		{
			string whereSql = "";
			if (genderCodeNull)
				whereSql += "[GenderCode] IS NULL";
			else
				whereSql += "[GenderCode]=" + CreateSqlParameterName("GenderCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!genderCodeNull)
				AddParameter(cmd, "GenderCode", genderCode);
			return cmd;
		}
		public int DeleteByReligionID(int religionID)
		{
			return DeleteByReligionID(religionID, false);
		}
		public int DeleteByReligionID(int religionID, bool religionIDNull)
		{
			return CreateDeleteByReligionIDCommand(religionID, religionIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByReligionIDCommand(int religionID, bool religionIDNull)
		{
			string whereSql = "";
			if (religionIDNull)
				whereSql += "[ReligionID] IS NULL";
			else
				whereSql += "[ReligionID]=" + CreateSqlParameterName("ReligionID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!religionIDNull)
				AddParameter(cmd, "ReligionID", religionID);
			return cmd;
		}
		public int DeleteByNationalityID(int nationalityID)
		{
			return DeleteByNationalityID(nationalityID, false);
		}
		public int DeleteByNationalityID(int nationalityID, bool nationalityIDNull)
		{
			return CreateDeleteByNationalityIDCommand(nationalityID, nationalityIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByNationalityIDCommand(int nationalityID, bool nationalityIDNull)
		{
			string whereSql = "";
			if (nationalityIDNull)
				whereSql += "[NationalityID] IS NULL";
			else
				whereSql += "[NationalityID]=" + CreateSqlParameterName("NationalityID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!nationalityIDNull)
				AddParameter(cmd, "NationalityID", nationalityID);
			return cmd;
		}
		public int DeleteByRaceID(int raceID)
		{
			return DeleteByRaceID(raceID, false);
		}
		public int DeleteByRaceID(int raceID, bool raceIDNull)
		{
			return CreateDeleteByRaceIDCommand(raceID, raceIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByRaceIDCommand(int raceID, bool raceIDNull)
		{
			string whereSql = "";
			if (raceIDNull)
				whereSql += "[RaceID] IS NULL";
			else
				whereSql += "[RaceID]=" + CreateSqlParameterName("RaceID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!raceIDNull)
				AddParameter(cmd, "RaceID", raceID);
			return cmd;
		}
		protected PersonRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected PersonRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected PersonRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int personIDColumnIndex = reader.GetOrdinal("PersonID");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int ageColumnIndex = reader.GetOrdinal("Age");
			int genderCodeColumnIndex = reader.GetOrdinal("GenderCode");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int positionColumnIndex = reader.GetOrdinal("Position");
			int relateColumnIndex = reader.GetOrdinal("Relate");
			int religionIDColumnIndex = reader.GetOrdinal("ReligionID");
			int nationalityIDColumnIndex = reader.GetOrdinal("NationalityID");
			int raceIDColumnIndex = reader.GetOrdinal("RaceID");
			int issuedAtColumnIndex = reader.GetOrdinal("IssuedAt");
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
					PersonRow record = new PersonRow();
					recordList.Add(record);
					record.PersonID =  Convert.ToInt32(reader.GetValue(personIDColumnIndex));
					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					if (!reader.IsDBNull(firstNameColumnIndex)) record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));

					if (!reader.IsDBNull(lastNameColumnIndex)) record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					if (!reader.IsDBNull(ageColumnIndex)) record.Age =  Convert.ToInt32(reader.GetValue(ageColumnIndex));

					if (!reader.IsDBNull(genderCodeColumnIndex)) record.GenderCode =  Convert.ToString(reader.GetValue(genderCodeColumnIndex));

					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					if (!reader.IsDBNull(positionColumnIndex)) record.Position =  Convert.ToString(reader.GetValue(positionColumnIndex));

					if (!reader.IsDBNull(relateColumnIndex)) record.Relate =  Convert.ToString(reader.GetValue(relateColumnIndex));

					if (!reader.IsDBNull(religionIDColumnIndex)) record.ReligionID =  Convert.ToInt32(reader.GetValue(religionIDColumnIndex));

					if (!reader.IsDBNull(nationalityIDColumnIndex)) record.NationalityID =  Convert.ToInt32(reader.GetValue(nationalityIDColumnIndex));

					if (!reader.IsDBNull(raceIDColumnIndex)) record.RaceID =  Convert.ToInt32(reader.GetValue(raceIDColumnIndex));

					if (!reader.IsDBNull(issuedAtColumnIndex)) record.IssuedAt =  Convert.ToString(reader.GetValue(issuedAtColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PersonRow[])(recordList.ToArray(typeof(PersonRow)));
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
				case "PersonID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "Age":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "GenderCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Position":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Relate":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ReligionID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NationalityID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RaceID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssuedAt":
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

