using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantFamilyIncomeRow
	{
		private int _familyID;
		private bool _isSetFamilyID = false;
		private double _income;
		private bool _isSetIncome = false;
		private bool _incomeNull = true;
		private string _incomeUnit;
		private bool _isSetIncomeUnit = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int FamilyID
		{
			get { return _familyID; }
			set { _familyID = value;
			      _isSetFamilyID = true; }
		}
		public bool _IsSetFamilyID
		{
			get { return _isSetFamilyID; }
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
	public class ApplicantFamilyIncomeData
	{
		private int _familyID;
		private double _income;
		private string _incomeUnit;
		private DateTime _modifiedDate;
		public int FamilyID
		{
			get{ return _familyID; }
			set{ _familyID = value; }
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
	public class ApplicantFamilyIncomePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantFamilyIncomeRow[] applicantFamilyIncomeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantFamilyIncomeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantFamilyIncomeItems : ApplicantFamilyIncomeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantFamilyIncomeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantFamilyIncomeItems[] applicantFamilyIncomeItems { get; set; }
	}
}

