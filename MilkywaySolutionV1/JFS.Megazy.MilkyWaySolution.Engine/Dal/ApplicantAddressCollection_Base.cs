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
	public partial class ApplicantAddressCollection_Base : MarshalByRefObject
	{
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string AddressIDColumnName = "AddressID";
		public const string AddressTypeIDColumnName = "AddressTypeID";
		public const string LatitudeColumnName = "Latitude";
		public const string LongitudeColumnName = "Longitude";
		public const string StayColumnName = "Stay";
		public const string StayUnitColumnName = "StayUnit";
		public const string IsPresentAddressColumnName = "IsPresentAddress";
		public const string IsPermanentAddressColumnName = "IsPermanentAddress";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public ApplicantAddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ApplicantAddressRow[] GetAll()
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
			"[AddressID],"+
			"[AddressTypeID],"+
			"[Latitude],"+
			"[Longitude],"+
			"[Stay],"+
			"[StayUnit],"+
			"[IsPresentAddress],"+
			"[IsPermanentAddress],"+
			"[TelephoneNo],"+
			"[ModifiedDate]"+
			" FROM [dbo].[ApplicantAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ApplicantAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ApplicantAddress"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressTypeID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Latitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Longitude",Type.GetType("System.Double"));
			dataColumn = dataTable.Columns.Add("Stay",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("StayUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsPresentAddress",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsPermanentAddress",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual ApplicantAddressRow[] GetByApplicantID(int applicantID)
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
		public ApplicantAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ApplicantAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ApplicantAddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ApplicantAddressRow"/> objects.</returns>
		public virtual ApplicantAddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ApplicantAddress]", top);
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
		public ApplicantAddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ApplicantAddressRow[] rows = null;
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
		public DataTable GetApplicantAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
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
		string sql = "SELECT COUNT(ApplicantID) AS TotalRow FROM [dbo].[ApplicantAddress] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApplicantID,AddressID,AddressTypeID,Latitude,Longitude,Stay,StayUnit,IsPresentAddress,IsPermanentAddress,TelephoneNo,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ApplicantAddress] " + whereSql +
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
		public ApplicantAddressItemsPaging GetApplicantAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApplicantID")
		{
		ApplicantAddressItemsPaging obj = new ApplicantAddressItemsPaging();
		DataTable dt = GetApplicantAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ApplicantAddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ApplicantAddressItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
			if (dt.Rows[i]["Latitude"] != DBNull.Value)
			record.Latitude = Convert.ToDouble(dt.Rows[i]["Latitude"]);
			if (dt.Rows[i]["Longitude"] != DBNull.Value)
			record.Longitude = Convert.ToDouble(dt.Rows[i]["Longitude"]);
			record.Stay = Convert.ToInt32(dt.Rows[i]["Stay"]);
			record.StayUnit = dt.Rows[i]["StayUnit"].ToString();
			record.IsPresentAddress = Convert.ToBoolean(dt.Rows[i]["IsPresentAddress"]);
			record.IsPermanentAddress = Convert.ToBoolean(dt.Rows[i]["IsPermanentAddress"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.applicantaddressItems = (ApplicantAddressItems[])(recordList.ToArray(typeof(ApplicantAddressItems)));
		return obj;
		}
		public ApplicantAddressRow GetByPrimaryKey(int applicantID, int addressID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "AddressID", addressID);
			ApplicantAddressRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ApplicantAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantAddress] (" +
			"[ApplicantID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Stay], " + 
			"[StayUnit], " + 
			"[IsPresentAddress], " + 
			"[IsPermanentAddress], " + 
			"[TelephoneNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateSqlParameterName("Stay") + ", " +
			CreateSqlParameterName("StayUnit") + ", " +
			CreateSqlParameterName("IsPresentAddress") + ", " +
			CreateSqlParameterName("IsPermanentAddress") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.AddressTypeID);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Stay", value.Stay);
			AddParameter(cmd, "StayUnit",value.StayUnit);
			AddParameter(cmd, "IsPresentAddress", value.IsPresentAddress);
			AddParameter(cmd, "IsPermanentAddress", value.IsPermanentAddress);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ApplicantAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ApplicantAddress] (" +
			"[ApplicantID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[Latitude], " + 
			"[Longitude], " + 
			"[Stay], " + 
			"[StayUnit], " + 
			"[IsPresentAddress], " + 
			"[IsPermanentAddress], " + 
			"[TelephoneNo], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("Latitude") + ", " +
			CreateSqlParameterName("Longitude") + ", " +
			CreateSqlParameterName("Stay") + ", " +
			CreateSqlParameterName("StayUnit") + ", " +
			CreateSqlParameterName("IsPresentAddress") + ", " +
			CreateSqlParameterName("IsPermanentAddress") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.AddressTypeID);
			AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
			AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
			AddParameter(cmd, "Stay", value.Stay);
			AddParameter(cmd, "StayUnit", Sanitizer.GetSafeHtmlFragment(value.StayUnit));
			AddParameter(cmd, "IsPresentAddress", value.IsPresentAddress);
			AddParameter(cmd, "IsPermanentAddress", value.IsPermanentAddress);
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ApplicantAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
				}
				if (value._IsSetStay)
				{
					strUpdate += "[Stay]=" + CreateSqlParameterName("Stay") + ",";
				}
				if (value._IsSetStayUnit)
				{
					strUpdate += "[StayUnit]=" + CreateSqlParameterName("StayUnit") + ",";
				}
				if (value._IsSetIsPresentAddress)
				{
					strUpdate += "[IsPresentAddress]=" + CreateSqlParameterName("IsPresentAddress") + ",";
				}
				if (value._IsSetIsPermanentAddress)
				{
					strUpdate += "[IsPermanentAddress]=" + CreateSqlParameterName("IsPermanentAddress") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.AddressTypeID);
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
					AddParameter(cmd, "Stay", value.Stay);
					AddParameter(cmd, "StayUnit",value.StayUnit);
					AddParameter(cmd, "IsPresentAddress", value.IsPresentAddress);
					AddParameter(cmd, "IsPermanentAddress", value.IsPermanentAddress);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ApplicantAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApplicantID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
				}
				if (value._IsSetLatitude)
				{
					strUpdate += "[Latitude]=" + CreateSqlParameterName("Latitude") + ",";
				}
				if (value._IsSetLongitude)
				{
					strUpdate += "[Longitude]=" + CreateSqlParameterName("Longitude") + ",";
				}
				if (value._IsSetStay)
				{
					strUpdate += "[Stay]=" + CreateSqlParameterName("Stay") + ",";
				}
				if (value._IsSetStayUnit)
				{
					strUpdate += "[StayUnit]=" + CreateSqlParameterName("StayUnit") + ",";
				}
				if (value._IsSetIsPresentAddress)
				{
					strUpdate += "[IsPresentAddress]=" + CreateSqlParameterName("IsPresentAddress") + ",";
				}
				if (value._IsSetIsPermanentAddress)
				{
					strUpdate += "[IsPermanentAddress]=" + CreateSqlParameterName("IsPermanentAddress") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ApplicantAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.AddressTypeID);
					AddParameter(cmd, "Latitude", value.IsLatitudeNull ? DBNull.Value : (object)value.Latitude);
					AddParameter(cmd, "Longitude", value.IsLongitudeNull ? DBNull.Value : (object)value.Longitude);
					AddParameter(cmd, "Stay", value.Stay);
					AddParameter(cmd, "StayUnit", Sanitizer.GetSafeHtmlFragment(value.StayUnit));
					AddParameter(cmd, "IsPresentAddress", value.IsPresentAddress);
					AddParameter(cmd, "IsPermanentAddress", value.IsPermanentAddress);
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
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
				Exception ex = new Exception("Set incorrect primarykey PK(ApplicantID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int applicantID, int addressID)
		{
			string whereSql = "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "AddressID", addressID);
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
		protected ApplicantAddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ApplicantAddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ApplicantAddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int addressTypeIDColumnIndex = reader.GetOrdinal("AddressTypeID");
			int latitudeColumnIndex = reader.GetOrdinal("Latitude");
			int longitudeColumnIndex = reader.GetOrdinal("Longitude");
			int stayColumnIndex = reader.GetOrdinal("Stay");
			int stayUnitColumnIndex = reader.GetOrdinal("StayUnit");
			int isPresentAddressColumnIndex = reader.GetOrdinal("IsPresentAddress");
			int isPermanentAddressColumnIndex = reader.GetOrdinal("IsPermanentAddress");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
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
					ApplicantAddressRow record = new ApplicantAddressRow();
					recordList.Add(record);
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));
					record.AddressTypeID =  Convert.ToInt32(reader.GetValue(addressTypeIDColumnIndex));
					if (!reader.IsDBNull(latitudeColumnIndex)) record.Latitude =  Convert.ToDouble(reader.GetValue(latitudeColumnIndex));

					if (!reader.IsDBNull(longitudeColumnIndex)) record.Longitude =  Convert.ToDouble(reader.GetValue(longitudeColumnIndex));

					record.Stay =  Convert.ToInt32(reader.GetValue(stayColumnIndex));
					record.StayUnit =  Convert.ToString(reader.GetValue(stayUnitColumnIndex));
					record.IsPresentAddress =  Convert.ToBoolean(reader.GetValue(isPresentAddressColumnIndex));
					record.IsPermanentAddress =  Convert.ToBoolean(reader.GetValue(isPermanentAddressColumnIndex));
					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ApplicantAddressRow[])(recordList.ToArray(typeof(ApplicantAddressRow)));
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
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Latitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Longitude":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "Stay":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "StayUnit":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsPresentAddress":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsPermanentAddress":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "TelephoneNo":
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

