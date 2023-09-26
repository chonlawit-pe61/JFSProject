using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class RequestStatusRow
	{
		private int _statusID;
		private bool _isSetStatusID = false;
		private string _statusName;
		private bool _isSetStatusName = false;
		[Required]
		public int StatusID
		{
			get { return _statusID; }
			set { _statusID = value;
			      _isSetStatusID = true; }
		}
		public bool _IsSetStatusID
		{
			get { return _isSetStatusID; }
		}
		public string StatusName
		{
			get { return _statusName; }
			set { _statusName = value;
			      _isSetStatusName = true; }
		}
		public bool _IsSetStatusName
		{
			get { return _isSetStatusName; }
		}
	}
	[Serializable]
	public class RequestStatusData
	{
		private int _statusID;
		private string _statusName;
		public int StatusID
		{
			get{ return _statusID; }
			set{ _statusID = value; }
		}
		public string StatusName
		{
			get{ return _statusName; }
			set{ _statusName = value; }
		}
	}
	[Serializable]
	public class RequestStatusPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public RequestStatusRow[] requestStatusRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส RequestStatusItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class RequestStatusItems : RequestStatusData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class RequestStatusItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public RequestStatusItems[] requestStatusItems { get; set; }
	}
}

