using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_ApplicationRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private string _subject;
		private bool _isSetSubject = false;
		private bool _subjectNull = true;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private bool _caseTypeNameNull = true;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private bool _caseTypeNameAbbrNull = true;
		private int _referenceCaseID;
		private bool _isSetReferenceCaseID = false;
		private bool _referenceCaseIDNull = true;
		private int _referenceMSCID;
		private bool _isSetReferenceMSCID = false;
		private bool _referenceMSCIDNull = true;
		private string _referenceMSCCODE;
		private bool _isSetReferenceMSCCODE = false;
		private bool _referenceMSCCODENull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _registerDate;
		private bool _isSetRegisterDate = false;
		private bool _registerDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _title;
		private bool _isSetTitle = false;
		private bool _titleNull = true;
		private string _firstName;
		private bool _isSetFirstName = false;
		private bool _firstNameNull = true;
		private string _lastName;
		private bool _isSetLastName = false;
		private bool _lastNameNull = true;
		private int _age;
		private bool _isSetAge = false;
		private double _requestAmount;
		private bool _isSetRequestAmount = false;
		private bool _requestAmountNull = true;
		private bool _hasProxy;
		private bool _isSetHasProxy = false;
		private bool _hasProxyNull = true;
		private string _gender;
		private bool _isSetGender = false;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private int _raceID;
		private bool _isSetRaceID = false;
		private bool _raceIDNull = true;
		private string _raceName;
		private bool _isSetRaceName = false;
		private bool _raceNameNull = true;
		private int _nationalityID;
		private bool _isSetNationalityID = false;
		private bool _nationalityIDNull = true;
		private string _nationalityname;
		private bool _isSetNationalityName = false;
		private bool _nationalitynameNull = true;
		private int _religionID;
		private bool _isSetReligionID = false;
		private bool _religionIDNull = true;
		private string _religionName;
		private bool _isSetReligionName = false;
		private bool _religionNameNull = true;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private bool _provinceNameNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private bool _departmentNameNull = true;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
		private bool _departmentNameAbbrNull = true;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private bool _workStepNameNull = true;
		private int _statusID;
		private bool _isSetStatusID = false;
		private bool _statusIDNull = true;
		private string _caseApplicationStatusName;
		private bool _isSetCaseApplicationStatusName = false;
		private bool _caseApplicationStatusNameNull = true;
		private string _cardID;
		private bool _isSetCardID = false;
		private bool _cardIDNull = true;
		private string _cardTypeName;
		private bool _isSetCardTypeName = false;
		private bool _cardTypeNameNull = true;
		private int _cardType;
		private bool _isSetCardType = false;
		private bool _cardTypeNull = true;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private bool _isAppealNull = true;
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private bool _lawyerIDNull = true;
		private string _lawyerFirstName;
		private bool _isSetLawyerFirstName = false;
		private bool _lawyerFirstNameNull = true;
		private string _lawyerlastName;
		private bool _isSetLawyerLastName = false;
		private bool _lawyerlastNameNull = true;
		private int _score;
		private bool _isSetScore = false;
		private int _temID;
		private bool _isSetTemID = false;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
		private DateTime _dateKPIStart;
		private bool _isSetDateKPIStart = false;
		private bool _dateKPIStartNull = true;
		private DateTime _dateKPIEnd;
		private bool _isSetDateKPIEnd = false;
		private bool _dateKPIEndNull = true;
		private int _lastKPIDay;
		private bool _isSetLastKPIDay = false;
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
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isMapRecord = false;
			      _isSetApplicantID = true; }
		}
		public Boolean _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
		}
		[Required]
		public string JFCaseNo
		{
			get { return _jFCaseNo; }
			set { _jFCaseNo = value;
			      _isMapRecord = false;
			      _isSetJFCaseNo = true; }
		}
		public Boolean _IsSetJFCaseNo
		{
			get { return _isSetJFCaseNo; }
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
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isMapRecord = false;
			      _isSetJFCaseTypeID = true; }
		}
		public Boolean _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		public string CaseTypeName
		{
			get
			{
				return _caseTypeName;
			}
			set
			{
				_caseTypeNameNull = false;
				_isSetCaseTypeName = true;
				_caseTypeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseTypeNameNull
		{
			get {
				 return _caseTypeNameNull; }
			set { _caseTypeNameNull = value; }
		}
		public Boolean _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get
			{
				return _caseTypeNameAbbr;
			}
			set
			{
				_caseTypeNameAbbrNull = false;
				_isSetCaseTypeNameAbbr = true;
				_caseTypeNameAbbr = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseTypeNameAbbrNull
		{
			get {
				 return _caseTypeNameAbbrNull; }
			set { _caseTypeNameAbbrNull = value; }
		}
		public Boolean _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public int ReferenceCaseID
		{
			get
			{
				return _referenceCaseID;
			}
			set
			{
				_referenceCaseIDNull = false;
				_isSetReferenceCaseID = true;
				_referenceCaseID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceCaseIDNull
		{
			get {
				 return _referenceCaseIDNull; }
			set { _referenceCaseIDNull = value; }
		}
		public Boolean _IsSetReferenceCaseID
		{
			get { return _isSetReferenceCaseID; }
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
		public string ReferenceMSCCODE
		{
			get
			{
				return _referenceMSCCODE;
			}
			set
			{
				_referenceMSCCODENull = false;
				_isSetReferenceMSCCODE = true;
				_referenceMSCCODE = value;
				_isMapRecord = false;
			}
		}
		public bool IsReferenceMSCCODENull
		{
			get {
				 return _referenceMSCCODENull; }
			set { _referenceMSCCODENull = value; }
		}
		public Boolean _IsSetReferenceMSCCODE
		{
			get { return _isSetReferenceMSCCODE; }
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
		public DateTime RegisterDate
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
				_isMapRecord = false;
			}
		}
		public bool IsRegisterDateNull
		{
			get {
				 return _registerDateNull; }
			set { _registerDateNull = value; }
		}
		public Boolean _IsSetRegisterDate
		{
			get { return _isSetRegisterDate; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
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
		[Required]
		public int Age
		{
			get { return _age; }
			set { _age = value;
			      _isMapRecord = false;
			      _isSetAge = true; }
		}
		public Boolean _IsSetAge
		{
			get { return _isSetAge; }
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
		public bool HasProxy
		{
			get
			{
				return _hasProxy;
			}
			set
			{
				_hasProxyNull = false;
				_isSetHasProxy = true;
				_hasProxy = value;
				_isMapRecord = false;
			}
		}
		public bool IsHasProxyNull
		{
			get {
				 return _hasProxyNull; }
			set { _hasProxyNull = value; }
		}
		public Boolean _IsSetHasProxy
		{
			get { return _isSetHasProxy; }
		}
		[Required]
		public string Gender
		{
			get { return _gender; }
			set { _gender = value;
			      _isMapRecord = false;
			      _isSetGender = true; }
		}
		public Boolean _IsSetGender
		{
			get { return _isSetGender; }
		}
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
			set
			{
				_dateOfBirthNull = false;
				_isSetDateOfBirth = true;
				_dateOfBirth = value;
				_isMapRecord = false;
			}
		}
		public bool IsDateOfBirthNull
		{
			get {
				 return _dateOfBirthNull; }
			set { _dateOfBirthNull = value; }
		}
		public Boolean _IsSetDateOfBirth
		{
			get { return _isSetDateOfBirth; }
		}
		public int RaceID
		{
			get
			{
				return _raceID;
			}
			set
			{
				_raceIDNull = false;
				_isSetRaceID = true;
				_raceID = value;
				_isMapRecord = false;
			}
		}
		public bool IsRaceIDNull
		{
			get {
				 return _raceIDNull; }
			set { _raceIDNull = value; }
		}
		public Boolean _IsSetRaceID
		{
			get { return _isSetRaceID; }
		}
		public string RaceName
		{
			get
			{
				return _raceName;
			}
			set
			{
				_raceNameNull = false;
				_isSetRaceName = true;
				_raceName = value;
				_isMapRecord = false;
			}
		}
		public bool IsRaceNameNull
		{
			get {
				 return _raceNameNull; }
			set { _raceNameNull = value; }
		}
		public Boolean _IsSetRaceName
		{
			get { return _isSetRaceName; }
		}
		public int NationalityID
		{
			get
			{
				return _nationalityID;
			}
			set
			{
				_nationalityIDNull = false;
				_isSetNationalityID = true;
				_nationalityID = value;
				_isMapRecord = false;
			}
		}
		public bool IsNationalityIDNull
		{
			get {
				 return _nationalityIDNull; }
			set { _nationalityIDNull = value; }
		}
		public Boolean _IsSetNationalityID
		{
			get { return _isSetNationalityID; }
		}
		public string NationalityName
		{
			get
			{
				return _nationalityname;
			}
			set
			{
				_nationalitynameNull = false;
				_isSetNationalityName = true;
				_nationalityname = value;
				_isMapRecord = false;
			}
		}
		public bool IsNationalityNameNull
		{
			get {
				 return _nationalitynameNull; }
			set { _nationalitynameNull = value; }
		}
		public Boolean _IsSetNationalityName
		{
			get { return _isSetNationalityName; }
		}
		public int ReligionID
		{
			get
			{
				return _religionID;
			}
			set
			{
				_religionIDNull = false;
				_isSetReligionID = true;
				_religionID = value;
				_isMapRecord = false;
			}
		}
		public bool IsReligionIDNull
		{
			get {
				 return _religionIDNull; }
			set { _religionIDNull = value; }
		}
		public Boolean _IsSetReligionID
		{
			get { return _isSetReligionID; }
		}
		public string ReligionName
		{
			get
			{
				return _religionName;
			}
			set
			{
				_religionNameNull = false;
				_isSetReligionName = true;
				_religionName = value;
				_isMapRecord = false;
			}
		}
		public bool IsReligionNameNull
		{
			get {
				 return _religionNameNull; }
			set { _religionNameNull = value; }
		}
		public Boolean _IsSetReligionName
		{
			get { return _isSetReligionName; }
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
				_isMapRecord = false;
			}
		}
		public bool IsProvinceIDNull
		{
			get {
				 return _provinceIDNull; }
			set { _provinceIDNull = value; }
		}
		public Boolean _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string ProvinceName
		{
			get
			{
				return _provinceName;
			}
			set
			{
				_provinceNameNull = false;
				_isSetProvinceName = true;
				_provinceName = value;
				_isMapRecord = false;
			}
		}
		public bool IsProvinceNameNull
		{
			get {
				 return _provinceNameNull; }
			set { _provinceNameNull = value; }
		}
		public Boolean _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
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
		public string DepartmentName
		{
			get
			{
				return _departmentName;
			}
			set
			{
				_departmentNameNull = false;
				_isSetDepartmentName = true;
				_departmentName = value;
				_isMapRecord = false;
			}
		}
		public bool IsDepartmentNameNull
		{
			get {
				 return _departmentNameNull; }
			set { _departmentNameNull = value; }
		}
		public Boolean _IsSetDepartmentName
		{
			get { return _isSetDepartmentName; }
		}
		public string DepartmentNameAbbr
		{
			get
			{
				return _departmentNameAbbr;
			}
			set
			{
				_departmentNameAbbrNull = false;
				_isSetDepartmentNameAbbr = true;
				_departmentNameAbbr = value;
				_isMapRecord = false;
			}
		}
		public bool IsDepartmentNameAbbrNull
		{
			get {
				 return _departmentNameAbbrNull; }
			set { _departmentNameAbbrNull = value; }
		}
		public Boolean _IsSetDepartmentNameAbbr
		{
			get { return _isSetDepartmentNameAbbr; }
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
		public string CardID
		{
			get
			{
				return _cardID;
			}
			set
			{
				_cardIDNull = false;
				_isSetCardID = true;
				_cardID = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardIDNull
		{
			get {
				 return _cardIDNull; }
			set { _cardIDNull = value; }
		}
		public Boolean _IsSetCardID
		{
			get { return _isSetCardID; }
		}
		public string CardTypeName
		{
			get
			{
				return _cardTypeName;
			}
			set
			{
				_cardTypeNameNull = false;
				_isSetCardTypeName = true;
				_cardTypeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardTypeNameNull
		{
			get {
				 return _cardTypeNameNull; }
			set { _cardTypeNameNull = value; }
		}
		public Boolean _IsSetCardTypeName
		{
			get { return _isSetCardTypeName; }
		}
		public int CardType
		{
			get
			{
				return _cardType;
			}
			set
			{
				_cardTypeNull = false;
				_isSetCardType = true;
				_cardType = value;
				_isMapRecord = false;
			}
		}
		public bool IsCardTypeNull
		{
			get {
				 return _cardTypeNull; }
			set { _cardTypeNull = value; }
		}
		public Boolean _IsSetCardType
		{
			get { return _isSetCardType; }
		}
		public bool IsAppeal
		{
			get
			{
				return _isAppeal;
			}
			set
			{
				_isAppealNull = false;
				_isSetIsAppeal = true;
				_isAppeal = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsAppealNull
		{
			get {
				 return _isAppealNull; }
			set { _isAppealNull = value; }
		}
		public Boolean _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
		}
		public int LawyerID
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
				_isMapRecord = false;
			}
		}
		public bool IsLawyerIDNull
		{
			get {
				 return _lawyerIDNull; }
			set { _lawyerIDNull = value; }
		}
		public Boolean _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		public string LawyerFirstName
		{
			get
			{
				return _lawyerFirstName;
			}
			set
			{
				_lawyerFirstNameNull = false;
				_isSetLawyerFirstName = true;
				_lawyerFirstName = value;
				_isMapRecord = false;
			}
		}
		public bool IsLawyerFirstNameNull
		{
			get {
				 return _lawyerFirstNameNull; }
			set { _lawyerFirstNameNull = value; }
		}
		public Boolean _IsSetLawyerFirstName
		{
			get { return _isSetLawyerFirstName; }
		}
		public string LawyerLastName
		{
			get
			{
				return _lawyerlastName;
			}
			set
			{
				_lawyerlastNameNull = false;
				_isSetLawyerLastName = true;
				_lawyerlastName = value;
				_isMapRecord = false;
			}
		}
		public bool IsLawyerLastNameNull
		{
			get {
				 return _lawyerlastNameNull; }
			set { _lawyerlastNameNull = value; }
		}
		public Boolean _IsSetLawyerLastName
		{
			get { return _isSetLawyerLastName; }
		}
		[Required]
		public int Score
		{
			get { return _score; }
			set { _score = value;
			      _isMapRecord = false;
			      _isSetScore = true; }
		}
		public Boolean _IsSetScore
		{
			get { return _isSetScore; }
		}
		[Required]
		public int TemID
		{
			get { return _temID; }
			set { _temID = value;
			      _isMapRecord = false;
			      _isSetTemID = true; }
		}
		public Boolean _IsSetTemID
		{
			get { return _isSetTemID; }
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
		public DateTime DateKPIStart
		{
			get
			{
				return _dateKPIStart;
			}
			set
			{
				_dateKPIStartNull = false;
				_isSetDateKPIStart = true;
				_dateKPIStart = value;
				_isMapRecord = false;
			}
		}
		public bool IsDateKPIStartNull
		{
			get {
				 return _dateKPIStartNull; }
			set { _dateKPIStartNull = value; }
		}
		public Boolean _IsSetDateKPIStart
		{
			get { return _isSetDateKPIStart; }
		}
		public DateTime DateKPIEnd
		{
			get
			{
				return _dateKPIEnd;
			}
			set
			{
				_dateKPIEndNull = false;
				_isSetDateKPIEnd = true;
				_dateKPIEnd = value;
				_isMapRecord = false;
			}
		}
		public bool IsDateKPIEndNull
		{
			get {
				 return _dateKPIEndNull; }
			set { _dateKPIEndNull = value; }
		}
		public Boolean _IsSetDateKPIEnd
		{
			get { return _isSetDateKPIEnd; }
		}
		[Required]
		public int LastKPIDay
		{
			get { return _lastKPIDay; }
			set { _lastKPIDay = value;
			      _isMapRecord = false;
			      _isSetLastKPIDay = true; }
		}
		public Boolean _IsSetLastKPIDay
		{
			get { return _isSetLastKPIDay; }
		}
	}
	[Serializable]
	public class View_ApplicationData
	{
		private int _caseID;
		private int _applicantID;
		private string _jFCaseNo;
		private string _subject;
		private int _jFCaseTypeID;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private int _referenceCaseID;
		private int _referenceMSCID;
		private string _referenceMSCCODE;
		private DateTime _createDate;
		private DateTime _registerDate;
		private DateTime _modifiedDate;
		private string _title;
		private string _firstName;
		private string _lastName;
		private int _age;
		private double _requestAmount;
		private bool _hasProxy;
		private string _gender;
		private DateTime _dateOfBirth;
		private int _raceID;
		private string _raceName;
		private int _nationalityID;
		private string _nationalityname;
		private int _religionID;
		private string _religionName;
		private int _provinceID;
		private string _provinceName;
		private int _departmentId;
		private string _departmentName;
		private string _departmentNameAbbr;
		private int _workStepID;
		private string _workStepName;
		private int _statusID;
		private string _caseApplicationStatusName;
		private string _cardID;
		private string _cardTypeName;
		private int _cardType;
		private bool _isAppeal;
		private int _lawyerID;
		private string _lawyerFirstName;
		private string _lawyerlastName;
		private int _score;
		private int _temID;
		private bool _deletedFlag;
		private DateTime _dateKPIStart;
		private DateTime _dateKPIEnd;
		private int _lastKPIDay;
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
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
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
		public int ReferenceCaseID
		{
			get{ return _referenceCaseID; }
			set{ _referenceCaseID = value; }
		}
		public int ReferenceMSCID
		{
			get{ return _referenceMSCID; }
			set{ _referenceMSCID = value; }
		}
		public string ReferenceMSCCODE
		{
			get{ return _referenceMSCCODE; }
			set{ _referenceMSCCODE = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime RegisterDate
		{
			get{ return _registerDate; }
			set{ _registerDate = value; }
		}
		public string RegisterDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
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
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public double RequestAmount
		{
			get{ return _requestAmount; }
			set{ _requestAmount = value; }
		}
		public bool HasProxy
		{
			get{ return _hasProxy; }
			set{ _hasProxy = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		public string DateOfBirthStr { get; set; }
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		public string RaceName
		{
			get{ return _raceName; }
			set{ _raceName = value; }
		}
		public int NationalityID
		{
			get{ return _nationalityID; }
			set{ _nationalityID = value; }
		}
		public string NationalityName
		{
			get{ return _nationalityname; }
			set{ _nationalityname = value; }
		}
		public int ReligionID
		{
			get{ return _religionID; }
			set{ _religionID = value; }
		}
		public string ReligionName
		{
			get{ return _religionName; }
			set{ _religionName = value; }
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
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
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
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public string CardTypeName
		{
			get{ return _cardTypeName; }
			set{ _cardTypeName = value; }
		}
		public int CardType
		{
			get{ return _cardType; }
			set{ _cardType = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public string LawyerFirstName
		{
			get{ return _lawyerFirstName; }
			set{ _lawyerFirstName = value; }
		}
		public string LawyerLastName
		{
			get{ return _lawyerlastName; }
			set{ _lawyerlastName = value; }
		}
		public int Score
		{
			get{ return _score; }
			set{ _score = value; }
		}
		public int TemID
		{
			get{ return _temID; }
			set{ _temID = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
		public DateTime DateKPIStart
		{
			get{ return _dateKPIStart; }
			set{ _dateKPIStart = value; }
		}
		public string DateKPIStartStr { get; set; }
		public DateTime DateKPIEnd
		{
			get{ return _dateKPIEnd; }
			set{ _dateKPIEnd = value; }
		}
		public string DateKPIEndStr { get; set; }
		public int LastKPIDay
		{
			get{ return _lastKPIDay; }
			set{ _lastKPIDay = value; }
		}
	}
	[Serializable]
	public class View_ApplicationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicationRow[] view_ApplicationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicationItems : View_ApplicationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicationItems[] view_ApplicationItems { get; set; }
	}
}

