using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseRepositoryRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private DateTime _repositoryDate;
		private bool _isSetRepositoryDate = false;
		private bool _repositoryDateNull = true;
		private bool _status;
		private bool _isSetStatus = false;
		private string _location;
		private bool _isSetLocation = false;
		private string _note;
		private bool _isSetNote = false;
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
		public DateTime RepositoryDate
		{
			get
			{
				return _repositoryDate;
			}
			set
			{
				_repositoryDateNull = false;
				_isSetRepositoryDate = true;
				_repositoryDate = value;
			}
		}
		public bool IsRepositoryDateNull
		{
			get {
				 return _repositoryDateNull; }
			set { _repositoryDateNull = value; }
		}
		public bool _IsSetRepositoryDate
		{
			get { return _isSetRepositoryDate; }
		}
		[Required]
		public bool Status
		{
			get { return _status; }
			set { _status = value;
			      _isSetStatus = true; }
		}
		public bool _IsSetStatus
		{
			get { return _isSetStatus; }
		}
		public string Location
		{
			get { return _location; }
			set { _location = value;
			      _isSetLocation = true; }
		}
		public bool _IsSetLocation
		{
			get { return _isSetLocation; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
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
	public class CaseRepositoryData
	{
		private int _caseID;
		private int _applicantID;
		private DateTime _repositoryDate;
		private bool _status;
		private string _location;
		private string _note;
		private DateTime _modifiedDate;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public DateTime RepositoryDate
		{
			get{ return _repositoryDate; }
			set{ _repositoryDate = value; }
		}
		public string RepositoryDateStr { get; set; }
		public bool Status
		{
			get{ return _status; }
			set{ _status = value; }
		}
		public string Location
		{
			get{ return _location; }
			set{ _location = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CaseRepositoryPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseRepositoryRow[] caseRepositoryRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseRepositoryItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseRepositoryItems : CaseRepositoryData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseRepositoryItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseRepositoryItems[] caseRepositoryItems { get; set; }
	}
}

