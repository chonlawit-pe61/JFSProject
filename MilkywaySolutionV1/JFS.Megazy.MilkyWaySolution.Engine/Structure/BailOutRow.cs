using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class BailOutRow
	{
		private int _bailID;
		private bool _isSetBailID = false;
		private int _bailOutLevelID;
		private bool _isSetBailOutLevelID = false;
		private bool _bailOutLevelIDNull = true;
		private string _bailAt;
		private bool _isSetBailAt = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class BailOutData
	{
		private int _bailID;
		private int _bailOutLevelID;
		private string _bailAt;
		private DateTime _modifiedDate;
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
		public string BailAt
		{
			get{ return _bailAt; }
			set{ _bailAt = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class BailOutPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public BailOutRow[] bailOutRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส BailOutItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class BailOutItems : BailOutData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class BailOutItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public BailOutItems[] bailOutItems { get; set; }
	}
}

