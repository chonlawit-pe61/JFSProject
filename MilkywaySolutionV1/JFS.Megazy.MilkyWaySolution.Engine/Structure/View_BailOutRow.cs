using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_BailOutRow
	{
		private int _bailID;
		private bool _isSetBailID = false;
		private int _bailOutLevelID;
		private bool _isSetBailOutLevelID = false;
		private bool _bailOutLevelIDNull = true;
		private string _bailOutLevelName;
		private bool _isSetBailOutLevelName = false;
		private string _bailAt;
		private bool _isSetBailAt = false;
		[Required]
		public int BailID
		{
			get { return _bailID; }
			set { _bailID = value;
			      _isSetBailID = true; }
		}
		public bool _IsSetBailID
		{
			get { return _isSetBailID; }
		}
		public int BailOutLevelID
		{
			get
			{
				return _bailOutLevelID;
			}
			set
			{
				_bailOutLevelIDNull = false;
				_isSetBailOutLevelID = true;
				_bailOutLevelID = value;
			}
		}
		public bool IsBailOutLevelIDNull
		{
			get {
				 return _bailOutLevelIDNull; }
			set { _bailOutLevelIDNull = value; }
		}
		public bool _IsSetBailOutLevelID
		{
			get { return _isSetBailOutLevelID; }
		}
		public string BailOutLevelName
		{
			get { return _bailOutLevelName; }
			set { _bailOutLevelName = value;
			      _isSetBailOutLevelName = true; }
		}
		public bool _IsSetBailOutLevelName
		{
			get { return _isSetBailOutLevelName; }
		}
		public string BailAt
		{
			get { return _bailAt; }
			set { _bailAt = value;
			      _isSetBailAt = true; }
		}
		public bool _IsSetBailAt
		{
			get { return _isSetBailAt; }
		}
	}
	[Serializable]
	public class View_BailOutData
	{
		private int _bailID;
		private int _bailOutLevelID;
		private string _bailOutLevelName;
		private string _bailAt;
		public int BailID
		{
			get{ return _bailID; }
			set{ _bailID = value; }
		}
		public int BailOutLevelID
		{
			get{ return _bailOutLevelID; }
			set{ _bailOutLevelID = value; }
		}
		public string BailOutLevelName
		{
			get{ return _bailOutLevelName; }
			set{ _bailOutLevelName = value; }
		}
		public string BailAt
		{
			get{ return _bailAt; }
			set{ _bailAt = value; }
		}
	}
	[Serializable]
	public class View_BailOutPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_BailOutRow[] view_BailOutRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_BailOutItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_BailOutItems : View_BailOutData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_BailOutItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_BailOutItems[] view_BailOutItems { get; set; }
	}
}

