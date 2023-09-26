using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class RecordMaxRunNoRow
	{
		private int _recordMaxID;
		private bool _isSetRecordMaxID = false;
		private string _recordName;
		private bool _isSetRecordName = false;
		private int _maxNo;
		private bool _isSetMaxNo = false;
		private string _prefix;
		private bool _isSetPrefix = false;
		[Required]
		public int RecordMaxID
		{
			get { return _recordMaxID; }
			set { _recordMaxID = value;
			      _isSetRecordMaxID = true; }
		}
		public bool _IsSetRecordMaxID
		{
			get { return _isSetRecordMaxID; }
		}
		[Required]
		public string RecordName
		{
			get { return _recordName; }
			set { _recordName = value;
			      _isSetRecordName = true; }
		}
		public bool _IsSetRecordName
		{
			get { return _isSetRecordName; }
		}
		[Required]
		public int MaxNo
		{
			get { return _maxNo; }
			set { _maxNo = value;
			      _isSetMaxNo = true; }
		}
		public bool _IsSetMaxNo
		{
			get { return _isSetMaxNo; }
		}
		[Required]
		public string Prefix
		{
			get { return _prefix; }
			set { _prefix = value;
			      _isSetPrefix = true; }
		}
		public bool _IsSetPrefix
		{
			get { return _isSetPrefix; }
		}
	}
	[Serializable]
	public class RecordMaxRunNoData
	{
		private int _recordMaxID;
		private string _recordName;
		private int _maxNo;
		private string _prefix;
		public int RecordMaxID
		{
			get{ return _recordMaxID; }
			set{ _recordMaxID = value; }
		}
		public string RecordName
		{
			get{ return _recordName; }
			set{ _recordName = value; }
		}
		public int MaxNo
		{
			get{ return _maxNo; }
			set{ _maxNo = value; }
		}
		public string Prefix
		{
			get{ return _prefix; }
			set{ _prefix = value; }
		}
	}
	[Serializable]
	public class RecordMaxRunNoPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public RecordMaxRunNoRow[] recordMaxrunNoRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส RecordMaxRunNoItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class RecordMaxRunNoItems : RecordMaxRunNoData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class RecordMaxRunNoItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public RecordMaxRunNoItems[] recordMaxrunNoItems { get; set; }
	}
}

