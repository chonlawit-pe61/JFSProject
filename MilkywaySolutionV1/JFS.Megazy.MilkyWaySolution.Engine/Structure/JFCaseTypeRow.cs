using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class JFCaseTypeRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private bool _caseTypeNameNull = true;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private bool _caseTypeNameAbbrNull = true;
		private string _caseTypePrefix;
		private bool _isSetCaseTypePrefix = false;
		private bool _caseTypePrefixNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isMapRecord = false;
			      _isSetJFCaseTypeID = true; }
		}
		public Boolean _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		public string CaseTypeName
		{
			get
			{
				return _caseTypeName;
			}
			set
			{
				_caseTypeNameNull = false;
				_isSetCaseTypeName = true;
				_caseTypeName = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseTypeNameNull
		{
			get {
				 return _caseTypeNameNull; }
			set { _caseTypeNameNull = value; }
		}
		public Boolean _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get
			{
				return _caseTypeNameAbbr;
			}
			set
			{
				_caseTypeNameAbbrNull = false;
				_isSetCaseTypeNameAbbr = true;
				_caseTypeNameAbbr = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseTypeNameAbbrNull
		{
			get {
				 return _caseTypeNameAbbrNull; }
			set { _caseTypeNameAbbrNull = value; }
		}
		public Boolean _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public string CaseTypePrefix
		{
			get
			{
				return _caseTypePrefix;
			}
			set
			{
				_caseTypePrefixNull = false;
				_isSetCaseTypePrefix = true;
				_caseTypePrefix = value;
				_isMapRecord = false;
			}
		}
		public bool IsCaseTypePrefixNull
		{
			get {
				 return _caseTypePrefixNull; }
			set { _caseTypePrefixNull = value; }
		}
		public Boolean _IsSetCaseTypePrefix
		{
			get { return _isSetCaseTypePrefix; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
				_isMapRecord = false;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public Boolean _IsSetIsActive
		{
			get { return _isSetIsActive; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class JFCaseTypeData
	{
		private int _jFCaseTypeID;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private string _caseTypePrefix;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public string CaseTypeNameAbbr
		{
			get{ return _caseTypeNameAbbr; }
			set{ _caseTypeNameAbbr = value; }
		}
		public string CaseTypePrefix
		{
			get{ return _caseTypePrefix; }
			set{ _caseTypePrefix = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class JFCaseTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public JFCaseTypeRow[] jFCaseTypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส JFCaseTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class JFCaseTypeItems : JFCaseTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class JFCaseTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public JFCaseTypeItems[] jFCaseTypeItems { get; set; }
	}
}

