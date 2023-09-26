using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerAddressRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
		private bool _addressTypeIDNull = true;
		private string _faxNo;
		private bool _isSetFaxNo = false;
		private string _telephoneNo;
		private bool _isSetTelephoneNo = false;
		private bool _isPrimary;
		private bool _isSetIsPrimary = false;
		private bool _isPrimaryNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
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
		public bool IsPrimary
		{
			get
			{
				return _isPrimary;
			}
			set
			{
				_isPrimaryNull = false;
				_isSetIsPrimary = true;
				_isPrimary = value;
			}
		}
		public bool IsIsPrimaryNull
		{
			get {
				 return _isPrimaryNull; }
			set { _isPrimaryNull = value; }
		}
		public bool _IsSetIsPrimary
		{
			get { return _isSetIsPrimary; }
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
	public class LawyerAddressData
	{
		private int _lawyerID;
		private int _addressID;
		private int _addressTypeID;
		private string _faxNo;
		private string _telephoneNo;
		private bool _isPrimary;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
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
		public string FaxNo
		{
			get{ return _faxNo; }
			set{ _faxNo = value; }
		}
		public string TelephoneNo
		{
			get{ return _telephoneNo; }
			set{ _telephoneNo = value; }
		}
		public bool IsPrimary
		{
			get{ return _isPrimary; }
			set{ _isPrimary = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class LawyerAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerAddressRow[] lawyerAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerAddressItems : LawyerAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerAddressItems[] lawyerAddressItems { get; set; }
	}
}

