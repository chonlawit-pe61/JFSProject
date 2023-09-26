using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CourtTypeRow
	{
		private int _courtTypeID;
		private bool _isSetCourtTypeID = false;
		private string _courtTypeName;
		private bool _isSetCourtTypeName = false;
		private bool _isOtherCourtType;
		private bool _isSetIsOtherCourtType = false;
		private bool _isOtherCourtTypeNull = true;
		[Required]
		public int CourtTypeID
		{
			get { return _courtTypeID; }
			set { _courtTypeID = value;
			      _isSetCourtTypeID = true; }
		}
		public bool _IsSetCourtTypeID
		{
			get { return _isSetCourtTypeID; }
		}
		public string CourtTypeName
		{
			get { return _courtTypeName; }
			set { _courtTypeName = value;
			      _isSetCourtTypeName = true; }
		}
		public bool _IsSetCourtTypeName
		{
			get { return _isSetCourtTypeName; }
		}
		public bool IsOtherCourtType
		{
			get
			{
				return _isOtherCourtType;
			}
			set
			{
				_isOtherCourtTypeNull = false;
				_isSetIsOtherCourtType = true;
				_isOtherCourtType = value;
			}
		}
		public bool IsIsOtherCourtTypeNull
		{
			get {
				 return _isOtherCourtTypeNull; }
			set { _isOtherCourtTypeNull = value; }
		}
		public bool _IsSetIsOtherCourtType
		{
			get { return _isSetIsOtherCourtType; }
		}
	}
	[Serializable]
	public class CourtTypeData
	{
		private int _courtTypeID;
		private string _courtTypeName;
		private bool _isOtherCourtType;
		public int CourtTypeID
		{
			get{ return _courtTypeID; }
			set{ _courtTypeID = value; }
		}
		public string CourtTypeName
		{
			get{ return _courtTypeName; }
			set{ _courtTypeName = value; }
		}
		public bool IsOtherCourtType
		{
			get{ return _isOtherCourtType; }
			set{ _isOtherCourtType = value; }
		}
	}
	[Serializable]
	public class CourtTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CourtTypeRow[] courtTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CourtTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CourtTypeItems : CourtTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CourtTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CourtTypeItems[] courtTypeItems { get; set; }
	}
}

