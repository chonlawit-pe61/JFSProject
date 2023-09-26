using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseExpenseExtensionRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private int _priceThreshold;
		private bool _isSetPriceThreshold = false;
		private bool _priceThresholdNull = true;
		private int _unit;
		private bool _isSetUnit = false;
		private bool _unitNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private bool _remarkNull = true;
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
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
		public int Unit
		{
			get
			{
				return _unit;
			}
			set
			{
				_unitNull = false;
				_isSetUnit = true;
				_unit = value;
				_isMapRecord = false;
			}
		}
		public bool IsUnitNull
		{
			get {
				 return _unitNull; }
			set { _unitNull = value; }
		}
		public Boolean _IsSetUnit
		{
			get { return _isSetUnit; }
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
				_isMapRecord = false;
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public Boolean _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		public string Remark
		{
			get
			{
				return _remark;
			}
			set
			{
				_remarkNull = false;
				_isSetRemark = true;
				_remark = value;
				_isMapRecord = false;
			}
		}
		public bool IsRemarkNull
		{
			get {
				 return _remarkNull; }
			set { _remarkNull = value; }
		}
		public Boolean _IsSetRemark
		{
			get { return _isSetRemark; }
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
	public class CaseExpenseExtensionData
	{
		private int _caseID;
		private int _applicantID;
		private int _expenseID;
		private int _priceThreshold;
		private int _unit;
		private double _amount;
		private string _remark;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int ExpenseID
		{
			get{ return _expenseID; }
			set{ _expenseID = value; }
		}
		public int PriceThreshold
		{
			get{ return _priceThreshold; }
			set{ _priceThreshold = value; }
		}
		public int Unit
		{
			get{ return _unit; }
			set{ _unit = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseExpenseExtensionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseExpenseExtensionRow[] caseExpenseExtensionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseExpenseExtensionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseExpenseExtensionItems : CaseExpenseExtensionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseExpenseExtensionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseExpenseExtensionItems[] caseExpenseExtensionItems { get; set; }
	}
}

