using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_FormMapAttributeRow
	{
		private int _formMapAttrID;
		private bool _isSetFormMapAttrID = false;
		private int _columns;
		private bool _isSetColumns = false;
		private bool _columnsNull = true;
		private int _sortID;
		private bool _isSetSortID = false;
		private bool _sortIDNull = true;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _jFCaseTypeIDNull = true;
		private int _caseTypeSortOrder;
		private bool _isSetCaseTypeSortOrder = false;
		private bool _caseTypeSortOrderNull = true;
		private int _formAttrID;
		private bool _isSetFormAttrID = false;
		private bool _formAttrIDNull = true;
		private string _dataType;
		private bool _isSetDataType = false;
		private string _formAttrAlias;
		private bool _isSetFormAttrAlias = false;
		private string _defaultVal;
		private bool _isSetDefaultVal = false;
		private string _formAttrName;
		private bool _isSetFormAttrName = false;
		private bool _isRequire;
		private bool _isSetIsRequire = false;
		private bool _isRequireNull = true;
		private string _unit;
		private bool _isSetUnit = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isReviewNull = true;
		private int _formID;
		private bool _isSetFormID = false;
		private bool _formIDNull = true;
		[Required]
		public int FormMapAttrID
		{
			get { return _formMapAttrID; }
			set { _formMapAttrID = value;
			      _isSetFormMapAttrID = true; }
		}
		public bool _IsSetFormMapAttrID
		{
			get { return _isSetFormMapAttrID; }
		}
		public int Columns
		{
			get
			{
				return _columns;
			}
			set
			{
				_columnsNull = false;
				_isSetColumns = true;
				_columns = value;
			}
		}
		public bool IsColumnsNull
		{
			get {
				 return _columnsNull; }
			set { _columnsNull = value; }
		}
		public bool _IsSetColumns
		{
			get { return _isSetColumns; }
		}
		public int SortID
		{
			get
			{
				return _sortID;
			}
			set
			{
				_sortIDNull = false;
				_isSetSortID = true;
				_sortID = value;
			}
		}
		public bool IsSortIDNull
		{
			get {
				 return _sortIDNull; }
			set { _sortIDNull = value; }
		}
		public bool _IsSetSortID
		{
			get { return _isSetSortID; }
		}
		public int JFCaseTypeID
		{
			get
			{
				return _jFCaseTypeID;
			}
			set
			{
				_jFCaseTypeIDNull = false;
				_isSetJFCaseTypeID = true;
				_jFCaseTypeID = value;
			}
		}
		public bool IsJFCaseTypeIDNull
		{
			get {
				 return _jFCaseTypeIDNull; }
			set { _jFCaseTypeIDNull = value; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		public int CaseTypeSortOrder
		{
			get
			{
				return _caseTypeSortOrder;
			}
			set
			{
				_caseTypeSortOrderNull = false;
				_isSetCaseTypeSortOrder = true;
				_caseTypeSortOrder = value;
			}
		}
		public bool IsCaseTypeSortOrderNull
		{
			get {
				 return _caseTypeSortOrderNull; }
			set { _caseTypeSortOrderNull = value; }
		}
		public bool _IsSetCaseTypeSortOrder
		{
			get { return _isSetCaseTypeSortOrder; }
		}
		public int FormAttrID
		{
			get
			{
				return _formAttrID;
			}
			set
			{
				_formAttrIDNull = false;
				_isSetFormAttrID = true;
				_formAttrID = value;
			}
		}
		public bool IsFormAttrIDNull
		{
			get {
				 return _formAttrIDNull; }
			set { _formAttrIDNull = value; }
		}
		public bool _IsSetFormAttrID
		{
			get { return _isSetFormAttrID; }
		}
		public string DataType
		{
			get { return _dataType; }
			set { _dataType = value;
			      _isSetDataType = true; }
		}
		public bool _IsSetDataType
		{
			get { return _isSetDataType; }
		}
		public string FormAttrAlias
		{
			get { return _formAttrAlias; }
			set { _formAttrAlias = value;
			      _isSetFormAttrAlias = true; }
		}
		public bool _IsSetFormAttrAlias
		{
			get { return _isSetFormAttrAlias; }
		}
		public string DefaultVal
		{
			get { return _defaultVal; }
			set { _defaultVal = value;
			      _isSetDefaultVal = true; }
		}
		public bool _IsSetDefaultVal
		{
			get { return _isSetDefaultVal; }
		}
		public string FormAttrName
		{
			get { return _formAttrName; }
			set { _formAttrName = value;
			      _isSetFormAttrName = true; }
		}
		public bool _IsSetFormAttrName
		{
			get { return _isSetFormAttrName; }
		}
		public bool IsRequire
		{
			get
			{
				return _isRequire;
			}
			set
			{
				_isRequireNull = false;
				_isSetIsRequire = true;
				_isRequire = value;
			}
		}
		public bool IsIsRequireNull
		{
			get {
				 return _isRequireNull; }
			set { _isRequireNull = value; }
		}
		public bool _IsSetIsRequire
		{
			get { return _isSetIsRequire; }
		}
		public string Unit
		{
			get { return _unit; }
			set { _unit = value;
			      _isSetUnit = true; }
		}
		public bool _IsSetUnit
		{
			get { return _isSetUnit; }
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
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public bool IsReview
		{
			get
			{
				return _isReview;
			}
			set
			{
				_isReviewNull = false;
				_isSetIsReview = true;
				_isReview = value;
			}
		}
		public bool IsIsReviewNull
		{
			get {
				 return _isReviewNull; }
			set { _isReviewNull = value; }
		}
		public bool _IsSetIsReview
		{
			get { return _isSetIsReview; }
		}
		public int FormID
		{
			get
			{
				return _formID;
			}
			set
			{
				_formIDNull = false;
				_isSetFormID = true;
				_formID = value;
			}
		}
		public bool IsFormIDNull
		{
			get {
				 return _formIDNull; }
			set { _formIDNull = value; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
	}
	[Serializable]
	public class View_FormMapAttributeData
	{
		private int _formMapAttrID;
		private int _columns;
		private int _sortID;
		private int _jFCaseTypeID;
		private int _caseTypeSortOrder;
		private int _formAttrID;
		private string _dataType;
		private string _formAttrAlias;
		private string _defaultVal;
		private string _formAttrName;
		private bool _isRequire;
		private string _unit;
		private bool _isActive;
		private bool _isReview;
		private int _formID;
		public int FormMapAttrID
		{
			get{ return _formMapAttrID; }
			set{ _formMapAttrID = value; }
		}
		public int Columns
		{
			get{ return _columns; }
			set{ _columns = value; }
		}
		public int SortID
		{
			get{ return _sortID; }
			set{ _sortID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int CaseTypeSortOrder
		{
			get{ return _caseTypeSortOrder; }
			set{ _caseTypeSortOrder = value; }
		}
		public int FormAttrID
		{
			get{ return _formAttrID; }
			set{ _formAttrID = value; }
		}
		public string DataType
		{
			get{ return _dataType; }
			set{ _dataType = value; }
		}
		public string FormAttrAlias
		{
			get{ return _formAttrAlias; }
			set{ _formAttrAlias = value; }
		}
		public string DefaultVal
		{
			get{ return _defaultVal; }
			set{ _defaultVal = value; }
		}
		public string FormAttrName
		{
			get{ return _formAttrName; }
			set{ _formAttrName = value; }
		}
		public bool IsRequire
		{
			get{ return _isRequire; }
			set{ _isRequire = value; }
		}
		public string Unit
		{
			get{ return _unit; }
			set{ _unit = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public bool IsReview
		{
			get{ return _isReview; }
			set{ _isReview = value; }
		}
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
	}
	[Serializable]
	public class View_FormMapAttributePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_FormMapAttributeRow[] view_FormMapAttributeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_FormMapAttributeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_FormMapAttributeItems : View_FormMapAttributeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_FormMapAttributeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_FormMapAttributeItems[] view_FormMapAttributeItems { get; set; }
	}
}

