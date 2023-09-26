using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SubcommitteeGroupListRow
	{
		private string _subcommitteeGroupCode;
		private bool _isSetSubcommitteeGroupCode = false;
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private string _subcommitteeGroupName;
		private bool _isSetSubcommitteeGroupName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		[Required]
		public string SubcommitteeGroupCode
		{
			get { return _subcommitteeGroupCode; }
			set { _subcommitteeGroupCode = value;
			      _isSetSubcommitteeGroupCode = true; }
		}
		public bool _IsSetSubcommitteeGroupCode
		{
			get { return _isSetSubcommitteeGroupCode; }
		}
		[Required]
		public int SubcommitteeID
		{
			get { return _subcommitteeID; }
			set { _subcommitteeID = value;
			      _isSetSubcommitteeID = true; }
		}
		public bool _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
		}
		public string SubcommitteeGroupName
		{
			get { return _subcommitteeGroupName; }
			set { _subcommitteeGroupName = value;
			      _isSetSubcommitteeGroupName = true; }
		}
		public bool _IsSetSubcommitteeGroupName
		{
			get { return _isSetSubcommitteeGroupName; }
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
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class SubcommitteeGroupListData
	{
		private string _subcommitteeGroupCode;
		private int _subcommitteeID;
		private string _subcommitteeGroupName;
		private DateTime _modifiedDate;
		private bool _isActive;
		public string SubcommitteeGroupCode
		{
			get{ return _subcommitteeGroupCode; }
			set{ _subcommitteeGroupCode = value; }
		}
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		public string SubcommitteeGroupName
		{
			get{ return _subcommitteeGroupName; }
			set{ _subcommitteeGroupName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class SubcommitteeGroupListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SubcommitteeGroupListRow[] subcommitteeGroupListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SubcommitteeGroupListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SubcommitteeGroupListItems : SubcommitteeGroupListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SubcommitteeGroupListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SubcommitteeGroupListItems[] subcommitteeGroupListItems { get; set; }
	}
}

