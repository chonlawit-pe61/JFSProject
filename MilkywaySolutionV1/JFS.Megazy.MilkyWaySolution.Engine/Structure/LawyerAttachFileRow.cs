using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class LawyerAttachFileRow
	{
		private int _lawyerID;
		private bool _isSetLawyerID = false;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		private string _title;
		private bool _isSetTitle = false;
		[Required]
		public int LawyerID
		{
			get { return _lawyerID; }
			set { _lawyerID = value;
			      _isSetLawyerID = true; }
		}
		public bool _IsSetLawyerID
		{
			get { return _isSetLawyerID; }
		}
		[Required]
		public int AttachFileID
		{
			get { return _attachFileID; }
			set { _attachFileID = value;
			      _isSetAttachFileID = true; }
		}
		public bool _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
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
		public string Title
		{
			get { return _title; }
			set { _title = value;
			      _isSetTitle = true; }
		}
		public bool _IsSetTitle
		{
			get { return _isSetTitle; }
		}
	}
	[Serializable]
	public class LawyerAttachFileData
	{
		private int _lawyerID;
		private int _attachFileID;
		private DateTime _modifiedDate;
		private string _title;
		public int LawyerID
		{
			get{ return _lawyerID; }
			set{ _lawyerID = value; }
		}
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
		public string Title
		{
			get{ return _title; }
			set{ _title = value; }
		}
	}
	[Serializable]
	public class LawyerAttachFilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public LawyerAttachFileRow[] lawyerAttachFileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส LawyerAttachFileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class LawyerAttachFileItems : LawyerAttachFileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class LawyerAttachFileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public LawyerAttachFileItems[] lawyerAttachFileItems { get; set; }
	}
}

