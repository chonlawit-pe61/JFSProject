using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseApplicantMapOwnerDepartmentRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private string _jFCaseNo;
		private bool _isSetJFCaseNo = false;
		private DateTime _dateCreatedCaseNo;
		private bool _isSetDateCreatedCaseNo = false;
		private bool _dateCreatedCaseNoNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสผู้ขอรับความช่วยเหลือ,สนับสนุน อ้างอิงตาราง CaseApplicant
		/// </summary>
		[Required]
		public int ApplicantID
		{
			get { return _applicantID; }
			set { _applicantID = value;
			      _isSetApplicantID = true; }
		}
		public bool _IsSetApplicantID
		{
			get { return _isSetApplicantID; }
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
		/// <summary>
		/// เลขที่ กทย. 
		/// </summary>
		public string JFCaseNo
		{
			get { return _jFCaseNo; }
			set { _jFCaseNo = value;
			      _isSetJFCaseNo = true; }
		}
		public bool _IsSetJFCaseNo
		{
			get { return _isSetJFCaseNo; }
		}
		/// <summary>
		/// วันที่ออกเลขที่รับเรื่อง
		/// </summary>
		public DateTime DateCreatedCaseNo
		{
			get
			{
				return _dateCreatedCaseNo;
			}
			set
			{
				_dateCreatedCaseNoNull = false;
				_isSetDateCreatedCaseNo = true;
				_dateCreatedCaseNo = value;
			}
		}
		public bool IsDateCreatedCaseNoNull
		{
			get {
				 return _dateCreatedCaseNoNull; }
			set { _dateCreatedCaseNoNull = value; }
		}
		public bool _IsSetDateCreatedCaseNo
		{
			get { return _isSetDateCreatedCaseNo; }
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
	public class CaseApplicantMapOwnerDepartmentData
	{
		private int _applicantID;
		private int _departmentId;
		private string _jFCaseNo;
		private DateTime _dateCreatedCaseNo;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสผู้ขอรับความช่วยเหลือ,สนับสนุน อ้างอิงตาราง CaseApplicant
		/// </summary>
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
		/// <summary>
		/// เลขที่ กทย. 
		/// </summary>
		public string JFCaseNo
		{
			get{ return _jFCaseNo; }
			set{ _jFCaseNo = value; }
		}
		/// <summary>
		/// วันที่ออกเลขที่รับเรื่อง
		/// </summary>
		public DateTime DateCreatedCaseNo
		{
			get{ return _dateCreatedCaseNo; }
			set{ _dateCreatedCaseNo = value; }
		}
		/// <summary>
		/// วันที่ออกเลขที่รับเรื่อง เก็บวันที่แบบ String
		/// </summary>
		public string DateCreatedCaseNoStr { get; set; }
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
	public class CaseApplicantMapOwnerDepartmentPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseApplicantMapOwnerDepartmentRow[] caseApplicantMapOwnerDepartmentRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseApplicantMapOwnerDepartmentItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseApplicantMapOwnerDepartmentItems : CaseApplicantMapOwnerDepartmentData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseApplicantMapOwnerDepartmentItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseApplicantMapOwnerDepartmentItems[] caseApplicantMapOwnerDepartmentItems { get; set; }
	}
}

