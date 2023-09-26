using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_FormMapContractRow
	{
		private int _formID;
		private bool _isSetFormID = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private string _formTypeName;
		private bool _isSetFormTypeName = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _formName;
		private bool _isSetFormName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isReviewNull = true;
		private int _formTypeID;
		private bool _isSetFormTypeID = false;
		[Required]
		public int FormID
		{
			get { return _formID; }
			set { _formID = value;
			      _isSetFormID = true; }
		}
		public bool _IsSetFormID
		{
			get { return _isSetFormID; }
		}
		[Required]
		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value;
			      _isSetSortOrder = true; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
		}
		public string FormTypeName
		{
			get { return _formTypeName; }
			set { _formTypeName = value;
			      _isSetFormTypeName = true; }
		}
		public bool _IsSetFormTypeName
		{
			get { return _isSetFormTypeName; }
		}
		[Required]
		public int JFCaseTypeID
		{
			get { return _jFCaseTypeID; }
			set { _jFCaseTypeID = value;
			      _isSetJFCaseTypeID = true; }
		}
		public bool _IsSetJFCaseTypeID
		{
			get { return _isSetJFCaseTypeID; }
		}
		[Required]
		public string FormName
		{
			get { return _formName; }
			set { _formName = value;
			      _isSetFormName = true; }
		}
		public bool _IsSetFormName
		{
			get { return _isSetFormName; }
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
		[Required]
		public int FormTypeID
		{
			get { return _formTypeID; }
			set { _formTypeID = value;
			      _isSetFormTypeID = true; }
		}
		public bool _IsSetFormTypeID
		{
			get { return _isSetFormTypeID; }
		}
	}
	[Serializable]
	public class View_FormMapContractData
	{
		private int _formID;
		private int _sortOrder;
		private string _formTypeName;
		private int _jFCaseTypeID;
		private string _formName;
		private bool _isActive;
		private bool _isReview;
		private int _formTypeID;
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public string FormTypeName
		{
			get{ return _formTypeName; }
			set{ _formTypeName = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string FormName
		{
			get{ return _formName; }
			set{ _formName = value; }
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
		public int FormTypeID
		{
			get{ return _formTypeID; }
			set{ _formTypeID = value; }
		}
	}
	[Serializable]
	public class View_FormMapContractPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_FormMapContractRow[] view_FormMapContractRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_FormMapContractItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_FormMapContractItems : View_FormMapContractData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_FormMapContractItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_FormMapContractItems[] view_FormMapContractItems { get; set; }
	}
}

