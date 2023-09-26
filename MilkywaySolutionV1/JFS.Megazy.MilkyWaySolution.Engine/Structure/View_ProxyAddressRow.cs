using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ProxyAddressRow
	{
		private int _proxyID;
		private bool _isSetProxyID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
		private bool _addressTypeIDNull = true;
		private int _stay;
		private bool _isSetStay = false;
		private bool _stayNull = true;
		private string _stayUnit;
		private bool _isSetStayUnit = false;
		private bool _isPresentAddress;
		private bool _isSetIsPresentAddress = false;
		private bool _isPresentAddressNull = true;
		private bool _isPermanentAddress;
		private bool _isSetIsPermanentAddress = false;
		private bool _isPermanentAddressNull = true;
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
		private string _typeName;
		private bool _isSetTypeName = false;
		private string _addressGroup;
		private bool _isSetAddressGroup = false;
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
		private string _subdistrictCode;
		private bool _isSetSubdistrictCode = false;
		private string _subdistrictName;
		private bool _isSetSubdistrictName = false;
		private string _districtName;
		private bool _isSetDistrictName = false;
		private string _districtCode;
		private bool _isSetDistrictCode = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private string _soi;
		private bool _isSetSoi = false;
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
		public int AddressTypeID
		{
			get
			{
				return _addressTypeID;
			}
			set
			{
				_addressTypeIDNull = false;
				_isSetAddressTypeID = true;
				_addressTypeID = value;
			}
		}
		public bool IsAddressTypeIDNull
		{
			get {
				 return _addressTypeIDNull; }
			set { _addressTypeIDNull = value; }
		}
		public bool _IsSetAddressTypeID
		{
			get { return _isSetAddressTypeID; }
		}
		public int Stay
		{
			get
			{
				return _stay;
			}
			set
			{
				_stayNull = false;
				_isSetStay = true;
				_stay = value;
			}
		}
		public bool IsStayNull
		{
			get {
				 return _stayNull; }
			set { _stayNull = value; }
		}
		public bool _IsSetStay
		{
			get { return _isSetStay; }
		}
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
		public bool IsPresentAddress
		{
			get
			{
				return _isPresentAddress;
			}
			set
			{
				_isPresentAddressNull = false;
				_isSetIsPresentAddress = true;
				_isPresentAddress = value;
			}
		}
		public bool IsIsPresentAddressNull
		{
			get {
				 return _isPresentAddressNull; }
			set { _isPresentAddressNull = value; }
		}
		public bool _IsSetIsPresentAddress
		{
			get { return _isSetIsPresentAddress; }
		}
		public bool IsPermanentAddress
		{
			get
			{
				return _isPermanentAddress;
			}
			set
			{
				_isPermanentAddressNull = false;
				_isSetIsPermanentAddress = true;
				_isPermanentAddress = value;
			}
		}
		public bool IsIsPermanentAddressNull
		{
			get {
				 return _isPermanentAddressNull; }
			set { _isPermanentAddressNull = value; }
		}
		public bool _IsSetIsPermanentAddress
		{
			get { return _isSetIsPermanentAddress; }
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
		public string AddressGroup
		{
			get { return _addressGroup; }
			set { _addressGroup = value;
			      _isSetAddressGroup = true; }
		}
		public bool _IsSetAddressGroup
		{
			get { return _isSetAddressGroup; }
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
	public class View_ProxyAddressData
	{
		private int _proxyID;
		private int _addressID;
		private int _addressTypeID;
		private int _stay;
		private string _stayUnit;
		private bool _isPresentAddress;
		private bool _isPermanentAddress;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _street;
		private int _provinceID;
		private int _disctrictId;
		private int _subdistrictID;
		private string _postCode;
		private string _typeName;
		private string _addressGroup;
		private string _countrycode;
		private int _provinceCode;
		private string _provinceName;
		private string _provinceNameEN;
		private int _regionID;
		private string _subdistrictCode;
		private string _subdistrictName;
		private string _districtName;
		private string _districtCode;
		private string _telephoneNo;
		private string _soi;
		public int ProxyID
		{
			get{ return _proxyID; }
			set{ _proxyID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public int AddressTypeID
		{
			get{ return _addressTypeID; }
			set{ _addressTypeID = value; }
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
		public string TypeName
		{
			get{ return _typeName; }
			set{ _typeName = value; }
		}
		public string AddressGroup
		{
			get{ return _addressGroup; }
			set{ _addressGroup = value; }
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
		public string DistrictName
		{
			get{ return _districtName; }
			set{ _districtName = value; }
		}
		public string DistrictCode
		{
			get{ return _districtCode; }
			set{ _districtCode = value; }
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
	public class View_ProxyAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ProxyAddressRow[] view_ProxyAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ProxyAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ProxyAddressItems : View_ProxyAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ProxyAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ProxyAddressItems[] view_ProxyAddressItems { get; set; }
	}
}

