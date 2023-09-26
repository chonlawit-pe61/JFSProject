using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ProxyAddressRow
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
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
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
	}
	[Serializable]
	public class ProxyAddressData
	{
		private int _proxyID;
		private int _addressID;
		private int _addressTypeID;
		private int _stay;
		private string _stayUnit;
		private bool _isPresentAddress;
		private bool _isPermanentAddress;
		private DateTime _modifiedDate;
		private string _telephoneNo;
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
	}
	[Serializable]
	public class ProxyAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ProxyAddressRow[] proxyAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ProxyAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ProxyAddressItems : ProxyAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ProxyAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ProxyAddressItems[] proxyAddressItems { get; set; }
	}
}

