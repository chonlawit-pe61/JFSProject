using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class AssignmentRecordRow
	{
		private int _assignmentID;
		private bool _isSetAssignmentID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private int _userID;
		private bool _isSetUserID = false;
		private bool _viaSMS;
		private bool _isSetViaSMS = false;
		private bool _viaEmail;
		private bool _isSetViaEmail = false;
		private string _assignmentNote;
		private bool _isSetAssignmentNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int AssignmentID
		{
			get { return _assignmentID; }
			set { _assignmentID = value;
			      _isSetAssignmentID = true; }
		}
		public bool _IsSetAssignmentID
		{
			get { return _isSetAssignmentID; }
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
		public bool ViaSMS
		{
			get { return _viaSMS; }
			set { _viaSMS = value;
			      _isSetViaSMS = true; }
		}
		public bool _IsSetViaSMS
		{
			get { return _isSetViaSMS; }
		}
		[Required]
		public bool ViaEmail
		{
			get { return _viaEmail; }
			set { _viaEmail = value;
			      _isSetViaEmail = true; }
		}
		public bool _IsSetViaEmail
		{
			get { return _isSetViaEmail; }
		}
		public string AssignmentNote
		{
			get { return _assignmentNote; }
			set { _assignmentNote = value;
			      _isSetAssignmentNote = true; }
		}
		public bool _IsSetAssignmentNote
		{
			get { return _isSetAssignmentNote; }
		}
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
	public class AssignmentRecordData
	{
		private int _assignmentID;
		private int _caseID;
		private int _userID;
		private bool _viaSMS;
		private bool _viaEmail;
		private string _assignmentNote;
		private DateTime _modifiedDate;
		public int AssignmentID
		{
			get{ return _assignmentID; }
			set{ _assignmentID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public int UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
		public bool ViaSMS
		{
			get{ return _viaSMS; }
			set{ _viaSMS = value; }
		}
		public bool ViaEmail
		{
			get{ return _viaEmail; }
			set{ _viaEmail = value; }
		}
		public string AssignmentNote
		{
			get{ return _assignmentNote; }
			set{ _assignmentNote = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class AssignmentRecordPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public AssignmentRecordRow[] assignmentRecordRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส AssignmentRecordItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class AssignmentRecordItems : AssignmentRecordData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class AssignmentRecordItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public AssignmentRecordItems[] assignmentRecordItems { get; set; }
	}
}

