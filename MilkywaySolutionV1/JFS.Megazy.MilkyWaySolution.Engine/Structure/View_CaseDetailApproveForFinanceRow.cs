using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_CaseDetailApproveForFinanceRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private bool _isFinalApproved;
		private bool _isSetIsFinalApproved = false;
		private bool _isFinalApprovedNull = true;
		private int _opinionID;
		private bool _isSetOpinionID = false;
		private bool _opinionIDNull = true;
		private string _opinionName;
		private bool _isSetOpinionName = false;
		private bool _opinionNameNull = true;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
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
		private int _temID;
		private bool _isSetTemID = false;
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private bool _subcommitteeIDNull = true;
		private string _subcommitteeName;
		private bool _isSetSubcommitteeName = false;
		private bool _subcommitteeNameNull = true;
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private bool _budgetIDNull = true;
		private string _budgetName;
		private bool _isSetBudgetName = false;
		private bool _budgetNameNull = true;
		private int _approveByID;
		private bool _isSetApproveByID = false;
		private bool _approveByIDNull = true;
		private string _approveBy;
		private bool _isSetApproveBy = false;
		private bool _approveByNull = true;
		private double _totalAmount;
		private bool _isSetTotalAmount = false;
		private bool _totalAmountNull = true;
		private string _redNo;
		private bool _isSetRedNo = false;
		private bool _redNoNull = true;
		private string _blackNo;
		private bool _isSetBlackNo = false;
		private bool _blackNoNull = true;
		private bool _deletedFlag;
		private bool _isSetDeletedFlag = false;
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
		public bool IsFinalApproved
		{
			get
			{
				return _isFinalApproved;
			}
			set
			{
				_isFinalApprovedNull = false;
				_isSetIsFinalApproved = true;
				_isFinalApproved = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsFinalApprovedNull
		{
			get {
				 return _isFinalApprovedNull; }
			set { _isFinalApprovedNull = value; }
		}
		public Boolean _IsSetIsFinalApproved
		{
			get { return _isSetIsFinalApproved; }
		}
		public int OpinionID
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
				_isMapRecord = false;
			}
		}
		public bool IsOpinionIDNull
		{
			get {
				 return _opinionIDNull; }
			set { _opinionIDNull = value; }
		}
		public Boolean _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
		}
		public string OpinionName
		{
			get
			{
				return _opinionName;
			}
			set
			{
				_opinionNameNull = false;
				_isSetOpinionName = true;
				_opinionName = value;
				_isMapRecord = false;
			}
		}
		public bool IsOpinionNameNull
		{
			get {
				 return _opinionNameNull; }
			set { _opinionNameNull = value; }
		}
		public Boolean _IsSetOpinionName
		{
			get { return _isSetOpinionName; }
		}
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isMapRecord = false;
			      _isSetOfficerRoleID = true; }
		}
		public Boolean _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
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
		public int SubcommitteeID
		{
			get
			{
				return _subcommitteeID;
			}
			set
			{
				_subcommitteeIDNull = false;
				_isSetSubcommitteeID = true;
				_subcommitteeID = value;
				_isMapRecord = false;
			}
		}
		public bool IsSubcommitteeIDNull
		{
			get {
				 return _subcommitteeIDNull; }
			set { _subcommitteeIDNull = value; }
		}
		public Boolean _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
		}
		public string SubcommitteeName
		{
			get
			{
				return _subcommitteeName;
			}
			set
			{
				_subcommitteeNameNull = false;
				_isSetSubcommitteeName = true;
				_subcommitteeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsSubcommitteeNameNull
		{
			get {
				 return _subcommitteeNameNull; }
			set { _subcommitteeNameNull = value; }
		}
		public Boolean _IsSetSubcommitteeName
		{
			get { return _isSetSubcommitteeName; }
		}
		public int BudgetID
		{
			get
			{
				return _budgetID;
			}
			set
			{
				_budgetIDNull = false;
				_isSetBudgetID = true;
				_budgetID = value;
				_isMapRecord = false;
			}
		}
		public bool IsBudgetIDNull
		{
			get {
				 return _budgetIDNull; }
			set { _budgetIDNull = value; }
		}
		public Boolean _IsSetBudgetID
		{
			get { return _isSetBudgetID; }
		}
		public string BudgetName
		{
			get
			{
				return _budgetName;
			}
			set
			{
				_budgetNameNull = false;
				_isSetBudgetName = true;
				_budgetName = value;
				_isMapRecord = false;
			}
		}
		public bool IsBudgetNameNull
		{
			get {
				 return _budgetNameNull; }
			set { _budgetNameNull = value; }
		}
		public Boolean _IsSetBudgetName
		{
			get { return _isSetBudgetName; }
		}
		public int ApproveByID
		{
			get
			{
				return _approveByID;
			}
			set
			{
				_approveByIDNull = false;
				_isSetApproveByID = true;
				_approveByID = value;
				_isMapRecord = false;
			}
		}
		public bool IsApproveByIDNull
		{
			get {
				 return _approveByIDNull; }
			set { _approveByIDNull = value; }
		}
		public Boolean _IsSetApproveByID
		{
			get { return _isSetApproveByID; }
		}
		public string ApproveBy
		{
			get
			{
				return _approveBy;
			}
			set
			{
				_approveByNull = false;
				_isSetApproveBy = true;
				_approveBy = value;
				_isMapRecord = false;
			}
		}
		public bool IsApproveByNull
		{
			get {
				 return _approveByNull; }
			set { _approveByNull = value; }
		}
		public Boolean _IsSetApproveBy
		{
			get { return _isSetApproveBy; }
		}
		public double TotalAmount
		{
			get
			{
				return _totalAmount;
			}
			set
			{
				_totalAmountNull = false;
				_isSetTotalAmount = true;
				_totalAmount = value;
				_isMapRecord = false;
			}
		}
		public bool IsTotalAmountNull
		{
			get {
				 return _totalAmountNull; }
			set { _totalAmountNull = value; }
		}
		public Boolean _IsSetTotalAmount
		{
			get { return _isSetTotalAmount; }
		}
		public string RedNo
		{
			get
			{
				return _redNo;
			}
			set
			{
				_redNoNull = false;
				_isSetRedNo = true;
				_redNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsRedNoNull
		{
			get {
				 return _redNoNull; }
			set { _redNoNull = value; }
		}
		public Boolean _IsSetRedNo
		{
			get { return _isSetRedNo; }
		}
		public string BlackNo
		{
			get
			{
				return _blackNo;
			}
			set
			{
				_blackNoNull = false;
				_isSetBlackNo = true;
				_blackNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsBlackNoNull
		{
			get {
				 return _blackNoNull; }
			set { _blackNoNull = value; }
		}
		public Boolean _IsSetBlackNo
		{
			get { return _isSetBlackNo; }
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
	}
	[Serializable]
	public class View_CaseDetailApproveForFinanceData
	{
		private int _caseID;
		private int _applicantID;
		private string _jFCaseNo;
		private bool _isFinalApproved;
		private int _opinionID;
		private string _opinionName;
		private int _officerRoleID;
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
		private int _temID;
		private int _subcommitteeID;
		private string _subcommitteeName;
		private int _budgetID;
		private string _budgetName;
		private int _approveByID;
		private string _approveBy;
		private double _totalAmount;
		private string _redNo;
		private string _blackNo;
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
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		public bool IsFinalApproved
		{
			get{ return _isFinalApproved; }
			set{ _isFinalApproved = value; }
		}
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		public string OpinionName
		{
			get{ return _opinionName; }
			set{ _opinionName = value; }
		}
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
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
		public int TemID
		{
			get{ return _temID; }
			set{ _temID = value; }
		}
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		public string SubcommitteeName
		{
			get{ return _subcommitteeName; }
			set{ _subcommitteeName = value; }
		}
		public int BudgetID
		{
			get{ return _budgetID; }
			set{ _budgetID = value; }
		}
		public string BudgetName
		{
			get{ return _budgetName; }
			set{ _budgetName = value; }
		}
		public int ApproveByID
		{
			get{ return _approveByID; }
			set{ _approveByID = value; }
		}
		public string ApproveBy
		{
			get{ return _approveBy; }
			set{ _approveBy = value; }
		}
		public double TotalAmount
		{
			get{ return _totalAmount; }
			set{ _totalAmount = value; }
		}
		public string RedNo
		{
			get{ return _redNo; }
			set{ _redNo = value; }
		}
		public string BlackNo
		{
			get{ return _blackNo; }
			set{ _blackNo = value; }
		}
		public bool DeletedFlag
		{
			get{ return _deletedFlag; }
			set{ _deletedFlag = value; }
		}
	}
	[Serializable]
	public class View_CaseDetailApproveForFinancePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_CaseDetailApproveForFinanceRow[] view_CaseDetailApproveForFinanceRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_CaseDetailApproveForFinanceItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_CaseDetailApproveForFinanceItems : View_CaseDetailApproveForFinanceData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_CaseDetailApproveForFinanceItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_CaseDetailApproveForFinanceItems[] view_CaseDetailApproveForFinanceItems { get; set; }
	}
}

