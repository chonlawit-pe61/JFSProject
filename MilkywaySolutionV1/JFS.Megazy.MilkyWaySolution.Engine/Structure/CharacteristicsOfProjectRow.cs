using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CharacteristicsOfProjectRow
	{
		private int _characteristicID;
		private bool _isSetCharacteristicID = false;
		private string _characteristic;
		private bool _isSetCharacteristic = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CharacteristicID
		{
			get { return _characteristicID; }
			set { _characteristicID = value;
			      _isSetCharacteristicID = true; }
		}
		public bool _IsSetCharacteristicID
		{
			get { return _isSetCharacteristicID; }
		}
		public string Characteristic
		{
			get { return _characteristic; }
			set { _characteristic = value;
			      _isSetCharacteristic = true; }
		}
		public bool _IsSetCharacteristic
		{
			get { return _isSetCharacteristic; }
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
	public class CharacteristicsOfProjectData
	{
		private int _characteristicID;
		private string _characteristic;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int CharacteristicID
		{
			get{ return _characteristicID; }
			set{ _characteristicID = value; }
		}
		public string Characteristic
		{
			get{ return _characteristic; }
			set{ _characteristic = value; }
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
	public class CharacteristicsOfProjectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CharacteristicsOfProjectRow[] characteristicsOfProjectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CharacteristicsOfProjectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CharacteristicsOfProjectItems : CharacteristicsOfProjectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CharacteristicsOfProjectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CharacteristicsOfProjectItems[] characteristicsOfProjectItems { get; set; }
	}
}

