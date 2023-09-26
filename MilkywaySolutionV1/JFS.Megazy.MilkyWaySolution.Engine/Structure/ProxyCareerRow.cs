using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProxyCareerRow
	{
		private int _proxyID;
		private bool _isSetProxyID = false;
		private string _career;
		private bool _isSetCareer = false;
		private double _income;
		private bool _isSetIncome = false;
		private bool _incomeNull = true;
		private string _incomeUnit;
		private bool _isSetIncomeUnit = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ProxyID
		{
			get { return _proxyID; }
			set { _proxyID = value;
			      _isSetProxyID = true; }
		}
		public bool _IsSetProxyID
		{
			get { return _isSetProxyID; }
		}
		public string Career
		{
			get { return _career; }
			set { _career = value;
			      _isSetCareer = true; }
		}
		public bool _IsSetCareer
		{
			get { return _isSetCareer; }
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
	public class ProxyCareerData
	{
		private int _proxyID;
		private string _career;
		private double _income;
		private string _incomeUnit;
		private DateTime _modifiedDate;
		public int ProxyID
		{
			get{ return _proxyID; }
			set{ _proxyID = value; }
		}
		public string Career
		{
			get{ return _career; }
			set{ _career = value; }
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
	public class ProxyCareerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProxyCareerRow[] proxyCareerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProxyCareerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProxyCareerItems : ProxyCareerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProxyCareerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProxyCareerItems[] proxyCareerItems { get; set; }
	}
}

