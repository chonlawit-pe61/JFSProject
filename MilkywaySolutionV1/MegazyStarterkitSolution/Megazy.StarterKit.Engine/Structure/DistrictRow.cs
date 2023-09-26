using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class DistrictRow
	{
		private int _districtId;
		private bool _isSetDistrictID = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private string _districtCode;
		private bool _isSetDistrictCode = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private string _districtNameEN;
		private bool _isSetDistrictNameEN = false;
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
		public int DistrictID
		{
			get { return _districtId; }
			set { _districtId = value;
			      _isSetDistrictID = true; }
		}
		public bool _IsSetDistrictID
		{
			get { return _isSetDistrictID; }
		}
		public int ProvinceID
		{
			get
			{
				return _provinceID;
			}
			set
			{
				_provinceIDNull = false;
				_isSetProvinceID = true;
				_provinceID = value;
			}
		}
		public bool IsProvinceIDNull
		{
			get {
				 return _provinceIDNull; }
			set { _provinceIDNull = value; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
		}
		public string DistrictCode
		{
			get { return _districtCode; }
			set { _districtCode = value;
			      _isSetDistrictCode = true; }
		}
		public bool _IsSetDistrictCode
		{
			get { return _isSetDistrictCode; }
		}
		public string DistrictName
		{
			get { return _districtName; }
			set { _districtName = value;
			      _isSetDistrictName = true; }
		}
		public bool _IsSetDistrictName
		{
			get { return _isSetDistrictName; }
		}
		public string DistrictNameEN
		{
			get { return _districtNameEN; }
			set { _districtNameEN = value;
			      _isSetDistrictNameEN = true; }
		}
		public bool _IsSetDistrictNameEN
		{
			get { return _isSetDistrictNameEN; }
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
	public class DistrictData
	{
		private int _districtId;
		private int _provinceID;
		private string _districtCode;
		private string _districtName;
		private string _districtNameEN;
		private double _latitude;
		private double _longitude;
		private string _geometry;
		private bool _isActive;
		public int DistrictID
		{
			get{ return _districtId; }
			set{ _districtId = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string DistrictCode
		{
			get{ return _districtCode; }
			set{ _districtCode = value; }
		}
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public string DistrictNameEN
		{
			get{ return _districtNameEN; }
			set{ _districtNameEN = value; }
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
	public class DistrictPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DistrictRow[] districtRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DistrictItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DistrictItems : DistrictData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DistrictItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DistrictItems[] districtItems { get; set; }
	}
}

