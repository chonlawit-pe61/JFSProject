using System.ServiceModel;
using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Engine.Structure;
namespace Megazy.StarterKit.Engine.Dal
{
	[Serializable]
	public partial class ProvinceTypeCollection_Base : MarshalByRefObject
	{
		public const string ProvinceTypeCodeColumnName = "ProvinceTypeCode";
		public const string ProvinceTypeNameColumnName = "ProvinceTypeName";
		public const string ProvinceGroupColumnName = "ProvinceGroup";
		private int _processID;
		public SqlCommand cmd = null;
		public ProvinceTypeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual ProvinceTypeRow[] GetAll()
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
			"[ProvinceTypeCode],"+
			"[ProvinceTypeName],"+
			"[ProvinceGroup]"+
			" FROM [dbo].[ProvinceType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[ProvinceType]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "ProvinceType"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ProvinceTypeCode",Type.GetType("System.String"));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProvinceGroup",Type.GetType("System.Int32"));
			return dataTable;
		}
		public ProvinceTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual ProvinceTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="ProvinceTypeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ProvinceTypeRow"/> objects.</returns>
		public virtual ProvinceTypeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[ProvinceType]", top);
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
		public ProvinceTypeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			ProvinceTypeRow[] rows = null;
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
		public DataTable GetProvinceTypePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceTypeCode")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ProvinceTypeCode";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ProvinceTypeCode) AS TotalRow FROM [dbo].[ProvinceType] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ProvinceTypeCode,ProvinceTypeName,ProvinceGroup," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[ProvinceType] " + whereSql +
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
		public ProvinceTypeItemsPaging GetProvinceTypePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ProvinceTypeCode")
		{
		ProvinceTypeItemsPaging obj = new ProvinceTypeItemsPaging();
		DataTable dt = GetProvinceTypePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		ProvinceTypeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new ProvinceTypeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ProvinceTypeCode = dt.Rows[i]["ProvinceTypeCode"].ToString();
			record.ProvinceTypeName = dt.Rows[i]["ProvinceTypeName"].ToString();
			if (dt.Rows[i]["ProvinceGroup"] != DBNull.Value)
			record.ProvinceGroup = Convert.ToInt32(dt.Rows[i]["ProvinceGroup"]);
			recordList.Add(record);
		}
		obj.provinceTypeItems = (ProvinceTypeItems[])(recordList.ToArray(typeof(ProvinceTypeItems)));
		return obj;
		}
		public ProvinceTypeRow GetByPrimaryKey(string provinceTypeCode)
		{
			string whereSql = "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			ProvinceTypeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(ProvinceTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceType] (" +
			"[ProvinceTypeCode], " + 
			"[ProvinceTypeName], " + 
			"[ProvinceGroup]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceTypeCode") + ", " +
			CreateSqlParameterName("ProvinceTypeName") + ", " +
			CreateSqlParameterName("ProvinceGroup") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceTypeCode",value.ProvinceTypeCode);
			AddParameter(cmd, "ProvinceTypeName",value.ProvinceTypeName);
			AddParameter(cmd, "ProvinceGroup", value.IsProvinceGroupNull ? DBNull.Value : (object)value.ProvinceGroup);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(ProvinceTypeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[ProvinceType] (" +
			"[ProvinceTypeCode], " + 
			"[ProvinceTypeName], " + 
			"[ProvinceGroup]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProvinceTypeCode") + ", " +
			CreateSqlParameterName("ProvinceTypeName") + ", " +
			CreateSqlParameterName("ProvinceGroup") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProvinceTypeCode", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeCode));
			AddParameter(cmd, "ProvinceTypeName", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeName));
			AddParameter(cmd, "ProvinceGroup", value.IsProvinceGroupNull ? DBNull.Value : (object)value.ProvinceGroup);
			cmd.ExecuteNonQuery();
		}
		public bool Update(ProvinceTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceTypeCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceTypeName)
				{
					strUpdate += "[ProvinceTypeName]=" + CreateSqlParameterName("ProvinceTypeName") + ",";
				}
				if (value._IsSetProvinceGroup)
				{
					strUpdate += "[ProvinceGroup]=" + CreateSqlParameterName("ProvinceGroup") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceTypeCode",value.ProvinceTypeCode);
					AddParameter(cmd, "ProvinceTypeName",value.ProvinceTypeName);
				if (value._IsSetProvinceGroup)
				{
					AddParameter(cmd, "ProvinceGroup", value.IsProvinceGroupNull ? DBNull.Value : (object)value.ProvinceGroup);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceTypeCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(ProvinceTypeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetProvinceTypeCode == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProvinceTypeName)
				{
					strUpdate += "[ProvinceTypeName]=" + CreateSqlParameterName("ProvinceTypeName") + ",";
				}
				if (value._IsSetProvinceGroup)
				{
					strUpdate += "[ProvinceGroup]=" + CreateSqlParameterName("ProvinceGroup") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[ProvinceType] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ProvinceTypeCode", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeCode));
					AddParameter(cmd, "ProvinceTypeName", Sanitizer.GetSafeHtmlFragment(value.ProvinceTypeName));
				if (value._IsSetProvinceGroup)
				{
					AddParameter(cmd, "ProvinceGroup", value.IsProvinceGroupNull ? DBNull.Value : (object)value.ProvinceGroup);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ProvinceTypeCode)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(string provinceTypeCode)
		{
			string whereSql = "[ProvinceTypeCode]=" + CreateSqlParameterName("ProvinceTypeCode");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ProvinceTypeCode", provinceTypeCode);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected ProvinceTypeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected ProvinceTypeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected ProvinceTypeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int provinceTypeCodeColumnIndex = reader.GetOrdinal("ProvinceTypeCode");
			int provinceTypeNameColumnIndex = reader.GetOrdinal("ProvinceTypeName");
			int provinceGroupColumnIndex = reader.GetOrdinal("ProvinceGroup");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					ProvinceTypeRow record = new ProvinceTypeRow();
					recordList.Add(record);
					record.ProvinceTypeCode =  Convert.ToString(reader.GetValue(provinceTypeCodeColumnIndex));
					record.ProvinceTypeName =  Convert.ToString(reader.GetValue(provinceTypeNameColumnIndex));
					if (!reader.IsDBNull(provinceGroupColumnIndex)) record.ProvinceGroup =  Convert.ToInt32(reader.GetValue(provinceGroupColumnIndex));

					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ProvinceTypeRow[])(recordList.ToArray(typeof(ProvinceTypeRow)));
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
				case "ProvinceTypeCode":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ProvinceTypeName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ProvinceGroup":
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
				throw new FaultException("Zero ProcessID");
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

