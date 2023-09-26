using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CaseProjectMetaRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _metaID;
		private bool _isSetMetaID = false;
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _metaKey;
		private bool _isSetMetaKey = false;
		private bool _metaKeyNull = true;
		private string _metaValue;
		private bool _isSetMetaValue = false;
		private bool _metaValueNull = true;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int MetaID
		{
			get { return _metaID; }
			set { _metaID = value;
			      _isMapRecord = false;
			      _isSetMetaID = true; }
		}
		public Boolean _IsSetMetaID
		{
			get { return _isSetMetaID; }
		}
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isMapRecord = false;
			      _isSetCaseID = true; }
		}
		public Boolean _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public string MetaKey
		{
			get
			{
				return _metaKey;
			}
			set
			{
				_metaKeyNull = false;
				_isSetMetaKey = true;
				_metaKey = value;
				_isMapRecord = false;
			}
		}
		public bool IsMetaKeyNull
		{
			get {
				 return _metaKeyNull; }
			set { _metaKeyNull = value; }
		}
		public Boolean _IsSetMetaKey
		{
			get { return _isSetMetaKey; }
		}
		public string MetaValue
		{
			get
			{
				return _metaValue;
			}
			set
			{
				_metaValueNull = false;
				_isSetMetaValue = true;
				_metaValue = value;
				_isMapRecord = false;
			}
		}
		public bool IsMetaValueNull
		{
			get {
				 return _metaValueNull; }
			set { _metaValueNull = value; }
		}
		public Boolean _IsSetMetaValue
		{
			get { return _isSetMetaValue; }
		}
	}
	[Serializable]
	public class CaseProjectMetaData
	{
		private int _metaID;
		private int _caseID;
		private string _metaKey;
		private string _metaValue;
		public int MetaID
		{
			get{ return _metaID; }
			set{ _metaID = value; }
		}
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string MetaKey
		{
			get{ return _metaKey; }
			set{ _metaKey = value; }
		}
		public string MetaValue
		{
			get{ return _metaValue; }
			set{ _metaValue = value; }
		}
	}
	[Serializable]
	public class CaseProjectMetaPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CaseProjectMetaRow[] caseProjectMetaRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CaseProjectMetaItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CaseProjectMetaItems : CaseProjectMetaData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CaseProjectMetaItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CaseProjectMetaItems[] caseProjectMetaItems { get; set; }
	}
}

