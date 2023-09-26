using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class WorkStepRow
	{
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private string _allowPermissionSetting;
		private bool _isSetAllowPermissionSetting = false;
		private string _groupName;
		private bool _isSetGroupName = false;
		private bool _isStopCountKiP;
		private bool _isSetIsStopCountKIP = false;
		private bool _isStopCountKiPNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสขั้นตอนการทำงาน
		/// </summary>
		[Required]
		public int WorkStepID
		{
			get { return _workStepID; }
			set { _workStepID = value;
			      _isSetWorkStepID = true; }
		}
		public bool _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
		}
		/// <summary>
		/// ขั้นตอนการทำงาน
		/// </summary>
		[Required]
		public string WorkStepName
		{
			get { return _workStepName; }
			set { _workStepName = value;
			      _isSetWorkStepName = true; }
		}
		public bool _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
		}
		/// <summary>
		/// กลุ่มข้อมูลสำหรับการตั้งค่าการอนุญาตให้ใช้งาน {[1,2,3]}
		/// </summary>
		public string AllowPermissionSetting
		{
			get { return _allowPermissionSetting; }
			set { _allowPermissionSetting = value;
			      _isSetAllowPermissionSetting = true; }
		}
		public bool _IsSetAllowPermissionSetting
		{
			get { return _isSetAllowPermissionSetting; }
		}
		/// <summary>
		/// กลุ่มงาน
		/// </summary>
		public string GroupName
		{
			get { return _groupName; }
			set { _groupName = value;
			      _isSetGroupName = true; }
		}
		public bool _IsSetGroupName
		{
			get { return _isSetGroupName; }
		}
		/// <summary>
		/// หยุดนับวัน KIP หรือไม่
		/// </summary>
		public bool IsStopCountKIP
		{
			get
			{
				return _isStopCountKiP;
			}
			set
			{
				_isStopCountKiPNull = false;
				_isSetIsStopCountKIP = true;
				_isStopCountKiP = value;
			}
		}
		public bool IsIsStopCountKIPNull
		{
			get {
				 return _isStopCountKiPNull; }
			set { _isStopCountKiPNull = value; }
		}
		public bool _IsSetIsStopCountKIP
		{
			get { return _isSetIsStopCountKIP; }
		}
		/// <summary>
		/// สถานะเปิดปิดการใช้งาน
		/// </summary>
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
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
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
	public class WorkStepData
	{
		private int _workStepID;
		private string _workStepName;
		private string _allowPermissionSetting;
		private string _groupName;
		private bool _isStopCountKiP;
		private bool _isActive;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสขั้นตอนการทำงาน
		/// </summary>
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		/// <summary>
		/// ขั้นตอนการทำงาน
		/// </summary>
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		/// <summary>
		/// กลุ่มข้อมูลสำหรับการตั้งค่าการอนุญาตให้ใช้งาน {[1,2,3]}
		/// </summary>
		public string AllowPermissionSetting
		{
			get{ return _allowPermissionSetting; }
			set{ _allowPermissionSetting = value; }
		}
		/// <summary>
		/// กลุ่มงาน
		/// </summary>
		public string GroupName
		{
			get{ return _groupName; }
			set{ _groupName = value; }
		}
		/// <summary>
		/// หยุดนับวัน KIP หรือไม่
		/// </summary>
		public bool IsStopCountKIP
		{
			get{ return _isStopCountKiP; }
			set{ _isStopCountKiP = value; }
		}
		/// <summary>
		/// สถานะเปิดปิดการใช้งาน
		/// </summary>
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		/// <summary>
		/// วันที่แก้ไข
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันที่แก้ไข เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class WorkStepPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public WorkStepRow[] workStepRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส WorkStepItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class WorkStepItems : WorkStepData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class WorkStepItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public WorkStepItems[] workStepItems { get; set; }
	}
}

