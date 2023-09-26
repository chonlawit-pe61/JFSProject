using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ArchivalCopyRow
	{
		private int _archivalCopyID;
		private bool _isSetArchivalCopyID = false;
		private string _archivalName;
		private bool _isSetArchivalName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ArchivalCopyID
		{
			get { return _archivalCopyID; }
			set { _archivalCopyID = value;
			      _isSetArchivalCopyID = true; }
		}
		public bool _IsSetArchivalCopyID
		{
			get { return _isSetArchivalCopyID; }
		}
		[Required]
		public string ArchivalName
		{
			get { return _archivalName; }
			set { _archivalName = value;
			      _isSetArchivalName = true; }
		}
		public bool _IsSetArchivalName
		{
			get { return _isSetArchivalName; }
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
	public class ArchivalCopyData
	{
		private int _archivalCopyID;
		private string _archivalName;
		private DateTime _modifiedDate;
		public int ArchivalCopyID
		{
			get{ return _archivalCopyID; }
			set{ _archivalCopyID = value; }
		}
		public string ArchivalName
		{
			get{ return _archivalName; }
			set{ _archivalName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ArchivalCopyPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ArchivalCopyRow[] archivalCopyRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ArchivalCopyItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ArchivalCopyItems : ArchivalCopyData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ArchivalCopyItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ArchivalCopyItems[] archivalCopyItems { get; set; }
	}
}

