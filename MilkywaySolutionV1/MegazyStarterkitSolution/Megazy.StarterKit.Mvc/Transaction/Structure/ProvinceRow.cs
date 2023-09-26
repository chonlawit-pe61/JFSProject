using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class ProvinceRow
	{
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _countrycode;
		private bool _isSetCountryCode = false;
		private int _provinceCode;
		private bool _isSetProvinceCode = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _provinceNameEN;
		private bool _isSetProvinceNameEN = false;
		private int _regionID;
		private bool _isSetRegionID = false;
		private bool _regionIDNull = true;
		private double _latitude;
		private bool _isSetLatitude = false;
		private bool _latitudeNull = true;
		private double _longitude;
		private bool _isSetLongitude = false;
		private bool _longitudeNull = true;
		private string _geometry;
		private bool _isSetGeometry = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int ProvinceID
		{
			get { return _provinceID; }
			set { _provinceID = value;
			      _isSetProvinceID = true; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
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
		[Required]
		public int ProvinceCode
		{
			get { return _provinceCode; }
			set { _provinceCode = value;
			      _isSetProvinceCode = true; }
		}
		public bool _IsSetProvinceCode
		{
			get { return _isSetProvinceCode; }
		}
		public string ProvinceName
		{
			get { return _provinceName; }
			set { _provinceName = value;
			      _isSetProvinceName = true; }
		}
		public bool _IsSetProvinceName
		{
			get { return _isSetProvinceName; }
		}
		public string ProvinceNameEN
		{
			get { return _provinceNameEN; }
			set { _provinceNameEN = value;
			      _isSetProvinceNameEN = true; }
		}
		public bool _IsSetProvinceNameEN
		{
			get { return _isSetProvinceNameEN; }
		}
		public int RegionID
		{
			get
			{
				return _regionID;
			}
			set
			{
				_regionIDNull = false;
				_isSetRegionID = true;
				_regionID = value;
			}
		}
		public bool IsRegionIDNull
		{
			get {
				 return _regionIDNull; }
			set { _regionIDNull = value; }
		}
		public bool _IsSetRegionID
		{
			get { return _isSetRegionID; }
		}
		public double Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				_latitudeNull = false;
				_isSetLatitude = true;
				_latitude = value;
			}
		}
		public bool IsLatitudeNull
		{
			get {
				 return _latitudeNull; }
			set { _latitudeNull = value; }
		}
		public bool _IsSetLatitude
		{
			get { return _isSetLatitude; }
		}
		public double Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				_longitudeNull = false;
				_isSetLongitude = true;
				_longitude = value;
			}
		}
		public bool IsLongitudeNull
		{
			get {
				 return _longitudeNull; }
			set { _longitudeNull = value; }
		}
		public bool _IsSetLongitude
		{
			get { return _isSetLongitude; }
		}
		public string Geometry
		{
			get { return _geometry; }
			set { _geometry = value;
			      _isSetGeometry = true; }
		}
		public bool _IsSetGeometry
		{
			get { return _isSetGeometry; }
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
	public class ProvinceData
	{
		private int _provinceID;
		private string _countrycode;
		private int _provinceCode;
		private string _provinceName;
		private string _provinceNameEN;
		private int _regionID;
		private double _latitude;
		private double _longitude;
		private string _geometry;
		private bool _isActive;
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string CountryCode
		{
			get{ return _countrycode; }
			set{ _countrycode = value; }
		}
		public int ProvinceCode
		{
			get{ return _provinceCode; }
			set{ _provinceCode = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string ProvinceNameEN
		{
			get{ return _provinceNameEN; }
			set{ _provinceNameEN = value; }
		}
		public int RegionID
		{
			get{ return _regionID; }
			set{ _regionID = value; }
		}
		public double Latitude
		{
			get{ return _latitude; }
			set{ _latitude = value; }
		}
		public double Longitude
		{
			get{ return _longitude; }
			set{ _longitude = value; }
		}
		public string Geometry
		{
			get{ return _geometry; }
			set{ _geometry = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class ProvincePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProvinceRow[] provinceRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProvinceItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProvinceItems : ProvinceData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProvinceItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProvinceItems[] provinceItems { get; set; }
	}
}

