using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ExpenseGroupRow
	{
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private string _expenseName;
		private bool _isSetExpenseName = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _groupCode;
		private bool _isSetGroupCode = false;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private bool _isOtherNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
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
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		[Required]
		public string GroupCode
		{
			get { return _groupCode; }
			set { _groupCode = value;
			      _isSetGroupCode = true; }
		}
		public bool _IsSetGroupCode
		{
			get { return _isSetGroupCode; }
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
	}
	[Serializable]
	public class View_ExpenseGroupData
	{
		private int _expenseID;
		private string _expenseName;
		private int _jFCaseTypeID;
		private string _groupCode;
		private bool _isOther;
		private int _sortOrder;
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
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string GroupCode
		{
			get{ return _groupCode; }
			set{ _groupCode = value; }
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
	}
	[Serializable]
	public class View_ExpenseGroupPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ExpenseGroupRow[] view_ExpenseGroupRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ExpenseGroupItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ExpenseGroupItems : View_ExpenseGroupData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ExpenseGroupItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ExpenseGroupItems[] view_ExpenseGroupItems { get; set; }
	}
}

