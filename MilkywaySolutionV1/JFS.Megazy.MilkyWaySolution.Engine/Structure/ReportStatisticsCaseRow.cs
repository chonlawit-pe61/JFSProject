using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ReportStatisticsCaseRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _firstName;
		private bool _isSetFirstName = false;
		private string _lastName;
		private bool _isSetLastName = false;
		private string _gender;
		private bool _isSetGender = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private string _subject;
		private bool _isSetSubject = false;
		private DateTime? _registerDate;
		private bool _isSetRegisterDate = false;
		private bool _registerDateNull = true;
		private int? _qT;
		private bool _isSetQT = false;
		private bool _qTNull = true;
		private int? _yyyy;
		private bool _isSetYYYY = false;
		private bool _yyyyNull = true;
		private int? _thaiQuarter;
		private bool _isSetThaiQuarter = false;
		private bool _thaiQuarterNull = true;
		private int? _thaiFiscalYear;
		private bool _isSetThaiFiscalYear = false;
		private bool _thaiFiscalYearNull = true;
		private string _mm;
		private bool _isSetMM = false;
		private string _thaiMonth;
		private bool _isSetThaiMonth = false;
		private DateTime? _meetingDate;
		private bool _isSetMeetingDate = false;
		private bool _meetingDateNull = true;
		private bool _isAdditional;
		private bool _isSetIsAdditional = false;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private int? _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private int? _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private DateTime? _step1;
		private bool _isSetStep1 = false;
		private bool _step1Null = true;
		private DateTime? _step2;
		private bool _isSetStep2 = false;
		private bool _step2Null = true;
		private DateTime? _step3;
		private bool _isSetStep3 = false;
		private bool _step3Null = true;
		private DateTime? _step4;
		private bool _isSetStep4 = false;
		private bool _step4Null = true;
		private DateTime? _step5;
		private bool _isSetStep5 = false;
		private bool _step5Null = true;
		private DateTime? _step6;
		private bool _isSetStep6 = false;
		private bool _step6Null = true;
		private DateTime? _step7;
		private bool _isSetStep7 = false;
		private bool _step7Null = true;
		private DateTime? _step8;
		private bool _isSetStep8 = false;
		private bool _step8Null = true;
		private DateTime? _step9;
		private bool _isSetStep9 = false;
		private bool _step9Null = true;
		private DateTime? _step10;
		private bool _isSetStep10 = false;
		private bool _step10Null = true;
		private DateTime? _step11;
		private bool _isSetStep11 = false;
		private bool _step11Null = true;
		private DateTime? _step12;
		private bool _isSetStep12 = false;
		private bool _step12Null = true;
		private DateTime? _step13;
		private bool _isSetStep13 = false;
		private bool _step13Null = true;
		private int? _opinionID;
		private bool _isSetOpinionID = false;
		private bool _opinionIDNull = true;
		private string _opinionName;
		private bool _isSetOpinionName = false;
		private int? _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private bool _officerRoleIDNull = true;
		private string _officerRoleName;
		private bool _isSetOfficerRoleName = false;
		private bool _isPay;
		private bool _isSetIsPay = false;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private int? _regionID;
		private bool _isSetRegionID = false;
		private bool _regionIDNull = true;
		private string _regionName;
		private bool _isSetRegionName = false;
		private int? _lawyerID;
		private bool _isSetLawyerID = false;
		private bool _lawyerIDNull = true;
		private string _lawyerName;
		private bool _isSetLawyerName = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _referenceMSCCODE;
		private bool _isSetReferenceMSCCODE = false;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
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
		public DateTime? RegisterDate
		{
			get
			{
				return _registerDate;
			}
			set
			{
				_registerDateNull = false;
				_isSetRegisterDate = true;
				_registerDate = value;
			}
		}
		public bool IsRegisterDateNull
		{
			get {
				 return _registerDateNull; }
			set { _registerDateNull = value; }
		}
		public bool _IsSetRegisterDate
		{
			get { return _isSetRegisterDate; }
		}
		public int? QT
		{
			get
			{
				return _qT;
			}
			set
			{
				_qTNull = false;
				_isSetQT = true;
				_qT = value;
			}
		}
		public bool IsQTNull
		{
			get {
				 return _qTNull; }
			set { _qTNull = value; }
		}
		public bool _IsSetQT
		{
			get { return _isSetQT; }
		}
		public int? YYYY
		{
			get
			{
				return _yyyy;
			}
			set
			{
				_yyyyNull = false;
				_isSetYYYY = true;
				_yyyy = value;
			}
		}
		public bool IsYYYYNull
		{
			get {
				 return _yyyyNull; }
			set { _yyyyNull = value; }
		}
		public bool _IsSetYYYY
		{
			get { return _isSetYYYY; }
		}
		public int? ThaiQuarter
		{
			get
			{
				return _thaiQuarter;
			}
			set
			{
				_thaiQuarterNull = false;
				_isSetThaiQuarter = true;
				_thaiQuarter = value;
			}
		}
		public bool IsThaiQuarterNull
		{
			get {
				 return _thaiQuarterNull; }
			set { _thaiQuarterNull = value; }
		}
		public bool _IsSetThaiQuarter
		{
			get { return _isSetThaiQuarter; }
		}
		public int? ThaiFiscalYear
		{
			get
			{
				return _thaiFiscalYear;
			}
			set
			{
				_thaiFiscalYearNull = false;
				_isSetThaiFiscalYear = true;
				_thaiFiscalYear = value;
			}
		}
		public bool IsThaiFiscalYearNull
		{
			get {
				 return _thaiFiscalYearNull; }
			set { _thaiFiscalYearNull = value; }
		}
		public bool _IsSetThaiFiscalYear
		{
			get { return _isSetThaiFiscalYear; }
		}
		public string MM
		{
			get { return _mm; }
			set { _mm = value;
			      _isSetMM = true; }
		}
		public bool _IsSetMM
		{
			get { return _isSetMM; }
		}
		public string ThaiMonth
		{
			get { return _thaiMonth; }
			set { _thaiMonth = value;
			      _isSetThaiMonth = true; }
		}
		public bool _IsSetThaiMonth
		{
			get { return _isSetThaiMonth; }
		}
		public DateTime? MeetingDate
		{
			get
			{
				return _meetingDate;
			}
			set
			{
				_meetingDateNull = false;
				_isSetMeetingDate = true;
				_meetingDate = value;
			}
		}
		public bool IsMeetingDateNull
		{
			get {
				 return _meetingDateNull; }
			set { _meetingDateNull = value; }
		}
		public bool _IsSetMeetingDate
		{
			get { return _isSetMeetingDate; }
		}
		[Required]
		public bool IsAdditional
		{
			get { return _isAdditional; }
			set { _isAdditional = value;
			      _isSetIsAdditional = true; }
		}
		public bool _IsSetIsAdditional
		{
			get { return _isSetIsAdditional; }
		}
		[Required]
		public bool IsReview
		{
			get { return _isReview; }
			set { _isReview = value;
			      _isSetIsReview = true; }
		}
		public bool _IsSetIsReview
		{
			get { return _isSetIsReview; }
		}
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
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
		public int? StatusID
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
			}
		}
		public bool IsStatusIDNull
		{
			get {
				 return _statusIDNull; }
			set { _statusIDNull = value; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		public string CaseApplicationStatusName
		{
			get { return _caseApplicationStatusName; }
			set { _caseApplicationStatusName = value;
			      _isSetCaseApplicationStatusName = true; }
		}
		public bool _IsSetCaseApplicationStatusName
		{
			get { return _isSetCaseApplicationStatusName; }
		}
		public int? WorkStepID
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
			}
		}
		public bool IsWorkStepIDNull
		{
			get {
				 return _workStepIDNull; }
			set { _workStepIDNull = value; }
		}
		public bool _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
		}
		public string WorkStepName
		{
			get { return _workStepName; }
			set { _workStepName = value;
			      _isSetWorkStepName = true; }
		}
		public bool _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
		}
		public DateTime? Step1
		{
			get
			{
				return _step1;
			}
			set
			{
				_step1Null = false;
				_isSetStep1 = true;
				_step1 = value;
			}
		}
		public bool IsStep1Null
		{
			get {
				 return _step1Null; }
			set { _step1Null = value; }
		}
		public bool _IsSetStep1
		{
			get { return _isSetStep1; }
		}
		public DateTime? Step2
		{
			get
			{
				return _step2;
			}
			set
			{
				_step2Null = false;
				_isSetStep2 = true;
				_step2 = value;
			}
		}
		public bool IsStep2Null
		{
			get {
				 return _step2Null; }
			set { _step2Null = value; }
		}
		public bool _IsSetStep2
		{
			get { return _isSetStep2; }
		}
		public DateTime? Step3
		{
			get
			{
				return _step3;
			}
			set
			{
				_step3Null = false;
				_isSetStep3 = true;
				_step3 = value;
			}
		}
		public bool IsStep3Null
		{
			get {
				 return _step3Null; }
			set { _step3Null = value; }
		}
		public bool _IsSetStep3
		{
			get { return _isSetStep3; }
		}
		public DateTime? Step4
		{
			get
			{
				return _step4;
			}
			set
			{
				_step4Null = false;
				_isSetStep4 = true;
				_step4 = value;
			}
		}
		public bool IsStep4Null
		{
			get {
				 return _step4Null; }
			set { _step4Null = value; }
		}
		public bool _IsSetStep4
		{
			get { return _isSetStep4; }
		}
		public DateTime? Step5
		{
			get
			{
				return _step5;
			}
			set
			{
				_step5Null = false;
				_isSetStep5 = true;
				_step5 = value;
			}
		}
		public bool IsStep5Null
		{
			get {
				 return _step5Null; }
			set { _step5Null = value; }
		}
		public bool _IsSetStep5
		{
			get { return _isSetStep5; }
		}
		public DateTime? Step6
		{
			get
			{
				return _step6;
			}
			set
			{
				_step6Null = false;
				_isSetStep6 = true;
				_step6 = value;
			}
		}
		public bool IsStep6Null
		{
			get {
				 return _step6Null; }
			set { _step6Null = value; }
		}
		public bool _IsSetStep6
		{
			get { return _isSetStep6; }
		}
		public DateTime? Step7
		{
			get
			{
				return _step7;
			}
			set
			{
				_step7Null = false;
				_isSetStep7 = true;
				_step7 = value;
			}
		}
		public bool IsStep7Null
		{
			get {
				 return _step7Null; }
			set { _step7Null = value; }
		}
		public bool _IsSetStep7
		{
			get { return _isSetStep7; }
		}
		public DateTime? Step8
		{
			get
			{
				return _step8;
			}
			set
			{
				_step8Null = false;
				_isSetStep8 = true;
				_step8 = value;
			}
		}
		public bool IsStep8Null
		{
			get {
				 return _step8Null; }
			set { _step8Null = value; }
		}
		public bool _IsSetStep8
		{
			get { return _isSetStep8; }
		}
		public DateTime? Step9
		{
			get
			{
				return _step9;
			}
			set
			{
				_step9Null = false;
				_isSetStep9 = true;
				_step9 = value;
			}
		}
		public bool IsStep9Null
		{
			get {
				 return _step9Null; }
			set { _step9Null = value; }
		}
		public bool _IsSetStep9
		{
			get { return _isSetStep9; }
		}
		public DateTime? Step10
		{
			get
			{
				return _step10;
			}
			set
			{
				_step10Null = false;
				_isSetStep10 = true;
				_step10 = value;
			}
		}
		public bool IsStep10Null
		{
			get {
				 return _step10Null; }
			set { _step10Null = value; }
		}
		public bool _IsSetStep10
		{
			get { return _isSetStep10; }
		}
		public DateTime? Step11
		{
			get
			{
				return _step11;
			}
			set
			{
				_step11Null = false;
				_isSetStep11 = true;
				_step11 = value;
			}
		}
		public bool IsStep11Null
		{
			get {
				 return _step11Null; }
			set { _step11Null = value; }
		}
		public bool _IsSetStep11
		{
			get { return _isSetStep11; }
		}
		public DateTime? Step12
		{
			get
			{
				return _step12;
			}
			set
			{
				_step12Null = false;
				_isSetStep12 = true;
				_step12 = value;
			}
		}
		public bool IsStep12Null
		{
			get {
				 return _step12Null; }
			set { _step12Null = value; }
		}
		public bool _IsSetStep12
		{
			get { return _isSetStep12; }
		}
		public DateTime? Step13
		{
			get
			{
				return _step13;
			}
			set
			{
				_step13Null = false;
				_isSetStep13 = true;
				_step13 = value;
			}
		}
		public bool IsStep13Null
		{
			get {
				 return _step13Null; }
			set { _step13Null = value; }
		}
		public bool _IsSetStep13
		{
			get { return _isSetStep13; }
		}
		public int? OpinionID
		{
			get
			{
				return _opinionID;
			}
			set
			{
				_opinionIDNull = false;
				_isSetOpinionID = true;
				_opinionID = value;
			}
		}
		public bool IsOpinionIDNull
		{
			get {
				 return _opinionIDNull; }
			set { _opinionIDNull = value; }
		}
		public bool _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
		}
		public string OpinionName
		{
			get { return _opinionName; }
			set { _opinionName = value;
			      _isSetOpinionName = true; }
		}
		public bool _IsSetOpinionName
		{
			get { return _isSetOpinionName; }
		}
		public int? OfficerRoleID
		{
			get
			{
				return _officerRoleID;
			}
			set
			{
				_officerRoleIDNull = false;
				_isSetOfficerRoleID = true;
				_officerRoleID = value;
			}
		}
		public bool IsOfficerRoleIDNull
		{
			get {
				 return _officerRoleIDNull; }
			set { _officerRoleIDNull = value; }
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
		public bool IsPay
		{
			get { return _isPay; }
			set { _isPay = value;
			      _isSetIsPay = true; }
		}
		public bool _IsSetIsPay
		{
			get { return _isSetIsPay; }
		}
		[Required]
		public bool IsAppeal
		{
			get { return _isAppeal; }
			set { _isAppeal = value;
			      _isSetIsAppeal = true; }
		}
		public bool _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
		}
		public int? RegionID
		{
			get
			{
				return _regionID;
			}
			set
			{
				_regionIDNull = false;
				_isSetRegionID = true;
				_regionID = value;
			}
		}
		public bool IsRegionIDNull
		{
			get {
				 return _regionIDNull; }
			set { _regionIDNull = value; }
		}
		public bool _IsSetRegionID
		{
			get { return _isSetRegionID; }
		}
		public string RegionName
		{
			get { return _regionName; }
			set { _regionName = value;
			      _isSetRegionName = true; }
		}
		public bool _IsSetRegionName
		{
			get { return _isSetRegionName; }
		}
		public int? LawyerID
		{
			get
			{
				return _lawyerID;
			}
			set
			{
				_lawyerIDNull = false;
				_isSetLawyerID = true;
				_lawyerID = value;
			}
		}
		public bool IsLawyerIDNull
		{
			get {
				 return _lawyerIDNull; }
			set { _lawyerIDNull = value; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		public string LawyerName
		{
			get { return _lawyerName; }
			set { _lawyerName = value;
			      _isSetLawyerName = true; }
		}
		public bool _IsSetLawyerName
		{
			get { return _isSetLawyerName; }
		}
		[Required]
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		public string ReferenceMSCCODE
		{
			get { return _referenceMSCCODE; }
			set { _referenceMSCCODE = value;
			      _isSetReferenceMSCCODE = true; }
		}
		public bool _IsSetReferenceMSCCODE
		{
			get { return _isSetReferenceMSCCODE; }
		}
		[Required]
		public bool DeletedFlag
		{
			get { return _deletedFlag; }
			set { _deletedFlag = value;
			      _isSetDeletedFlag = true; }
		}
		public bool _IsSetDeletedFlag
		{
			get { return _isSetDeletedFlag; }
		}
	}
	[Serializable]
	public class ReportStatisticsCaseData
	{
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private string _firstName;
		private string _lastName;
		private string _gender;
		private string _jFCaseNo;
		private string _subject;
		private DateTime? _registerDate;
		private int? _qT;
		private int? _yyyy;
		private int? _thaiQuarter;
		private int? _thaiFiscalYear;
		private string _mm;
		private string _thaiMonth;
		private DateTime? _meetingDate;
		private bool _isAdditional;
		private bool _isReview;
		private int _jFCaseTypeID;
		private string _caseTypeNameAbbr;
		private string _departmentName;
		private int? _statusID;
		private string _caseApplicationStatusName;
		private int? _workStepID;
		private string _workStepName;
		private DateTime? _step1;
		private DateTime? _step2;
		private DateTime? _step3;
		private DateTime? _step4;
		private DateTime? _step5;
		private DateTime? _step6;
		private DateTime? _step7;
		private DateTime? _step8;
		private DateTime? _step9;
		private DateTime? _step10;
		private DateTime? _step11;
		private DateTime? _step12;
		private DateTime? _step13;
		private int? _opinionID;
		private string _opinionName;
		private int? _officerRoleID;
		private string _officerRoleName;
		private bool _isPay;
		private bool _isAppeal;
		private int? _regionID;
		private string _regionName;
		private int? _lawyerID;
		private string _lawyerName;
		private int _provinceID;
		private string _provinceName;
		private string _referenceMSCCODE;
		private bool _deletedFlag;
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
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public DateTime? RegisterDate
		{
			get{ return _registerDate; }
			set{ _registerDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string RegisterDateStr { get; set; }
		public int? QT
		{
			get{ return _qT; }
			set{ _qT = value; }
		}
		public int? YYYY
		{
			get{ return _yyyy; }
			set{ _yyyy = value; }
		}
		public int? ThaiQuarter
		{
			get{ return _thaiQuarter; }
			set{ _thaiQuarter = value; }
		}
		public int? ThaiFiscalYear
		{
			get{ return _thaiFiscalYear; }
			set{ _thaiFiscalYear = value; }
		}
		public string MM
		{
			get{ return _mm; }
			set{ _mm = value; }
		}
		public string ThaiMonth
		{
			get{ return _thaiMonth; }
			set{ _thaiMonth = value; }
		}
		public DateTime? MeetingDate
		{
			get{ return _meetingDate; }
			set{ _meetingDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string MeetingDateStr { get; set; }
		public bool IsAdditional
		{
			get{ return _isAdditional; }
			set{ _isAdditional = value; }
		}
		public bool IsReview
		{
			get{ return _isReview; }
			set{ _isReview = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
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
		public int? StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public string CaseApplicationStatusName
		{
			get{ return _caseApplicationStatusName; }
			set{ _caseApplicationStatusName = value; }
		}
		public int? WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		public DateTime? Step1
		{
			get{ return _step1; }
			set{ _step1 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step1Str { get; set; }
		public DateTime? Step2
		{
			get{ return _step2; }
			set{ _step2 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step2Str { get; set; }
		public DateTime? Step3
		{
			get{ return _step3; }
			set{ _step3 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step3Str { get; set; }
		public DateTime? Step4
		{
			get{ return _step4; }
			set{ _step4 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step4Str { get; set; }
		public DateTime? Step5
		{
			get{ return _step5; }
			set{ _step5 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step5Str { get; set; }
		public DateTime? Step6
		{
			get{ return _step6; }
			set{ _step6 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step6Str { get; set; }
		public DateTime? Step7
		{
			get{ return _step7; }
			set{ _step7 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step7Str { get; set; }
		public DateTime? Step8
		{
			get{ return _step8; }
			set{ _step8 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step8Str { get; set; }
		public DateTime? Step9
		{
			get{ return _step9; }
			set{ _step9 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step9Str { get; set; }
		public DateTime? Step10
		{
			get{ return _step10; }
			set{ _step10 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step10Str { get; set; }
		public DateTime? Step11
		{
			get{ return _step11; }
			set{ _step11 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step11Str { get; set; }
		public DateTime? Step12
		{
			get{ return _step12; }
			set{ _step12 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step12Str { get; set; }
		public DateTime? Step13
		{
			get{ return _step13; }
			set{ _step13 = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string Step13Str { get; set; }
		public int? OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		public string OpinionName
		{
			get{ return _opinionName; }
			set{ _opinionName = value; }
		}
		public int? OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public string OfficerRoleName
		{
			get{ return _officerRoleName; }
			set{ _officerRoleName = value; }
		}
		public bool IsPay
		{
			get{ return _isPay; }
			set{ _isPay = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public int? RegionID
		{
			get{ return _regionID; }
			set{ _regionID = value; }
		}
		public string RegionName
		{
			get{ return _regionName; }
			set{ _regionName = value; }
		}
		public int? LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public string LawyerName
		{
			get{ return _lawyerName; }
			set{ _lawyerName = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string ReferenceMSCCODE
		{
			get{ return _referenceMSCCODE; }
			set{ _referenceMSCCODE = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
	}
	[Serializable]
	public class ReportStatisticsCasePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ReportStatisticsCaseRow[] reportStatisticsCaseRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ReportStatisticsCaseItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ReportStatisticsCaseItems : ReportStatisticsCaseData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ReportStatisticsCaseItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ReportStatisticsCaseItems[] reportStatisticsCaseItems { get; set; }
	}
}

