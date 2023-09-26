using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MatterMapBracketRow
	{
		private int _matterID;
		private bool _isSetMatterID = false;
		private int _bracketID;
		private bool _isSetBracketID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int MatterID
		{
			get { return _matterID; }
			set { _matterID = value;
			      _isSetMatterID = true; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		[Required]
		public int BracketID
		{
			get { return _bracketID; }
			set { _bracketID = value;
			      _isSetBracketID = true; }
		}
		public bool _IsSetBracketID
		{
			get { return _isSetBracketID; }
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
	public class MatterMapBracketData
	{
		private int _matterID;
		private int _bracketID;
		private DateTime _modifiedDate;
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public int BracketID
		{
			get{ return _bracketID; }
			set{ _bracketID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class MatterMapBracketPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MatterMapBracketRow[] mattermapBracketRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MatterMapBracketItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MatterMapBracketItems : MatterMapBracketData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MatterMapBracketItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MatterMapBracketItems[] mattermapBracketItems { get; set; }
	}
}

