using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseSubcommitteeConsiderationRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _subcommitteeID;
		private bool _isSetSubcommitteeID = false;
		private bool _subcommitteeIDNull = true;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private bool _officerRoleIDNull = true;
		private int _termID;
		private bool _isSetTermID = false;
		private bool _termIDNull = true;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private bool _isAppealNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		/// <summary>
		/// รหัสคณะอนุกรรมการพิจารณาสำนวน อ้างอิงตาราง
		/// </summary>
		public int SubcommitteeID
		{
			get
			{
				return _subcommitteeID;
			}
			set
			{
				_subcommitteeIDNull = false;
				_isSetSubcommitteeID = true;
				_subcommitteeID = value;
			}
		}
		public bool IsSubcommitteeIDNull
		{
			get {
				 return _subcommitteeIDNull; }
			set { _subcommitteeIDNull = value; }
		}
		public bool _IsSetSubcommitteeID
		{
			get { return _isSetSubcommitteeID; }
		}
		/// <summary>
		/// รหัสบทบาทเจ้าหน้าที่ อ้างอิงตาราง OfficerRole
		/// </summary>
		public int OfficerRoleID
		{
			get
			{
				return _officerRoleID;
			}
			set
			{
				_officerRoleIDNull = false;
				_isSetOfficerRoleID = true;
				_officerRoleID = value;
			}
		}
		public bool IsOfficerRoleIDNull
		{
			get {
				 return _officerRoleIDNull; }
			set { _officerRoleIDNull = value; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		/// <summary>
		/// รหัสวาระการประชุม อ้างอิงตาราง Term เช่น วาระปกติ วาระสืบเนื่อง วาระแร่งด่วน
		/// </summary>
		public int TermID
		{
			get
			{
				return _termID;
			}
			set
			{
				_termIDNull = false;
				_isSetTermID = true;
				_termID = value;
			}
		}
		public bool IsTermIDNull
		{
			get {
				 return _termIDNull; }
			set { _termIDNull = value; }
		}
		public bool _IsSetTermID
		{
			get { return _isSetTermID; }
		}
		/// <summary>
		/// เป็นสำนวนที่อุทธรณ์ใช่หรือไม่ 1=ใช่ 0=ไม่ใช่
		/// </summary>
		public bool IsAppeal
		{
			get
			{
				return _isAppeal;
			}
			set
			{
				_isAppealNull = false;
				_isSetIsAppeal = true;
				_isAppeal = value;
			}
		}
		public bool IsIsAppealNull
		{
			get {
				 return _isAppealNull; }
			set { _isAppealNull = value; }
		}
		public bool _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
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
	public class CaseSubcommitteeConsiderationData
	{
		private int _caseID;
		private int _subcommitteeID;
		private int _officerRoleID;
		private int _termID;
		private bool _isAppeal;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		/// <summary>
		/// รหัสคณะอนุกรรมการพิจารณาสำนวน อ้างอิงตาราง
		/// </summary>
		public int SubcommitteeID
		{
			get{ return _subcommitteeID; }
			set{ _subcommitteeID = value; }
		}
		/// <summary>
		/// รหัสบทบาทเจ้าหน้าที่ อ้างอิงตาราง OfficerRole
		/// </summary>
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		/// <summary>
		/// รหัสวาระการประชุม อ้างอิงตาราง Term เช่น วาระปกติ วาระสืบเนื่อง วาระแร่งด่วน
		/// </summary>
		public int TermID
		{
			get{ return _termID; }
			set{ _termID = value; }
		}
		/// <summary>
		/// เป็นสำนวนที่อุทธรณ์ใช่หรือไม่ 1=ใช่ 0=ไม่ใช่
		/// </summary>
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseSubcommitteeConsiderationPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseSubcommitteeConsiderationRow[] caseSubcommitteeconsiderationRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseSubcommitteeConsiderationItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseSubcommitteeConsiderationItems : CaseSubcommitteeConsiderationData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseSubcommitteeConsiderationItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseSubcommitteeConsiderationItems[] caseSubcommitteeconsiderationItems { get; set; }
	}
}

