using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseRunningRow
	{
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _prefix;
		private bool _isSetPrefix = false;
		private int _maxNo;
		private bool _isSetMaxNo = false;
		private bool _maxNoNull = true;
		private int _inYear;
		private bool _isSetInYear = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public string Prefix
		{
			get { return _prefix; }
			set { _prefix = value;
			      _isSetPrefix = true; }
		}
		public bool _IsSetPrefix
		{
			get { return _isSetPrefix; }
		}
		public int MaxNo
		{
			get
			{
				return _maxNo;
			}
			set
			{
				_maxNoNull = false;
				_isSetMaxNo = true;
				_maxNo = value;
			}
		}
		public bool IsMaxNoNull
		{
			get {
				 return _maxNoNull; }
			set { _maxNoNull = value; }
		}
		public bool _IsSetMaxNo
		{
			get { return _isSetMaxNo; }
		}
		[Required]
		public int InYear
		{
			get { return _inYear; }
			set { _inYear = value;
			      _isSetInYear = true; }
		}
		public bool _IsSetInYear
		{
			get { return _isSetInYear; }
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
	public class CaseRunningData
	{
		private int _departmentId;
		private string _prefix;
		private int _maxNo;
		private int _inYear;
		private DateTime _modifiedDate;
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public string Prefix
		{
			get{ return _prefix; }
			set{ _prefix = value; }
		}
		public int MaxNo
		{
			get{ return _maxNo; }
			set{ _maxNo = value; }
		}
		public int InYear
		{
			get{ return _inYear; }
			set{ _inYear = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseRunningPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseRunningRow[] caseRunningRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseRunningItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseRunningItems : CaseRunningData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseRunningItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseRunningItems[] caseRunningItems { get; set; }
	}
}

