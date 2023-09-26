using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class View_TransactionRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private bool _contractNoNull = true;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private string _title;
		private bool _isSetTitle = false;
		private bool _titleNull = true;
		private string _firstName;
		private bool _isSetFirstName = false;
		private bool _firstNameNull = true;
		private string _lastName;
		private bool _isSetLastName = false;
		private bool _lastNameNull = true;
		private double _transactionAmount;
		private bool _isSetTransactionAmount = false;
		private bool _transactionAmountNull = true;
		private int _contractID;
		private bool _isSetContractID = false;
		private bool _contractIDNull = true;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		private string _formName;
		private bool _isSetFormName = false;
		private bool _formNameNull = true;
		private int _transactionStatusID;
		private bool _isSetTransactionStatusID = false;
		private string _transactionStatusName;
		private bool _isSetTransactionStatusName = false;
		private bool _transactionStatusNameNull = true;
		private int _transactiontypeID;
		private bool _isSetTransactionTypeID = false;
		private string _trasactiontypeDesc;
		private bool _isSetTrasactionTypeDesc = false;
		private string _redNo;
		private bool _isSetRedNo = false;
		private bool _redNoNull = true;
		private string _blackNo;
		private bool _isSetBlackNo = false;
		private bool _blackNoNull = true;
		private int _courID;
		private bool _isSetCourID = false;
		private bool _courIDNull = true;
		private string _courtName;
		private bool _isSetCourtName = false;
		private bool _courtNameNull = true;
		private string _transactionNo;
		private bool _isSetTransactionNo = false;
		private bool _transactionNoNull = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _departmentIdNull = true;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private bool _departmentNameNull = true;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _tranferDate;
		private bool _isSetTranferDate = false;
		private bool _tranferDateNull = true;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _workStepIDNull = true;
		private int _age;
		private bool _isSetAge = false;
		private bool _ageNull = true;
		private string _gender;
		private bool _isSetGender = false;
		private bool _genderNull = true;
		private string _cardID;
		private bool _isSetCardID = false;
		private bool _cardIDNull = true;
		private DateTime _dateOfBirth;
		private bool _isSetDateOfBirth = false;
		private bool _dateOfBirthNull = true;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private bool _jFCaseNoNull = true;
		private DateTime _paidDate;
		private bool _isSetPaidDate = false;
		private bool _paidDateNull = true;
		private double _totalAmountPaid;
		private bool _isSetTotalAmountPaid = false;
		private bool _totalAmountPaidNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _signingPlace;
		private bool _isSetSigningPlace = false;
		private bool _signingPlaceNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private bool _contractNoteNull = true;
		private string _note;
		private bool _isSetNote = false;
		private bool _noteNull = true;
		private string _financialOfficerNote;
		private bool _isSetFinancialOfficerNote = false;
		private bool _financialOfficerNoteNull = true;
		private string _payer;
		private bool _isSetPayer = false;
		private bool _payerNull = true;
		private string _payee;
		private bool _isSetPayee = false;
		private bool _payeeNull = true;
		private string _additionnalCourtName;
		private bool _isSetAdditionnalCourtName = false;
		private bool _additionnalCourtNameNull = true;
		private string _courtLevel;
		private bool _isSetCourtLevel = false;
		private bool _courtLevelNull = true;
		private string _lawyerAddressline;
		private bool _isSetLawyerAddressLine = false;
		private bool _lawyerAddresslineNull = true;
		private string _bankAccountName;
		private bool _isSetBankAccountName = false;
		private bool _bankAccountNameNull = true;
		private string _bankAccountNo;
		private bool _isSetBankAccountNo = false;
		private bool _bankAccountNoNull = true;
		private string _bankName;
		private bool _isSetBankName = false;
		private bool _bankNameNull = true;
		private string _bankbranch;
		private bool _isSetBankBranch = false;
		private bool _bankbranchNull = true;
		private string _bankAccountType;
		private bool _isSetBankAccountType = false;
		private bool _bankAccountTypeNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _deleteFlag;
		private bool _isSetDeleteFlag = false;
		private bool _deleteFlagNull = true;
		private DateTime _transactionDate;
		private bool _isSetTransactionDate = false;
		private bool _transactionDateNull = true;
		private string _paymentListJson;
		private bool _isSetPaymentListJson = false;
		private bool _paymentListJsonNull = true;
		private string _transactionDetail;
		private bool _isSetTransactionDetail = false;
		private bool _transactionDetailNull = true;
		private bool _isCancel;
		private bool _isSetIsCancel = false;
		private bool _isCancelNull = true;
		private int _refTransactionID;
		private bool _isSetRefTransactionID = false;
		private bool _refTransactionIDNull = true;
		private string _refTransactionNo;
		private bool _isSetRefTransactionNo = false;
		private bool _refTransactionNoNull = true;
		private DateTime _jFPortalReceiveDate;
		private bool _isSetJFPortalReceiveDate = false;
		private bool _jFPortalReceiveDateNull = true;
		private bool _isRequestRefund;
		private bool _isSetIsRequestRefund = false;
		private bool _isRequestRefundNull = true;
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
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isMapRecord = false;
			      _isSetTransactionID = true; }
		}
		public Boolean _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		public string ContractNo
		{
			get
			{
				return _contractNo;
			}
			set
			{
				_contractNoNull = false;
				_isSetContractNo = true;
				_contractNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsContractNoNull
		{
			get {
				 return _contractNoNull; }
			set { _contractNoNull = value; }
		}
		public Boolean _IsSetContractNo
		{
			get { return _isSetContractNo; }
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
		public double TransactionAmount
		{
			get
			{
				return _transactionAmount;
			}
			set
			{
				_transactionAmountNull = false;
				_isSetTransactionAmount = true;
				_transactionAmount = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionAmountNull
		{
			get {
				 return _transactionAmountNull; }
			set { _transactionAmountNull = value; }
		}
		public Boolean _IsSetTransactionAmount
		{
			get { return _isSetTransactionAmount; }
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
				_isMapRecord = false;
			}
		}
		public bool IsContractIDNull
		{
			get {
				 return _contractIDNull; }
			set { _contractIDNull = value; }
		}
		public Boolean _IsSetContractID
		{
			get { return _isSetContractID; }
		}
		public int FormID
		{
			get
			{
				return _formID;
			}
			set
			{
				_formIDNull = false;
				_isSetFormID = true;
				_formID = value;
				_isMapRecord = false;
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public Boolean _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		public string FormName
		{
			get
			{
				return _formName;
			}
			set
			{
				_formNameNull = false;
				_isSetFormName = true;
				_formName = value;
				_isMapRecord = false;
			}
		}
		public bool IsFormNameNull
		{
			get {
				 return _formNameNull; }
			set { _formNameNull = value; }
		}
		public Boolean _IsSetFormName
		{
			get { return _isSetFormName; }
		}
		[Required]
		public int TransactionStatusID
		{
			get { return _transactionStatusID; }
			set { _transactionStatusID = value;
			      _isMapRecord = false;
			      _isSetTransactionStatusID = true; }
		}
		public Boolean _IsSetTransactionStatusID
		{
			get { return _isSetTransactionStatusID; }
		}
		public string TransactionStatusName
		{
			get
			{
				return _transactionStatusName;
			}
			set
			{
				_transactionStatusNameNull = false;
				_isSetTransactionStatusName = true;
				_transactionStatusName = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionStatusNameNull
		{
			get {
				 return _transactionStatusNameNull; }
			set { _transactionStatusNameNull = value; }
		}
		public Boolean _IsSetTransactionStatusName
		{
			get { return _isSetTransactionStatusName; }
		}
		[Required]
		public int TransactionTypeID
		{
			get { return _transactiontypeID; }
			set { _transactiontypeID = value;
			      _isMapRecord = false;
			      _isSetTransactionTypeID = true; }
		}
		public Boolean _IsSetTransactionTypeID
		{
			get { return _isSetTransactionTypeID; }
		}
		[Required]
		public string TrasactionTypeDesc
		{
			get { return _trasactiontypeDesc; }
			set { _trasactiontypeDesc = value;
			      _isMapRecord = false;
			      _isSetTrasactionTypeDesc = true; }
		}
		public Boolean _IsSetTrasactionTypeDesc
		{
			get { return _isSetTrasactionTypeDesc; }
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
				_isMapRecord = false;
			}
		}
		public bool IsCourIDNull
		{
			get {
				 return _courIDNull; }
			set { _courIDNull = value; }
		}
		public Boolean _IsSetCourID
		{
			get { return _isSetCourID; }
		}
		public string CourtName
		{
			get
			{
				return _courtName;
			}
			set
			{
				_courtNameNull = false;
				_isSetCourtName = true;
				_courtName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCourtNameNull
		{
			get {
				 return _courtNameNull; }
			set { _courtNameNull = value; }
		}
		public Boolean _IsSetCourtName
		{
			get { return _isSetCourtName; }
		}
		public string TransactionNo
		{
			get
			{
				return _transactionNo;
			}
			set
			{
				_transactionNoNull = false;
				_isSetTransactionNo = true;
				_transactionNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionNoNull
		{
			get {
				 return _transactionNoNull; }
			set { _transactionNoNull = value; }
		}
		public Boolean _IsSetTransactionNo
		{
			get { return _isSetTransactionNo; }
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
		public DateTime TranferDate
		{
			get
			{
				return _tranferDate;
			}
			set
			{
				_tranferDateNull = false;
				_isSetTranferDate = true;
				_tranferDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsTranferDateNull
		{
			get {
				 return _tranferDateNull; }
			set { _tranferDateNull = value; }
		}
		public Boolean _IsSetTranferDate
		{
			get { return _isSetTranferDate; }
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
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_ageNull = false;
				_isSetAge = true;
				_age = value;
				_isMapRecord = false;
			}
		}
		public bool IsAgeNull
		{
			get {
				 return _ageNull; }
			set { _ageNull = value; }
		}
		public Boolean _IsSetAge
		{
			get { return _isSetAge; }
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
		public DateTime PaidDate
		{
			get
			{
				return _paidDate;
			}
			set
			{
				_paidDateNull = false;
				_isSetPaidDate = true;
				_paidDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsPaidDateNull
		{
			get {
				 return _paidDateNull; }
			set { _paidDateNull = value; }
		}
		public Boolean _IsSetPaidDate
		{
			get { return _isSetPaidDate; }
		}
		public double TotalAmountPaid
		{
			get
			{
				return _totalAmountPaid;
			}
			set
			{
				_totalAmountPaidNull = false;
				_isSetTotalAmountPaid = true;
				_totalAmountPaid = value;
				_isMapRecord = false;
			}
		}
		public bool IsTotalAmountPaidNull
		{
			get {
				 return _totalAmountPaidNull; }
			set { _totalAmountPaidNull = value; }
		}
		public Boolean _IsSetTotalAmountPaid
		{
			get { return _isSetTotalAmountPaid; }
		}
		public double Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amountNull = false;
				_isSetAmount = true;
				_amount = value;
				_isMapRecord = false;
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public Boolean _IsSetAmount
		{
			get { return _isSetAmount; }
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
				_isMapRecord = false;
			}
		}
		public bool IsContractDateNull
		{
			get {
				 return _contractDateNull; }
			set { _contractDateNull = value; }
		}
		public Boolean _IsSetContractDate
		{
			get { return _isSetContractDate; }
		}
		public string SigningPlace
		{
			get
			{
				return _signingPlace;
			}
			set
			{
				_signingPlaceNull = false;
				_isSetSigningPlace = true;
				_signingPlace = value;
				_isMapRecord = false;
			}
		}
		public bool IsSigningPlaceNull
		{
			get {
				 return _signingPlaceNull; }
			set { _signingPlaceNull = value; }
		}
		public Boolean _IsSetSigningPlace
		{
			get { return _isSetSigningPlace; }
		}
		public string ContractNote
		{
			get
			{
				return _contractNote;
			}
			set
			{
				_contractNoteNull = false;
				_isSetContractNote = true;
				_contractNote = value;
				_isMapRecord = false;
			}
		}
		public bool IsContractNoteNull
		{
			get {
				 return _contractNoteNull; }
			set { _contractNoteNull = value; }
		}
		public Boolean _IsSetContractNote
		{
			get { return _isSetContractNote; }
		}
		public string Note
		{
			get
			{
				return _note;
			}
			set
			{
				_noteNull = false;
				_isSetNote = true;
				_note = value;
				_isMapRecord = false;
			}
		}
		public bool IsNoteNull
		{
			get {
				 return _noteNull; }
			set { _noteNull = value; }
		}
		public Boolean _IsSetNote
		{
			get { return _isSetNote; }
		}
		public string FinancialOfficerNote
		{
			get
			{
				return _financialOfficerNote;
			}
			set
			{
				_financialOfficerNoteNull = false;
				_isSetFinancialOfficerNote = true;
				_financialOfficerNote = value;
				_isMapRecord = false;
			}
		}
		public bool IsFinancialOfficerNoteNull
		{
			get {
				 return _financialOfficerNoteNull; }
			set { _financialOfficerNoteNull = value; }
		}
		public Boolean _IsSetFinancialOfficerNote
		{
			get { return _isSetFinancialOfficerNote; }
		}
		public string Payer
		{
			get
			{
				return _payer;
			}
			set
			{
				_payerNull = false;
				_isSetPayer = true;
				_payer = value;
				_isMapRecord = false;
			}
		}
		public bool IsPayerNull
		{
			get {
				 return _payerNull; }
			set { _payerNull = value; }
		}
		public Boolean _IsSetPayer
		{
			get { return _isSetPayer; }
		}
		public string Payee
		{
			get
			{
				return _payee;
			}
			set
			{
				_payeeNull = false;
				_isSetPayee = true;
				_payee = value;
				_isMapRecord = false;
			}
		}
		public bool IsPayeeNull
		{
			get {
				 return _payeeNull; }
			set { _payeeNull = value; }
		}
		public Boolean _IsSetPayee
		{
			get { return _isSetPayee; }
		}
		public string AdditionnalCourtName
		{
			get
			{
				return _additionnalCourtName;
			}
			set
			{
				_additionnalCourtNameNull = false;
				_isSetAdditionnalCourtName = true;
				_additionnalCourtName = value;
				_isMapRecord = false;
			}
		}
		public bool IsAdditionnalCourtNameNull
		{
			get {
				 return _additionnalCourtNameNull; }
			set { _additionnalCourtNameNull = value; }
		}
		public Boolean _IsSetAdditionnalCourtName
		{
			get { return _isSetAdditionnalCourtName; }
		}
		public string CourtLevel
		{
			get
			{
				return _courtLevel;
			}
			set
			{
				_courtLevelNull = false;
				_isSetCourtLevel = true;
				_courtLevel = value;
				_isMapRecord = false;
			}
		}
		public bool IsCourtLevelNull
		{
			get {
				 return _courtLevelNull; }
			set { _courtLevelNull = value; }
		}
		public Boolean _IsSetCourtLevel
		{
			get { return _isSetCourtLevel; }
		}
		public string LawyerAddressLine
		{
			get
			{
				return _lawyerAddressline;
			}
			set
			{
				_lawyerAddresslineNull = false;
				_isSetLawyerAddressLine = true;
				_lawyerAddressline = value;
				_isMapRecord = false;
			}
		}
		public bool IsLawyerAddressLineNull
		{
			get {
				 return _lawyerAddresslineNull; }
			set { _lawyerAddresslineNull = value; }
		}
		public Boolean _IsSetLawyerAddressLine
		{
			get { return _isSetLawyerAddressLine; }
		}
		public string BankAccountName
		{
			get
			{
				return _bankAccountName;
			}
			set
			{
				_bankAccountNameNull = false;
				_isSetBankAccountName = true;
				_bankAccountName = value;
				_isMapRecord = false;
			}
		}
		public bool IsBankAccountNameNull
		{
			get {
				 return _bankAccountNameNull; }
			set { _bankAccountNameNull = value; }
		}
		public Boolean _IsSetBankAccountName
		{
			get { return _isSetBankAccountName; }
		}
		public string BankAccountNo
		{
			get
			{
				return _bankAccountNo;
			}
			set
			{
				_bankAccountNoNull = false;
				_isSetBankAccountNo = true;
				_bankAccountNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsBankAccountNoNull
		{
			get {
				 return _bankAccountNoNull; }
			set { _bankAccountNoNull = value; }
		}
		public Boolean _IsSetBankAccountNo
		{
			get { return _isSetBankAccountNo; }
		}
		public string BankName
		{
			get
			{
				return _bankName;
			}
			set
			{
				_bankNameNull = false;
				_isSetBankName = true;
				_bankName = value;
				_isMapRecord = false;
			}
		}
		public bool IsBankNameNull
		{
			get {
				 return _bankNameNull; }
			set { _bankNameNull = value; }
		}
		public Boolean _IsSetBankName
		{
			get { return _isSetBankName; }
		}
		public string BankBranch
		{
			get
			{
				return _bankbranch;
			}
			set
			{
				_bankbranchNull = false;
				_isSetBankBranch = true;
				_bankbranch = value;
				_isMapRecord = false;
			}
		}
		public bool IsBankBranchNull
		{
			get {
				 return _bankbranchNull; }
			set { _bankbranchNull = value; }
		}
		public Boolean _IsSetBankBranch
		{
			get { return _isSetBankBranch; }
		}
		public string BankAccountType
		{
			get
			{
				return _bankAccountType;
			}
			set
			{
				_bankAccountTypeNull = false;
				_isSetBankAccountType = true;
				_bankAccountType = value;
				_isMapRecord = false;
			}
		}
		public bool IsBankAccountTypeNull
		{
			get {
				 return _bankAccountTypeNull; }
			set { _bankAccountTypeNull = value; }
		}
		public Boolean _IsSetBankAccountType
		{
			get { return _isSetBankAccountType; }
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
		public bool DeleteFlag
		{
			get
			{
				return _deleteFlag;
			}
			set
			{
				_deleteFlagNull = false;
				_isSetDeleteFlag = true;
				_deleteFlag = value;
				_isMapRecord = false;
			}
		}
		public bool IsDeleteFlagNull
		{
			get {
				 return _deleteFlagNull; }
			set { _deleteFlagNull = value; }
		}
		public Boolean _IsSetDeleteFlag
		{
			get { return _isSetDeleteFlag; }
		}
		public DateTime TransactionDate
		{
			get
			{
				return _transactionDate;
			}
			set
			{
				_transactionDateNull = false;
				_isSetTransactionDate = true;
				_transactionDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionDateNull
		{
			get {
				 return _transactionDateNull; }
			set { _transactionDateNull = value; }
		}
		public Boolean _IsSetTransactionDate
		{
			get { return _isSetTransactionDate; }
		}
		public string PaymentListJson
		{
			get
			{
				return _paymentListJson;
			}
			set
			{
				_paymentListJsonNull = false;
				_isSetPaymentListJson = true;
				_paymentListJson = value;
				_isMapRecord = false;
			}
		}
		public bool IsPaymentListJsonNull
		{
			get {
				 return _paymentListJsonNull; }
			set { _paymentListJsonNull = value; }
		}
		public Boolean _IsSetPaymentListJson
		{
			get { return _isSetPaymentListJson; }
		}
		public string TransactionDetail
		{
			get
			{
				return _transactionDetail;
			}
			set
			{
				_transactionDetailNull = false;
				_isSetTransactionDetail = true;
				_transactionDetail = value;
				_isMapRecord = false;
			}
		}
		public bool IsTransactionDetailNull
		{
			get {
				 return _transactionDetailNull; }
			set { _transactionDetailNull = value; }
		}
		public Boolean _IsSetTransactionDetail
		{
			get { return _isSetTransactionDetail; }
		}
		public bool IsCancel
		{
			get
			{
				return _isCancel;
			}
			set
			{
				_isCancelNull = false;
				_isSetIsCancel = true;
				_isCancel = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsCancelNull
		{
			get {
				 return _isCancelNull; }
			set { _isCancelNull = value; }
		}
		public Boolean _IsSetIsCancel
		{
			get { return _isSetIsCancel; }
		}
		public int RefTransactionID
		{
			get
			{
				return _refTransactionID;
			}
			set
			{
				_refTransactionIDNull = false;
				_isSetRefTransactionID = true;
				_refTransactionID = value;
				_isMapRecord = false;
			}
		}
		public bool IsRefTransactionIDNull
		{
			get {
				 return _refTransactionIDNull; }
			set { _refTransactionIDNull = value; }
		}
		public Boolean _IsSetRefTransactionID
		{
			get { return _isSetRefTransactionID; }
		}
		public string RefTransactionNo
		{
			get
			{
				return _refTransactionNo;
			}
			set
			{
				_refTransactionNoNull = false;
				_isSetRefTransactionNo = true;
				_refTransactionNo = value;
				_isMapRecord = false;
			}
		}
		public bool IsRefTransactionNoNull
		{
			get {
				 return _refTransactionNoNull; }
			set { _refTransactionNoNull = value; }
		}
		public Boolean _IsSetRefTransactionNo
		{
			get { return _isSetRefTransactionNo; }
		}
		public DateTime JFPortalReceiveDate
		{
			get
			{
				return _jFPortalReceiveDate;
			}
			set
			{
				_jFPortalReceiveDateNull = false;
				_isSetJFPortalReceiveDate = true;
				_jFPortalReceiveDate = value;
				_isMapRecord = false;
			}
		}
		public bool IsJFPortalReceiveDateNull
		{
			get {
				 return _jFPortalReceiveDateNull; }
			set { _jFPortalReceiveDateNull = value; }
		}
		public Boolean _IsSetJFPortalReceiveDate
		{
			get { return _isSetJFPortalReceiveDate; }
		}
		public bool IsRequestRefund
		{
			get
			{
				return _isRequestRefund;
			}
			set
			{
				_isRequestRefundNull = false;
				_isSetIsRequestRefund = true;
				_isRequestRefund = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsRequestRefundNull
		{
			get {
				 return _isRequestRefundNull; }
			set { _isRequestRefundNull = value; }
		}
		public Boolean _IsSetIsRequestRefund
		{
			get { return _isSetIsRequestRefund; }
		}
	}
	[Serializable]
	public class View_TransactionData
	{
		private int _transactionID;
		private string _contractNo;
		private int _caseID;
		private int _applicantID;
		private string _title;
		private string _firstName;
		private string _lastName;
		private double _transactionAmount;
		private int _contractID;
		private int _formID;
		private string _formName;
		private int _transactionStatusID;
		private string _transactionStatusName;
		private int _transactiontypeID;
		private string _trasactiontypeDesc;
		private string _redNo;
		private string _blackNo;
		private int _courID;
		private string _courtName;
		private string _transactionNo;
		private int _departmentId;
		private string _departmentName;
		private DateTime _createDate;
		private DateTime _tranferDate;
		private int _workStepID;
		private int _age;
		private string _gender;
		private string _cardID;
		private DateTime _dateOfBirth;
		private string _jFCaseNo;
		private DateTime _paidDate;
		private double _totalAmountPaid;
		private double _amount;
		private DateTime _contractDate;
		private string _signingPlace;
		private string _contractNote;
		private string _note;
		private string _financialOfficerNote;
		private string _payer;
		private string _payee;
		private string _additionnalCourtName;
		private string _courtLevel;
		private string _lawyerAddressline;
		private string _bankAccountName;
		private string _bankAccountNo;
		private string _bankName;
		private string _bankbranch;
		private string _bankAccountType;
		private DateTime _modifiedDate;
		private bool _deleteFlag;
		private DateTime _transactionDate;
		private string _paymentListJson;
		private string _transactionDetail;
		private bool _isCancel;
		private int _refTransactionID;
		private string _refTransactionNo;
		private DateTime _jFPortalReceiveDate;
		private bool _isRequestRefund;
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string ContractNo
		{
			get{ return _contractNo; }
			set{ _contractNo = value; }
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
		public double TransactionAmount
		{
			get{ return _transactionAmount; }
			set{ _transactionAmount = value; }
		}
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string FormName
		{
			get{ return _formName; }
			set{ _formName = value; }
		}
		public int TransactionStatusID
		{
			get{ return _transactionStatusID; }
			set{ _transactionStatusID = value; }
		}
		public string TransactionStatusName
		{
			get{ return _transactionStatusName; }
			set{ _transactionStatusName = value; }
		}
		public int TransactionTypeID
		{
			get{ return _transactiontypeID; }
			set{ _transactiontypeID = value; }
		}
		public string TrasactionTypeDesc
		{
			get{ return _trasactiontypeDesc; }
			set{ _trasactiontypeDesc = value; }
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
		public int CourID
		{
			get{ return _courID; }
			set{ _courID = value; }
		}
		public string CourtName
		{
			get{ return _courtName; }
			set{ _courtName = value; }
		}
		public string TransactionNo
		{
			get{ return _transactionNo; }
			set{ _transactionNo = value; }
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
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime TranferDate
		{
			get{ return _tranferDate; }
			set{ _tranferDate = value; }
		}
		public string TranferDateStr { get; set; }
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public int Age
		{
			get{ return _age; }
			set{ _age = value; }
		}
		public string Gender
		{
			get{ return _gender; }
			set{ _gender = value; }
		}
		public string CardID
		{
			get{ return _cardID; }
			set{ _cardID = value; }
		}
		public DateTime DateOfBirth
		{
			get{ return _dateOfBirth; }
			set{ _dateOfBirth = value; }
		}
		public string DateOfBirthStr { get; set; }
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		public DateTime PaidDate
		{
			get{ return _paidDate; }
			set{ _paidDate = value; }
		}
		public string PaidDateStr { get; set; }
		public double TotalAmountPaid
		{
			get{ return _totalAmountPaid; }
			set{ _totalAmountPaid = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public DateTime ContractDate
		{
			get{ return _contractDate; }
			set{ _contractDate = value; }
		}
		public string ContractDateStr { get; set; }
		public string SigningPlace
		{
			get{ return _signingPlace; }
			set{ _signingPlace = value; }
		}
		public string ContractNote
		{
			get{ return _contractNote; }
			set{ _contractNote = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public string FinancialOfficerNote
		{
			get{ return _financialOfficerNote; }
			set{ _financialOfficerNote = value; }
		}
		public string Payer
		{
			get{ return _payer; }
			set{ _payer = value; }
		}
		public string Payee
		{
			get{ return _payee; }
			set{ _payee = value; }
		}
		public string AdditionnalCourtName
		{
			get{ return _additionnalCourtName; }
			set{ _additionnalCourtName = value; }
		}
		public string CourtLevel
		{
			get{ return _courtLevel; }
			set{ _courtLevel = value; }
		}
		public string LawyerAddressLine
		{
			get{ return _lawyerAddressline; }
			set{ _lawyerAddressline = value; }
		}
		public string BankAccountName
		{
			get{ return _bankAccountName; }
			set{ _bankAccountName = value; }
		}
		public string BankAccountNo
		{
			get{ return _bankAccountNo; }
			set{ _bankAccountNo = value; }
		}
		public string BankName
		{
			get{ return _bankName; }
			set{ _bankName = value; }
		}
		public string BankBranch
		{
			get{ return _bankbranch; }
			set{ _bankbranch = value; }
		}
		public string BankAccountType
		{
			get{ return _bankAccountType; }
			set{ _bankAccountType = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool DeleteFlag
		{
			get{ return _deleteFlag; }
			set{ _deleteFlag = value; }
		}
		public DateTime TransactionDate
		{
			get{ return _transactionDate; }
			set{ _transactionDate = value; }
		}
		public string TransactionDateStr { get; set; }
		public string PaymentListJson
		{
			get{ return _paymentListJson; }
			set{ _paymentListJson = value; }
		}
		public string TransactionDetail
		{
			get{ return _transactionDetail; }
			set{ _transactionDetail = value; }
		}
		public bool IsCancel
		{
			get{ return _isCancel; }
			set{ _isCancel = value; }
		}
		public int RefTransactionID
		{
			get{ return _refTransactionID; }
			set{ _refTransactionID = value; }
		}
		public string RefTransactionNo
		{
			get{ return _refTransactionNo; }
			set{ _refTransactionNo = value; }
		}
		public DateTime JFPortalReceiveDate
		{
			get{ return _jFPortalReceiveDate; }
			set{ _jFPortalReceiveDate = value; }
		}
		public string JFPortalReceiveDateStr { get; set; }
		public bool IsRequestRefund
		{
			get{ return _isRequestRefund; }
			set{ _isRequestRefund = value; }
		}
	}
	[Serializable]
	public class View_TransactionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_TransactionRow[] view_TransactionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_TransactionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_TransactionItems : View_TransactionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_TransactionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_TransactionItems[] view_TransactionItems { get; set; }
	}
}

