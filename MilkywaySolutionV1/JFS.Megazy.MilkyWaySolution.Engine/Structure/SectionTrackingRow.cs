using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SectionTrackingRow
	{
		private int _sectionID;
		private bool _isSetSectionID = false;
		private string _sectionName;
		private bool _isSetSectionName = false;
		private bool _isCaseSection;
		private bool _isSetIsCaseSection = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int SectionID
		{
			get { return _sectionID; }
			set { _sectionID = value;
			      _isSetSectionID = true; }
		}
		public bool _IsSetSectionID
		{
			get { return _isSetSectionID; }
		}
		[Required]
		public string SectionName
		{
			get { return _sectionName; }
			set { _sectionName = value;
			      _isSetSectionName = true; }
		}
		public bool _IsSetSectionName
		{
			get { return _isSetSectionName; }
		}
		[Required]
		public bool IsCaseSection
		{
			get { return _isCaseSection; }
			set { _isCaseSection = value;
			      _isSetIsCaseSection = true; }
		}
		public bool _IsSetIsCaseSection
		{
			get { return _isSetIsCaseSection; }
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
	public class SectionTrackingData
	{
		private int _sectionID;
		private string _sectionName;
		private bool _isCaseSection;
		private DateTime _modifiedDate;
		public int SectionID
		{
			get{ return _sectionID; }
			set{ _sectionID = value; }
		}
		public string SectionName
		{
			get{ return _sectionName; }
			set{ _sectionName = value; }
		}
		public bool IsCaseSection
		{
			get{ return _isCaseSection; }
			set{ _isCaseSection = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class SectionTrackingPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SectionTrackingRow[] sectionTrackingRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SectionTrackingItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SectionTrackingItems : SectionTrackingData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SectionTrackingItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SectionTrackingItems[] sectionTrackingItems { get; set; }
	}
}

