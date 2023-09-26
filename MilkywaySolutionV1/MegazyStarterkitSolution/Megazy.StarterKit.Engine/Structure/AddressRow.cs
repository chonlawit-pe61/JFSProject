using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class AddressRow
	{
		private int _addressID;
		private bool _isSetAddressID = false;
		private string _address1;
		private bool _isSetAddress1 = false;
		private string _houseNo;
		private bool _isSetHouseNo = false;
		private string _villageNo;
		private bool _isSetVillageNo = false;
		private string _soi;
		private bool _isSetSoi = false;
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
	}
	[Serializable]
	public class AddressData
	{
		private int _addressID;
		private string _address1;
		private string _houseNo;
		private string _villageNo;
		private string _soi;
		private string _street;
		private int _provinceID;
		private int _disctrictId;
		private int _subdistrictID;
		private string _postCode;
		private DateTime _createdate;
		private DateTime _modifiedDate;
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
		public string Soi
		{
			get{ return _soi; }
			set{ _soi = value; }
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
		public string CreatedateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class AddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AddressRow[] addressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AddressItems : AddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AddressItems[] addressItems { get; set; }
	}
}

