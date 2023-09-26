using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class BailOutLevelRow
	{
		private int _bailOutLevelID;
		private bool _isSetBailOutLevelID = false;
		private string _bailOutLevelName;
		private bool _isSetBailOutLevelName = false;
		[Required]
		public int BailOutLevelID
		{
			get { return _bailOutLevelID; }
			set { _bailOutLevelID = value;
			      _isSetBailOutLevelID = true; }
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
	}
	[Serializable]
	public class BailOutLevelData
	{
		private int _bailOutLevelID;
		private string _bailOutLevelName;
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
	}
	[Serializable]
	public class BailOutLevelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public BailOutLevelRow[] bailOutLevelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส BailOutLevelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class BailOutLevelItems : BailOutLevelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class BailOutLevelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public BailOutLevelItems[] bailOutLevelItems { get; set; }
	}
}

