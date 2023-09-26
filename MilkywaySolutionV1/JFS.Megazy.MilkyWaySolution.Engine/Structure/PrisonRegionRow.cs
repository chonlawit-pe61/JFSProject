using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class PrisonRegionRow
	{
		private int _prisonRegionID;
		private bool _isSetPrisonRegionID = false;
		private string _prisonRegionName;
		private bool _isSetPrisonRegionName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public string PrisonRegionName
		{
			get { return _prisonRegionName; }
			set { _prisonRegionName = value;
			      _isSetPrisonRegionName = true; }
		}
		public bool _IsSetPrisonRegionName
		{
			get { return _isSetPrisonRegionName; }
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
	public class PrisonRegionData
	{
		private int _prisonRegionID;
		private string _prisonRegionName;
		private DateTime _modifiedDate;
		public int PrisonRegionID
		{
			get{ return _prisonRegionID; }
			set{ _prisonRegionID = value; }
		}
		public string PrisonRegionName
		{
			get{ return _prisonRegionName; }
			set{ _prisonRegionName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class PrisonRegionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public PrisonRegionRow[] prisonRegionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส PrisonRegionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class PrisonRegionItems : PrisonRegionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class PrisonRegionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public PrisonRegionItems[] prisonRegionItems { get; set; }
	}
}

