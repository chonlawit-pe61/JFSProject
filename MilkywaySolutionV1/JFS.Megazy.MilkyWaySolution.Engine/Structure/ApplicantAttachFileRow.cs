using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class ApplicantAttachFileRow
	{
		private int _archivalCopyID;
		private bool _isSetArchivalCopyID = false;
		private int _applicantID;
		private bool _isSetApplicantID = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private bool _attachFileIDNull = true;
		private string _remark;
		private bool _isSetRemark = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int ArchivalCopyID
		{
			get { return _archivalCopyID; }
			set { _archivalCopyID = value;
			      _isSetArchivalCopyID = true; }
		}
		public bool _IsSetArchivalCopyID
		{
			get { return _isSetArchivalCopyID; }
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
		public int AttachFileID
		{
			get
			{
				return _attachFileID;
			}
			set
			{
				_attachFileIDNull = false;
				_isSetAttachFileID = true;
				_attachFileID = value;
			}
		}
		public bool IsAttachFileIDNull
		{
			get {
				 return _attachFileIDNull; }
			set { _attachFileIDNull = value; }
		}
		public bool _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
		}
		public string Remark
		{
			get { return _remark; }
			set { _remark = value;
			      _isSetRemark = true; }
		}
		public bool _IsSetRemark
		{
			get { return _isSetRemark; }
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
	public class ApplicantAttachFileData
	{
		private int _archivalCopyID;
		private int _applicantID;
		private int _attachFileID;
		private string _remark;
		private DateTime _modifiedDate;
		public int ArchivalCopyID
		{
			get{ return _archivalCopyID; }
			set{ _archivalCopyID = value; }
		}
		public int ApplicantID
		{
			get{ return _applicantID; }
			set{ _applicantID = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public string Remark
		{
			get{ return _remark; }
			set{ _remark = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class ApplicantAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public ApplicantAttachFileRow[] applicantattachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส ApplicantAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class ApplicantAttachFileItems : ApplicantAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class ApplicantAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public ApplicantAttachFileItems[] applicantattachFileItems { get; set; }
	}
}

