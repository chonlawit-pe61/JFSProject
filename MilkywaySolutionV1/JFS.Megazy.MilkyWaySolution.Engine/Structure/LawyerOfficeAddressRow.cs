using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerOfficeAddressRow
	{
		private int _lawyerOfficeID;
		private bool _isSetLawyerOfficeID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int LawyerOfficeID
		{
			get { return _lawyerOfficeID; }
			set { _lawyerOfficeID = value;
			      _isSetLawyerOfficeID = true; }
		}
		public bool _IsSetLawyerOfficeID
		{
			get { return _isSetLawyerOfficeID; }
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
	public class LawyerOfficeAddressData
	{
		private int _lawyerOfficeID;
		private int _addressID;
		private DateTime _modifiedDate;
		public int LawyerOfficeID
		{
			get{ return _lawyerOfficeID; }
			set{ _lawyerOfficeID = value; }
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
	public class LawyerOfficeAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerOfficeAddressRow[] lawyerOfficeAddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerOfficeAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerOfficeAddressItems : LawyerOfficeAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerOfficeAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerOfficeAddressItems[] lawyerOfficeAddressItems { get; set; }
	}
}

