using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ComplaintChannelRow
	{
		private int _channelID;
		private bool _isSetChannelID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _channelName;
		private bool _isSetChannelName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		[Required]
		public int ChannelID
		{
			get { return _channelID; }
			set { _channelID = value;
			      _isSetChannelID = true; }
		}
		public bool _IsSetChannelID
		{
			get { return _isSetChannelID; }
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
		public string ChannelName
		{
			get { return _channelName; }
			set { _channelName = value;
			      _isSetChannelName = true; }
		}
		public bool _IsSetChannelName
		{
			get { return _isSetChannelName; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
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
	}
	[Serializable]
	public class View_ComplaintChannelData
	{
		private int _channelID;
		private int _jFCaseTypeID;
		private string _channelName;
		private int _sortOrder;
		private bool _isActive;
		public int ChannelID
		{
			get{ return _channelID; }
			set{ _channelID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string ChannelName
		{
			get{ return _channelName; }
			set{ _channelName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class View_ComplaintChannelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ComplaintChannelRow[] view_ComplaintChannelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ComplaintChannelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ComplaintChannelItems : View_ComplaintChannelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ComplaintChannelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ComplaintChannelItems[] view_ComplaintChannelItems { get; set; }
	}
}

