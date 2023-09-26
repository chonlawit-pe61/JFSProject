using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CommitteeRow
	{
		private int _committeeID;
		private bool _isSetCommitteeID = false;
		private string _committee;
		private bool _isSetCommittee = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CommitteeID
		{
			get { return _committeeID; }
			set { _committeeID = value;
			      _isSetCommitteeID = true; }
		}
		public bool _IsSetCommitteeID
		{
			get { return _isSetCommitteeID; }
		}
		public string Committee
		{
			get { return _committee; }
			set { _committee = value;
			      _isSetCommittee = true; }
		}
		public bool _IsSetCommittee
		{
			get { return _isSetCommittee; }
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
	public class CommitteeData
	{
		private int _committeeID;
		private string _committee;
		private DateTime _modifiedDate;
		public int CommitteeID
		{
			get{ return _committeeID; }
			set{ _committeeID = value; }
		}
		public string Committee
		{
			get{ return _committee; }
			set{ _committee = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CommitteePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CommitteeRow[] committeeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CommitteeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CommitteeItems : CommitteeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CommitteeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CommitteeItems[] committeeItems { get; set; }
	}
}

