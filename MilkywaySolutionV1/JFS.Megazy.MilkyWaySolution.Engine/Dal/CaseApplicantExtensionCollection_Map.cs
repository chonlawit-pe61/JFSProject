using System;
using System.Data;
using Sk.StepUpSolution.WebDisplay.CommonProvider;
using Sk.StepUpSolution.IntProxy;
using Sk.StepUpSolution.IntProxy.BusinessLogic;
using Sk.StepUpSolution.IntProxy.StructureType;
namespace JFS.Megazy.MilkyWaySolution.Engine.Converter
{
	public partial class CaseApplicantExtensionCollection_Map
	{
		private int _processID = 0;

		public ICaseApplicantExtensionCollection_Base CreateInstance()

		{
			ICaseApplicantExtensionCollection_Base obj = (ICaseApplicantExtensionCollection_Base)RemotingHelper.Instance.GetObject(typeof(ICaseApplicantExtensionCollection_Base));
			return obj;
		}
		public void ProcessID(int intProcessID)
			{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			//Empty
		}
		public CaseApplicantExtensionRow[] GetAll()
		{
			return CreateInstance().GetAll(_processID, ConvertConstant.key);
		}
		public DataTable GetAllAsDataTable()
		{
			return CreateInstance().GetAllAsDataTable(_processID, ConvertConstant.key);
		}
		public int Delete(string whereSql)
		{
			return CreateInstance().Delete(whereSql, _processID, ConvertConstant.key);
		}
		public CaseApplicantExtensionRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			return CreateInstance().GetAsArray(List<SqlParameter> sqlParameter, whereSql, orderBySql, _processID, ConvertConstant.key);
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			return CreateInstance().GetAsDataTable(List<SqlParameter> sqlParameter, whereSql, orderBySql, _processID, ConvertConstant.key);
		}
		public CaseApplicantExtensionRow GetByPrimaryKey(int applicantID)
		{
			return CreateInstance().GetByPrimaryKey(applicantID, _processID, ConvertConstant.key);
		}
		public void Insert(CaseApplicantExtensionRow value)
		{
			CreateInstance().Insert( value, _processID, ConvertConstant.key);
		}
		public void InsertOnlyPlainText(CaseApplicantExtensionRow value)
		{
			CreateInstance().InsertOnlyPlainText( value, _processID, ConvertConstant.key);
		}
		public bool Update(CaseApplicantExtensionRow value)
		{
			return CreateInstance().Update( value, _processID, ConvertConstant.key);
		}
		public bool Update(CaseApplicantExtensionRow value)
		{
			return CreateInstance().Update( value, _processID, ConvertConstant.key);
		}
		public bool DeleteByPrimaryKey(int applicantID)
		{
			return CreateInstance().DeleteByPrimaryKey(applicantID, _processID, ConvertConstant.key);
		}
	}
}
