using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class RaceRow
	{
		private int _raceID;
		private bool _isSetRaceID = false;
		private string _raceName;
		private bool _isSetRaceName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int RaceID
		{
			get { return _raceID; }
			set { _raceID = value;
			      _isSetRaceID = true; }
		}
		public bool _IsSetRaceID
		{
			get { return _isSetRaceID; }
		}
		public string RaceName
		{
			get { return _raceName; }
			set { _raceName = value;
			      _isSetRaceName = true; }
		}
		public bool _IsSetRaceName
		{
			get { return _isSetRaceName; }
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
	public class RaceData
	{
		private int _raceID;
		private string _raceName;
		private DateTime _modifiedDate;
		public int RaceID
		{
			get{ return _raceID; }
			set{ _raceID = value; }
		}
		public string RaceName
		{
			get{ return _raceName; }
			set{ _raceName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class RacePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public RaceRow[] raceRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส RaceItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class RaceItems : RaceData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class RaceItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public RaceItems[] raceItems { get; set; }
	}
}

