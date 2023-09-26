using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseComplicateRow
	{
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _complicateID;
		private bool _isSetComplicateID = false;
		private string _complicateOtherNote;
		private bool _isSetComplicateOtherNote = false;
		private DateTime _createDate;
		private bool _isSetCreateDate = false;
		private bool _createDateNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int ComplicateID
		{
			get { return _complicateID; }
			set { _complicateID = value;
			      _isSetComplicateID = true; }
		}
		public bool _IsSetComplicateID
		{
			get { return _isSetComplicateID; }
		}
		public string ComplicateOtherNote
		{
			get { return _complicateOtherNote; }
			set { _complicateOtherNote = value;
			      _isSetComplicateOtherNote = true; }
		}
		public bool _IsSetComplicateOtherNote
		{
			get { return _isSetComplicateOtherNote; }
		}
		public DateTime CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDateNull = false;
				_isSetCreateDate = true;
				_createDate = value;
			}
		}
		public bool IsCreateDateNull
		{
			get {
				 return _createDateNull; }
			set { _createDateNull = value; }
		}
		public bool _IsSetCreateDate
		{
			get { return _isSetCreateDate; }
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
	public class CaseComplicateData
	{
		private int _applicantID;
		private int _caseID;
		private int _complicateID;
		private string _complicateOtherNote;
		private DateTime _createDate;
		private DateTime _modifiedDate;
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ComplicateID
		{
			get{ return _complicateID; }
			set{ _complicateID = value; }
		}
		public string ComplicateOtherNote
		{
			get{ return _complicateOtherNote; }
			set{ _complicateOtherNote = value; }
		}
		public DateTime CreateDate
		{
			get{ return _createDate; }
			set{ _createDate = value; }
		}
		public string CreateDateStr { get; set; }
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseComplicatePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseComplicateRow[] casecomplicateRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseComplicateItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseComplicateItems : CaseComplicateData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseComplicateItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseComplicateItems[] casecomplicateItems { get; set; }
	}
}

