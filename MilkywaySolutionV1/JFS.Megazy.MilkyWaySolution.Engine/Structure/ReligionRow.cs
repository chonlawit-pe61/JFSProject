using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ReligionRow
	{
		private int _religionID;
		private bool _isSetReligionID = false;
		private string _religionCode;
		private bool _isSetReligionCode = false;
		private string _religionName;
		private bool _isSetReligionName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isOther;
		private bool _isSetIsOther = false;
		private bool _isOtherNull = true;
		[Required]
		public int ReligionID
		{
			get { return _religionID; }
			set { _religionID = value;
			      _isSetReligionID = true; }
		}
		public bool _IsSetReligionID
		{
			get { return _isSetReligionID; }
		}
		public string ReligionCode
		{
			get { return _religionCode; }
			set { _religionCode = value;
			      _isSetReligionCode = true; }
		}
		public bool _IsSetReligionCode
		{
			get { return _isSetReligionCode; }
		}
		public string ReligionName
		{
			get { return _religionName; }
			set { _religionName = value;
			      _isSetReligionName = true; }
		}
		public bool _IsSetReligionName
		{
			get { return _isSetReligionName; }
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
		public bool IsOther
		{
			get
			{
				return _isOther;
			}
			set
			{
				_isOtherNull = false;
				_isSetIsOther = true;
				_isOther = value;
			}
		}
		public bool IsIsOtherNull
		{
			get {
				 return _isOtherNull; }
			set { _isOtherNull = value; }
		}
		public bool _IsSetIsOther
		{
			get { return _isSetIsOther; }
		}
	}
	[Serializable]
	public class ReligionData
	{
		private int _religionID;
		private string _religionCode;
		private string _religionName;
		private bool _isActive;
		private bool _isOther;
		public int ReligionID
		{
			get{ return _religionID; }
			set{ _religionID = value; }
		}
		public string ReligionCode
		{
			get{ return _religionCode; }
			set{ _religionCode = value; }
		}
		public string ReligionName
		{
			get{ return _religionName; }
			set{ _religionName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public bool IsOther
		{
			get{ return _isOther; }
			set{ _isOther = value; }
		}
	}
	[Serializable]
	public class ReligionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ReligionRow[] religionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ReligionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ReligionItems : ReligionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ReligionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ReligionItems[] religionItems { get; set; }
	}
}

