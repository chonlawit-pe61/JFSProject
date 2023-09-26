using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_OfficerApprovedExpenseRow
	{
		private int _approvedID;
		private bool _isSetApprovedID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private string _officerRoleName;
		private bool _isSetOfficerRoleName = false;
		private double _totalAmount;
		private bool _isSetTotalAmount = false;
		private DateTime _approveDate;
		private bool _isSetApproveDate = false;
		private bool _approveDateNull = true;
		private bool _isFinalApproved;
		private bool _isSetIsFinalApproved = false;
		private string _note;
		private bool _isSetNote = false;
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private string _budgetName;
		private bool _isSetBudgetName = false;
		[Required]
		public int ApprovedID
		{
			get { return _approvedID; }
			set { _approvedID = value;
			      _isSetApprovedID = true; }
		}
		public bool _IsSetApprovedID
		{
			get { return _isSetApprovedID; }
		}
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
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		public string OfficerRoleName
		{
			get { return _officerRoleName; }
			set { _officerRoleName = value;
			      _isSetOfficerRoleName = true; }
		}
		public bool _IsSetOfficerRoleName
		{
			get { return _isSetOfficerRoleName; }
		}
		[Required]
		public double TotalAmount
		{
			get { return _totalAmount; }
			set { _totalAmount = value;
			      _isSetTotalAmount = true; }
		}
		public bool _IsSetTotalAmount
		{
			get { return _isSetTotalAmount; }
		}
		[Required]
		public DateTime ApproveDate
		{
			get { return _approveDate; }
			set { _approveDate = value;
			      _approveDateNull = false;
			      _isSetApproveDate = true; }
		}
		public bool IsApproveDateNull
		{
			get {
				 return _approveDateNull; }
			set { _approveDateNull = value; }
		}
		public bool _IsSetApproveDate
		{
			get { return _isSetApproveDate; }
		}
		[Required]
		public bool IsFinalApproved
		{
			get { return _isFinalApproved; }
			set { _isFinalApproved = value;
			      _isSetIsFinalApproved = true; }
		}
		public bool _IsSetIsFinalApproved
		{
			get { return _isSetIsFinalApproved; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
		}
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
		[Required]
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
	}
	[Serializable]
	public class View_OfficerApprovedExpenseData
	{
		private int _approvedID;
		private int _caseID;
		private int _applicantID;
		private int _officerRoleID;
		private string _officerRoleName;
		private double _totalAmount;
		private DateTime _approveDate;
		private bool _isFinalApproved;
		private string _note;
		private int _budgetID;
		private string _budgetName;
		public int ApprovedID
		{
			get{ return _approvedID; }
			set{ _approvedID = value; }
		}
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
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public string OfficerRoleName
		{
			get{ return _officerRoleName; }
			set{ _officerRoleName = value; }
		}
		public double TotalAmount
		{
			get{ return _totalAmount; }
			set{ _totalAmount = value; }
		}
		public DateTime ApproveDate
		{
			get{ return _approveDate; }
			set{ _approveDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ApproveDateStr { get; set; }
		public bool IsFinalApproved
		{
			get{ return _isFinalApproved; }
			set{ _isFinalApproved = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
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
	}
	[Serializable]
	public class View_OfficerApprovedExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_OfficerApprovedExpenseRow[] view_OfficerApprovedExpenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_OfficerApprovedExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_OfficerApprovedExpenseItems : View_OfficerApprovedExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_OfficerApprovedExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_OfficerApprovedExpenseItems[] view_OfficerApprovedExpenseItems { get; set; }
	}
}

