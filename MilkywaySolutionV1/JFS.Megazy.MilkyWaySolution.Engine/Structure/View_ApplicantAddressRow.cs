using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ApplicantAddressRow
	{
		private int _addressID;
		private bool _isSetAddressID = false;
		private string _address1;
		private bool _isSetAddress1 = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _street;
		private bool _isSetStreet = false;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private int _disctrictId;
		private bool _isSetDisctrictID = false;
		private bool _disctrictIdNull = true;
		private int _subdistrictID;
		private bool _isSetSubdistrictID = false;
		private bool _subdistrictIDNull = true;
		private string _postCode;
		private bool _isSetPostCode = false;
		private DateTime _createdate;
		private bool _isSetCreatedate = false;
		private bool _createdateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _countrycode;
		private bool _isSetCountryCode = false;
		private int _provinceCode;
		private bool _isSetProvinceCode = false;
		private string _provinceName;
		private bool _isSetProvinceName = false;
		private string _provinceNameEN;
		private bool _isSetProvinceNameEN = false;
		private string _districtCode;
		private bool _isSetDistrictCode = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private string _districtNameEN;
		private bool _isSetDistrictNameEN = false;
		private string _subdistrictCode;
		private bool _isSetSubdistrictCode = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _subdistrictNameEN;
		private bool _isSetSubdistrictNameEN = false;
		private string _districtPostCode;
		private bool _isSetDistrictPostCode = false;
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
		private string _typeName;
		private bool _isSetTypeName = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private double _latitude;
		private bool _isSetLatitude = false;
		private bool _latitudeNull = true;
		private double _longitude;
		private bool _isSetLongitude = false;
		private bool _longitudeNull = true;
		private int _stay;
		private bool _isSetStay = false;
		private string _stayUnit;
		private bool _isSetStayUnit = false;
		private bool _isPresentAddress;
		private bool _isSetIsPresentAddress = false;
		private bool _isPermanentAddress;
		private bool _isSetIsPermanentAddress = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _soi;
		private bool _isSetSoi = false;
		[Required]
		public int AddressID
		{
			get { return _addressID; }
			set { _addressID = value;
			      _isSetAddressID = true; }
		}
		public bool _IsSetAddressID
		{
			get { return _isSetAddressID; }
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
		public DateTime Createdate
		{
			get
			{
				return _createdate;
			}
			set
			{
				_createdateNull = false;
				_isSetCreatedate = true;
				_createdate = value;
			}
		}
		public bool IsCreatedateNull
		{
			get {
				 return _createdateNull; }
			set { _createdateNull = value; }
		}
		public bool _IsSetCreatedate
		{
			get { return _isSetCreatedate; }
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
		public string DistrictPostCode
		{
			get { return _districtPostCode; }
			set { _districtPostCode = value;
			      _isSetDistrictPostCode = true; }
		}
		public bool _IsSetDistrictPostCode
		{
			get { return _isSetDistrictPostCode; }
		}
		[Required]
		public int AddressTypeID
		{
			get { return _addressTypeID; }
			set { _addressTypeID = value;
			      _isSetAddressTypeID = true; }
		}
		public bool _IsSetAddressTypeID
		{
			get { return _isSetAddressTypeID; }
		}
		[Required]
		public string TypeName
		{
			get { return _typeName; }
			set { _typeName = value;
			      _isSetTypeName = true; }
		}
		public bool _IsSetTypeName
		{
			get { return _isSetTypeName; }
		}
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
		[Required]
		public int Stay
		{
			get { return _stay; }
			set { _stay = value;
			      _isSetStay = true; }
		}
		public bool _IsSetStay
		{
			get { return _isSetStay; }
		}
		[Required]
		public string StayUnit
		{
			get { return _stayUnit; }
			set { _stayUnit = value;
			      _isSetStayUnit = true; }
		}
		public bool _IsSetStayUnit
		{
			get { return _isSetStayUnit; }
		}
		[Required]
		public bool IsPresentAddress
		{
			get { return _isPresentAddress; }
			set { _isPresentAddress = value;
			      _isSetIsPresentAddress = true; }
		}
		public bool _IsSetIsPresentAddress
		{
			get { return _isSetIsPresentAddress; }
		}
		[Required]
		public bool IsPermanentAddress
		{
			get { return _isPermanentAddress; }
			set { _isPermanentAddress = value;
			      _isSetIsPermanentAddress = true; }
		}
		public bool _IsSetIsPermanentAddress
		{
			get { return _isSetIsPermanentAddress; }
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
	}
	[Serializable]
	public class View_ApplicantAddressData
	{
		private int _addressID;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _street;
		private int _provinceID;
		private int _disctrictId;
		private int _subdistrictID;
		private string _postCode;
		private DateTime _createdate;
		private DateTime _modifiedDate;
		private string _countrycode;
		private int _provinceCode;
		private string _provinceName;
		private string _provinceNameEN;
		private string _districtCode;
		private string _districtName;
		private string _districtNameEN;
		private string _subdistrictCode;
		private string _subdistrictName;
		private string _subdistrictNameEN;
		private string _districtPostCode;
		private int _addressTypeID;
		private string _typeName;
		private int _applicantID;
		private double _latitude;
		private double _longitude;
		private int _stay;
		private string _stayUnit;
		private bool _isPresentAddress;
		private bool _isPermanentAddress;
		private string _telephoneNo;
		private string _soi;
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
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
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
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
		public DateTime Createdate
		{
			get{ return _createdate; }
			set{ _createdate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string CreatedateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
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
		public string DistrictPostCode
		{
			get{ return _districtPostCode; }
			set{ _districtPostCode = value; }
		}
		public int AddressTypeID
		{
			get{ return _addressTypeID; }
			set{ _addressTypeID = value; }
		}
		public string TypeName
		{
			get{ return _typeName; }
			set{ _typeName = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
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
		public int Stay
		{
			get{ return _stay; }
			set{ _stay = value; }
		}
		public string StayUnit
		{
			get{ return _stayUnit; }
			set{ _stayUnit = value; }
		}
		public bool IsPresentAddress
		{
			get{ return _isPresentAddress; }
			set{ _isPresentAddress = value; }
		}
		public bool IsPermanentAddress
		{
			get{ return _isPermanentAddress; }
			set{ _isPermanentAddress = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public string Soi
		{
			get{ return _soi; }
			set{ _soi = value; }
		}
	}
	[Serializable]
	public class View_ApplicantAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ApplicantAddressRow[] view_ApplicantAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ApplicantAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ApplicantAddressItems : View_ApplicantAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ApplicantAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ApplicantAddressItems[] view_ApplicantAddressItems { get; set; }
	}
}

