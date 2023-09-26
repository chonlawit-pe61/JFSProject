using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_DepartmentRow
	{
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private string _departmentName;
		private bool _isSetDepartmentName = false;
		private string _departmentNameAbbr;
		private bool _isSetDepartmentNameAbbr = false;
		private string _departmentCode;
		private bool _isSetDepartmentCode = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _sortOder;
		private bool _isSetSortOder = false;
		private bool _sortOderNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private double _latitude;
		private bool _isSetLatitude = false;
		private bool _latitudeNull = true;
		private double _longitude;
		private bool _isSetLongitude = false;
		private bool _longitudeNull = true;
		private string _address1;
		private bool _isSetAddress1 = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _street;
		private bool _isSetStreet = false;
		private int _disctrictId;
		private bool _isSetDisctrictID = false;
		private bool _disctrictIdNull = true;
		private int _subdistrictID;
		private bool _isSetSubdistrictID = false;
		private bool _subdistrictIDNull = true;
		private string _postCode;
		private bool _isSetPostCode = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private string _geometry;
		private bool _isSetGeometry = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _soi;
		private bool _isSetSoi = false;
		private string _provinceTypeCode;
		private bool _isSetProvinceTypeCode = false;
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
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
		public string DepartmentName
		{
			get { return _departmentName; }
			set { _departmentName = value;
			      _isSetDepartmentName = true; }
		}
		public bool _IsSetDepartmentName
		{
			get { return _isSetDepartmentName; }
		}
		[Required]
		public string DepartmentNameAbbr
		{
			get { return _departmentNameAbbr; }
			set { _departmentNameAbbr = value;
			      _isSetDepartmentNameAbbr = true; }
		}
		public bool _IsSetDepartmentNameAbbr
		{
			get { return _isSetDepartmentNameAbbr; }
		}
		public string DepartmentCode
		{
			get { return _departmentCode; }
			set { _departmentCode = value;
			      _isSetDepartmentCode = true; }
		}
		public bool _IsSetDepartmentCode
		{
			get { return _isSetDepartmentCode; }
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
		public int SortOder
		{
			get
			{
				return _sortOder;
			}
			set
			{
				_sortOderNull = false;
				_isSetSortOder = true;
				_sortOder = value;
			}
		}
		public bool IsSortOderNull
		{
			get {
				 return _sortOderNull; }
			set { _sortOderNull = value; }
		}
		public bool _IsSetSortOder
		{
			get { return _isSetSortOder; }
		}
		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value;
			      _isSetTelephoneNo = true; }
		}
		public bool _IsSetTelephoneNo
		{
			get { return _isSetTelephoneNo; }
		}
		public string FaxNo
		{
			get { return _faxNo; }
			set { _faxNo = value;
			      _isSetFaxNo = true; }
		}
		public bool _IsSetFaxNo
		{
			get { return _isSetFaxNo; }
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
		public string Address1
		{
			get { return _address1; }
			set { _address1 = value;
			      _isSetAddress1 = true; }
		}
		public bool _IsSetAddress1
		{
			get { return _isSetAddress1; }
		}
		public string HouseNo
		{
			get { return _houseNo; }
			set { _houseNo = value;
			      _isSetHouseNo = true; }
		}
		public bool _IsSetHouseNo
		{
			get { return _isSetHouseNo; }
		}
		public string VillageNo
		{
			get { return _villageNo; }
			set { _villageNo = value;
			      _isSetVillageNo = true; }
		}
		public bool _IsSetVillageNo
		{
			get { return _isSetVillageNo; }
		}
		public string Street
		{
			get { return _street; }
			set { _street = value;
			      _isSetStreet = true; }
		}
		public bool _IsSetStreet
		{
			get { return _isSetStreet; }
		}
		public int DisctrictID
		{
			get
			{
				return _disctrictId;
			}
			set
			{
				_disctrictIdNull = false;
				_isSetDisctrictID = true;
				_disctrictId = value;
			}
		}
		public bool IsDisctrictIDNull
		{
			get {
				 return _disctrictIdNull; }
			set { _disctrictIdNull = value; }
		}
		public bool _IsSetDisctrictID
		{
			get { return _isSetDisctrictID; }
		}
		public int SubdistrictID
		{
			get
			{
				return _subdistrictID;
			}
			set
			{
				_subdistrictIDNull = false;
				_isSetSubdistrictID = true;
				_subdistrictID = value;
			}
		}
		public bool IsSubdistrictIDNull
		{
			get {
				 return _subdistrictIDNull; }
			set { _subdistrictIDNull = value; }
		}
		public bool _IsSetSubdistrictID
		{
			get { return _isSetSubdistrictID; }
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
		public string Soi
		{
			get { return _soi; }
			set { _soi = value;
			      _isSetSoi = true; }
		}
		public bool _IsSetSoi
		{
			get { return _isSetSoi; }
		}
		public string ProvinceTypeCode
		{
			get { return _provinceTypeCode; }
			set { _provinceTypeCode = value;
			      _isSetProvinceTypeCode = true; }
		}
		public bool _IsSetProvinceTypeCode
		{
			get { return _isSetProvinceTypeCode; }
		}
	}
	[Serializable]
	public class View_DepartmentData
	{
		private int _departmentId;
		private int _provinceID;
		private string _departmentName;
		private string _departmentNameAbbr;
		private string _departmentCode;
		private bool _isActive;
		private int _sortOder;
		private string _telephoneNo;
		private string _faxNo;
		private double _latitude;
		private double _longitude;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _street;
		private int _disctrictId;
		private int _subdistrictID;
		private string _postCode;
		private string _subdistrictName;
		private string _districtName;
		private string _geometry;
		private string _provinceName;
		private string _soi;
		private string _provinceTypeCode;
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public string DepartmentName
		{
			get{ return _departmentName; }
			set{ _departmentName = value; }
		}
		public string DepartmentNameAbbr
		{
			get{ return _departmentNameAbbr; }
			set{ _departmentNameAbbr = value; }
		}
		public string DepartmentCode
		{
			get{ return _departmentCode; }
			set{ _departmentCode = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int SortOder
		{
			get{ return _sortOder; }
			set{ _sortOder = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string FaxNo
		{
			get{ return _faxNo; }
			set{ _faxNo = value; }
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
		public string Address1
		{
			get{ return _address1; }
			set{ _address1 = value; }
		}
		public string HouseNo
		{
			get{ return _houseNo; }
			set{ _houseNo = value; }
		}
		public string VillageNo
		{
			get{ return _villageNo; }
			set{ _villageNo = value; }
		}
		public string Street
		{
			get{ return _street; }
			set{ _street = value; }
		}
		public int DisctrictID
		{
			get{ return _disctrictId; }
			set{ _disctrictId = value; }
		}
		public int SubdistrictID
		{
			get{ return _subdistrictID; }
			set{ _subdistrictID = value; }
		}
		public string PostCode
		{
			get{ return _postCode; }
			set{ _postCode = value; }
		}
		public string SubdistrictName
		{
			get{ return _subdistrictName; }
			set{ _subdistrictName = value; }
		}
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public string Geometry
		{
			get{ return _geometry; }
			set{ _geometry = value; }
		}
		public string ProvinceName
		{
			get{ return _provinceName; }
			set{ _provinceName = value; }
		}
		public string Soi
		{
			get{ return _soi; }
			set{ _soi = value; }
		}
		public string ProvinceTypeCode
		{
			get{ return _provinceTypeCode; }
			set{ _provinceTypeCode = value; }
		}
	}
	[Serializable]
	public class View_DepartmentPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_DepartmentRow[] view_DepartmentRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_DepartmentItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_DepartmentItems : View_DepartmentData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_DepartmentItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_DepartmentItems[] view_DepartmentItems { get; set; }
	}
}

