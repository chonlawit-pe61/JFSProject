using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseChangeWorkStepHistoryRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
		private int _rowID;
		private bool _isSetRowID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสคดี,สำนวน
		/// </summary>
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
		/// รหัสขั้นตอนงาน
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
		/// รหัสสมาชิก
		/// </summary>
		[Required]
		public int UserID
		{
			get { return _userID; }
			set { _userID = value;
			      _isSetUserID = true; }
		}
		public bool _IsSetUserID
		{
			get { return _isSetUserID; }
		}
		/// <summary>
		/// รหัสหน่วยงาน อ้างอิงตาราง Department
		/// </summary>
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		/// <summary>
		/// วันที่เปลี่ยนขั้นตอนงาน
		/// </summary>
		[Required]
		public DateTime ChangeDate
		{
			get { return _changeDate; }
			set { _changeDate = value;
			      _changeDateNull = false;
			      _isSetChangeDate = true; }
		}
		public bool IsChangeDateNull
		{
			get {
				 return _changeDateNull; }
			set { _changeDateNull = value; }
		}
		public bool _IsSetChangeDate
		{
			get { return _isSetChangeDate; }
		}
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string Comment
		{
			get { return _comment; }
			set { _comment = value;
			      _isSetComment = true; }
		}
		public bool _IsSetComment
		{
			get { return _isSetComment; }
		}
		[Required]
		public int RowID
		{
			get { return _rowID; }
			set { _rowID = value;
			      _isSetRowID = true; }
		}
		public bool _IsSetRowID
		{
			get { return _isSetRowID; }
		}
		/// <summary>
		/// วันที่แก้ไข
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
	public class CaseChangeWorkStepHistoryData
	{
		private int _caseID;
		private int _workStepID;
		private int _userID;
		private int _departmentId;
		private DateTime _changeDate;
		private string _comment;
		private int _rowID;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสคดี,สำนวน
		/// </summary>
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		/// <summary>
		/// รหัสขั้นตอนงาน
		/// </summary>
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		/// <summary>
		/// รหัสสมาชิก
		/// </summary>
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		/// <summary>
		/// รหัสหน่วยงาน อ้างอิงตาราง Department
		/// </summary>
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		/// <summary>
		/// วันที่เปลี่ยนขั้นตอนงาน
		/// </summary>
		public DateTime ChangeDate
		{
			get{ return _changeDate; }
			set{ _changeDate = value; }
		}
		/// <summary>
		/// วันที่เปลี่ยนขั้นตอนงาน เก็บวันที่แบบ String
		/// </summary>
		public string ChangeDateStr { get; set; }
		/// <summary>
		/// หมายเหตุ
		/// </summary>
		public string Comment
		{
			get{ return _comment; }
			set{ _comment = value; }
		}
		public int RowID
		{
			get{ return _rowID; }
			set{ _rowID = value; }
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
	public class CaseChangeWorkStepHistoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseChangeWorkStepHistoryRow[] casechangeWorkStepHistoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseChangeWorkStepHistoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseChangeWorkStepHistoryItems : CaseChangeWorkStepHistoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseChangeWorkStepHistoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseChangeWorkStepHistoryItems[] casechangeWorkStepHistoryItems { get; set; }
	}
}

