using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantExpenseRow
	{
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _description;
		private bool _isSetDescription = false;
		private double _amount;
		private bool _isSetAmount = false;
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
		[Required]
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public double Amount
		{
			get { return _amount; }
			set { _amount = value;
			      _isSetAmount = true; }
		}
		public bool _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class ApplicantExpenseData
	{
		private int _expenseID;
		private int _applicantID;
		private string _description;
		private double _amount;
		private DateTime _modifiedDate;
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
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantExpenseRow[] applicantExpenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantExpenseItems : ApplicantExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantExpenseItems[] applicantExpenseItems { get; set; }
	}
}

