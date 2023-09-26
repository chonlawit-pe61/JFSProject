using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_LawyerContractRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _courtJudgmentID;
		private bool _isSetCourtJudgmentID = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private string _note;
		private bool _isSetNote = false;
		private int _formID;
		private bool _isSetFormID = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private string _subject;
		private bool _isSetSubject = false;
		private string _title;
		private bool _isSetTitle = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _applicant;
		private bool _isSetApplicant = false;
		[Required]
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isSetContractID = true; }
		}
		public bool _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		[Required]
		public int CourtJudgmentID
		{
			get { return _courtJudgmentID; }
			set { _courtJudgmentID = value;
			      _isSetCourtJudgmentID = true; }
		}
		public bool _IsSetCourtJudgmentID
		{
			get { return _isSetCourtJudgmentID; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
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
		public DateTime ContractDate
		{
			get
			{
				return _contractDate;
			}
			set
			{
				_contractDateNull = false;
				_isSetContractDate = true;
				_contractDate = value;
			}
		}
		public bool IsContractDateNull
		{
			get {
				 return _contractDateNull; }
			set { _contractDateNull = value; }
		}
		public bool _IsSetContractDate
		{
			get { return _isSetContractDate; }
		}
		public string ContractNote
		{
			get { return _contractNote; }
			set { _contractNote = value;
			      _isSetContractNote = true; }
		}
		public bool _IsSetContractNote
		{
			get { return _isSetContractNote; }
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
		public string Applicant
		{
			get { return _applicant; }
			set { _applicant = value;
			      _isSetApplicant = true; }
		}
		public bool _IsSetApplicant
		{
			get { return _isSetApplicant; }
		}
	}
	[Serializable]
	public class View_LawyerContractData
	{
		private int _contractID;
		private int _lawyerID;
		private int _courtJudgmentID;
		private bool _isActive;
		private int _caseID;
		private int _departmentId;
		private int _applicantID;
		private string _note;
		private int _formID;
		private string _contractNo;
		private DateTime _contractDate;
		private string _contractNote;
		private string _subject;
		private string _title;
		private string _firstName;
		private string _lastName;
		private string _applicant;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int CourtJudgmentID
		{
			get{ return _courtJudgmentID; }
			set{ _courtJudgmentID = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
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
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string ContractNo
		{
			get{ return _contractNo; }
			set{ _contractNo = value; }
		}
		public DateTime ContractDate
		{
			get{ return _contractDate; }
			set{ _contractDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ContractDateStr { get; set; }
		public string ContractNote
		{
			get{ return _contractNote; }
			set{ _contractNote = value; }
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
		public string Applicant
		{
			get{ return _applicant; }
			set{ _applicant = value; }
		}
	}
	[Serializable]
	public class View_LawyerContractPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_LawyerContractRow[] view_LawyerContractRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_LawyerContractItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_LawyerContractItems : View_LawyerContractData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_LawyerContractItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_LawyerContractItems[] view_LawyerContractItems { get; set; }
	}
}

