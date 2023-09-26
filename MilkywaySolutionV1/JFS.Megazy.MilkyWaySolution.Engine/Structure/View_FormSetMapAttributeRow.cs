using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_FormSetMapAttributeRow
	{
		private int _formMapAttrID;
		private bool _isSetFormMapAttrID = false;
		private int _sortID;
		private bool _isSetSortID = false;
		private bool _sortIDNull = true;
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
		private int _columns;
		private bool _isSetColumns = false;
		private bool _columnsNull = true;
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
	}
	[Serializable]
	public class View_FormSetMapAttributeData
	{
		private int _formMapAttrID;
		private int _sortID;
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
		private int _columns;
		public int FormMapAttrID
		{
			get{ return _formMapAttrID; }
			set{ _formMapAttrID = value; }
		}
		public int SortID
		{
			get{ return _sortID; }
			set{ _sortID = value; }
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
		public int Columns
		{
			get{ return _columns; }
			set{ _columns = value; }
		}
	}
	[Serializable]
	public class View_FormSetMapAttributePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_FormSetMapAttributeRow[] view_FormSetMapAttributeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_FormSetMapAttributeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_FormSetMapAttributeItems : View_FormSetMapAttributeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_FormSetMapAttributeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_FormSetMapAttributeItems[] view_FormSetMapAttributeItems { get; set; }
	}
}

