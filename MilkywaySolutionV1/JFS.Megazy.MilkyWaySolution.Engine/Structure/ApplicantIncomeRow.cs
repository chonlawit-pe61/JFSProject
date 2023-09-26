using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantIncomeRow
	{
		private int _incomeiD;
		private bool _isSetIncomeID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private bool _isPermanent;
		private bool _isSetIsPermanent = false;
		private bool _isPermanentNull = true;
		private string _ocupationPosition;
		private bool _isSetOcupationPosition = false;
		private double _income;
		private bool _isSetIncome = false;
		private bool _incomeNull = true;
		private string _incomeUnit;
		private bool _isSetIncomeUnit = false;
		private string _workPlace;
		private bool _isSetWorkPlace = false;
		private string _telphoneNo;
		private bool _isSetTelphoneNo = false;
		private decimal _yearsExperience;
		private bool _isSetYearsExperience = false;
		private bool _yearsExperienceNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int IncomeID
		{
			get { return _incomeiD; }
			set { _incomeiD = value;
			      _isSetIncomeID = true; }
		}
		public bool _IsSetIncomeID
		{
			get { return _isSetIncomeID; }
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
		public bool IsPermanent
		{
			get
			{
				return _isPermanent;
			}
			set
			{
				_isPermanentNull = false;
				_isSetIsPermanent = true;
				_isPermanent = value;
			}
		}
		public bool IsIsPermanentNull
		{
			get {
				 return _isPermanentNull; }
			set { _isPermanentNull = value; }
		}
		public bool _IsSetIsPermanent
		{
			get { return _isSetIsPermanent; }
		}
		public string OcupationPosition
		{
			get { return _ocupationPosition; }
			set { _ocupationPosition = value;
			      _isSetOcupationPosition = true; }
		}
		public bool _IsSetOcupationPosition
		{
			get { return _isSetOcupationPosition; }
		}
		public double Income
		{
			get
			{
				return _income;
			}
			set
			{
				_incomeNull = false;
				_isSetIncome = true;
				_income = value;
			}
		}
		public bool IsIncomeNull
		{
			get {
				 return _incomeNull; }
			set { _incomeNull = value; }
		}
		public bool _IsSetIncome
		{
			get { return _isSetIncome; }
		}
		public string IncomeUnit
		{
			get { return _incomeUnit; }
			set { _incomeUnit = value;
			      _isSetIncomeUnit = true; }
		}
		public bool _IsSetIncomeUnit
		{
			get { return _isSetIncomeUnit; }
		}
		public string WorkPlace
		{
			get { return _workPlace; }
			set { _workPlace = value;
			      _isSetWorkPlace = true; }
		}
		public bool _IsSetWorkPlace
		{
			get { return _isSetWorkPlace; }
		}
		public string TelphoneNo
		{
			get { return _telphoneNo; }
			set { _telphoneNo = value;
			      _isSetTelphoneNo = true; }
		}
		public bool _IsSetTelphoneNo
		{
			get { return _isSetTelphoneNo; }
		}
		public decimal YearsExperience
		{
			get
			{
				return _yearsExperience;
			}
			set
			{
				_yearsExperienceNull = false;
				_isSetYearsExperience = true;
				_yearsExperience = value;
			}
		}
		public bool IsYearsExperienceNull
		{
			get {
				 return _yearsExperienceNull; }
			set { _yearsExperienceNull = value; }
		}
		public bool _IsSetYearsExperience
		{
			get { return _isSetYearsExperience; }
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
	public class ApplicantIncomeData
	{
		private int _incomeiD;
		private int _applicantID;
		private bool _isPermanent;
		private string _ocupationPosition;
		private double _income;
		private string _incomeUnit;
		private string _workPlace;
		private string _telphoneNo;
		private decimal _yearsExperience;
		private DateTime _modifiedDate;
		public int IncomeID
		{
			get{ return _incomeiD; }
			set{ _incomeiD = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public bool IsPermanent
		{
			get{ return _isPermanent; }
			set{ _isPermanent = value; }
		}
		public string OcupationPosition
		{
			get{ return _ocupationPosition; }
			set{ _ocupationPosition = value; }
		}
		public double Income
		{
			get{ return _income; }
			set{ _income = value; }
		}
		public string IncomeUnit
		{
			get{ return _incomeUnit; }
			set{ _incomeUnit = value; }
		}
		public string WorkPlace
		{
			get{ return _workPlace; }
			set{ _workPlace = value; }
		}
		public string TelphoneNo
		{
			get{ return _telphoneNo; }
			set{ _telphoneNo = value; }
		}
		public decimal YearsExperience
		{
			get{ return _yearsExperience; }
			set{ _yearsExperience = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantIncomePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantIncomeRow[] applicantIncomeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantIncomeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantIncomeItems : ApplicantIncomeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantIncomeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantIncomeItems[] applicantIncomeItems { get; set; }
	}
}

