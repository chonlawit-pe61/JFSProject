using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CurrentCaseStatusRow
	{
		private int _currentStatuscaseID;
		private bool _isSetCurrentStatusCaseID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _courID;
		private bool _isSetCourID = false;
		private bool _courIDNull = true;
		private int _helpCaseLevelID;
		private bool _isSetHelpCaseLevelID = false;
		private bool _helpCaseLevelIDNull = true;
		private int _caseTypeID;
		private bool _isSetCaseTypeID = false;
		private bool _caseTypeIDNull = true;
		private string _helpCaseLevelOther;
		private bool _isSetHelpCaseLevelOther = false;
		private string _caseTypeOther;
		private bool _isSetCaseTypeOther = false;
		private string _caseRedNo;
		private bool _isSetCaseRedNo = false;
		private string _caseBlackNo;
		private bool _isSetCaseBlackNo = false;
		private string _litigantTitle;
		private bool _isSetLitigantTitle = false;
		private string _litigantName;
		private bool _isSetLitigantName = false;
		private string _judgement;
		private bool _isSetJudgement = false;
		private string _applicantStatus;
		private bool _isSetApplicantStatus = false;
		private string _charge;
		private bool _isSetCharge = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CurrentStatusCaseID
		{
			get { return _currentStatuscaseID; }
			set { _currentStatuscaseID = value;
			      _isSetCurrentStatusCaseID = true; }
		}
		public bool _IsSetCurrentStatusCaseID
		{
			get { return _isSetCurrentStatusCaseID; }
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
		public int CourID
		{
			get
			{
				return _courID;
			}
			set
			{
				_courIDNull = false;
				_isSetCourID = true;
				_courID = value;
			}
		}
		public bool IsCourIDNull
		{
			get {
				 return _courIDNull; }
			set { _courIDNull = value; }
		}
		public bool _IsSetCourID
		{
			get { return _isSetCourID; }
		}
		public int HelpCaseLevelID
		{
			get
			{
				return _helpCaseLevelID;
			}
			set
			{
				_helpCaseLevelIDNull = false;
				_isSetHelpCaseLevelID = true;
				_helpCaseLevelID = value;
			}
		}
		public bool IsHelpCaseLevelIDNull
		{
			get {
				 return _helpCaseLevelIDNull; }
			set { _helpCaseLevelIDNull = value; }
		}
		public bool _IsSetHelpCaseLevelID
		{
			get { return _isSetHelpCaseLevelID; }
		}
		public int CaseTypeID
		{
			get
			{
				return _caseTypeID;
			}
			set
			{
				_caseTypeIDNull = false;
				_isSetCaseTypeID = true;
				_caseTypeID = value;
			}
		}
		public bool IsCaseTypeIDNull
		{
			get {
				 return _caseTypeIDNull; }
			set { _caseTypeIDNull = value; }
		}
		public bool _IsSetCaseTypeID
		{
			get { return _isSetCaseTypeID; }
		}
		public string HelpCaseLevelOther
		{
			get { return _helpCaseLevelOther; }
			set { _helpCaseLevelOther = value;
			      _isSetHelpCaseLevelOther = true; }
		}
		public bool _IsSetHelpCaseLevelOther
		{
			get { return _isSetHelpCaseLevelOther; }
		}
		public string CaseTypeOther
		{
			get { return _caseTypeOther; }
			set { _caseTypeOther = value;
			      _isSetCaseTypeOther = true; }
		}
		public bool _IsSetCaseTypeOther
		{
			get { return _isSetCaseTypeOther; }
		}
		public string CaseRedNo
		{
			get { return _caseRedNo; }
			set { _caseRedNo = value;
			      _isSetCaseRedNo = true; }
		}
		public bool _IsSetCaseRedNo
		{
			get { return _isSetCaseRedNo; }
		}
		public string CaseBlackNo
		{
			get { return _caseBlackNo; }
			set { _caseBlackNo = value;
			      _isSetCaseBlackNo = true; }
		}
		public bool _IsSetCaseBlackNo
		{
			get { return _isSetCaseBlackNo; }
		}
		public string LitigantTitle
		{
			get { return _litigantTitle; }
			set { _litigantTitle = value;
			      _isSetLitigantTitle = true; }
		}
		public bool _IsSetLitigantTitle
		{
			get { return _isSetLitigantTitle; }
		}
		public string LitigantName
		{
			get { return _litigantName; }
			set { _litigantName = value;
			      _isSetLitigantName = true; }
		}
		public bool _IsSetLitigantName
		{
			get { return _isSetLitigantName; }
		}
		public string Judgement
		{
			get { return _judgement; }
			set { _judgement = value;
			      _isSetJudgement = true; }
		}
		public bool _IsSetJudgement
		{
			get { return _isSetJudgement; }
		}
		public string ApplicantStatus
		{
			get { return _applicantStatus; }
			set { _applicantStatus = value;
			      _isSetApplicantStatus = true; }
		}
		public bool _IsSetApplicantStatus
		{
			get { return _isSetApplicantStatus; }
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
	public class CurrentCaseStatusData
	{
		private int _currentStatuscaseID;
		private int _caseID;
		private int _applicantID;
		private int _courID;
		private int _helpCaseLevelID;
		private int _caseTypeID;
		private string _helpCaseLevelOther;
		private string _caseTypeOther;
		private string _caseRedNo;
		private string _caseBlackNo;
		private string _litigantTitle;
		private string _litigantName;
		private string _judgement;
		private string _applicantStatus;
		private string _charge;
		private DateTime _modifiedDate;
		public int CurrentStatusCaseID
		{
			get{ return _currentStatuscaseID; }
			set{ _currentStatuscaseID = value; }
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
		public int CourID
		{
			get{ return _courID; }
			set{ _courID = value; }
		}
		public int HelpCaseLevelID
		{
			get{ return _helpCaseLevelID; }
			set{ _helpCaseLevelID = value; }
		}
		public int CaseTypeID
		{
			get{ return _caseTypeID; }
			set{ _caseTypeID = value; }
		}
		public string HelpCaseLevelOther
		{
			get{ return _helpCaseLevelOther; }
			set{ _helpCaseLevelOther = value; }
		}
		public string CaseTypeOther
		{
			get{ return _caseTypeOther; }
			set{ _caseTypeOther = value; }
		}
		public string CaseRedNo
		{
			get{ return _caseRedNo; }
			set{ _caseRedNo = value; }
		}
		public string CaseBlackNo
		{
			get{ return _caseBlackNo; }
			set{ _caseBlackNo = value; }
		}
		public string LitigantTitle
		{
			get{ return _litigantTitle; }
			set{ _litigantTitle = value; }
		}
		public string LitigantName
		{
			get{ return _litigantName; }
			set{ _litigantName = value; }
		}
		public string Judgement
		{
			get{ return _judgement; }
			set{ _judgement = value; }
		}
		public string ApplicantStatus
		{
			get{ return _applicantStatus; }
			set{ _applicantStatus = value; }
		}
		public string Charge
		{
			get{ return _charge; }
			set{ _charge = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CurrentCaseStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CurrentCaseStatusRow[] currentcaseStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CurrentCaseStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CurrentCaseStatusItems : CurrentCaseStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CurrentCaseStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CurrentCaseStatusItems[] currentcaseStatusItems { get; set; }
	}
}

