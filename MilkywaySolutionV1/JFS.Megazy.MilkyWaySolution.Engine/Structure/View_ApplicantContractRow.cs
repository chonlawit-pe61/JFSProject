using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantContractRow
	{
		private int _contractID;
		private bool _isSetContractID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _formID;
		private bool _isSetFormID = false;
		private string _contractNo;
		private bool _isSetContractNo = false;
		private DateTime _contractDate;
		private bool _isSetContractDate = false;
		private bool _contractDateNull = true;
		private string _contractNote;
		private bool _isSetContractNote = false;
		private int _formTypeID;
		private bool _isSetFormTypeID = false;
		private bool _formTypeIDNull = true;
		private string _formName;
		private bool _isSetFormName = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _isMoneyForm;
		private bool _isSetIsMoneyForm = false;
		private bool _isMoneyFormNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private bool _formActive;
		private bool _isSetFormActive = false;
		private bool _formActiveNull = true;
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
		public int FormTypeID
		{
			get
			{
				return _formTypeID;
			}
			set
			{
				_formTypeIDNull = false;
				_isSetFormTypeID = true;
				_formTypeID = value;
			}
		}
		public bool IsFormTypeIDNull
		{
			get {
				 return _formTypeIDNull; }
			set { _formTypeIDNull = value; }
		}
		public bool _IsSetFormTypeID
		{
			get { return _isSetFormTypeID; }
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
		public bool IsMoneyForm
		{
			get
			{
				return _isMoneyForm;
			}
			set
			{
				_isMoneyFormNull = false;
				_isSetIsMoneyForm = true;
				_isMoneyForm = value;
			}
		}
		public bool IsIsMoneyFormNull
		{
			get {
				 return _isMoneyFormNull; }
			set { _isMoneyFormNull = value; }
		}
		public bool _IsSetIsMoneyForm
		{
			get { return _isSetIsMoneyForm; }
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
		public bool FormActive
		{
			get
			{
				return _formActive;
			}
			set
			{
				_formActiveNull = false;
				_isSetFormActive = true;
				_formActive = value;
			}
		}
		public bool IsFormActiveNull
		{
			get {
				 return _formActiveNull; }
			set { _formActiveNull = value; }
		}
		public bool _IsSetFormActive
		{
			get { return _isSetFormActive; }
		}
	}
	[Serializable]
	public class View_ApplicantContractData
	{
		private int _contractID;
		private int _caseID;
		private int _formID;
		private string _contractNo;
		private DateTime _contractDate;
		private string _contractNote;
		private int _formTypeID;
		private string _formName;
		private int _applicantID;
		private bool _isMoneyForm;
		private double _amount;
		private bool _formActive;
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
		public int FormTypeID
		{
			get{ return _formTypeID; }
			set{ _formTypeID = value; }
		}
		public string FormName
		{
			get{ return _formName; }
			set{ _formName = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public bool IsMoneyForm
		{
			get{ return _isMoneyForm; }
			set{ _isMoneyForm = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public bool FormActive
		{
			get{ return _formActive; }
			set{ _formActive = value; }
		}
	}
	[Serializable]
	public class View_ApplicantContractPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantContractRow[] view_ApplicantContractRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantContractItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantContractItems : View_ApplicantContractData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantContractItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantContractItems[] view_ApplicantContractItems { get; set; }
	}
}

