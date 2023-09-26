using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CourtRow
	{
		private int _courtID;
		private bool _isSetCourtID = false;
		private int _courtGroupID;
		private bool _isSetCourtGroupID = false;
		private bool _courtGroupIDNull = true;
		private string _courtName;
		private bool _isSetCourtName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private int _provinceID;
		private bool _isSetProvinceID = false;
		private bool _provinceIDNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CourtID
		{
			get { return _courtID; }
			set { _courtID = value;
			      _isSetCourtID = true; }
		}
		public bool _IsSetCourtID
		{
			get { return _isSetCourtID; }
		}
		public int CourtGroupID
		{
			get
			{
				return _courtGroupID;
			}
			set
			{
				_courtGroupIDNull = false;
				_isSetCourtGroupID = true;
				_courtGroupID = value;
			}
		}
		public bool IsCourtGroupIDNull
		{
			get {
				 return _courtGroupIDNull; }
			set { _courtGroupIDNull = value; }
		}
		public bool _IsSetCourtGroupID
		{
			get { return _isSetCourtGroupID; }
		}
		public string CourtName
		{
			get { return _courtName; }
			set { _courtName = value;
			      _isSetCourtName = true; }
		}
		public bool _IsSetCourtName
		{
			get { return _isSetCourtName; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public int ProvinceID
		{
			get
			{
				return _provinceID;
			}
			set
			{
				_provinceIDNull = false;
				_isSetProvinceID = true;
				_provinceID = value;
			}
		}
		public bool IsProvinceIDNull
		{
			get {
				 return _provinceIDNull; }
			set { _provinceIDNull = value; }
		}
		public bool _IsSetProvinceID
		{
			get { return _isSetProvinceID; }
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
	public class CourtData
	{
		private int _courtID;
		private int _courtGroupID;
		private string _courtName;
		private bool _isActive;
		private int _provinceID;
		private DateTime _modifiedDate;
		public int CourtID
		{
			get{ return _courtID; }
			set{ _courtID = value; }
		}
		public int CourtGroupID
		{
			get{ return _courtGroupID; }
			set{ _courtGroupID = value; }
		}
		public string CourtName
		{
			get{ return _courtName; }
			set{ _courtName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public int ProvinceID
		{
			get{ return _provinceID; }
			set{ _provinceID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CourtPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CourtRow[] courtRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CourtItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CourtItems : CourtData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CourtItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CourtItems[] courtItems { get; set; }
	}
}

