using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class DocumentCheckListGroupRow
	{
		private int _documentGroupId;
		private bool _isSetDocumentGroupID = false;
		private string _documentGroupName;
		private bool _isSetDocumentGroupName = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int DocumentGroupID
		{
			get { return _documentGroupId; }
			set { _documentGroupId = value;
			      _isSetDocumentGroupID = true; }
		}
		public bool _IsSetDocumentGroupID
		{
			get { return _isSetDocumentGroupID; }
		}
		public string DocumentGroupName
		{
			get { return _documentGroupName; }
			set { _documentGroupName = value;
			      _isSetDocumentGroupName = true; }
		}
		public bool _IsSetDocumentGroupName
		{
			get { return _isSetDocumentGroupName; }
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
	public class DocumentCheckListGroupData
	{
		private int _documentGroupId;
		private string _documentGroupName;
		private DateTime _modifiedDate;
		public int DocumentGroupID
		{
			get{ return _documentGroupId; }
			set{ _documentGroupId = value; }
		}
		public string DocumentGroupName
		{
			get{ return _documentGroupName; }
			set{ _documentGroupName = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class DocumentCheckListGroupPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DocumentCheckListGroupRow[] documentCheckListGroupRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DocumentCheckListGroupItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DocumentCheckListGroupItems : DocumentCheckListGroupData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DocumentCheckListGroupItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DocumentCheckListGroupItems[] documentCheckListGroupItems { get; set; }
	}
}

