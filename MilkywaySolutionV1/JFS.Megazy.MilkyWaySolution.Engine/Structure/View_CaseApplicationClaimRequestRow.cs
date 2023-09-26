using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_CaseApplicationClaimRequestRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _subject;
		private bool _isSetSubject = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private int _memberID;
		private bool _isSetMemberID = false;
		private string _memberFirstName;
		private bool _isSetMemberFirstName = false;
		private string _memberLastName;
		private bool _isSetMemberLastName = false;
		private string _orgName;
		private bool _isSetOrgName = false;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private DateTime _requestDate;
		private bool _isSetRequestDate = false;
		private bool _requestDateNull = true;
		private int _claimStatusID;
		private bool _isSetClaimStatusID = false;
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
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		public int ReferenceMSCID
		{
			get
			{
				return _referenceMSCID;
			}
			set
			{
				_referenceMSCIDNull = false;
				_isSetReferenceMSCID = true;
				_referenceMSCID = value;
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public bool _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value;
			      _isSetFirstName = true; }
		}
		public bool _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value;
			      _isSetLastName = true; }
		}
		public bool _IsSetLastName
		{
			get { return _isSetLastName; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isSetMemberID = true; }
		}
		public bool _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		public string MemberFirstName
		{
			get { return _memberFirstName; }
			set { _memberFirstName = value;
			      _isSetMemberFirstName = true; }
		}
		public bool _IsSetMemberFirstName
		{
			get { return _isSetMemberFirstName; }
		}
		public string MemberLastName
		{
			get { return _memberLastName; }
			set { _memberLastName = value;
			      _isSetMemberLastName = true; }
		}
		public bool _IsSetMemberLastName
		{
			get { return _isSetMemberLastName; }
		}
		public string OrgName
		{
			get { return _orgName; }
			set { _orgName = value;
			      _isSetOrgName = true; }
		}
		public bool _IsSetOrgName
		{
			get { return _isSetOrgName; }
		}
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value;
			      _isSetPhoneNumber = true; }
		}
		public bool _IsSetPhoneNumber
		{
			get { return _isSetPhoneNumber; }
		}
		[Required]
		public DateTime RequestDate
		{
			get { return _requestDate; }
			set { _requestDate = value;
			      _requestDateNull = false;
			      _isSetRequestDate = true; }
		}
		public bool IsRequestDateNull
		{
			get {
				 return _requestDateNull; }
			set { _requestDateNull = value; }
		}
		public bool _IsSetRequestDate
		{
			get { return _isSetRequestDate; }
		}
		[Required]
		public int ClaimStatusID
		{
			get { return _claimStatusID; }
			set { _claimStatusID = value;
			      _isSetClaimStatusID = true; }
		}
		public bool _IsSetClaimStatusID
		{
			get { return _isSetClaimStatusID; }
		}
	}
	[Serializable]
	public class View_CaseApplicationClaimRequestData
	{
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private int _referenceMSCID;
		private string _subject;
		private string _title;
		private string _firstName;
		private string _lastName;
		private DateTime _createDate;
		private int _memberID;
		private string _memberFirstName;
		private string _memberLastName;
		private string _orgName;
		private string _phoneNumber;
		private DateTime _requestDate;
		private int _claimStatusID;
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
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
		public string FirstName
		{
			get{ return _firstName; }
			set{ _firstName = value; }
		}
		public string LastName
		{
			get{ return _lastName; }
			set{ _lastName = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreateDateStr { get; set; }
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public string MemberFirstName
		{
			get{ return _memberFirstName; }
			set{ _memberFirstName = value; }
		}
		public string MemberLastName
		{
			get{ return _memberLastName; }
			set{ _memberLastName = value; }
		}
		public string OrgName
		{
			get{ return _orgName; }
			set{ _orgName = value; }
		}
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		public DateTime RequestDate
		{
			get{ return _requestDate; }
			set{ _requestDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RequestDateStr { get; set; }
		public int ClaimStatusID
		{
			get{ return _claimStatusID; }
			set{ _claimStatusID = value; }
		}
	}
	[Serializable]
	public class View_CaseApplicationClaimRequestPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseApplicationClaimRequestRow[] view_CaseApplicationClaimRequestRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseApplicationClaimRequestItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseApplicationClaimRequestItems : View_CaseApplicationClaimRequestData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseApplicationClaimRequestItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseApplicationClaimRequestItems[] view_CaseApplicationClaimRequestItems { get; set; }
	}
}

