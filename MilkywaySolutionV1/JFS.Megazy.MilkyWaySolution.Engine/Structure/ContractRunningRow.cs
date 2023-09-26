using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ContractRunningRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _inYear;
		private bool _isSetInYear = false;
		private string _prefix;
		private bool _isSetPrefix = false;
		private bool _prefixNull = true;
		private int _maxNo;
		private bool _isSetMaxNo = false;
		private bool _maxNoNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isMapRecord = false;
			      _isSetDepartmentID = true; }
		}
		public Boolean _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
		[Required]
		public int InYear
		{
			get { return _inYear; }
			set { _inYear = value;
			      _isMapRecord = false;
			      _isSetInYear = true; }
		}
		public Boolean _IsSetInYear
		{
			get { return _isSetInYear; }
		}
		public string Prefix
		{
			get
			{
				return _prefix;
			}
			set
			{
				_prefixNull = false;
				_isSetPrefix = true;
				_prefix = value;
				_isMapRecord = false;
			}
		}
		public bool IsPrefixNull
		{
			get {
				 return _prefixNull; }
			set { _prefixNull = value; }
		}
		public Boolean _IsSetPrefix
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
				_isMapRecord = false;
			}
		}
		public bool IsMaxNoNull
		{
			get {
				 return _maxNoNull; }
			set { _maxNoNull = value; }
		}
		public Boolean _IsSetMaxNo
		{
			get { return _isSetMaxNo; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class ContractRunningData
	{
		private int _departmentId;
		private int _inYear;
		private string _prefix;
		private int _maxNo;
		private DateTime _modifiedDate;
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int InYear
		{
			get{ return _inYear; }
			set{ _inYear = value; }
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
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ContractRunningPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ContractRunningRow[] contractRunningRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ContractRunningItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ContractRunningItems : ContractRunningData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ContractRunningItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ContractRunningItems[] contractRunningItems { get; set; }
	}
}

