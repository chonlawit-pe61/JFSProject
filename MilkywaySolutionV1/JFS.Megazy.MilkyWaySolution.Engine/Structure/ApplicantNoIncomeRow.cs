using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantNoIncomeRow
	{
		private int _noIncomeID;
		private bool _isSetNoIncomeID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private bool _applicantIDNull = true;
		private string _cause;
		private bool _isSetCause = false;
		private string _supportBy;
		private bool _isSetSupportBy = false;
		private double _income;
		private bool _isSetIncome = false;
		private bool _incomeNull = true;
		private string _incomeUnit;
		private bool _isSetIncomeUnit = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int NoIncomeID
		{
			get { return _noIncomeID; }
			set { _noIncomeID = value;
			      _isSetNoIncomeID = true; }
		}
		public bool _IsSetNoIncomeID
		{
			get { return _isSetNoIncomeID; }
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
		public string Cause
		{
			get { return _cause; }
			set { _cause = value;
			      _isSetCause = true; }
		}
		public bool _IsSetCause
		{
			get { return _isSetCause; }
		}
		public string SupportBy
		{
			get { return _supportBy; }
			set { _supportBy = value;
			      _isSetSupportBy = true; }
		}
		public bool _IsSetSupportBy
		{
			get { return _isSetSupportBy; }
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
	public class ApplicantNoIncomeData
	{
		private int _noIncomeID;
		private int _applicantID;
		private string _cause;
		private string _supportBy;
		private double _income;
		private string _incomeUnit;
		private DateTime _modifiedDate;
		public int NoIncomeID
		{
			get{ return _noIncomeID; }
			set{ _noIncomeID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public string Cause
		{
			get{ return _cause; }
			set{ _cause = value; }
		}
		public string SupportBy
		{
			get{ return _supportBy; }
			set{ _supportBy = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantNoIncomePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantNoIncomeRow[] applicantNoIncomeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantNoIncomeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantNoIncomeItems : ApplicantNoIncomeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantNoIncomeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantNoIncomeItems[] applicantNoIncomeItems { get; set; }
	}
}

