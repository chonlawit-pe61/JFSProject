using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ArchivalCopyMapJFCaseTypeRow
	{
		private int _archivalCopyID;
		private bool _isSetArchivalCopyID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
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
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
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
	public class ArchivalCopyMapJFCaseTypeData
	{
		private int _archivalCopyID;
		private int _jFCaseTypeID;
		private DateTime _modifiedDate;
		public int ArchivalCopyID
		{
			get{ return _archivalCopyID; }
			set{ _archivalCopyID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ArchivalCopyMapJFCaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ArchivalCopyMapJFCaseTypeRow[] archivalCopyMapJFCaseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ArchivalCopyMapJFCaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ArchivalCopyMapJFCaseTypeItems : ArchivalCopyMapJFCaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ArchivalCopyMapJFCaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ArchivalCopyMapJFCaseTypeItems[] archivalCopyMapJFCaseTypeItems { get; set; }
	}
}

