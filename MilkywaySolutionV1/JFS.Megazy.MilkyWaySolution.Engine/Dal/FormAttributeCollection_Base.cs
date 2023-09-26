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
	public partial class FormAttributeCollection_Base : MarshalByRefObject
	{
		public const string FormAttrIDColumnName = "FormAttrID";
		public const string FormAttrAliasColumnName = "FormAttrAlias";
		public const string FormAttrNameColumnName = "FormAttrName";
		public const string DefaultValColumnName = "DefaultVal";
		public const string IsRequireColumnName = "IsRequire";
		public const string DataTypeColumnName = "DataType";
		public const string UnitColumnName = "Unit";
		private int _processID;
		public SqlCommand cmd = null;
		public FormAttributeCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual FormAttributeRow[] GetAll()
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
			"[FormAttrID],"+
			"[FormAttrAlias],"+
			"[FormAttrName],"+
			"[DefaultVal],"+
			"[IsRequire],"+
			"[DataType],"+
			"[Unit]"+
			" FROM [dbo].[FormAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[FormAttribute]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "FormAttribute"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FormAttrID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FormAttrAlias",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FormAttrName",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DefaultVal",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("IsRequire",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DataType",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("Unit",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			return dataTable;
		}
		public FormAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual FormAttributeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="FormAttributeRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FormAttributeRow"/> objects.</returns>
		public virtual FormAttributeRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[FormAttribute]", top);
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
		public FormAttributeRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			FormAttributeRow[] rows = null;
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
		public DataTable GetFormAttributePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormAttrID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "FormAttrID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(FormAttrID) AS TotalRow FROM [dbo].[FormAttribute] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,FormAttrID,FormAttrAlias,FormAttrName,DefaultVal,IsRequire,DataType,Unit," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[FormAttribute] " + whereSql +
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
		public FormAttributeItemsPaging GetFormAttributePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "FormAttrID")
		{
		FormAttributeItemsPaging obj = new FormAttributeItemsPaging();
		DataTable dt = GetFormAttributePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		FormAttributeItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new FormAttributeItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.FormAttrID = Convert.ToInt32(dt.Rows[i]["FormAttrID"]);
			record.FormAttrAlias = dt.Rows[i]["FormAttrAlias"].ToString();
			record.FormAttrName = dt.Rows[i]["FormAttrName"].ToString();
			record.DefaultVal = dt.Rows[i]["DefaultVal"].ToString();
			record.IsRequire = Convert.ToBoolean(dt.Rows[i]["IsRequire"]);
			record.DataType = dt.Rows[i]["DataType"].ToString();
			record.Unit = dt.Rows[i]["Unit"].ToString();
			recordList.Add(record);
		}
		obj.formAttributeItems = (FormAttributeItems[])(recordList.ToArray(typeof(FormAttributeItems)));
		return obj;
		}
		public FormAttributeRow GetByPrimaryKey(int formAttrID)
		{
			string whereSql = "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FormAttrID", formAttrID);
			FormAttributeRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(FormAttributeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormAttribute] (" +
			"[FormAttrID], " + 
			"[FormAttrAlias], " + 
			"[FormAttrName], " + 
			"[DefaultVal], " + 
			"[IsRequire], " + 
			"[DataType], " + 
			"[Unit]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormAttrID") + ", " +
			CreateSqlParameterName("FormAttrAlias") + ", " +
			CreateSqlParameterName("FormAttrName") + ", " +
			CreateSqlParameterName("DefaultVal") + ", " +
			CreateSqlParameterName("IsRequire") + ", " +
			CreateSqlParameterName("DataType") + ", " +
			CreateSqlParameterName("Unit") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormAttrID", value.FormAttrID);
			AddParameter(cmd, "FormAttrAlias", value.FormAttrAlias);
			AddParameter(cmd, "FormAttrName",value.FormAttrName);
			AddParameter(cmd, "DefaultVal", value.DefaultVal);
			AddParameter(cmd, "IsRequire", value.IsRequire);
			AddParameter(cmd, "DataType", value.DataType);
			AddParameter(cmd, "Unit", value.Unit);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(FormAttributeRow value)		{
			string sqlStr = "INSERT INTO [dbo].[FormAttribute] (" +
			"[FormAttrID], " + 
			"[FormAttrAlias], " + 
			"[FormAttrName], " + 
			"[DefaultVal], " + 
			"[IsRequire], " + 
			"[DataType], " + 
			"[Unit]			" + 
			") VALUES (" +
			CreateSqlParameterName("FormAttrID") + ", " +
			CreateSqlParameterName("FormAttrAlias") + ", " +
			CreateSqlParameterName("FormAttrName") + ", " +
			CreateSqlParameterName("DefaultVal") + ", " +
			CreateSqlParameterName("IsRequire") + ", " +
			CreateSqlParameterName("DataType") + ", " +
			CreateSqlParameterName("Unit") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "FormAttrID", value.FormAttrID);
			AddParameter(cmd, "FormAttrAlias", Sanitizer.GetSafeHtmlFragment(value.FormAttrAlias));
			AddParameter(cmd, "FormAttrName", Sanitizer.GetSafeHtmlFragment(value.FormAttrName));
			AddParameter(cmd, "DefaultVal", Sanitizer.GetSafeHtmlFragment(value.DefaultVal));
			AddParameter(cmd, "IsRequire", value.IsRequire);
			AddParameter(cmd, "DataType", Sanitizer.GetSafeHtmlFragment(value.DataType));
			AddParameter(cmd, "Unit", Sanitizer.GetSafeHtmlFragment(value.Unit));
			cmd.ExecuteNonQuery();
		}
		public bool Update(FormAttributeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormAttrID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormAttrAlias)
				{
					strUpdate += "[FormAttrAlias]=" + CreateSqlParameterName("FormAttrAlias") + ",";
				}
				if (value._IsSetFormAttrName)
				{
					strUpdate += "[FormAttrName]=" + CreateSqlParameterName("FormAttrName") + ",";
				}
				if (value._IsSetDefaultVal)
				{
					strUpdate += "[DefaultVal]=" + CreateSqlParameterName("DefaultVal") + ",";
				}
				if (value._IsSetIsRequire)
				{
					strUpdate += "[IsRequire]=" + CreateSqlParameterName("IsRequire") + ",";
				}
				if (value._IsSetDataType)
				{
					strUpdate += "[DataType]=" + CreateSqlParameterName("DataType") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormAttribute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormAttrID", value.FormAttrID);
					AddParameter(cmd, "FormAttrAlias", value.FormAttrAlias);
					AddParameter(cmd, "FormAttrName",value.FormAttrName);
					AddParameter(cmd, "DefaultVal", value.DefaultVal);
					AddParameter(cmd, "IsRequire", value.IsRequire);
					AddParameter(cmd, "DataType", value.DataType);
					AddParameter(cmd, "Unit", value.Unit);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(FormAttrID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(FormAttributeRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetFormAttrID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetFormAttrAlias)
				{
					strUpdate += "[FormAttrAlias]=" + CreateSqlParameterName("FormAttrAlias") + ",";
				}
				if (value._IsSetFormAttrName)
				{
					strUpdate += "[FormAttrName]=" + CreateSqlParameterName("FormAttrName") + ",";
				}
				if (value._IsSetDefaultVal)
				{
					strUpdate += "[DefaultVal]=" + CreateSqlParameterName("DefaultVal") + ",";
				}
				if (value._IsSetIsRequire)
				{
					strUpdate += "[IsRequire]=" + CreateSqlParameterName("IsRequire") + ",";
				}
				if (value._IsSetDataType)
				{
					strUpdate += "[DataType]=" + CreateSqlParameterName("DataType") + ",";
				}
				if (value._IsSetUnit)
				{
					strUpdate += "[Unit]=" + CreateSqlParameterName("Unit") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[FormAttribute] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "FormAttrID", value.FormAttrID);
					AddParameter(cmd, "FormAttrAlias", Sanitizer.GetSafeHtmlFragment(value.FormAttrAlias));
					AddParameter(cmd, "FormAttrName", Sanitizer.GetSafeHtmlFragment(value.FormAttrName));
					AddParameter(cmd, "DefaultVal", Sanitizer.GetSafeHtmlFragment(value.DefaultVal));
					AddParameter(cmd, "IsRequire", value.IsRequire);
					AddParameter(cmd, "DataType", Sanitizer.GetSafeHtmlFragment(value.DataType));
					AddParameter(cmd, "Unit", Sanitizer.GetSafeHtmlFragment(value.Unit));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(FormAttrID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int formAttrID)
		{
			string whereSql = "[FormAttrID]=" + CreateSqlParameterName("FormAttrID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FormAttrID", formAttrID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected FormAttributeRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected FormAttributeRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected FormAttributeRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int formAttrIDColumnIndex = reader.GetOrdinal("FormAttrID");
			int formAttrAliasColumnIndex = reader.GetOrdinal("FormAttrAlias");
			int formAttrNameColumnIndex = reader.GetOrdinal("FormAttrName");
			int defaultValColumnIndex = reader.GetOrdinal("DefaultVal");
			int isRequireColumnIndex = reader.GetOrdinal("IsRequire");
			int dataTypeColumnIndex = reader.GetOrdinal("DataType");
			int unitColumnIndex = reader.GetOrdinal("Unit");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					FormAttributeRow record = new FormAttributeRow();
					recordList.Add(record);
					record.FormAttrID =  Convert.ToInt32(reader.GetValue(formAttrIDColumnIndex));
					if (!reader.IsDBNull(formAttrAliasColumnIndex)) record.FormAttrAlias =  Convert.ToString(reader.GetValue(formAttrAliasColumnIndex));

					record.FormAttrName =  Convert.ToString(reader.GetValue(formAttrNameColumnIndex));
					if (!reader.IsDBNull(defaultValColumnIndex)) record.DefaultVal =  Convert.ToString(reader.GetValue(defaultValColumnIndex));

					record.IsRequire =  Convert.ToBoolean(reader.GetValue(isRequireColumnIndex));
					if (!reader.IsDBNull(dataTypeColumnIndex)) record.DataType =  Convert.ToString(reader.GetValue(dataTypeColumnIndex));

					if (!reader.IsDBNull(unitColumnIndex)) record.Unit =  Convert.ToString(reader.GetValue(unitColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FormAttributeRow[])(recordList.ToArray(typeof(FormAttributeRow)));
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
				case "FormAttrID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "FormAttrAlias":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FormAttrName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DefaultVal":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsRequire":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "DataType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Unit":
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

