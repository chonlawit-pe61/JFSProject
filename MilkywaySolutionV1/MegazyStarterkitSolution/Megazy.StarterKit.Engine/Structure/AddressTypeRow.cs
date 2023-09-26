using System;
using System.ComponentModel.DataAnnotations;
using Megazy.StarterKit.Engine.Dal;
namespace Megazy.StarterKit.Engine.Structure
{
	[Serializable]
	public class AddressTypeRow
	{
		private int _addressTypeID;
		private bool _isSetAddressTypeID = false;
		private string _typeName;
		private bool _isSetTypeName = false;
		private string _addressGroup;
		private bool _isSetAddressGroup = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class AddressTypeData
	{
		private int _addressTypeID;
		private string _typeName;
		private string _addressGroup;
		private bool _isActive;
		private DateTime _modifiedDate;
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
		public string AddressGroup
		{
			get{ return _addressGroup; }
			set{ _addressGroup = value; }
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
	public class AddressTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AddressTypeRow[] addressTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AddressTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AddressTypeItems : AddressTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AddressTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AddressTypeItems[] addressTypeItems { get; set; }
	}
}

