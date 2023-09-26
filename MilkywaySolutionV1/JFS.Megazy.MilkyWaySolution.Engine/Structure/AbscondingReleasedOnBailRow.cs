using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class AbscondingReleasedOnBailRow
	{
		private int _escapeSupportID;
		private bool _isSetEscapeSupportID = false;
		private bool _escapeStatus;
		private bool _isSetEscapeStatus = false;
		private bool _escapeStatusNull = true;
		private string _detail;
		private bool _isSetDetail = false;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
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
		public bool EscapeStatus
		{
			get
			{
				return _escapeStatus;
			}
			set
			{
				_escapeStatusNull = false;
				_isSetEscapeStatus = true;
				_escapeStatus = value;
			}
		}
		public bool IsEscapeStatusNull
		{
			get {
				 return _escapeStatusNull; }
			set { _escapeStatusNull = value; }
		}
		public bool _IsSetEscapeStatus
		{
			get { return _isSetEscapeStatus; }
		}
		public string Detail
		{
			get { return _detail; }
			set { _detail = value;
			      _isSetDetail = true; }
		}
		public bool _IsSetDetail
		{
			get { return _isSetDetail; }
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
	}
	[Serializable]
	public class AbscondingReleasedOnBailData
	{
		private int _escapeSupportID;
		private bool _escapeStatus;
		private string _detail;
		private DateTime _modified;
		public int EscapeSupportID
		{
			get{ return _escapeSupportID; }
			set{ _escapeSupportID = value; }
		}
		public bool EscapeStatus
		{
			get{ return _escapeStatus; }
			set{ _escapeStatus = value; }
		}
		public string Detail
		{
			get{ return _detail; }
			set{ _detail = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class AbscondingReleasedOnBailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AbscondingReleasedOnBailRow[] abscondingReleasedOnBailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AbscondingReleasedOnBailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AbscondingReleasedOnBailItems : AbscondingReleasedOnBailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AbscondingReleasedOnBailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AbscondingReleasedOnBailItems[] abscondingReleasedOnBailItems { get; set; }
	}
}

