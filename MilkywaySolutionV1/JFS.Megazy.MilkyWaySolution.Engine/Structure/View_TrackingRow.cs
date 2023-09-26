using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_TrackingRow
	{
		private int _accusedTrackingID;
		private bool _isSetAccusedTrackingID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private DateTime _startDate;
		private bool _isSetStartDate = false;
		private bool _startDateNull = true;
		private DateTime _endDate;
		private bool _isSetEndDate = false;
		private bool _endDateNull = true;
		private DateTime _lastReportDate;
		private bool _isSetLastReportDate = false;
		private bool _lastReportDateNull = true;
		private DateTime _duedate;
		private bool _isSetDueDate = false;
		private bool _duedateNull = true;
		private int _overDue;
		private bool _isSetOverDue = false;
		private bool _overDueNull = true;
		private string _subject;
		private bool _isSetSubject = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private string _gender;
		private bool _isSetGender = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _cardID;
		private bool _isSetCardID = false;
		private string _note;
		private bool _isSetNote = false;
		private bool _isComplete;
		private bool _isSetIsComplete = false;
		private bool _isCompleteNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _jFCaseTypeIDNull = true;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _suretyFirstName;
		private bool _isSetSuretyFirstName = false;
		private string _suretyLastName;
		private bool _isSetSuretyLastName = false;
		private string _suretyTelephoneNo;
		private bool _isSetSuretyTelephoneNo = false;
		private string _suretyAddress;
		private bool _isSetSuretyAddress = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private int _contractID;
		private bool _isSetContractID = false;
		private bool _contractIDNull = true;
		[Required]
		public int AccusedTrackingID
		{
			get { return _accusedTrackingID; }
			set { _accusedTrackingID = value;
			      _isSetAccusedTrackingID = true; }
		}
		public bool _IsSetAccusedTrackingID
		{
			get { return _isSetAccusedTrackingID; }
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
			}
		}
		public bool IsCaseIDNull
		{
			get {
				 return _caseIDNull; }
			set { _caseIDNull = value; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
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
			}
		}
		public bool IsDepartmentIDNull
		{
			get {
				 return _departmentIdNull; }
			set { _departmentIdNull = value; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
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
			}
		}
		public bool IsApplicantIDNull
		{
			get {
				 return _applicantIDNull; }
			set { _applicantIDNull = value; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDateNull = false;
				_isSetStartDate = true;
				_startDate = value;
			}
		}
		public bool IsStartDateNull
		{
			get {
				 return _startDateNull; }
			set { _startDateNull = value; }
		}
		public bool _IsSetStartDate
		{
			get { return _isSetStartDate; }
		}
		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDateNull = false;
				_isSetEndDate = true;
				_endDate = value;
			}
		}
		public bool IsEndDateNull
		{
			get {
				 return _endDateNull; }
			set { _endDateNull = value; }
		}
		public bool _IsSetEndDate
		{
			get { return _isSetEndDate; }
		}
		public DateTime LastReportDate
		{
			get
			{
				return _lastReportDate;
			}
			set
			{
				_lastReportDateNull = false;
				_isSetLastReportDate = true;
				_lastReportDate = value;
			}
		}
		public bool IsLastReportDateNull
		{
			get {
				 return _lastReportDateNull; }
			set { _lastReportDateNull = value; }
		}
		public bool _IsSetLastReportDate
		{
			get { return _isSetLastReportDate; }
		}
		public DateTime DueDate
		{
			get
			{
				return _duedate;
			}
			set
			{
				_duedateNull = false;
				_isSetDueDate = true;
				_duedate = value;
			}
		}
		public bool IsDueDateNull
		{
			get {
				 return _duedateNull; }
			set { _duedateNull = value; }
		}
		public bool _IsSetDueDate
		{
			get { return _isSetDueDate; }
		}
		public int OverDue
		{
			get
			{
				return _overDue;
			}
			set
			{
				_overDueNull = false;
				_isSetOverDue = true;
				_overDue = value;
			}
		}
		public bool IsOverDueNull
		{
			get {
				 return _overDueNull; }
			set { _overDueNull = value; }
		}
		public bool _IsSetOverDue
		{
			get { return _isSetOverDue; }
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
		public string CaseTypeName
		{
			get { return _caseTypeName; }
			set { _caseTypeName = value;
			      _isSetCaseTypeName = true; }
		}
		public bool _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get { return _caseTypeNameAbbr; }
			set { _caseTypeNameAbbr = value;
			      _isSetCaseTypeNameAbbr = true; }
		}
		public bool _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public string DepartmentName
		{
			get { return _departmentName; }
			set { _departmentName = value;
			      _isSetDepartmentName = true; }
		}
		public bool _IsSetDepartmentName
		{
			get { return _isSetDepartmentName; }
		}
		public string DepartmentNameAbbr
		{
			get { return _departmentNameAbbr; }
			set { _departmentNameAbbr = value;
			      _isSetDepartmentNameAbbr = true; }
		}
		public bool _IsSetDepartmentNameAbbr
		{
			get { return _isSetDepartmentNameAbbr; }
		}
		public string JFCaseNo
		{
			get { return _jFCaseNo; }
			set { _jFCaseNo = value;
			      _isSetJFCaseNo = true; }
		}
		public bool _IsSetJFCaseNo
		{
			get { return _isSetJFCaseNo; }
		}
		public string Gender
		{
			get { return _gender; }
			set { _gender = value;
			      _isSetGender = true; }
		}
		public bool _IsSetGender
		{
			get { return _isSetGender; }
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
		public string CardID
		{
			get { return _cardID; }
			set { _cardID = value;
			      _isSetCardID = true; }
		}
		public bool _IsSetCardID
		{
			get { return _isSetCardID; }
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
		public bool IsComplete
		{
			get
			{
				return _isComplete;
			}
			set
			{
				_isCompleteNull = false;
				_isSetIsComplete = true;
				_isComplete = value;
			}
		}
		public bool IsIsCompleteNull
		{
			get {
				 return _isCompleteNull; }
			set { _isCompleteNull = value; }
		}
		public bool _IsSetIsComplete
		{
			get { return _isSetIsComplete; }
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
		public int JFCaseTypeID
		{
			get
			{
				return _jFCaseTypeID;
			}
			set
			{
				_jFCaseTypeIDNull = false;
				_isSetJFCaseTypeID = true;
				_jFCaseTypeID = value;
			}
		}
		public bool IsJFCaseTypeIDNull
		{
			get {
				 return _jFCaseTypeIDNull; }
			set { _jFCaseTypeIDNull = value; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		public int ProvinceID
		{
			get
			{
				return _provinceID;
			}
			set
			{
				_provinceIDNull = false;
				_isSetProvinceID = true;
				_provinceID = value;
			}
		}
		public bool IsProvinceIDNull
		{
			get {
				 return _provinceIDNull; }
			set { _provinceIDNull = value; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string SuretyFirstName
		{
			get { return _suretyFirstName; }
			set { _suretyFirstName = value;
			      _isSetSuretyFirstName = true; }
		}
		public bool _IsSetSuretyFirstName
		{
			get { return _isSetSuretyFirstName; }
		}
		public string SuretyLastName
		{
			get { return _suretyLastName; }
			set { _suretyLastName = value;
			      _isSetSuretyLastName = true; }
		}
		public bool _IsSetSuretyLastName
		{
			get { return _isSetSuretyLastName; }
		}
		public string SuretyTelephoneNo
		{
			get { return _suretyTelephoneNo; }
			set { _suretyTelephoneNo = value;
			      _isSetSuretyTelephoneNo = true; }
		}
		public bool _IsSetSuretyTelephoneNo
		{
			get { return _isSetSuretyTelephoneNo; }
		}
		public string SuretyAddress
		{
			get { return _suretyAddress; }
			set { _suretyAddress = value;
			      _isSetSuretyAddress = true; }
		}
		public bool _IsSetSuretyAddress
		{
			get { return _isSetSuretyAddress; }
		}
		public string ContractNo
		{
			get { return _contractNo; }
			set { _contractNo = value;
			      _isSetContractNo = true; }
		}
		public bool _IsSetContractNo
		{
			get { return _isSetContractNo; }
		}
		public int ContractID
		{
			get
			{
				return _contractID;
			}
			set
			{
				_contractIDNull = false;
				_isSetContractID = true;
				_contractID = value;
			}
		}
		public bool IsContractIDNull
		{
			get {
				 return _contractIDNull; }
			set { _contractIDNull = value; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
	}
	[Serializable]
	public class View_TrackingData
	{
		private int _accusedTrackingID;
		private int _caseID;
		private int _departmentId;
		private int _applicantID;
		private DateTime _startDate;
		private DateTime _endDate;
		private DateTime _lastReportDate;
		private DateTime _duedate;
		private int _overDue;
		private string _subject;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private string _departmentName;
		private string _departmentNameAbbr;
		private string _jFCaseNo;
		private string _gender;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _cardID;
		private string _note;
		private bool _isComplete;
		private DateTime _modifiedDate;
		private int _jFCaseTypeID;
		private int _provinceID;
		private string _suretyFirstName;
		private string _suretyLastName;
		private string _suretyTelephoneNo;
		private string _suretyAddress;
		private string _contractNo;
		private int _contractID;
		public int AccusedTrackingID
		{
			get{ return _accusedTrackingID; }
			set{ _accusedTrackingID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public DateTime StartDate
		{
			get{ return _startDate; }
			set{ _startDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string StartDateStr { get; set; }
		public DateTime EndDate
		{
			get{ return _endDate; }
			set{ _endDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string EndDateStr { get; set; }
		public DateTime LastReportDate
		{
			get{ return _lastReportDate; }
			set{ _lastReportDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string LastReportDateStr { get; set; }
		public DateTime DueDate
		{
			get{ return _duedate; }
			set{ _duedate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string DueDateStr { get; set; }
		public int OverDue
		{
			get{ return _overDue; }
			set{ _overDue = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public string CaseTypeNameAbbr
		{
			get{ return _caseTypeNameAbbr; }
			set{ _caseTypeNameAbbr = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public string DepartmentNameAbbr
		{
			get{ return _departmentNameAbbr; }
			set{ _departmentNameAbbr = value; }
		}
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
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
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public bool IsComplete
		{
			get{ return _isComplete; }
			set{ _isComplete = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string SuretyFirstName
		{
			get{ return _suretyFirstName; }
			set{ _suretyFirstName = value; }
		}
		public string SuretyLastName
		{
			get{ return _suretyLastName; }
			set{ _suretyLastName = value; }
		}
		public string SuretyTelephoneNo
		{
			get{ return _suretyTelephoneNo; }
			set{ _suretyTelephoneNo = value; }
		}
		public string SuretyAddress
		{
			get{ return _suretyAddress; }
			set{ _suretyAddress = value; }
		}
		public string ContractNo
		{
			get{ return _contractNo; }
			set{ _contractNo = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
	}
	[Serializable]
	public class View_TrackingPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_TrackingRow[] view_TrackingRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_TrackingItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_TrackingItems : View_TrackingData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_TrackingItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_TrackingItems[] view_TrackingItems { get; set; }
	}
}

