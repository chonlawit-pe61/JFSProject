using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class PrisonRow
	{
		private int _prisonID;
		private bool _isSetPrisonID = false;
		private int _prisonRegionID;
		private bool _isSetPrisonRegionID = false;
		private string _prisonName;
		private bool _isSetPrisonName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int PrisonID
		{
			get { return _prisonID; }
			set { _prisonID = value;
			      _isSetPrisonID = true; }
		}
		public bool _IsSetPrisonID
		{
			get { return _isSetPrisonID; }
		}
		[Required]
		public int PrisonRegionID
		{
			get { return _prisonRegionID; }
			set { _prisonRegionID = value;
			      _isSetPrisonRegionID = true; }
		}
		public bool _IsSetPrisonRegionID
		{
			get { return _isSetPrisonRegionID; }
		}
		[Required]
		public string PrisonName
		{
			get { return _prisonName; }
			set { _prisonName = value;
			      _isSetPrisonName = true; }
		}
		public bool _IsSetPrisonName
		{
			get { return _isSetPrisonName; }
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
	public class PrisonData
	{
		private int _prisonID;
		private int _prisonRegionID;
		private string _prisonName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int PrisonID
		{
			get{ return _prisonID; }
			set{ _prisonID = value; }
		}
		public int PrisonRegionID
		{
			get{ return _prisonRegionID; }
			set{ _prisonRegionID = value; }
		}
		public string PrisonName
		{
			get{ return _prisonName; }
			set{ _prisonName = value; }
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
	public class PrisonPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public PrisonRow[] prisonRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส PrisonItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class PrisonItems : PrisonData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class PrisonItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public PrisonItems[] prisonItems { get; set; }
	}
}

