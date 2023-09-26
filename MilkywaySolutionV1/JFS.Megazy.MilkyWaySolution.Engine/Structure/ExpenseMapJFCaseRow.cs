using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ExpenseMapJFCaseRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private int _priceThreshold;
		private bool _isSetPriceThreshold = false;
		private bool _priceThresholdNull = true;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private bool _isOtherNull = true;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int ExpenseID
		{
			get { return _expenseID; }
			set { _expenseID = value;
			      _isMapRecord = false;
			      _isSetExpenseID = true; }
		}
		public Boolean _IsSetExpenseID
		{
			get { return _isSetExpenseID; }
		}
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isMapRecord = false;
			      _isSetJFCaseTypeID = true; }
		}
		public Boolean _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
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
				_isMapRecord = false;
			}
		}
		public bool IsPriceThresholdNull
		{
			get {
				 return _priceThresholdNull; }
			set { _priceThresholdNull = value; }
		}
		public Boolean _IsSetPriceThreshold
		{
			get { return _isSetPriceThreshold; }
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
				_isMapRecord = false;
			}
		}
		public bool IsIsOtherNull
		{
			get {
				 return _isOtherNull; }
			set { _isOtherNull = value; }
		}
		public Boolean _IsSetIsOther
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
				_isMapRecord = false;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public Boolean _IsSetSortOrder
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class ExpenseMapJFCaseData
	{
		private int _expenseID;
		private int _jFCaseTypeID;
		private int _priceThreshold;
		private bool _isOther;
		private int _sortOrder;
		private DateTime _modifiedDate;
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
		public int PriceThreshold
		{
			get{ return _priceThreshold; }
			set{ _priceThreshold = value; }
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
	public class ExpenseMapJFCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ExpenseMapJFCaseRow[] expenseMapJFCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ExpenseMapJFCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ExpenseMapJFCaseItems : ExpenseMapJFCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ExpenseMapJFCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ExpenseMapJFCaseItems[] expenseMapJFCaseItems { get; set; }
	}
}

