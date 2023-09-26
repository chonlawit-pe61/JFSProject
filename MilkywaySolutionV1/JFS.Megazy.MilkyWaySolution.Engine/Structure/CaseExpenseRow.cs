using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseExpenseRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private double _requestAmount;
		private bool _isSetRequestAmount = false;
		private bool _requestAmountNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
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
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public double RequestAmount
		{
			get
			{
				return _requestAmount;
			}
			set
			{
				_requestAmountNull = false;
				_isSetRequestAmount = true;
				_requestAmount = value;
			}
		}
		public bool IsRequestAmountNull
		{
			get {
				 return _requestAmountNull; }
			set { _requestAmountNull = value; }
		}
		public bool _IsSetRequestAmount
		{
			get { return _isSetRequestAmount; }
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
	public class CaseExpenseData
	{
		private int _caseID;
		private int _expenseID;
		private int _applicantID;
		private double _requestAmount;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ExpenseID
		{
			get{ return _expenseID; }
			set{ _expenseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public double RequestAmount
		{
			get{ return _requestAmount; }
			set{ _requestAmount = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseExpenseRow[] caseExpenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseExpenseItems : CaseExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseExpenseItems[] caseExpenseItems { get; set; }
	}
}

