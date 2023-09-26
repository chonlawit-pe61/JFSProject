using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ContractFormRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private DateTime _signingDate;
		private bool _isSetSigningDate = false;
		private bool _signingDateNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _formName;
		private bool _isSetFormName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isReviewNull = true;
		private string _formTypeName;
		private bool _isSetFormTypeName = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private bool _activeForm;
		private bool _isSetActiveForm = false;
		private bool _activeFormNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
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
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public bool _IsSetAmount
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
		public DateTime SigningDate
		{
			get
			{
				return _signingDate;
			}
			set
			{
				_signingDateNull = false;
				_isSetSigningDate = true;
				_signingDate = value;
			}
		}
		public bool IsSigningDateNull
		{
			get {
				 return _signingDateNull; }
			set { _signingDateNull = value; }
		}
		public bool _IsSetSigningDate
		{
			get { return _isSetSigningDate; }
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
		public string Remark
		{
			get { return _remark; }
			set { _remark = value;
			      _isSetRemark = true; }
		}
		public bool _IsSetRemark
		{
			get { return _isSetRemark; }
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
		[Required]
		public string FormName
		{
			get { return _formName; }
			set { _formName = value;
			      _isSetFormName = true; }
		}
		public bool _IsSetFormName
		{
			get { return _isSetFormName; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		public bool IsReview
		{
			get
			{
				return _isReview;
			}
			set
			{
				_isReviewNull = false;
				_isSetIsReview = true;
				_isReview = value;
			}
		}
		public bool IsIsReviewNull
		{
			get {
				 return _isReviewNull; }
			set { _isReviewNull = value; }
		}
		public bool _IsSetIsReview
		{
			get { return _isSetIsReview; }
		}
		public string FormTypeName
		{
			get { return _formTypeName; }
			set { _formTypeName = value;
			      _isSetFormTypeName = true; }
		}
		public bool _IsSetFormTypeName
		{
			get { return _isSetFormTypeName; }
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
		public bool ActiveForm
		{
			get
			{
				return _activeForm;
			}
			set
			{
				_activeFormNull = false;
				_isSetActiveForm = true;
				_activeForm = value;
			}
		}
		public bool IsActiveFormNull
		{
			get {
				 return _activeFormNull; }
			set { _activeFormNull = value; }
		}
		public bool _IsSetActiveForm
		{
			get { return _isSetActiveForm; }
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
	}
	[Serializable]
	public class View_ContractFormData
	{
		private int _contractID;
		private int _caseID;
		private int _applicantID;
		private int _formID;
		private string _contractNo;
		private double _amount;
		private DateTime _contractDate;
		private DateTime _signingDate;
		private string _contractNote;
		private string _remark;
		private DateTime _modifiedDate;
		private string _formName;
		private int _sortOrder;
		private bool _isReview;
		private string _formTypeName;
		private int _departmentId;
		private bool _activeForm;
		private bool _isActive;
		public int ContractID
		{
			get{ return _contractID; }
			set{ _contractID = value; }
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
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ContractDateStr { get; set; }
		public DateTime SigningDate
		{
			get{ return _signingDate; }
			set{ _signingDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string SigningDateStr { get; set; }
		public string ContractNote
		{
			get{ return _contractNote; }
			set{ _contractNote = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
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
		public string FormName
		{
			get{ return _formName; }
			set{ _formName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsReview
		{
			get{ return _isReview; }
			set{ _isReview = value; }
		}
		public string FormTypeName
		{
			get{ return _formTypeName; }
			set{ _formTypeName = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public bool ActiveForm
		{
			get{ return _activeForm; }
			set{ _activeForm = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class View_ContractFormPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ContractFormRow[] view_ContractFormRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ContractFormItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ContractFormItems : View_ContractFormData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ContractFormItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ContractFormItems[] view_ContractFormItems { get; set; }
	}
}

