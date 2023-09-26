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
	public partial class InspectCollection_Base : MarshalByRefObject
	{
		public const string InspectIDColumnName = "InspectID";
		public const string InspectNameColumnName = "InspectName";
		public const string ServiceCodeColumnName = "ServiceCode";
		public const string IsThaiCitizenColumnName = "IsThaiCitizen";
		public const string SortOrderColumnName = "SortOrder";
		public const string IsActiveColumnName = "IsActive";
		public const string InspectValueTypeColumnName = "InspectValueType";
		private int _processID;
		public SqlCommand cmd = null;
		public InspectCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual InspectRow[] GetAll()
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
			"[InspectID],"+
			"[InspectName],"+
			"[ServiceCode],"+
			"[IsThaiCitizen],"+
			"[SortOrder],"+
			"[IsActive],"+
			"[InspectValueType]"+
			" FROM [dbo].[Inspect]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[Inspect]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "Inspect"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("InspectID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ServiceCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("IsThaiCitizen",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SortOrder",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsActive",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("InspectValueType",Type.GetType("System.Int32"));
			return dataTable;
		}
		public virtual InspectRow[] GetByInspectValueType(int inspectValueType)
		{
			return MapRecords(CreateGetByInspectValueTypeCommand(inspectValueType));
		}
		public virtual DataTable GetByInspectValueTypeAsDataTable(int inspectValueType)
		{
			return MapRecordsToDataTable(CreateGetByInspectValueTypeCommand(inspectValueType));
		}
		protected virtual IDbCommand CreateGetByInspectValueTypeCommand(int inspectValueType)
		{
			string whereSql = "";
			whereSql += "[InspectValueType]=" + CreateSqlParameterName("InspectValueType");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectValueType", inspectValueType);
			return cmd;
		}
		public InspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual InspectRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="InspectRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="InspectRow"/> objects.</returns>
		public virtual InspectRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[Inspect]", top);
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
		public InspectRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			InspectRow[] rows = null;
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
		public DataTable GetInspectPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "InspectID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(InspectID) AS TotalRow FROM [dbo].[Inspect] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,InspectID,InspectName,ServiceCode,IsThaiCitizen,SortOrder,IsActive,InspectValueType," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [Inspect].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[Inspect] " + whereSql +
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
		public InspectItemsPaging GetInspectPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "InspectID")
		{
		InspectItemsPaging obj = new InspectItemsPaging();
		DataTable dt = GetInspectPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		InspectItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new InspectItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.InspectID = Convert.ToInt32(dt.Rows[i]["InspectID"]);
			record.InspectName = dt.Rows[i]["InspectName"].ToString();
			record.ServiceCode = dt.Rows[i]["ServiceCode"].ToString();
			record.IsThaiCitizen = Convert.ToBoolean(dt.Rows[i]["IsThaiCitizen"]);
			record.SortOrder = Convert.ToInt32(dt.Rows[i]["SortOrder"]);
			record.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
			if (dt.Rows[i]["InspectValueType"] != DBNull.Value)
			record.InspectValueType = Convert.ToInt32(dt.Rows[i]["InspectValueType"]);
			recordList.Add(record);
		}
		obj.inspectItems = (InspectItems[])(recordList.ToArray(typeof(InspectItems)));
		return obj;
		}
		public InspectRow GetByPrimaryKey(int inspectiD)
		{
			string whereSql = "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "InspectID", inspectiD);
			InspectRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(InspectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Inspect] (" +
			"[InspectID], " + 
			"[InspectName], " + 
			"[ServiceCode], " + 
			"[IsThaiCitizen], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[InspectValueType]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("InspectName") + ", " +
			CreateSqlParameterName("ServiceCode") + ", " +
			CreateSqlParameterName("IsThaiCitizen") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("InspectValueType") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "InspectName",value.InspectName);
			AddParameter(cmd, "ServiceCode", value.ServiceCode);
			AddParameter(cmd, "IsThaiCitizen", value.IsThaiCitizen);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "InspectValueType", value.IsInspectValueTypeNull ? DBNull.Value : (object)value.InspectValueType);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(InspectRow value)		{
			string sqlStr = "INSERT INTO [dbo].[Inspect] (" +
			"[InspectID], " + 
			"[InspectName], " + 
			"[ServiceCode], " + 
			"[IsThaiCitizen], " + 
			"[SortOrder], " + 
			"[IsActive], " + 
			"[InspectValueType]			" + 
			") VALUES (" +
			CreateSqlParameterName("InspectID") + ", " +
			CreateSqlParameterName("InspectName") + ", " +
			CreateSqlParameterName("ServiceCode") + ", " +
			CreateSqlParameterName("IsThaiCitizen") + ", " +
			CreateSqlParameterName("SortOrder") + ", " +
			CreateSqlParameterName("IsActive") + ", " +
			CreateSqlParameterName("InspectValueType") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "InspectID", value.InspectID);
			AddParameter(cmd, "InspectName", Sanitizer.GetSafeHtmlFragment(value.InspectName));
			AddParameter(cmd, "ServiceCode", Sanitizer.GetSafeHtmlFragment(value.ServiceCode));
			AddParameter(cmd, "IsThaiCitizen", value.IsThaiCitizen);
			AddParameter(cmd, "SortOrder", value.SortOrder);
			AddParameter(cmd, "IsActive", value.IsActive);
			AddParameter(cmd, "InspectValueType", value.IsInspectValueTypeNull ? DBNull.Value : (object)value.InspectValueType);
			cmd.ExecuteNonQuery();
		}
		public bool Update(InspectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectName)
				{
					strUpdate += "[InspectName]=" + CreateSqlParameterName("InspectName") + ",";
				}
				if (value._IsSetServiceCode)
				{
					strUpdate += "[ServiceCode]=" + CreateSqlParameterName("ServiceCode") + ",";
				}
				if (value._IsSetIsThaiCitizen)
				{
					strUpdate += "[IsThaiCitizen]=" + CreateSqlParameterName("IsThaiCitizen") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetInspectValueType)
				{
					strUpdate += "[InspectValueType]=" + CreateSqlParameterName("InspectValueType") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Inspect] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "InspectName",value.InspectName);
					AddParameter(cmd, "ServiceCode", value.ServiceCode);
					AddParameter(cmd, "IsThaiCitizen", value.IsThaiCitizen);
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "InspectValueType", value.IsInspectValueTypeNull ? DBNull.Value : (object)value.InspectValueType);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(InspectRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetInspectID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetInspectName)
				{
					strUpdate += "[InspectName]=" + CreateSqlParameterName("InspectName") + ",";
				}
				if (value._IsSetServiceCode)
				{
					strUpdate += "[ServiceCode]=" + CreateSqlParameterName("ServiceCode") + ",";
				}
				if (value._IsSetIsThaiCitizen)
				{
					strUpdate += "[IsThaiCitizen]=" + CreateSqlParameterName("IsThaiCitizen") + ",";
				}
				if (value._IsSetSortOrder)
				{
					strUpdate += "[SortOrder]=" + CreateSqlParameterName("SortOrder") + ",";
				}
				if (value._IsSetIsActive)
				{
					strUpdate += "[IsActive]=" + CreateSqlParameterName("IsActive") + ",";
				}
				if (value._IsSetInspectValueType)
				{
					strUpdate += "[InspectValueType]=" + CreateSqlParameterName("InspectValueType") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[Inspect] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[InspectID]=" + CreateSqlParameterName("InspectID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "InspectID", value.InspectID);
					AddParameter(cmd, "InspectName", Sanitizer.GetSafeHtmlFragment(value.InspectName));
					AddParameter(cmd, "ServiceCode", Sanitizer.GetSafeHtmlFragment(value.ServiceCode));
					AddParameter(cmd, "IsThaiCitizen", value.IsThaiCitizen);
					AddParameter(cmd, "SortOrder", value.SortOrder);
					AddParameter(cmd, "IsActive", value.IsActive);
					AddParameter(cmd, "InspectValueType", value.IsInspectValueTypeNull ? DBNull.Value : (object)value.InspectValueType);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(InspectID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int inspectiD)
		{
			string whereSql = "[InspectID]=" + CreateSqlParameterName("InspectID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "InspectID", inspectiD);
			return 0 < cmd.ExecuteNonQuery();
		}
		public InspectRow[] GetIsActive(bool isActive)
		{
			string whereSql = "[IsActive]=" + CreateSqlParameterName("IsActive");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IsActive", isActive);
			InspectRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray;
		}
		public int DeleteByInspectValueType(int inspectValueType)
		{
			return DeleteByInspectValueType(inspectValueType, false);
		}
		public int DeleteByInspectValueType(int inspectValueType, bool inspectValueTypeNull)
		{
			return CreateDeleteByInspectValueTypeCommand(inspectValueType, inspectValueTypeNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByInspectValueTypeCommand(int inspectValueType, bool inspectValueTypeNull)
		{
			string whereSql = "";
			if (inspectValueTypeNull)
				whereSql += "[InspectValueType] IS NULL";
			else
				whereSql += "[InspectValueType]=" + CreateSqlParameterName("InspectValueType");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!inspectValueTypeNull)
				AddParameter(cmd, "InspectValueType", inspectValueType);
			return cmd;
		}
		protected InspectRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected InspectRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected InspectRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int inspectiDColumnIndex = reader.GetOrdinal("InspectID");
			int inspectNameColumnIndex = reader.GetOrdinal("InspectName");
			int serviceCodeColumnIndex = reader.GetOrdinal("ServiceCode");
			int isThaiCitizenColumnIndex = reader.GetOrdinal("IsThaiCitizen");
			int sortOrderColumnIndex = reader.GetOrdinal("SortOrder");
			int isActiveColumnIndex = reader.GetOrdinal("IsActive");
			int inspectValueTypeColumnIndex = reader.GetOrdinal("InspectValueType");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					InspectRow record = new InspectRow();
					recordList.Add(record);
					record.InspectID =  Convert.ToInt32(reader.GetValue(inspectiDColumnIndex));
					record.InspectName =  Convert.ToString(reader.GetValue(inspectNameColumnIndex));
					if (!reader.IsDBNull(serviceCodeColumnIndex)) record.ServiceCode =  Convert.ToString(reader.GetValue(serviceCodeColumnIndex));

					record.IsThaiCitizen =  Convert.ToBoolean(reader.GetValue(isThaiCitizenColumnIndex));
					record.SortOrder =  Convert.ToInt32(reader.GetValue(sortOrderColumnIndex));
					record.IsActive =  Convert.ToBoolean(reader.GetValue(isActiveColumnIndex));
					if (!reader.IsDBNull(inspectValueTypeColumnIndex)) record.InspectValueType =  Convert.ToInt32(reader.GetValue(inspectValueTypeColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (InspectRow[])(recordList.ToArray(typeof(InspectRow)));
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
				case "InspectID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "InspectName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ServiceCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsThaiCitizen":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "SortOrder":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IsActive":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "InspectValueType":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
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

