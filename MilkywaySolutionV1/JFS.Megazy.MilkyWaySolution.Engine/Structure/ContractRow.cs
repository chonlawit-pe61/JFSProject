using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _contractID;
		private bool _isSetContractID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private bool _contractNoNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _signingPlace;
		private bool _isSetSigningPlace = false;
		private bool _signingPlaceNull = true;
		private DateTime _signingDate;
		private bool _isSetSigningDate = false;
		private bool _signingDateNull = true;
		private string _powerOfAttorney;
		private bool _isSetPowerOfAttorney = false;
		private bool _powerOfAttorneyNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private bool _contractNoteNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private bool _remarkNull = true;
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
		public int ContractID
		{
			get { return _contractID; }
			set { _contractID = value;
			      _isMapRecord = false;
			      _isSetContractID = true; }
		}
		public Boolean _IsSetContractID
		{
			get { return _isSetContractID; }
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
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isMapRecord = false;
			      _isSetDepartmentID = true; }
		}
		public Boolean _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isMapRecord = false;
			      _isSetFormID = true; }
		}
		public Boolean _IsSetFormID
		{
			get { return _isSetFormID; }
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
				_isMapRecord = false;
			}
		}
		public bool IsSigningDateNull
		{
			get {
				 return _signingDateNull; }
			set { _signingDateNull = value; }
		}
		public Boolean _IsSetSigningDate
		{
			get { return _isSetSigningDate; }
		}
		public string PowerOfAttorney
		{
			get
			{
				return _powerOfAttorney;
			}
			set
			{
				_powerOfAttorneyNull = false;
				_isSetPowerOfAttorney = true;
				_powerOfAttorney = value;
				_isMapRecord = false;
			}
		}
		public bool IsPowerOfAttorneyNull
		{
			get {
				 return _powerOfAttorneyNull; }
			set { _powerOfAttorneyNull = value; }
		}
		public Boolean _IsSetPowerOfAttorney
		{
			get { return _isSetPowerOfAttorney; }
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
				_isMapRecord = false;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public Boolean _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
		public string Remark
		{
			get
			{
				return _remark;
			}
			set
			{
				_remarkNull = false;
				_isSetRemark = true;
				_remark = value;
				_isMapRecord = false;
			}
		}
		public bool IsRemarkNull
		{
			get {
				 return _remarkNull; }
			set { _remarkNull = value; }
		}
		public Boolean _IsSetRemark
		{
			get { return _isSetRemark; }
		}
	}
	[Serializable]
	public class ContractData
	{
		private int _contractID;
		private int _caseID;
		private int _applicantID;
		private int _departmentId;
		private int _formID;
		private string _contractNo;
		private double _amount;
		private DateTime _contractDate;
		private string _signingPlace;
		private DateTime _signingDate;
		private string _powerOfAttorney;
		private string _contractNote;
		private bool _isActive;
		private DateTime _modifiedDate;
		private string _remark;
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
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
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
		public string ContractDateStr { get; set; }
		public string SigningPlace
		{
			get{ return _signingPlace; }
			set{ _signingPlace = value; }
		}
		public DateTime SigningDate
		{
			get{ return _signingDate; }
			set{ _signingDate = value; }
		}
		public string SigningDateStr { get; set; }
		public string PowerOfAttorney
		{
			get{ return _powerOfAttorney; }
			set{ _powerOfAttorney = value; }
		}
		public string ContractNote
		{
			get{ return _contractNote; }
			set{ _contractNote = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
	}
	[Serializable]
	public class ContractPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractRow[] contractRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractItems : ContractData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractItems[] contractItems { get; set; }
	}
}

