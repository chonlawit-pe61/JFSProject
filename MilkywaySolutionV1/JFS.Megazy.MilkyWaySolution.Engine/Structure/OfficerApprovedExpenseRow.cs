using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerApprovedExpenseRow
	{
		private int _approvedID;
		private bool _isSetApprovedID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private double _totalAmount;
		private bool _isSetTotalAmount = false;
		private DateTime _approveDate;
		private bool _isSetApproveDate = false;
		private bool _approveDateNull = true;
		private bool _isFinalApproved;
		private bool _isSetIsFinalApproved = false;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class OfficerApprovedExpenseData
	{
		private int _approvedID;
		private int _caseID;
		private int _applicantID;
		private int _officerRoleID;
		private double _totalAmount;
		private DateTime _approveDate;
		private bool _isFinalApproved;
		private string _note;
		private DateTime _modifiedDate;
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OfficerApprovedExpensePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerApprovedExpenseRow[] officerApprovedExpenseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerApprovedExpenseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerApprovedExpenseItems : OfficerApprovedExpenseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerApprovedExpenseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerApprovedExpenseItems[] officerApprovedExpenseItems { get; set; }
	}
}

