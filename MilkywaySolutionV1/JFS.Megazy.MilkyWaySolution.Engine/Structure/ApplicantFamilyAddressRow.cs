using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantFamilyAddressRow
	{
		private int _familyID;
		private bool _isSetFamilyID = false;
		private int _addressID;
		private bool _isSetAddressID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int FamilyID
		{
			get { return _familyID; }
			set { _familyID = value;
			      _isSetFamilyID = true; }
		}
		public bool _IsSetFamilyID
		{
			get { return _isSetFamilyID; }
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
	public class ApplicantFamilyAddressData
	{
		private int _familyID;
		private int _addressID;
		private DateTime _modifiedDate;
		public int FamilyID
		{
			get{ return _familyID; }
			set{ _familyID = value; }
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
	public class ApplicantFamilyAddressPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantFamilyAddressRow[] applicantFamilyaddressRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantFamilyAddressItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantFamilyAddressItems : ApplicantFamilyAddressData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantFamilyAddressItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantFamilyAddressItems[] applicantFamilyaddressItems { get; set; }
	}
}

