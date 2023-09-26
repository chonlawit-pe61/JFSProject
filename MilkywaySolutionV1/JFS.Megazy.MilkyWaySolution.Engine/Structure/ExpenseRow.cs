using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ExpenseRow
	{
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private string _expenseName;
		private bool _isSetExpenseName = false;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private bool _isOtherNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ExpenseID
		{
			get { return _expenseID; }
			set { _expenseID = value;
			      _isSetExpenseID = true; }
		}
		public bool _IsSetExpenseID
		{
			get { return _isSetExpenseID; }
		}
		public string ExpenseName
		{
			get { return _expenseName; }
			set { _expenseName = value;
			      _isSetExpenseName = true; }
		}
		public bool _IsSetExpenseName
		{
			get { return _isSetExpenseName; }
		}
		public bool IsOther
		{
			get
			{
				return _isOther;
			}
			set
			{
				_isOtherNull = false;
				_isSetIsOther = true;
				_isOther = value;
			}
		}
		public bool IsIsOtherNull
		{
			get {
				 return _isOtherNull; }
			set { _isOtherNull = value; }
		}
		public bool _IsSetIsOther
		{
			get { return _isSetIsOther; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
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
	public class ExpenseData
	{
		private int _expenseID;
		private string _expenseName;
		private bool _isOther;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int ExpenseID
		{
			get{ return _expenseID; }
			set{ _expenseID = value; }
		}
		public string ExpenseName
		{
			get{ return _expenseName; }
			set{ _expenseName = value; }
		}
		public bool IsOther
		{
			get{ return _isOther; }
			set{ _isOther = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ExpenseRow[] expenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ExpenseItems : ExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ExpenseItems[] expenseItems { get; set; }
	}
}

