using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseExpenseOtherRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _expenseOther;
		private bool _isSetExpenseOther = false;
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
		public string ExpenseOther
		{
			get { return _expenseOther; }
			set { _expenseOther = value;
			      _isSetExpenseOther = true; }
		}
		public bool _IsSetExpenseOther
		{
			get { return _isSetExpenseOther; }
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
	public class CaseExpenseOtherData
	{
		private int _caseID;
		private int _applicantID;
		private string _expenseOther;
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
		public string ExpenseOther
		{
			get{ return _expenseOther; }
			set{ _expenseOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseExpenseOtherPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseExpenseOtherRow[] caseExpenseOtherRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseExpenseOtherItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseExpenseOtherItems : CaseExpenseOtherData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseExpenseOtherItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseExpenseOtherItems[] caseExpenseOtherItems { get; set; }
	}
}

