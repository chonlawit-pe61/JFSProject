using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ComplaintChannelMapJFCaseTypeRow
	{
		private int _channelID;
		private bool _isSetChannelID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
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
	}
	[Serializable]
	public class ComplaintChannelMapJFCaseTypeData
	{
		private int _channelID;
		private int _jFCaseTypeID;
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
	}
	[Serializable]
	public class ComplaintChannelMapJFCaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ComplaintChannelMapJFCaseTypeRow[] complaintchannelMapJFcaseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ComplaintChannelMapJFCaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ComplaintChannelMapJFCaseTypeItems : ComplaintChannelMapJFCaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ComplaintChannelMapJFCaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ComplaintChannelMapJFCaseTypeItems[] complaintchannelMapJFcaseTypeItems { get; set; }
	}
}

