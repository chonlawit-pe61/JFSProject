using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class GuaranteeFormRow
	{
		private int _guaranteeFormID;
		private bool _isSetGuaranteeFormID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private bool _caseIDNull = true;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		private string _signingPlace;
		private bool _isSetSigningPlace = false;
		private DateTime _formDate;
		private bool _isSetFormDate = false;
		private bool _formDateNull = true;
		private string _guaranteeNote;
		private bool _isSetGuaranteeNote = false;
		private string _ralateAs;
		private bool _isSetRalateAs = false;
		private string _guranteeCareer;
		private bool _isSetGuranteeCareer = false;
		private double _incomeAmount;
		private bool _isSetIncomeAmount = false;
		private bool _incomeAmountNull = true;
		private string _incomePerUnit;
		private bool _isSetIncomePerUnit = false;
		private int _witnessID;
		private bool _isSetWitnessID = false;
		private bool _witnessIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int GuaranteeFormID
		{
			get { return _guaranteeFormID; }
			set { _guaranteeFormID = value;
			      _isSetGuaranteeFormID = true; }
		}
		public bool _IsSetGuaranteeFormID
		{
			get { return _isSetGuaranteeFormID; }
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
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		public string SigningPlace
		{
			get { return _signingPlace; }
			set { _signingPlace = value;
			      _isSetSigningPlace = true; }
		}
		public bool _IsSetSigningPlace
		{
			get { return _isSetSigningPlace; }
		}
		public DateTime FormDate
		{
			get
			{
				return _formDate;
			}
			set
			{
				_formDateNull = false;
				_isSetFormDate = true;
				_formDate = value;
			}
		}
		public bool IsFormDateNull
		{
			get {
				 return _formDateNull; }
			set { _formDateNull = value; }
		}
		public bool _IsSetFormDate
		{
			get { return _isSetFormDate; }
		}
		public string GuaranteeNote
		{
			get { return _guaranteeNote; }
			set { _guaranteeNote = value;
			      _isSetGuaranteeNote = true; }
		}
		public bool _IsSetGuaranteeNote
		{
			get { return _isSetGuaranteeNote; }
		}
		public string RalateAs
		{
			get { return _ralateAs; }
			set { _ralateAs = value;
			      _isSetRalateAs = true; }
		}
		public bool _IsSetRalateAs
		{
			get { return _isSetRalateAs; }
		}
		public string GuranteeCareer
		{
			get { return _guranteeCareer; }
			set { _guranteeCareer = value;
			      _isSetGuranteeCareer = true; }
		}
		public bool _IsSetGuranteeCareer
		{
			get { return _isSetGuranteeCareer; }
		}
		public double IncomeAmount
		{
			get
			{
				return _incomeAmount;
			}
			set
			{
				_incomeAmountNull = false;
				_isSetIncomeAmount = true;
				_incomeAmount = value;
			}
		}
		public bool IsIncomeAmountNull
		{
			get {
				 return _incomeAmountNull; }
			set { _incomeAmountNull = value; }
		}
		public bool _IsSetIncomeAmount
		{
			get { return _isSetIncomeAmount; }
		}
		public string IncomePerUnit
		{
			get { return _incomePerUnit; }
			set { _incomePerUnit = value;
			      _isSetIncomePerUnit = true; }
		}
		public bool _IsSetIncomePerUnit
		{
			get { return _isSetIncomePerUnit; }
		}
		public int WitnessID
		{
			get
			{
				return _witnessID;
			}
			set
			{
				_witnessIDNull = false;
				_isSetWitnessID = true;
				_witnessID = value;
			}
		}
		public bool IsWitnessIDNull
		{
			get {
				 return _witnessIDNull; }
			set { _witnessIDNull = value; }
		}
		public bool _IsSetWitnessID
		{
			get { return _isSetWitnessID; }
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
	public class GuaranteeFormData
	{
		private int _guaranteeFormID;
		private int _caseID;
		private int _applicantID;
		private int _formID;
		private string _signingPlace;
		private DateTime _formDate;
		private string _guaranteeNote;
		private string _ralateAs;
		private string _guranteeCareer;
		private double _incomeAmount;
		private string _incomePerUnit;
		private int _witnessID;
		private DateTime _modifiedDate;
		public int GuaranteeFormID
		{
			get{ return _guaranteeFormID; }
			set{ _guaranteeFormID = value; }
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
		public string SigningPlace
		{
			get{ return _signingPlace; }
			set{ _signingPlace = value; }
		}
		public DateTime FormDate
		{
			get{ return _formDate; }
			set{ _formDate = value; }
		}
		public string FormDateStr { get; set; }
		public string GuaranteeNote
		{
			get{ return _guaranteeNote; }
			set{ _guaranteeNote = value; }
		}
		public string RalateAs
		{
			get{ return _ralateAs; }
			set{ _ralateAs = value; }
		}
		public string GuranteeCareer
		{
			get{ return _guranteeCareer; }
			set{ _guranteeCareer = value; }
		}
		public double IncomeAmount
		{
			get{ return _incomeAmount; }
			set{ _incomeAmount = value; }
		}
		public string IncomePerUnit
		{
			get{ return _incomePerUnit; }
			set{ _incomePerUnit = value; }
		}
		public int WitnessID
		{
			get{ return _witnessID; }
			set{ _witnessID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class GuaranteeFormPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public GuaranteeFormRow[] guaranteeFormRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส GuaranteeFormItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class GuaranteeFormItems : GuaranteeFormData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class GuaranteeFormItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public GuaranteeFormItems[] guaranteeFormItems { get; set; }
	}
}

