using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseOwnerRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private int _rowUniqueID;
		private bool _isSetRowUniqueID = false;
		private DateTime _changeDate;
		private bool _isSetChangeDate = false;
		private bool _changeDateNull = true;
		private string _comment;
		private bool _isSetComment = false;
		/// <summary>
		/// รหัสผู้ของรับความช่วยเหลือ,สนับสนุน อ้างอิง ApplicationID ตาราง CaseApplicant
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
		/// <summary>
		/// รหัสสำนวน อ้างอิงตาราง CaseApplicantion
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
		/// รหัสนิติกรเจ้าของคดี อ้างอิงตาราง User
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
		[Required]
		public int RowUniqueID
		{
			get { return _rowUniqueID; }
			set { _rowUniqueID = value;
			      _isSetRowUniqueID = true; }
		}
		public bool _IsSetRowUniqueID
		{
			get { return _isSetRowUniqueID; }
		}
		/// <summary>
		/// วันที่เปลี่ยนแปลง
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
	}
	[Serializable]
	public class CaseOwnerData
	{
		private int _applicantID;
		private int _caseID;
		private int _departmentId;
		private int _userID;
		private int _rowUniqueID;
		private DateTime _changeDate;
		private string _comment;
		/// <summary>
		/// รหัสผู้ของรับความช่วยเหลือ,สนับสนุน อ้างอิง ApplicationID ตาราง CaseApplicant
		/// </summary>
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		/// <summary>
		/// รหัสสำนวน อ้างอิงตาราง CaseApplicantion
		/// </summary>
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
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
		/// รหัสนิติกรเจ้าของคดี อ้างอิงตาราง User
		/// </summary>
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public int RowUniqueID
		{
			get{ return _rowUniqueID; }
			set{ _rowUniqueID = value; }
		}
		/// <summary>
		/// วันที่เปลี่ยนแปลง
		/// </summary>
		public DateTime ChangeDate
		{
			get{ return _changeDate; }
			set{ _changeDate = value; }
		}
		/// <summary>
		/// วันที่เปลี่ยนแปลง เก็บวันที่แบบ String
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
	}
	[Serializable]
	public class CaseOwnerPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseOwnerRow[] caseOwnerRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseOwnerItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseOwnerItems : CaseOwnerData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseOwnerItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseOwnerItems[] caseOwnerItems { get; set; }
	}
}

