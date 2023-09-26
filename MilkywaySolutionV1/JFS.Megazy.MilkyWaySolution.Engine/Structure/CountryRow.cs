using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CountryRow
	{
		private string _countrycode;
		private bool _isSetCountryCode = false;
		private string _countryName;
		private bool _isSetCountryName = false;
		private bool _hasSubCountries;
		private bool _isSetHasSubCountries = false;
		private bool _hasSubCountriesNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isBlock;
		private bool _isSetIsBlock = false;
		private bool _isBlockNull = true;
		[Required]
		public string CountryCode
		{
			get { return _countrycode; }
			set { _countrycode = value;
			      _isSetCountryCode = true; }
		}
		public bool _IsSetCountryCode
		{
			get { return _isSetCountryCode; }
		}
		public string CountryName
		{
			get { return _countryName; }
			set { _countryName = value;
			      _isSetCountryName = true; }
		}
		public bool _IsSetCountryName
		{
			get { return _isSetCountryName; }
		}
		public bool HasSubCountries
		{
			get
			{
				return _hasSubCountries;
			}
			set
			{
				_hasSubCountriesNull = false;
				_isSetHasSubCountries = true;
				_hasSubCountries = value;
			}
		}
		public bool IsHasSubCountriesNull
		{
			get {
				 return _hasSubCountriesNull; }
			set { _hasSubCountriesNull = value; }
		}
		public bool _IsSetHasSubCountries
		{
			get { return _isSetHasSubCountries; }
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
		public bool IsBlock
		{
			get
			{
				return _isBlock;
			}
			set
			{
				_isBlockNull = false;
				_isSetIsBlock = true;
				_isBlock = value;
			}
		}
		public bool IsIsBlockNull
		{
			get {
				 return _isBlockNull; }
			set { _isBlockNull = value; }
		}
		public bool _IsSetIsBlock
		{
			get { return _isSetIsBlock; }
		}
	}
	[Serializable]
	public class CountryData
	{
		private string _countrycode;
		private string _countryName;
		private bool _hasSubCountries;
		private bool _isActive;
		private bool _isBlock;
		public string CountryCode
		{
			get{ return _countrycode; }
			set{ _countrycode = value; }
		}
		public string CountryName
		{
			get{ return _countryName; }
			set{ _countryName = value; }
		}
		public bool HasSubCountries
		{
			get{ return _hasSubCountries; }
			set{ _hasSubCountries = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public bool IsBlock
		{
			get{ return _isBlock; }
			set{ _isBlock = value; }
		}
	}
	[Serializable]
	public class CountryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CountryRow[] countryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CountryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CountryItems : CountryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CountryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CountryItems[] countryItems { get; set; }
	}
}

