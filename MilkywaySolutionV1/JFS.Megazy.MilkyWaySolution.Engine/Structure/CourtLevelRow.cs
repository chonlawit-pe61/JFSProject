using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CourtLevelRow
	{
		private int _courtLevelID;
		private bool _isSetCourtLevelID = false;
		private string _courtLevelName;
		private bool _isSetCourtLevelName = false;
		[Required]
		public int CourtLevelID
		{
			get { return _courtLevelID; }
			set { _courtLevelID = value;
			      _isSetCourtLevelID = true; }
		}
		public bool _IsSetCourtLevelID
		{
			get { return _isSetCourtLevelID; }
		}
		public string CourtLevelName
		{
			get { return _courtLevelName; }
			set { _courtLevelName = value;
			      _isSetCourtLevelName = true; }
		}
		public bool _IsSetCourtLevelName
		{
			get { return _isSetCourtLevelName; }
		}
	}
	[Serializable]
	public class CourtLevelData
	{
		private int _courtLevelID;
		private string _courtLevelName;
		public int CourtLevelID
		{
			get{ return _courtLevelID; }
			set{ _courtLevelID = value; }
		}
		public string CourtLevelName
		{
			get{ return _courtLevelName; }
			set{ _courtLevelName = value; }
		}
	}
	[Serializable]
	public class CourtLevelPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CourtLevelRow[] courtLevelRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CourtLevelItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CourtLevelItems : CourtLevelData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CourtLevelItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CourtLevelItems[] courtLevelItems { get; set; }
	}
}

