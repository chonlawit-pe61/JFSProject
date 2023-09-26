using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ExpenseMapJFCaseRow
	{
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private bool _isOtherNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private string _expenseName;
		private bool _isSetExpenseName = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private string _caseTypePrefix;
		private bool _isSetCaseTypePrefix = false;
		private int _priceThreshold;
		private bool _isSetPriceThreshold = false;
		private bool _priceThresholdNull = true;
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
		public string CaseTypeName
		{
			get { return _caseTypeName; }
			set { _caseTypeName = value;
			      _isSetCaseTypeName = true; }
		}
		public bool _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get { return _caseTypeNameAbbr; }
			set { _caseTypeNameAbbr = value;
			      _isSetCaseTypeNameAbbr = true; }
		}
		public bool _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public string CaseTypePrefix
		{
			get { return _caseTypePrefix; }
			set { _caseTypePrefix = value;
			      _isSetCaseTypePrefix = true; }
		}
		public bool _IsSetCaseTypePrefix
		{
			get { return _isSetCaseTypePrefix; }
		}
		public int PriceThreshold
		{
			get
			{
				return _priceThreshold;
			}
			set
			{
				_priceThresholdNull = false;
				_isSetPriceThreshold = true;
				_priceThreshold = value;
			}
		}
		public bool IsPriceThresholdNull
		{
			get {
				 return _priceThresholdNull; }
			set { _priceThresholdNull = value; }
		}
		public bool _IsSetPriceThreshold
		{
			get { return _isSetPriceThreshold; }
		}
	}
	[Serializable]
	public class View_ExpenseMapJFCaseData
	{
		private int _expenseID;
		private int _jFCaseTypeID;
		private bool _isOther;
		private int _sortOrder;
		private string _expenseName;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private string _caseTypePrefix;
		private int _priceThreshold;
		public int ExpenseID
		{
			get{ return _expenseID; }
			set{ _expenseID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
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
		public string ExpenseName
		{
			get{ return _expenseName; }
			set{ _expenseName = value; }
		}
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public string CaseTypeNameAbbr
		{
			get{ return _caseTypeNameAbbr; }
			set{ _caseTypeNameAbbr = value; }
		}
		public string CaseTypePrefix
		{
			get{ return _caseTypePrefix; }
			set{ _caseTypePrefix = value; }
		}
		public int PriceThreshold
		{
			get{ return _priceThreshold; }
			set{ _priceThreshold = value; }
		}
	}
	[Serializable]
	public class View_ExpenseMapJFCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ExpenseMapJFCaseRow[] view_ExpenseMapJFCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ExpenseMapJFCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ExpenseMapJFCaseItems : View_ExpenseMapJFCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ExpenseMapJFCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ExpenseMapJFCaseItems[] view_ExpenseMapJFCaseItems { get; set; }
	}
}

