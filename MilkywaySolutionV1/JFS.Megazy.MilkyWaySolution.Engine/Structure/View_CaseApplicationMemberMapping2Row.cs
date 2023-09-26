using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_CaseApplicationMemberMapping2Row
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _memberID;
		private bool _isSetMemberID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private int _ownerDepartmentID;
		private bool _isSetOwnerDepartmentID = false;
		private bool _ownerDepartmentIDNull = true;
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
		private string _gender;
		private bool _isSetGender = false;
		private bool _genderNull = true;
		private double _requestAmount;
		private bool _isSetRequestAmount = false;
		private bool _requestAmountNull = true;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private int _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private bool _caseApplicationStatusNameNull = true;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private bool _workStepNameNull = true;
		private int _referenceDepartmentID;
		private bool _isSetReferenceDepartmentID = false;
		private bool _referenceDepartmentIDNull = true;
		private string _memberFirstName;
		private bool _isSetMemberFirstName = false;
		private bool _memberFirstNameNull = true;
		private string _memberLastName;
		private bool _isSetMemberLastName = false;
		private bool _memberLastNameNull = true;
		private string _orgName;
		private bool _isSetOrgName = false;
		private bool _orgNameNull = true;
		private int _memberGender;
		private bool _isSetMemberGender = false;
		private bool _memberGenderNull = true;
		private string _email;
		private bool _isSetEmail = false;
		private bool _emailNull = true;
		private string _phoneNumber;
		private bool _isSetPhoneNumber = false;
		private bool _phoneNumberNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
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
		public int OwnerDepartmentID
		{
			get
			{
				return _ownerDepartmentID;
			}
			set
			{
				_ownerDepartmentIDNull = false;
				_isSetOwnerDepartmentID = true;
				_ownerDepartmentID = value;
				_isMapRecord = false;
			}
		}
		public bool IsOwnerDepartmentIDNull
		{
			get {
				 return _ownerDepartmentIDNull; }
			set { _ownerDepartmentIDNull = value; }
		}
		public Boolean _IsSetOwnerDepartmentID
		{
			get { return _isSetOwnerDepartmentID; }
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
		public string Gender
		{
			get
			{
				return _gender;
			}
			set
			{
				_genderNull = false;
				_isSetGender = true;
				_gender = value;
				_isMapRecord = false;
			}
		}
		public bool IsGenderNull
		{
			get {
				 return _genderNull; }
			set { _genderNull = value; }
		}
		public Boolean _IsSetGender
		{
			get { return _isSetGender; }
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
				_isMapRecord = false;
			}
		}
		public bool IsRequestAmountNull
		{
			get {
				 return _requestAmountNull; }
			set { _requestAmountNull = value; }
		}
		public Boolean _IsSetRequestAmount
		{
			get { return _isSetRequestAmount; }
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
		public int StatusID
		{
			get
			{
				return _statusID;
			}
			set
			{
				_statusIDNull = false;
				_isSetStatusID = true;
				_statusID = value;
				_isMapRecord = false;
			}
		}
		public bool IsStatusIDNull
		{
			get {
				 return _statusIDNull; }
			set { _statusIDNull = value; }
		}
		public Boolean _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		public string CaseApplicationStatusName
		{
			get
			{
				return _caseApplicationStatusName;
			}
			set
			{
				_caseApplicationStatusNameNull = false;
				_isSetCaseApplicationStatusName = true;
				_caseApplicationStatusName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseApplicationStatusNameNull
		{
			get {
				 return _caseApplicationStatusNameNull; }
			set { _caseApplicationStatusNameNull = value; }
		}
		public Boolean _IsSetCaseApplicationStatusName
		{
			get { return _isSetCaseApplicationStatusName; }
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
		public int ReferenceDepartmentID
		{
			get
			{
				return _referenceDepartmentID;
			}
			set
			{
				_referenceDepartmentIDNull = false;
				_isSetReferenceDepartmentID = true;
				_referenceDepartmentID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceDepartmentIDNull
		{
			get {
				 return _referenceDepartmentIDNull; }
			set { _referenceDepartmentIDNull = value; }
		}
		public Boolean _IsSetReferenceDepartmentID
		{
			get { return _isSetReferenceDepartmentID; }
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
		public int MemberGender
		{
			get
			{
				return _memberGender;
			}
			set
			{
				_memberGenderNull = false;
				_isSetMemberGender = true;
				_memberGender = value;
				_isMapRecord = false;
			}
		}
		public bool IsMemberGenderNull
		{
			get {
				 return _memberGenderNull; }
			set { _memberGenderNull = value; }
		}
		public Boolean _IsSetMemberGender
		{
			get { return _isSetMemberGender; }
		}
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_emailNull = false;
				_isSetEmail = true;
				_email = value;
				_isMapRecord = false;
			}
		}
		public bool IsEmailNull
		{
			get {
				 return _emailNull; }
			set { _emailNull = value; }
		}
		public Boolean _IsSetEmail
		{
			get { return _isSetEmail; }
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
	}
	[Serializable]
	public class View_CaseApplicationMemberMapping2Data
	{
		private int _caseID;
		private int _memberID;
		private int _applicantID;
		private int _referenceMSCID;
		private int _ownerDepartmentID;
		private string _subject;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _gender;
		private double _requestAmount;
		private bool _deletedFlag;
		private int _departmentId;
		private int _statusID;
		private string _caseApplicationStatusName;
		private int _workStepID;
		private string _workStepName;
		private int _referenceDepartmentID;
		private string _memberFirstName;
		private string _memberLastName;
		private string _orgName;
		private int _memberGender;
		private string _email;
		private string _phoneNumber;
		private DateTime _createDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public int OwnerDepartmentID
		{
			get{ return _ownerDepartmentID; }
			set{ _ownerDepartmentID = value; }
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
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public double RequestAmount
		{
			get{ return _requestAmount; }
			set{ _requestAmount = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public string CaseApplicationStatusName
		{
			get{ return _caseApplicationStatusName; }
			set{ _caseApplicationStatusName = value; }
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
		public int ReferenceDepartmentID
		{
			get{ return _referenceDepartmentID; }
			set{ _referenceDepartmentID = value; }
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
		public int MemberGender
		{
			get{ return _memberGender; }
			set{ _memberGender = value; }
		}
		public string Email
		{
			get{ return _email; }
			set{ _email = value; }
		}
		public string PhoneNumber
		{
			get{ return _phoneNumber; }
			set{ _phoneNumber = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
	}
	[Serializable]
	public class View_CaseApplicationMemberMapping2Paging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseApplicationMemberMapping2Row[] view_CaseApplicationMemberMapping2Row { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseApplicationMemberMapping2ItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseApplicationMemberMapping2Items : View_CaseApplicationMemberMapping2Data
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseApplicationMemberMapping2ItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseApplicationMemberMapping2Items[] view_CaseApplicationMemberMapping2Items { get; set; }
	}
}

