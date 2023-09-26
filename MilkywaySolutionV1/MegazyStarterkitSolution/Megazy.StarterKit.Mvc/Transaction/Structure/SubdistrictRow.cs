using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Mvc.Transaction.Dal;
namespace Megazy.StarterKit.Mvc.Transaction.Structure
{
	[Serializable]
	public class SubdistrictRow
	{
		private int _subdistrictID;
		private bool _isSetSubdistrictID = false;
		private int _districtId;
		private bool _isSetDistrictID = false;
		private bool _districtIdNull = true;
		private string _subdistrictCode;
		private bool _isSetSubdistrictCode = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _subdistrictNameEN;
		private bool _isSetSubdistrictNameEN = false;
		private double _latitude;
		private bool _isSetLatitude = false;
		private bool _latitudeNull = true;
		private double _longitude;
		private bool _isSetLongitude = false;
		private bool _longitudeNull = true;
		private string _postCode;
		private bool _isSetPostCode = false;
		private string _geometry;
		private bool _isSetGeometry = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int SubdistrictID
		{
			get { return _subdistrictID; }
			set { _subdistrictID = value;
			      _isSetSubdistrictID = true; }
		}
		public bool _IsSetSubdistrictID
		{
			get { return _isSetSubdistrictID; }
		}
		public int DistrictID
		{
			get
			{
				return _districtId;
			}
			set
			{
				_districtIdNull = false;
				_isSetDistrictID = true;
				_districtId = value;
			}
		}
		public bool IsDistrictIDNull
		{
			get {
				 return _districtIdNull; }
			set { _districtIdNull = value; }
		}
		public bool _IsSetDistrictID
		{
			get { return _isSetDistrictID; }
		}
		public string SubdistrictCode
		{
			get { return _subdistrictCode; }
			set { _subdistrictCode = value;
			      _isSetSubdistrictCode = true; }
		}
		public bool _IsSetSubdistrictCode
		{
			get { return _isSetSubdistrictCode; }
		}
		public string SubdistrictName
		{
			get { return _subdistrictName; }
			set { _subdistrictName = value;
			      _isSetSubdistrictName = true; }
		}
		public bool _IsSetSubdistrictName
		{
			get { return _isSetSubdistrictName; }
		}
		public string SubdistrictNameEN
		{
			get { return _subdistrictNameEN; }
			set { _subdistrictNameEN = value;
			      _isSetSubdistrictNameEN = true; }
		}
		public bool _IsSetSubdistrictNameEN
		{
			get { return _isSetSubdistrictNameEN; }
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
		public string PostCode
		{
			get { return _postCode; }
			set { _postCode = value;
			      _isSetPostCode = true; }
		}
		public bool _IsSetPostCode
		{
			get { return _isSetPostCode; }
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
	public class SubdistrictData
	{
		private int _subdistrictID;
		private int _districtId;
		private string _subdistrictCode;
		private string _subdistrictName;
		private string _subdistrictNameEN;
		private double _latitude;
		private double _longitude;
		private string _postCode;
		private string _geometry;
		private bool _isActive;
		public int SubdistrictID
		{
			get{ return _subdistrictID; }
			set{ _subdistrictID = value; }
		}
		public int DistrictID
		{
			get{ return _districtId; }
			set{ _districtId = value; }
		}
		public string SubdistrictCode
		{
			get{ return _subdistrictCode; }
			set{ _subdistrictCode = value; }
		}
		public string SubdistrictName
		{
			get{ return _subdistrictName; }
			set{ _subdistrictName = value; }
		}
		public string SubdistrictNameEN
		{
			get{ return _subdistrictNameEN; }
			set{ _subdistrictNameEN = value; }
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
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
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
	public class SubdistrictPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SubdistrictRow[] subdistrictRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SubdistrictItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SubdistrictItems : SubdistrictData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SubdistrictItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SubdistrictItems[] subdistrictItems { get; set; }
	}
}

