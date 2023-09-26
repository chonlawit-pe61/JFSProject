using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class BracketRow
	{
		private int _bracketID;
		private bool _isSetBracketID = false;
		private int _matterID;
		private bool _isSetMatterID = false;
		private bool _matterIDNull = true;
		private string _bracketName;
		private bool _isSetBracketName = false;
		private string _bracketDescription;
		private bool _isSetBracketDescription = false;
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
		public int MatterID
		{
			get
			{
				return _matterID;
			}
			set
			{
				_matterIDNull = false;
				_isSetMatterID = true;
				_matterID = value;
			}
		}
		public bool IsMatterIDNull
		{
			get {
				 return _matterIDNull; }
			set { _matterIDNull = value; }
		}
		public bool _IsSetMatterID
		{
			get { return _isSetMatterID; }
		}
		public string BracketName
		{
			get { return _bracketName; }
			set { _bracketName = value;
			      _isSetBracketName = true; }
		}
		public bool _IsSetBracketName
		{
			get { return _isSetBracketName; }
		}
		public string BracketDescription
		{
			get { return _bracketDescription; }
			set { _bracketDescription = value;
			      _isSetBracketDescription = true; }
		}
		public bool _IsSetBracketDescription
		{
			get { return _isSetBracketDescription; }
		}
	}
	[Serializable]
	public class BracketData
	{
		private int _bracketID;
		private int _matterID;
		private string _bracketName;
		private string _bracketDescription;
		public int BracketID
		{
			get{ return _bracketID; }
			set{ _bracketID = value; }
		}
		public int MatterID
		{
			get{ return _matterID; }
			set{ _matterID = value; }
		}
		public string BracketName
		{
			get{ return _bracketName; }
			set{ _bracketName = value; }
		}
		public string BracketDescription
		{
			get{ return _bracketDescription; }
			set{ _bracketDescription = value; }
		}
	}
	[Serializable]
	public class BracketPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public BracketRow[] bracketRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส BracketItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class BracketItems : BracketData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class BracketItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public BracketItems[] bracketItems { get; set; }
	}
}

