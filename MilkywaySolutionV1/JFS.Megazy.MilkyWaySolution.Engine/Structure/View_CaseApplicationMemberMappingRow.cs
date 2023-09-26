using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_CaseApplicationMemberMappingRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _subject;
		private bool _isSetSubject = false;
		private bool _subjectNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private bool _titleNull = true;
		private string _firstName;
		private bool _isSetFirstName = false;
		private bool _firstNameNull = true;
		private string _lastName;
		private bool _isSetLastName = false;
		private bool _lastNameNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private int _memberID;
		private bool _isSetMemberID = false;
		private string _memberFirstName;
		private bool _isSetMemberFirstName = false;
		private bool _memberFirstNameNull = true;
		private string _memberLastName;
		private bool _isSetMemberLastName = false;
		private bool _memberLastNameNull = true;
		private string _orgName;
		private bool _isSetOrgName = false;
		private bool _orgNameNull = true;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private bool _phoneNumberNull = true;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private bool _workStepNameNull = true;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private bool _jFCaseNoNull = true;
		private DateTime _dateCreatedCaseNo;
		private bool _isSetDateCreatedCaseNo = false;
		private bool _dateCreatedCaseNoNull = true;
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
		public int CaseID
		{
			get
			{
				return _caseID;
			}
			set
			{
				_caseIDNull = false;
				_isSetCaseID = true;
				_caseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public int ApplicantID
		{
			get
			{
				return _applicantID;
			}
			set
			{
				_applicantIDNull = false;
				_isSetApplicantID = true;
				_applicantID = value;
				_isMapRecord = false;
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public int DepartmentID
		{
			get
			{
				return _departmentId;
			}
			set
			{
				_departmentIdNull = false;
				_isSetDepartmentID = true;
				_departmentId = value;
				_isMapRecord = false;
			}
		}
		public bool IsDepartmentIDNull
		{
			get {
				 return _departmentIdNull; }
			set { _departmentIdNull = value; }
		}
		public Boolean _IsSetDepartmentID
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
				_isMapRecord = false;
			}
		}
		public bool IsReferenceMSCIDNull
		{
			get {
				 return _referenceMSCIDNull; }
			set { _referenceMSCIDNull = value; }
		}
		public Boolean _IsSetReferenceMSCID
		{
			get { return _isSetReferenceMSCID; }
		}
		public string Subject
		{
			get
			{
				return _subject;
			}
			set
			{
				_subjectNull = false;
				_isSetSubject = true;
				_subject = value;
				_isMapRecord = false;
			}
		}
		public bool IsSubjectNull
		{
			get {
				 return _subjectNull; }
			set { _subjectNull = value; }
		}
		public Boolean _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_titleNull = false;
				_isSetTitle = true;
				_title = value;
				_isMapRecord = false;
			}
		}
		public bool IsTitleNull
		{
			get {
				 return _titleNull; }
			set { _titleNull = value; }
		}
		public Boolean _IsSetTitle
		{
			get { return _isSetTitle; }
		}
		public string FirstName
		{
			get
			{
				return _firstName;
			}
			set
			{
				_firstNameNull = false;
				_isSetFirstName = true;
				_firstName = value;
				_isMapRecord = false;
			}
		}
		public bool IsFirstNameNull
		{
			get {
				 return _firstNameNull; }
			set { _firstNameNull = value; }
		}
		public Boolean _IsSetFirstName
		{
			get { return _isSetFirstName; }
		}
		public string LastName
		{
			get
			{
				return _lastName;
			}
			set
			{
				_lastNameNull = false;
				_isSetLastName = true;
				_lastName = value;
				_isMapRecord = false;
			}
		}
		public bool IsLastNameNull
		{
			get {
				 return _lastNameNull; }
			set { _lastNameNull = value; }
		}
		public Boolean _IsSetLastName
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
				_isMapRecord = false;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public Boolean _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
		}
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isMapRecord = false;
			      _isSetMemberID = true; }
		}
		public Boolean _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		public string MemberFirstName
		{
			get
			{
				return _memberFirstName;
			}
			set
			{
				_memberFirstNameNull = false;
				_isSetMemberFirstName = true;
				_memberFirstName = value;
				_isMapRecord = false;
			}
		}
		public bool IsMemberFirstNameNull
		{
			get {
				 return _memberFirstNameNull; }
			set { _memberFirstNameNull = value; }
		}
		public Boolean _IsSetMemberFirstName
		{
			get { return _isSetMemberFirstName; }
		}
		public string MemberLastName
		{
			get
			{
				return _memberLastName;
			}
			set
			{
				_memberLastNameNull = false;
				_isSetMemberLastName = true;
				_memberLastName = value;
				_isMapRecord = false;
			}
		}
		public bool IsMemberLastNameNull
		{
			get {
				 return _memberLastNameNull; }
			set { _memberLastNameNull = value; }
		}
		public Boolean _IsSetMemberLastName
		{
			get { return _isSetMemberLastName; }
		}
		public string OrgName
		{
			get
			{
				return _orgName;
			}
			set
			{
				_orgNameNull = false;
				_isSetOrgName = true;
				_orgName = value;
				_isMapRecord = false;
			}
		}
		public bool IsOrgNameNull
		{
			get {
				 return _orgNameNull; }
			set { _orgNameNull = value; }
		}
		public Boolean _IsSetOrgName
		{
			get { return _isSetOrgName; }
		}
		public string PhoneNumber
		{
			get
			{
				return _phoneNumber;
			}
			set
			{
				_phoneNumberNull = false;
				_isSetPhoneNumber = true;
				_phoneNumber = value;
				_isMapRecord = false;
			}
		}
		public bool IsPhoneNumberNull
		{
			get {
				 return _phoneNumberNull; }
			set { _phoneNumberNull = value; }
		}
		public Boolean _IsSetPhoneNumber
		{
			get { return _isSetPhoneNumber; }
		}
		public int WorkStepID
		{
			get
			{
				return _workStepID;
			}
			set
			{
				_workStepIDNull = false;
				_isSetWorkStepID = true;
				_workStepID = value;
				_isMapRecord = false;
			}
		}
		public bool IsWorkStepIDNull
		{
			get {
				 return _workStepIDNull; }
			set { _workStepIDNull = value; }
		}
		public Boolean _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
		}
		public string WorkStepName
		{
			get
			{
				return _workStepName;
			}
			set
			{
				_workStepNameNull = false;
				_isSetWorkStepName = true;
				_workStepName = value;
				_isMapRecord = false;
			}
		}
		public bool IsWorkStepNameNull
		{
			get {
				 return _workStepNameNull; }
			set { _workStepNameNull = value; }
		}
		public Boolean _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
		}
		[Required]
		public bool DeletedFlag
		{
			get { return _deletedFlag; }
			set { _deletedFlag = value;
			      _isMapRecord = false;
			      _isSetDeletedFlag = true; }
		}
		public Boolean _IsSetDeletedFlag
		{
			get { return _isSetDeletedFlag; }
		}
		public string JFCaseNo
		{
			get
			{
				return _jFCaseNo;
			}
			set
			{
				_jFCaseNoNull = false;
				_isSetJFCaseNo = true;
				_jFCaseNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsJFCaseNoNull
		{
			get {
				 return _jFCaseNoNull; }
			set { _jFCaseNoNull = value; }
		}
		public Boolean _IsSetJFCaseNo
		{
			get { return _isSetJFCaseNo; }
		}
		public DateTime DateCreatedCaseNo
		{
			get
			{
				return _dateCreatedCaseNo;
			}
			set
			{
				_dateCreatedCaseNoNull = false;
				_isSetDateCreatedCaseNo = true;
				_dateCreatedCaseNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsDateCreatedCaseNoNull
		{
			get {
				 return _dateCreatedCaseNoNull; }
			set { _dateCreatedCaseNoNull = value; }
		}
		public Boolean _IsSetDateCreatedCaseNo
		{
			get { return _isSetDateCreatedCaseNo; }
		}
	}
	[Serializable]
	public class View_CaseApplicationMemberMappingData
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
		private int _workStepID;
		private string _workStepName;
		private bool _deletedFlag;
		private string _jFCaseNo;
		private DateTime _dateCreatedCaseNo;
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
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		public DateTime DateCreatedCaseNo
		{
			get{ return _dateCreatedCaseNo; }
			set{ _dateCreatedCaseNo = value; }
		}
		public string DateCreatedCaseNoStr { get; set; }
	}
	[Serializable]
	public class View_CaseApplicationMemberMappingPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseApplicationMemberMappingRow[] view_CaseApplicationMemberMappingRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseApplicationMemberMappingItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseApplicationMemberMappingItems : View_CaseApplicationMemberMappingData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseApplicationMemberMappingItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseApplicationMemberMappingItems[] view_CaseApplicationMemberMappingItems { get; set; }
	}
}

