using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CourtGroupRow
	{
		private int _courtGroupID;
		private bool _isSetCourtGroupID = false;
		private string _courtGroupName;
		private bool _isSetCourtGroupName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CourtGroupID
		{
			get { return _courtGroupID; }
			set { _courtGroupID = value;
			      _isSetCourtGroupID = true; }
		}
		public bool _IsSetCourtGroupID
		{
			get { return _isSetCourtGroupID; }
		}
		[Required]
		public string CourtGroupName
		{
			get { return _courtGroupName; }
			set { _courtGroupName = value;
			      _isSetCourtGroupName = true; }
		}
		public bool _IsSetCourtGroupName
		{
			get { return _isSetCourtGroupName; }
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
	public class CourtGroupData
	{
		private int _courtGroupID;
		private string _courtGroupName;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int CourtGroupID
		{
			get{ return _courtGroupID; }
			set{ _courtGroupID = value; }
		}
		public string CourtGroupName
		{
			get{ return _courtGroupName; }
			set{ _courtGroupName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CourtGroupPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CourtGroupRow[] courtGroupRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CourtGroupItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CourtGroupItems : CourtGroupData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CourtGroupItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CourtGroupItems[] courtGroupItems { get; set; }
	}
}

