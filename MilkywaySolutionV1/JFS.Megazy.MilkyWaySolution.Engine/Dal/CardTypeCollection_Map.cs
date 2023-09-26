using System;
using System.Data;
using Sk.StepUpSolution.WebDisplay.CommonProvider;
using Sk.StepUpSolution.IntProxy;
using Sk.StepUpSolution.IntProxy.BusinessLogic;
using Sk.StepUpSolution.IntProxy.StructureType;
namespace JFS.Megazy.MilkyWaySolution.Engine.Converter
{
	public partial class CardTypeCollection_Map
	{
		private int _processID = 0;

		public ICardTypeCollection_Base CreateInstance()

		{
			ICardTypeCollection_Base obj = (ICardTypeCollection_Base)RemotingHelper.Instance.GetObject(typeof(ICardTypeCollection_Base));
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
		public CardTypeRow[] GetAll()
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
		public CardTypeRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			return CreateInstance().GetAsArray(List<SqlParameter> sqlParameter, whereSql, orderBySql, _processID, ConvertConstant.key);
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			return CreateInstance().GetAsDataTable(List<SqlParameter> sqlParameter, whereSql, orderBySql, _processID, ConvertConstant.key);
		}
		public CardTypeRow GetByPrimaryKey(int cardTypeID)
		{
			return CreateInstance().GetByPrimaryKey(cardTypeID, _processID, ConvertConstant.key);
		}
		public void Insert(CardTypeRow value)
		{
			CreateInstance().Insert( value, _processID, ConvertConstant.key);
		}
		public void InsertOnlyPlainText(CardTypeRow value)
		{
			CreateInstance().InsertOnlyPlainText( value, _processID, ConvertConstant.key);
		}
		public bool Update(CardTypeRow value)
		{
			return CreateInstance().Update( value, _processID, ConvertConstant.key);
		}
		public bool Update(CardTypeRow value)
		{
			return CreateInstance().Update( value, _processID, ConvertConstant.key);
		}
		public bool DeleteByPrimaryKey(int cardTypeID)
		{
			return CreateInstance().DeleteByPrimaryKey(cardTypeID, _processID, ConvertConstant.key);
		}
		public CardTypeRow[] GetIsActive(bool isActive)
		{
			return CreateInstance().GetIsActive(isActive, _processID, ConvertConstant.key);
		}
	}
}
