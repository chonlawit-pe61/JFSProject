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
	public partial class ApplicantCrimeCollection_Base : MarshalByRefObject
	{
		public const string CrimeIDColumnName = "CrimeID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string PoliceStationColumnName = "PoliceStation";
		public const string ChargeColumnName = "Charge";
		public const string LegalConsequenceColumnName = "LegalConsequence";
		public const string CrimeDateColumnName = "CrimeDate";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantCrimeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantCrimeRow[] GetAll()
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
			"[CrimeID],"+
			"[ApplicantID],"+
			"[PoliceStation],"+
			"[Charge],"+
			"[LegalConsequence],"+
			"[CrimeDate],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantCrime]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantCrime]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantCrime"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CrimeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("PoliceStation",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("Charge",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("LegalConsequence",Type.GetType("System.String"));
			dataColumn.MaxLength = 350;
			dataColumn = dataTable.Columns.Add("CrimeDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual ApplicantCrimeRow[] GetByApplicantID(int applicantID)
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
		public ApplicantCrimeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantCrimeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantCrimeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantCrimeRow"/> objects.</returns>
		public virtual ApplicantCrimeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantCrime]", top);
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
		public ApplicantCrimeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantCrimeRow[] rows = null;
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
		public DataTable GetApplicantCrimePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CrimeID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CrimeID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CrimeID) AS TotalRow FROM [dbo].[ApplicantCrime] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CrimeID,ApplicantID,PoliceStation,Charge,LegalConsequence,CrimeDate,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantCrime] " + whereSql +
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
		public ApplicantCrimeItemsPaging GetApplicantCrimePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CrimeID")
		{
		ApplicantCrimeItemsPaging obj = new ApplicantCrimeItemsPaging();
		DataTable dt = GetApplicantCrimePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantCrimeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantCrimeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CrimeID = Convert.ToInt32(dt.Rows[i]["CrimeID"]);
			if (dt.Rows[i]["ApplicantID"] != DBNull.Value)
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.PoliceStation = dt.Rows[i]["PoliceStation"].ToString();
			record.Charge = dt.Rows[i]["Charge"].ToString();
			record.LegalConsequence = dt.Rows[i]["LegalConsequence"].ToString();
			if (dt.Rows[i]["CrimeDate"] != DBNull.Value)
			record.CrimeDate = Convert.ToDateTime(dt.Rows[i]["CrimeDate"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantCrimeItems = (ApplicantCrimeItems[])(recordList.ToArray(typeof(ApplicantCrimeItems)));
		return obj;
		}
		public ApplicantCrimeRow GetByPrimaryKey(int crimeID)
		{
			string whereSql = "[CrimeID]=" + CreateSqlParameterName("CrimeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CrimeID", crimeID);
			ApplicantCrimeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantCrimeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantCrime] (" +
			"[CrimeID], " + 
			"[ApplicantID], " + 
			"[PoliceStation], " + 
			"[Charge], " + 
			"[LegalConsequence], " + 
			"[CrimeDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CrimeID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("PoliceStation") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("LegalConsequence") + ", " +
			CreateSqlParameterName("CrimeDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CrimeID", value.CrimeID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "PoliceStation", value.PoliceStation);
			AddParameter(cmd, "Charge", value.Charge);
			AddParameter(cmd, "LegalConsequence", value.LegalConsequence);
			AddParameter(cmd, "CrimeDate", value.IsCrimeDateNull ? DBNull.Value : (object)value.CrimeDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantCrimeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantCrime] (" +
			"[CrimeID], " + 
			"[ApplicantID], " + 
			"[PoliceStation], " + 
			"[Charge], " + 
			"[LegalConsequence], " + 
			"[CrimeDate], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CrimeID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("PoliceStation") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("LegalConsequence") + ", " +
			CreateSqlParameterName("CrimeDate") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CrimeID", value.CrimeID);
			AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
			AddParameter(cmd, "PoliceStation", Sanitizer.GetSafeHtmlFragment(value.PoliceStation));
			AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
			AddParameter(cmd, "LegalConsequence", Sanitizer.GetSafeHtmlFragment(value.LegalConsequence));
			AddParameter(cmd, "CrimeDate", value.IsCrimeDateNull ? DBNull.Value : (object)value.CrimeDate);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantCrimeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCrimeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetPoliceStation)
				{
					strUpdate += "[PoliceStation]=" + CreateSqlParameterName("PoliceStation") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetLegalConsequence)
				{
					strUpdate += "[LegalConsequence]=" + CreateSqlParameterName("LegalConsequence") + ",";
				}
				if (value._IsSetCrimeDate)
				{
					strUpdate += "[CrimeDate]=" + CreateSqlParameterName("CrimeDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantCrime] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CrimeID]=" + CreateSqlParameterName("CrimeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CrimeID", value.CrimeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "PoliceStation", value.PoliceStation);
					AddParameter(cmd, "Charge", value.Charge);
					AddParameter(cmd, "LegalConsequence", value.LegalConsequence);
					AddParameter(cmd, "CrimeDate", value.IsCrimeDateNull ? DBNull.Value : (object)value.CrimeDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CrimeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantCrimeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCrimeID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetPoliceStation)
				{
					strUpdate += "[PoliceStation]=" + CreateSqlParameterName("PoliceStation") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetLegalConsequence)
				{
					strUpdate += "[LegalConsequence]=" + CreateSqlParameterName("LegalConsequence") + ",";
				}
				if (value._IsSetCrimeDate)
				{
					strUpdate += "[CrimeDate]=" + CreateSqlParameterName("CrimeDate") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantCrime] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CrimeID]=" + CreateSqlParameterName("CrimeID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CrimeID", value.CrimeID);
					AddParameter(cmd, "ApplicantID", value.IsApplicantIDNull ? DBNull.Value : (object)value.ApplicantID);
					AddParameter(cmd, "PoliceStation", Sanitizer.GetSafeHtmlFragment(value.PoliceStation));
					AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
					AddParameter(cmd, "LegalConsequence", Sanitizer.GetSafeHtmlFragment(value.LegalConsequence));
					AddParameter(cmd, "CrimeDate", value.IsCrimeDateNull ? DBNull.Value : (object)value.CrimeDate);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CrimeID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int crimeID)
		{
			string whereSql = "[CrimeID]=" + CreateSqlParameterName("CrimeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CrimeID", crimeID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByApplicantID(int applicantID)
		{
			return DeleteByApplicantID(applicantID, false);
		}
		public int DeleteByApplicantID(int applicantID, bool applicantIDNull)
		{
			return CreateDeleteByApplicantIDCommand(applicantID, applicantIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID, bool applicantIDNull)
		{
			string whereSql = "";
			if (applicantIDNull)
				whereSql += "[ApplicantID] IS NULL";
			else
				whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!applicantIDNull)
				AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		protected ApplicantCrimeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantCrimeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantCrimeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int crimeIDColumnIndex = reader.GetOrdinal("CrimeID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int policeStationColumnIndex = reader.GetOrdinal("PoliceStation");
			int chargeColumnIndex = reader.GetOrdinal("Charge");
			int legalConsequenceColumnIndex = reader.GetOrdinal("LegalConsequence");
			int crimeDateColumnIndex = reader.GetOrdinal("CrimeDate");
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
					ApplicantCrimeRow record = new ApplicantCrimeRow();
					recordList.Add(record);
					record.CrimeID =  Convert.ToInt32(reader.GetValue(crimeIDColumnIndex));
					if (!reader.IsDBNull(applicantIDColumnIndex)) record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));

					if (!reader.IsDBNull(policeStationColumnIndex)) record.PoliceStation =  Convert.ToString(reader.GetValue(policeStationColumnIndex));

					if (!reader.IsDBNull(chargeColumnIndex)) record.Charge =  Convert.ToString(reader.GetValue(chargeColumnIndex));

					if (!reader.IsDBNull(legalConsequenceColumnIndex)) record.LegalConsequence =  Convert.ToString(reader.GetValue(legalConsequenceColumnIndex));

					if (!reader.IsDBNull(crimeDateColumnIndex)) record.CrimeDate =  Convert.ToDateTime(reader.GetValue(crimeDateColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantCrimeRow[])(recordList.ToArray(typeof(ApplicantCrimeRow)));
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
				case "CrimeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PoliceStation":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Charge":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LegalConsequence":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CrimeDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
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

