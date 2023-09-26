using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class SubcommitteeRow
	{
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private int _subcommitteeGroupID;
		private bool _isSetSubcommitteeGroupID = false;
		private bool _subcommitteeGroupIDNull = true;
		private string _subcommitteeName;
		private bool _isSetSubcommitteeName = false;
		private string _appointmentNo;
		private bool _isSetAppointmentNo = false;
		private bool _isHeadquarter;
		private bool _isSetIsHeadquarter = false;
		private bool _isHeadquarterNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int SubcommitteeID
		{
			get { return _subcommitteeID; }
			set { _subcommitteeID = value;
			      _isSetSubcommitteeID = true; }
		}
		public bool _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
		}
		public int SubcommitteeGroupID
		{
			get
			{
				return _subcommitteeGroupID;
			}
			set
			{
				_subcommitteeGroupIDNull = false;
				_isSetSubcommitteeGroupID = true;
				_subcommitteeGroupID = value;
			}
		}
		public bool IsSubcommitteeGroupIDNull
		{
			get {
				 return _subcommitteeGroupIDNull; }
			set { _subcommitteeGroupIDNull = value; }
		}
		public bool _IsSetSubcommitteeGroupID
		{
			get { return _isSetSubcommitteeGroupID; }
		}
		public string SubcommitteeName
		{
			get { return _subcommitteeName; }
			set { _subcommitteeName = value;
			      _isSetSubcommitteeName = true; }
		}
		public bool _IsSetSubcommitteeName
		{
			get { return _isSetSubcommitteeName; }
		}
		public string AppointmentNo
		{
			get { return _appointmentNo; }
			set { _appointmentNo = value;
			      _isSetAppointmentNo = true; }
		}
		public bool _IsSetAppointmentNo
		{
			get { return _isSetAppointmentNo; }
		}
		public bool IsHeadquarter
		{
			get
			{
				return _isHeadquarter;
			}
			set
			{
				_isHeadquarterNull = false;
				_isSetIsHeadquarter = true;
				_isHeadquarter = value;
			}
		}
		public bool IsIsHeadquarterNull
		{
			get {
				 return _isHeadquarterNull; }
			set { _isHeadquarterNull = value; }
		}
		public bool _IsSetIsHeadquarter
		{
			get { return _isSetIsHeadquarter; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		[Required]
		public DateTime ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value;
			      _modifiedDateNull = false;
			      _isSetModifiedDate = true; }
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
	public class SubcommitteeData
	{
		private int _subcommitteeID;
		private int _subcommitteeGroupID;
		private string _subcommitteeName;
		private string _appointmentNo;
		private bool _isHeadquarter;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		public int SubcommitteeGroupID
		{
			get{ return _subcommitteeGroupID; }
			set{ _subcommitteeGroupID = value; }
		}
		public string SubcommitteeName
		{
			get{ return _subcommitteeName; }
			set{ _subcommitteeName = value; }
		}
		public string AppointmentNo
		{
			get{ return _appointmentNo; }
			set{ _appointmentNo = value; }
		}
		public bool IsHeadquarter
		{
			get{ return _isHeadquarter; }
			set{ _isHeadquarter = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class SubcommitteePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public SubcommitteeRow[] subcommitteeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส SubcommitteeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class SubcommitteeItems : SubcommitteeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class SubcommitteeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public SubcommitteeItems[] subcommitteeItems { get; set; }
	}
}

