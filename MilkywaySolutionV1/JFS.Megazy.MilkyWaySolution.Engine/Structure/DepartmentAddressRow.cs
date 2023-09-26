using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class DepartmentAddressRow
	{
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
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
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class DepartmentAddressData
	{
		private int _departmentId;
		private int _addressID;
		private string _telephoneNo;
		private string _faxNo;
		private double _latitude;
		private double _longitude;
		private DateTime _modifiedDate;
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class DepartmentAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DepartmentAddressRow[] departmentAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DepartmentAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DepartmentAddressItems : DepartmentAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DepartmentAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DepartmentAddressItems[] departmentAddressItems { get; set; }
	}
}

