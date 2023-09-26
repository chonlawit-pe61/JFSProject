using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantInterviewBailRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private DateTime _issueDate;
		private bool _isSetIssueDate = false;
		private bool _issueDateNull = true;
		private string _officerorDepartment;
		private bool _isSetOfficerOrDepartment = false;
		private string _arrestName;
		private bool _isSetArrestName = false;
		private bool _arrestWithStatus;
		private bool _isSetArrestWithStatus = false;
		private bool _arrestWithStatusNull = true;
		private string _arrestWith;
		private bool _isSetArrestWith = false;
		private string _charge;
		private bool _isSetCharge = false;
		private int _penalty;
		private bool _isSetPenalty = false;
		private bool _penaltyNull = true;
		private string _testify;
		private bool _isSetTestify = false;
		private string _captureAs;
		private bool _isSetCaptureAs = false;
		private string _accusedTellCode;
		private bool _isSetAccusedTellCode = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public DateTime IssueDate
		{
			get
			{
				return _issueDate;
			}
			set
			{
				_issueDateNull = false;
				_isSetIssueDate = true;
				_issueDate = value;
			}
		}
		public bool IsIssueDateNull
		{
			get {
				 return _issueDateNull; }
			set { _issueDateNull = value; }
		}
		public bool _IsSetIssueDate
		{
			get { return _isSetIssueDate; }
		}
		public string OfficerOrDepartment
		{
			get { return _officerorDepartment; }
			set { _officerorDepartment = value;
			      _isSetOfficerOrDepartment = true; }
		}
		public bool _IsSetOfficerOrDepartment
		{
			get { return _isSetOfficerOrDepartment; }
		}
		public string ArrestName
		{
			get { return _arrestName; }
			set { _arrestName = value;
			      _isSetArrestName = true; }
		}
		public bool _IsSetArrestName
		{
			get { return _isSetArrestName; }
		}
		public bool ArrestWithStatus
		{
			get
			{
				return _arrestWithStatus;
			}
			set
			{
				_arrestWithStatusNull = false;
				_isSetArrestWithStatus = true;
				_arrestWithStatus = value;
			}
		}
		public bool IsArrestWithStatusNull
		{
			get {
				 return _arrestWithStatusNull; }
			set { _arrestWithStatusNull = value; }
		}
		public bool _IsSetArrestWithStatus
		{
			get { return _isSetArrestWithStatus; }
		}
		public string ArrestWith
		{
			get { return _arrestWith; }
			set { _arrestWith = value;
			      _isSetArrestWith = true; }
		}
		public bool _IsSetArrestWith
		{
			get { return _isSetArrestWith; }
		}
		public string Charge
		{
			get { return _charge; }
			set { _charge = value;
			      _isSetCharge = true; }
		}
		public bool _IsSetCharge
		{
			get { return _isSetCharge; }
		}
		public int Penalty
		{
			get
			{
				return _penalty;
			}
			set
			{
				_penaltyNull = false;
				_isSetPenalty = true;
				_penalty = value;
			}
		}
		public bool IsPenaltyNull
		{
			get {
				 return _penaltyNull; }
			set { _penaltyNull = value; }
		}
		public bool _IsSetPenalty
		{
			get { return _isSetPenalty; }
		}
		public string Testify
		{
			get { return _testify; }
			set { _testify = value;
			      _isSetTestify = true; }
		}
		public bool _IsSetTestify
		{
			get { return _isSetTestify; }
		}
		public string CaptureAs
		{
			get { return _captureAs; }
			set { _captureAs = value;
			      _isSetCaptureAs = true; }
		}
		public bool _IsSetCaptureAs
		{
			get { return _isSetCaptureAs; }
		}
		public string AccusedTellCode
		{
			get { return _accusedTellCode; }
			set { _accusedTellCode = value;
			      _isSetAccusedTellCode = true; }
		}
		public bool _IsSetAccusedTellCode
		{
			get { return _isSetAccusedTellCode; }
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
	public class ApplicantInterviewBailData
	{
		private int _applicantID;
		private DateTime _issueDate;
		private string _officerorDepartment;
		private string _arrestName;
		private bool _arrestWithStatus;
		private string _arrestWith;
		private string _charge;
		private int _penalty;
		private string _testify;
		private string _captureAs;
		private string _accusedTellCode;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public DateTime IssueDate
		{
			get{ return _issueDate; }
			set{ _issueDate = value; }
		}
		public string IssueDateStr { get; set; }
		public string OfficerOrDepartment
		{
			get{ return _officerorDepartment; }
			set{ _officerorDepartment = value; }
		}
		public string ArrestName
		{
			get{ return _arrestName; }
			set{ _arrestName = value; }
		}
		public bool ArrestWithStatus
		{
			get{ return _arrestWithStatus; }
			set{ _arrestWithStatus = value; }
		}
		public string ArrestWith
		{
			get{ return _arrestWith; }
			set{ _arrestWith = value; }
		}
		public string Charge
		{
			get{ return _charge; }
			set{ _charge = value; }
		}
		public int Penalty
		{
			get{ return _penalty; }
			set{ _penalty = value; }
		}
		public string Testify
		{
			get{ return _testify; }
			set{ _testify = value; }
		}
		public string CaptureAs
		{
			get{ return _captureAs; }
			set{ _captureAs = value; }
		}
		public string AccusedTellCode
		{
			get{ return _accusedTellCode; }
			set{ _accusedTellCode = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantInterviewBailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantInterviewBailRow[] applicantInterviewBailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantInterviewBailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantInterviewBailItems : ApplicantInterviewBailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantInterviewBailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantInterviewBailItems[] applicantInterviewBailItems { get; set; }
	}
}

