using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectDocumentCheckRow
	{
		private int _documentId;
		private bool _isSetDocumentID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _remark;
		private bool _isSetRemark = false;
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
	public class CaseProjectDocumentCheckData
	{
		private int _documentId;
		private int _caseID;
		private string _remark;
		private DateTime _modifiedDate;
		public int DocumentID
		{
			get{ return _documentId; }
			set{ _documentId = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
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
	public class CaseProjectDocumentCheckPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectDocumentCheckRow[] caseProjectDocumentcheckRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectDocumentCheckItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectDocumentCheckItems : CaseProjectDocumentCheckData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectDocumentCheckItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectDocumentCheckItems[] caseProjectDocumentcheckItems { get; set; }
	}
}

