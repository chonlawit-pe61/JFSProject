using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class DocumentChecklistOfProjectRow
	{
		private int _documentId;
		private bool _isSetDocumentID = false;
		private int _documentGroupId;
		private bool _isSetDocumentGroupID = false;
		private string _documentName;
		private bool _isSetDocumentName = false;
		private bool _isShowOther;
		private bool _isSetIsShowOther = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int DocumentID
		{
			get { return _documentId; }
			set { _documentId = value;
			      _isSetDocumentID = true; }
		}
		public bool _IsSetDocumentID
		{
			get { return _isSetDocumentID; }
		}
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
		[Required]
		public string DocumentName
		{
			get { return _documentName; }
			set { _documentName = value;
			      _isSetDocumentName = true; }
		}
		public bool _IsSetDocumentName
		{
			get { return _isSetDocumentName; }
		}
		[Required]
		public bool IsShowOther
		{
			get { return _isShowOther; }
			set { _isShowOther = value;
			      _isSetIsShowOther = true; }
		}
		public bool _IsSetIsShowOther
		{
			get { return _isSetIsShowOther; }
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
	public class DocumentChecklistOfProjectData
	{
		private int _documentId;
		private int _documentGroupId;
		private string _documentName;
		private bool _isShowOther;
		private DateTime _modifiedDate;
		public int DocumentID
		{
			get{ return _documentId; }
			set{ _documentId = value; }
		}
		public int DocumentGroupID
		{
			get{ return _documentGroupId; }
			set{ _documentGroupId = value; }
		}
		public string DocumentName
		{
			get{ return _documentName; }
			set{ _documentName = value; }
		}
		public bool IsShowOther
		{
			get{ return _isShowOther; }
			set{ _isShowOther = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class DocumentChecklistOfProjectPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public DocumentChecklistOfProjectRow[] documentChecklistOfProjectRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส DocumentChecklistOfProjectItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class DocumentChecklistOfProjectItems : DocumentChecklistOfProjectData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class DocumentChecklistOfProjectItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public DocumentChecklistOfProjectItems[] documentChecklistOfProjectItems { get; set; }
	}
}

