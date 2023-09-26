using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProjectExpenseRow
	{
		private int _projectExpenseID;
		private bool _isSetProjectExpenseID = false;
		private string _projectExpenseName;
		private bool _isSetProjectExpenseName = false;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private string _unit;
		private bool _isSetUnit = false;
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
		public int ProjectExpenseID
		{
			get { return _projectExpenseID; }
			set { _projectExpenseID = value;
			      _isSetProjectExpenseID = true; }
		}
		public bool _IsSetProjectExpenseID
		{
			get { return _isSetProjectExpenseID; }
		}
		public string ProjectExpenseName
		{
			get { return _projectExpenseName; }
			set { _projectExpenseName = value;
			      _isSetProjectExpenseName = true; }
		}
		public bool _IsSetProjectExpenseName
		{
			get { return _isSetProjectExpenseName; }
		}
		public double Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amountNull = false;
				_isSetAmount = true;
				_amount = value;
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public bool _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		public string Unit
		{
			get { return _unit; }
			set { _unit = value;
			      _isSetUnit = true; }
		}
		public bool _IsSetUnit
		{
			get { return _isSetUnit; }
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
	public class ProjectExpenseData
	{
		private int _projectExpenseID;
		private string _projectExpenseName;
		private double _amount;
		private string _unit;
		private bool _isOther;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int ProjectExpenseID
		{
			get{ return _projectExpenseID; }
			set{ _projectExpenseID = value; }
		}
		public string ProjectExpenseName
		{
			get{ return _projectExpenseName; }
			set{ _projectExpenseName = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public string Unit
		{
			get{ return _unit; }
			set{ _unit = value; }
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
	public class ProjectExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProjectExpenseRow[] projectExpenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProjectExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProjectExpenseItems : ProjectExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProjectExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProjectExpenseItems[] projectExpenseItems { get; set; }
	}
}

