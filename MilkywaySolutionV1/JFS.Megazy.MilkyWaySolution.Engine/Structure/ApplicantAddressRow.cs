using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantAddressRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
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
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class ApplicantAddressData
	{
		private int _applicantID;
		private int _addressID;
		private int _addressTypeID;
		private double _latitude;
		private double _longitude;
		private int _stay;
		private string _stayUnit;
		private bool _isPresentAddress;
		private bool _isPermanentAddress;
		private string _telephoneNo;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantAddressRow[] applicantaddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantAddressItems : ApplicantAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantAddressItems[] applicantaddressItems { get; set; }
	}
}

