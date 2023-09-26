using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CoordinatorAddressRow
	{
		private int _contactID;
		private bool _isSetContactID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ContactID
		{
			get { return _contactID; }
			set { _contactID = value;
			      _isSetContactID = true; }
		}
		public bool _IsSetContactID
		{
			get { return _isSetContactID; }
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
	public class CoordinatorAddressData
	{
		private int _contactID;
		private int _addressID;
		private DateTime _modifiedDate;
		public int ContactID
		{
			get{ return _contactID; }
			set{ _contactID = value; }
		}
		public int AddressID
		{
			get{ return _addressID; }
			set{ _addressID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CoordinatorAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CoordinatorAddressRow[] coordinatorAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CoordinatorAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CoordinatorAddressItems : CoordinatorAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CoordinatorAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CoordinatorAddressItems[] coordinatorAddressItems { get; set; }
	}
}

