using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_SubcommitteeRow
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
		private string _subcommitteeGroupName;
		private bool _isSetSubcommitteeGroupName = false;
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
		public string SubcommitteeGroupName
		{
			get { return _subcommitteeGroupName; }
			set { _subcommitteeGroupName = value;
			      _isSetSubcommitteeGroupName = true; }
		}
		public bool _IsSetSubcommitteeGroupName
		{
			get { return _isSetSubcommitteeGroupName; }
		}
	}
	[Serializable]
	public class View_SubcommitteeData
	{
		private int _subcommitteeID;
		private int _subcommitteeGroupID;
		private string _subcommitteeName;
		private string _appointmentNo;
		private bool _isHeadquarter;
		private bool _isActive;
		private string _subcommitteeGroupName;
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
		public string SubcommitteeGroupName
		{
			get{ return _subcommitteeGroupName; }
			set{ _subcommitteeGroupName = value; }
		}
	}
	[Serializable]
	public class View_SubcommitteePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_SubcommitteeRow[] view_SubcommitteeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_SubcommitteeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_SubcommitteeItems : View_SubcommitteeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_SubcommitteeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_SubcommitteeItems[] view_SubcommitteeItems { get; set; }
	}
}

