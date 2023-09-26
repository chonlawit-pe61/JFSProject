using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TempCaseOwnerDepartmentRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int? _referenceDepartmentID;
		private bool _isSetReferenceDepartmentID = false;
		private bool _referenceDepartmentIDNull = true;
		private bool _isSysn;
		private bool _isSetIsSysn = false;
		private DateTime? _modifiedDate;
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
		public int? ReferenceDepartmentID
		{
			get
			{
				return _referenceDepartmentID;
			}
			set
			{
				_referenceDepartmentIDNull = false;
				_isSetReferenceDepartmentID = true;
				_referenceDepartmentID = value;
			}
		}
		public bool IsReferenceDepartmentIDNull
		{
			get {
				 return _referenceDepartmentIDNull; }
			set { _referenceDepartmentIDNull = value; }
		}
		public bool _IsSetReferenceDepartmentID
		{
			get { return _isSetReferenceDepartmentID; }
		}
		[Required]
		public bool IsSysn
		{
			get { return _isSysn; }
			set { _isSysn = value;
			      _isSetIsSysn = true; }
		}
		public bool _IsSetIsSysn
		{
			get { return _isSetIsSysn; }
		}
		public DateTime? ModifiedDate
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
	public class TempCaseOwnerDepartmentData
	{
		private int _caseID;
		private int _departmentId;
		private int? _referenceDepartmentID;
		private bool _isSysn;
		private DateTime? _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		public int? ReferenceDepartmentID
		{
			get{ return _referenceDepartmentID; }
			set{ _referenceDepartmentID = value; }
		}
		public bool IsSysn
		{
			get{ return _isSysn; }
			set{ _isSysn = value; }
		}
		public DateTime? ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		///  เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TempCaseOwnerDepartmentPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TempCaseOwnerDepartmentRow[] tempCaseOwnerDepartmentRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TempCaseOwnerDepartmentItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TempCaseOwnerDepartmentItems : TempCaseOwnerDepartmentData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TempCaseOwnerDepartmentItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TempCaseOwnerDepartmentItems[] tempCaseOwnerDepartmentItems { get; set; }
	}
}

