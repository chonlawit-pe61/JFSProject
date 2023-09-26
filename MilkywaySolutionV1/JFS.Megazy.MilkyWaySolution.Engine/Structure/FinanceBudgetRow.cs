using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FinanceBudgetRow
	{
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private string _budgetName;
		private bool _isSetBudgetName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int BudgetID
		{
			get { return _budgetID; }
			set { _budgetID = value;
			      _isSetBudgetID = true; }
		}
		public bool _IsSetBudgetID
		{
			get { return _isSetBudgetID; }
		}
		public string BudgetName
		{
			get { return _budgetName; }
			set { _budgetName = value;
			      _isSetBudgetName = true; }
		}
		public bool _IsSetBudgetName
		{
			get { return _isSetBudgetName; }
		}
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				_modifiedDateNull = false;
				_isSetModifiedDate = true;
				_modifiedDate = value;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public bool _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class FinanceBudgetData
	{
		private int _budgetID;
		private string _budgetName;
		private DateTime _modifiedDate;
		public int BudgetID
		{
			get{ return _budgetID; }
			set{ _budgetID = value; }
		}
		public string BudgetName
		{
			get{ return _budgetName; }
			set{ _budgetName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class FinanceBudgetPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FinanceBudgetRow[] financeBudgetRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FinanceBudgetItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FinanceBudgetItems : FinanceBudgetData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FinanceBudgetItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FinanceBudgetItems[] financeBudgetItems { get; set; }
	}
}

