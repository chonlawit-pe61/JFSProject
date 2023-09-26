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
	public partial class ProxyAddressCollection_Base : MarshalByRefObject
	{
		public const string ProxyIDColumnName = "ProxyID";
		public const string AddressIDColumnName = "AddressID";
		public const string AddressTypeIDColumnName = "AddressTypeID";
		public const string StayColumnName = "Stay";
		public const string StayUnitColumnName = "StayUnit";
		public const string IsPresentAddressColumnName = "IsPresentAddress";
		public const string IsPermanentAddressColumnName = "IsPermanentAddress";
		public const string ModifiedDateColumnName = "ModifiedDate";
		public const string TelephoneNoColumnName = "TelephoneNo";
		private int _processID;
		public SqlCommand cmd = null;
		public ProxyAddressCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProxyAddressRow[] GetAll()
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
			"[ProxyID],"+
			"[AddressID],"+
			"[AddressTypeID],"+
			"[Stay],"+
			"[StayUnit],"+
			"[IsPresentAddress],"+
			"[IsPermanentAddress],"+
			"[ModifiedDate],"+
			"[TelephoneNo]"+
			" FROM [dbo].[ProxyAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ProxyAddress]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ProxyAddress"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProxyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AddressTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("Stay",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("StayUnit",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("IsPresentAddress",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("IsPermanentAddress",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public ProxyAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProxyAddressRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProxyAddressRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProxyAddressRow"/> objects.</returns>
		public virtual ProxyAddressRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ProxyAddress]", top);
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
		public ProxyAddressRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProxyAddressRow[] rows = null;
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
		public DataTable GetProxyAddressPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProxyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProxyID) AS TotalRow FROM [dbo].[ProxyAddress] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProxyID,AddressID,AddressTypeID,Stay,StayUnit,IsPresentAddress,IsPermanentAddress,ModifiedDate,TelephoneNo," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ProxyAddress] " + whereSql +
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
		public ProxyAddressItemsPaging GetProxyAddressPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProxyID")
		{
		ProxyAddressItemsPaging obj = new ProxyAddressItemsPaging();
		DataTable dt = GetProxyAddressPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProxyAddressItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProxyAddressItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProxyID = Convert.ToInt32(dt.Rows[i]["ProxyID"]);
			record.AddressID = Convert.ToInt32(dt.Rows[i]["AddressID"]);
			if (dt.Rows[i]["AddressTypeID"] != DBNull.Value)
			record.AddressTypeID = Convert.ToInt32(dt.Rows[i]["AddressTypeID"]);
			if (dt.Rows[i]["Stay"] != DBNull.Value)
			record.Stay = Convert.ToInt32(dt.Rows[i]["Stay"]);
			record.StayUnit = dt.Rows[i]["StayUnit"].ToString();
			if (dt.Rows[i]["IsPresentAddress"] != DBNull.Value)
			record.IsPresentAddress = Convert.ToBoolean(dt.Rows[i]["IsPresentAddress"]);
			if (dt.Rows[i]["IsPermanentAddress"] != DBNull.Value)
			record.IsPermanentAddress = Convert.ToBoolean(dt.Rows[i]["IsPermanentAddress"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			recordList.Add(record);
		}
		obj.proxyAddressItems = (ProxyAddressItems[])(recordList.ToArray(typeof(ProxyAddressItems)));
		return obj;
		}
		public ProxyAddressRow GetByPrimaryKey(int proxyID, int addressID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProxyID", proxyID);
			AddParameter(cmd, "AddressID", addressID);
			ProxyAddressRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProxyAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProxyAddress] (" +
			"[ProxyID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[Stay], " + 
			"[StayUnit], " + 
			"[IsPresentAddress], " + 
			"[IsPermanentAddress], " + 
			"[ModifiedDate], " + 
			"[TelephoneNo]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("Stay") + ", " +
			CreateSqlParameterName("StayUnit") + ", " +
			CreateSqlParameterName("IsPresentAddress") + ", " +
			CreateSqlParameterName("IsPermanentAddress") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("TelephoneNo") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
			AddParameter(cmd, "Stay", value.IsStayNull ? DBNull.Value : (object)value.Stay);
			AddParameter(cmd, "StayUnit", value.StayUnit);
			AddParameter(cmd, "IsPresentAddress", value.IsIsPresentAddressNull ? DBNull.Value : (object)value.IsPresentAddress);
			AddParameter(cmd, "IsPermanentAddress", value.IsIsPermanentAddressNull ? DBNull.Value : (object)value.IsPermanentAddress);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProxyAddressRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProxyAddress] (" +
			"[ProxyID], " + 
			"[AddressID], " + 
			"[AddressTypeID], " + 
			"[Stay], " + 
			"[StayUnit], " + 
			"[IsPresentAddress], " + 
			"[IsPermanentAddress], " + 
			"[ModifiedDate], " + 
			"[TelephoneNo]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProxyID") + ", " +
			CreateSqlParameterName("AddressID") + ", " +
			CreateSqlParameterName("AddressTypeID") + ", " +
			CreateSqlParameterName("Stay") + ", " +
			CreateSqlParameterName("StayUnit") + ", " +
			CreateSqlParameterName("IsPresentAddress") + ", " +
			CreateSqlParameterName("IsPermanentAddress") + ", " +
			CreateSqlParameterName("ModifiedDate") + ", " +
			CreateSqlParameterName("TelephoneNo") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProxyID", value.ProxyID);
			AddParameter(cmd, "AddressID", value.AddressID);
			AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
			AddParameter(cmd, "Stay", value.IsStayNull ? DBNull.Value : (object)value.Stay);
			AddParameter(cmd, "StayUnit", Sanitizer.GetSafeHtmlFragment(value.StayUnit));
			AddParameter(cmd, "IsPresentAddress", value.IsIsPresentAddressNull ? DBNull.Value : (object)value.IsPresentAddress);
			AddParameter(cmd, "IsPermanentAddress", value.IsIsPermanentAddressNull ? DBNull.Value : (object)value.IsPermanentAddress);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProxyAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
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
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProxyAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
					AddParameter(cmd, "Stay", value.IsStayNull ? DBNull.Value : (object)value.Stay);
					AddParameter(cmd, "StayUnit", value.StayUnit);
					AddParameter(cmd, "IsPresentAddress", value.IsIsPresentAddressNull ? DBNull.Value : (object)value.IsPresentAddress);
					AddParameter(cmd, "IsPermanentAddress", value.IsIsPermanentAddressNull ? DBNull.Value : (object)value.IsPermanentAddress);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProxyAddressRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProxyID == true && value._IsSetAddressID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAddressTypeID)
				{
					strUpdate += "[AddressTypeID]=" + CreateSqlParameterName("AddressTypeID") + ",";
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
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProxyAddress] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProxyID]=" + CreateSqlParameterName("ProxyID")+ " AND [AddressID]=" + CreateSqlParameterName("AddressID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProxyID", value.ProxyID);
					AddParameter(cmd, "AddressID", value.AddressID);
					AddParameter(cmd, "AddressTypeID", value.IsAddressTypeIDNull ? DBNull.Value : (object)value.AddressTypeID);
					AddParameter(cmd, "Stay", value.IsStayNull ? DBNull.Value : (object)value.Stay);
					AddParameter(cmd, "StayUnit", Sanitizer.GetSafeHtmlFragment(value.StayUnit));
					AddParameter(cmd, "IsPresentAddress", value.IsIsPresentAddressNull ? DBNull.Value : (object)value.IsPresentAddress);
					AddParameter(cmd, "IsPermanentAddress", value.IsIsPermanentAddressNull ? DBNull.Value : (object)value.IsPermanentAddress);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProxyID,AddressID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int proxyID, int addressID)
		{
			string whereSql = "[ProxyID]=" + CreateSqlParameterName("ProxyID") + " AND [AddressID]=" + CreateSqlParameterName("AddressID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProxyID", proxyID);
			AddParameter(cmd, "AddressID", addressID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected ProxyAddressRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProxyAddressRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProxyAddressRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int proxyIDColumnIndex = reader.GetOrdinal("ProxyID");
			int addressIDColumnIndex = reader.GetOrdinal("AddressID");
			int addressTypeIDColumnIndex = reader.GetOrdinal("AddressTypeID");
			int stayColumnIndex = reader.GetOrdinal("Stay");
			int stayUnitColumnIndex = reader.GetOrdinal("StayUnit");
			int isPresentAddressColumnIndex = reader.GetOrdinal("IsPresentAddress");
			int isPermanentAddressColumnIndex = reader.GetOrdinal("IsPermanentAddress");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ProxyAddressRow record = new ProxyAddressRow();
					recordList.Add(record);
					record.ProxyID =  Convert.ToInt32(reader.GetValue(proxyIDColumnIndex));
					record.AddressID =  Convert.ToInt32(reader.GetValue(addressIDColumnIndex));
					if (!reader.IsDBNull(addressTypeIDColumnIndex)) record.AddressTypeID =  Convert.ToInt32(reader.GetValue(addressTypeIDColumnIndex));

					if (!reader.IsDBNull(stayColumnIndex)) record.Stay =  Convert.ToInt32(reader.GetValue(stayColumnIndex));

					if (!reader.IsDBNull(stayUnitColumnIndex)) record.StayUnit =  Convert.ToString(reader.GetValue(stayUnitColumnIndex));

					if (!reader.IsDBNull(isPresentAddressColumnIndex)) record.IsPresentAddress =  Convert.ToBoolean(reader.GetValue(isPresentAddressColumnIndex));

					if (!reader.IsDBNull(isPermanentAddressColumnIndex)) record.IsPermanentAddress =  Convert.ToBoolean(reader.GetValue(isPermanentAddressColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProxyAddressRow[])(recordList.ToArray(typeof(ProxyAddressRow)));
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
				case "ProxyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AddressTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "TelephoneNo":
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

