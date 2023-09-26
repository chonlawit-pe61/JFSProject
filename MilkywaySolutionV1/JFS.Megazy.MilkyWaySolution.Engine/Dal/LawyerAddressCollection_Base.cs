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
	public partial class LawyerAddressCollection_Base : MarshalByRefObject
	{
		public const string LawyerIDColumnName = "LawyerID";
		public const string AddressIDColumnName = "AddressID";
		public const string AddressTypeIDColumnName = "AddressTypeID";
		public const string FaxNoColumnName = "FaxNo";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string IsPrimaryColumnName = "IsPrimary";
		public const string IsActiveColumnName = "IsActive";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public LawyerAddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual LawyerAddressRow[] GetAll()
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
			"[LawyerID],"+
			"[AddressID],"+
			"[AddressTypeID],"+
			"[FaxNo],"+
			"[TelephoneNo],"+
			"[IsPrimary],"+
			"[IsActive],"+
			"[ModifiedDate]"+
			" FROM [dbo].[LawyerAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[LawyerAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "LawyerAddress"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("LawyerID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("FaxNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IsPrimary",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual LawyerAddressRow[] GetByLawyerID(int lawyerID)
		{
			return MapRecords(CreateGetByLawyerIDCommand(lawyerID));
		}
		public virtual DataTable GetByLawyerIDAsDataTable(int lawyerID)
		{
			return MapRecordsToDataTable(CreateGetByLawyerIDCommand(lawyerID));
		}
		protected virtual IDbCommand CreateGetByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public virtual LawyerAddressRow[] GetByAddressID(int addressID)
		{
			return MapRecords(CreateGetByAddressIDCommand(addressID));
		}
		public virtual DataTable GetByAddressIDAsDataTable(int addressID)
		{
			return MapRecordsToDataTable(CreateGetByAddressIDCommand(addressID));
		}
		protected virtual IDbCommand CreateGetByAddressIDCommand(int addressID)
		{
			string whereSql = "";
			whereSql += "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AddressID", addressID);
			return cmd;
		}
		public virtual LawyerAddressRow[] GetByAddressTypeID(int addressTypeID)
		{
			return MapRecords(CreateGetByAddressTypeIDCommand(addressTypeID));
		}
		public virtual DataTable GetByAddressTypeIDAsDataTable(int addressTypeID)
		{
			return MapRecordsToDataTable(CreateGetByAddressTypeIDCommand(addressTypeID));
		}
		protected virtual IDbCommand CreateGetByAddressTypeIDCommand(int addressTypeID)
		{
			string whereSql = "";
			whereSql += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AddressTypeID", addressTypeID);
			return cmd;
		}
		public LawyerAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual LawyerAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="LawyerAddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LawyerAddressRow"/> objects.</returns>
		public virtual LawyerAddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[LawyerAddress]", top);
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
		public LawyerAddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			LawyerAddressRow[] rows = null;
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
		public DataTable GetLawyerAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "LawyerID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(LawyerID) AS TotalRow FROM [dbo].[LawyerAddress] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,LawyerID,AddressID,AddressTypeID,FaxNo,TelephoneNo,IsPrimary,IsActive,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[LawyerAddress] " + whereSql +
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
		public LawyerAddressItemsPaging GetLawyerAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LawyerID")
		{
		LawyerAddressItemsPaging obj = new LawyerAddressItemsPaging();
		DataTable dt = GetLawyerAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		LawyerAddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new LawyerAddressItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.LawyerID = Convert.ToInt32(dt.Rows[i]["LawyerID"]);
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["AddressTypeID"] != DBNull.Value)
			record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
			record.FaxNo = dt.Rows[i]["FaxNo"].ToString();
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			if (dt.Rows[i]["IsPrimary"] != DBNull.Value)
			record.IsPrimary = Convert.ToBoolean(dt.Rows[i]["IsPrimary"]);
			if (dt.Rows[i]["IsActive"] != DBNull.Value)
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.lawyerAddressItems = (LawyerAddressItems[])(recordList.ToArray(typeof(LawyerAddressItems)));
		return obj;
		}
		public LawyerAddressRow GetByPrimaryKey(int lawyerID, int addressID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LawyerID", lawyerID);
			AddParameter(cmd, "AddressID", addressID);
			LawyerAddressRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(LawyerAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerAddress] (" +
			"[LawyerID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[FaxNo], " + 
			"[TelephoneNo], " + 
			"[IsPrimary], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("FaxNo") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("IsPrimary") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
			AddParameter(cmd, "FaxNo", value.FaxNo);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "IsPrimary", value.IsIsPrimaryNull ? DBNull.Value : (object)value.IsPrimary);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(LawyerAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[LawyerAddress] (" +
			"[LawyerID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[FaxNo], " + 
			"[TelephoneNo], " + 
			"[IsPrimary], " + 
			"[IsActive], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("LawyerID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("FaxNo") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("IsPrimary") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "LawyerID", value.LawyerID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
			AddParameter(cmd, "FaxNo", Sanitizer.GetSafeHtmlFragment(value.FaxNo));
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "IsPrimary", value.IsIsPrimaryNull ? DBNull.Value : (object)value.IsPrimary);
			AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(LawyerAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
				}
				if (value._IsSetFaxNo)
				{
					strUpdate += "[FaxNo]=" + CreateSqlParameterName("FaxNo") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetIsPrimary)
				{
					strUpdate += "[IsPrimary]=" + CreateSqlParameterName("IsPrimary") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
					AddParameter(cmd, "FaxNo", value.FaxNo);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "IsPrimary", value.IsIsPrimaryNull ? DBNull.Value : (object)value.IsPrimary);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(LawyerAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLawyerID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
				}
				if (value._IsSetFaxNo)
				{
					strUpdate += "[FaxNo]=" + CreateSqlParameterName("FaxNo") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetIsPrimary)
				{
					strUpdate += "[IsPrimary]=" + CreateSqlParameterName("IsPrimary") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[LawyerAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LawyerID]=" + CreateSqlParameterName("LawyerID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LawyerID", value.LawyerID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
					AddParameter(cmd, "FaxNo", Sanitizer.GetSafeHtmlFragment(value.FaxNo));
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "IsPrimary", value.IsIsPrimaryNull ? DBNull.Value : (object)value.IsPrimary);
					AddParameter(cmd, "IsActive", value.IsIsActiveNull ? DBNull.Value : (object)value.IsActive);
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
				Exception ex = new Exception("Set incorrect primarykey PK(LawyerID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int lawyerID, int addressID)
		{
			string whereSql = "[LawyerID]=" + CreateSqlParameterName("LawyerID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			AddParameter(cmd, "AddressID", addressID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public LawyerAddressRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			LawyerAddressRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByLawyerID(int lawyerID)
		{
			return CreateDeleteByLawyerIDCommand(lawyerID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByLawyerIDCommand(int lawyerID)
		{
			string whereSql = "";
			whereSql += "[LawyerID]=" + CreateSqlParameterName("LawyerID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LawyerID", lawyerID);
			return cmd;
		}
		public int DeleteByAddressID(int addressID)
		{
			return CreateDeleteByAddressIDCommand(addressID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAddressIDCommand(int addressID)
		{
			string whereSql = "";
			whereSql += "[AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AddressID", addressID);
			return cmd;
		}
		public int DeleteByAddressTypeID(int addressTypeID)
		{
			return DeleteByAddressTypeID(addressTypeID, false);
		}
		public int DeleteByAddressTypeID(int addressTypeID, bool addressTypeIDNull)
		{
			return CreateDeleteByAddressTypeIDCommand(addressTypeID, addressTypeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByAddressTypeIDCommand(int addressTypeID, bool addressTypeIDNull)
		{
			string whereSql = "";
			if (addressTypeIDNull)
				whereSql += "[AddressTypeID] IS NULL";
			else
				whereSql += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!addressTypeIDNull)
				AddParameter(cmd, "AddressTypeID", addressTypeID);
			return cmd;
		}
		protected LawyerAddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected LawyerAddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected LawyerAddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int lawyerIDColumnIndex = reader.GetOrdinal("LawyerID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int addressTypeIDColumnIndex = reader.GetOrdinal("AddressTypeID");
			int faxNoColumnIndex = reader.GetOrdinal("FaxNo");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int isPrimaryColumnIndex = reader.GetOrdinal("IsPrimary");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
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
					LawyerAddressRow record = new LawyerAddressRow();
					recordList.Add(record);
					record.LawyerID =  Convert.ToInt32(reader.GetValue(lawyerIDColumnIndex));
					record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));
					if (!reader.IsDBNull(addressTypeIDColumnIndex)) record.AddressTypeID =  Convert.ToInt32(reader.GetValue(addressTypeIDColumnIndex));

					if (!reader.IsDBNull(faxNoColumnIndex)) record.FaxNo =  Convert.ToString(reader.GetValue(faxNoColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(isPrimaryColumnIndex)) record.IsPrimary =  Convert.ToBoolean(reader.GetValue(isPrimaryColumnIndex));

					if (!reader.IsDBNull(isActiveColumnIndex)) record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LawyerAddressRow[])(recordList.ToArray(typeof(LawyerAddressRow)));
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
				case "LawyerID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FaxNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsPrimary":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

