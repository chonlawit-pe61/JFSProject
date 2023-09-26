using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OffenseHistoryRow
	{
		private int _escapeSupportID;
		private bool _isSetEscapeSupportID = false;
		private string _conductDetail;
		private bool _isSetConductDetail = false;
		private string _offenseDetail;
		private bool _isSetOffenseDetail = false;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
		private bool _historyStatus;
		private bool _isSetHistoryStatus = false;
		private bool _historyStatusNull = true;
		[Required]
		public int EscapeSupportID
		{
			get { return _escapeSupportID; }
			set { _escapeSupportID = value;
			      _isSetEscapeSupportID = true; }
		}
		public bool _IsSetEscapeSupportID
		{
			get { return _isSetEscapeSupportID; }
		}
		public string ConductDetail
		{
			get { return _conductDetail; }
			set { _conductDetail = value;
			      _isSetConductDetail = true; }
		}
		public bool _IsSetConductDetail
		{
			get { return _isSetConductDetail; }
		}
		public string OffenseDetail
		{
			get { return _offenseDetail; }
			set { _offenseDetail = value;
			      _isSetOffenseDetail = true; }
		}
		public bool _IsSetOffenseDetail
		{
			get { return _isSetOffenseDetail; }
		}
		[Required]
		public DateTime Modified
		{
			get { return _modified; }
			set { _modified = value;
			      _modifiedNull = false;
			      _isSetModified = true; }
		}
		public bool IsModifiedNull
		{
			get {
				 return _modifiedNull; }
			set { _modifiedNull = value; }
		}
		public bool _IsSetModified
		{
			get { return _isSetModified; }
		}
		public bool HistoryStatus
		{
			get
			{
				return _historyStatus;
			}
			set
			{
				_historyStatusNull = false;
				_isSetHistoryStatus = true;
				_historyStatus = value;
			}
		}
		public bool IsHistoryStatusNull
		{
			get {
				 return _historyStatusNull; }
			set { _historyStatusNull = value; }
		}
		public bool _IsSetHistoryStatus
		{
			get { return _isSetHistoryStatus; }
		}
	}
	[Serializable]
	public class OffenseHistoryData
	{
		private int _escapeSupportID;
		private string _conductDetail;
		private string _offenseDetail;
		private DateTime _modified;
		private bool _historyStatus;
		public int EscapeSupportID
		{
			get{ return _escapeSupportID; }
			set{ _escapeSupportID = value; }
		}
		public string ConductDetail
		{
			get{ return _conductDetail; }
			set{ _conductDetail = value; }
		}
		public string OffenseDetail
		{
			get{ return _offenseDetail; }
			set{ _offenseDetail = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
		public bool HistoryStatus
		{
			get{ return _historyStatus; }
			set{ _historyStatus = value; }
		}
	}
	[Serializable]
	public class OffenseHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OffenseHistoryRow[] offenseHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OffenseHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OffenseHistoryItems : OffenseHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OffenseHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OffenseHistoryItems[] offenseHistoryItems { get; set; }
	}
}

