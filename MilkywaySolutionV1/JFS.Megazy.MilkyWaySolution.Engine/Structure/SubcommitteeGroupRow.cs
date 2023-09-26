using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SubcommitteeGroupRow
	{
		private int _subcommitteeGroupID;
		private bool _isSetSubcommitteeGroupID = false;
		private string _subcommitteeGroupName;
		private bool _isSetSubcommitteeGroupName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		[Required]
		public int SubcommitteeGroupID
		{
			get { return _subcommitteeGroupID; }
			set { _subcommitteeGroupID = value;
			      _isSetSubcommitteeGroupID = true; }
		}
		public bool _IsSetSubcommitteeGroupID
		{
			get { return _isSetSubcommitteeGroupID; }
		}
		[Required]
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
	public class SubcommitteeGroupData
	{
		private int _subcommitteeGroupID;
		private string _subcommitteeGroupName;
		private bool _isActive;
		public int SubcommitteeGroupID
		{
			get{ return _subcommitteeGroupID; }
			set{ _subcommitteeGroupID = value; }
		}
		public string SubcommitteeGroupName
		{
			get{ return _subcommitteeGroupName; }
			set{ _subcommitteeGroupName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class SubcommitteeGroupPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SubcommitteeGroupRow[] subcommitteeGroupRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SubcommitteeGroupItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SubcommitteeGroupItems : SubcommitteeGroupData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SubcommitteeGroupItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SubcommitteeGroupItems[] subcommitteeGroupItems { get; set; }
	}
}

