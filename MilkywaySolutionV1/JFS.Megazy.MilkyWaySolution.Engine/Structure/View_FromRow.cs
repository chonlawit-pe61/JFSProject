using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_FromRow
	{
		private int _formID;
		private bool _isSetFormID = false;
		private string _formName;
		private bool _isSetFormName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isReviewNull = true;
		private int _formTypeID;
		private bool _isSetFormTypeID = false;
		private bool _formTypeIDNull = true;
		private string _formTypeName;
		private bool _isSetFormTypeName = false;
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
		public int FormTypeID
		{
			get
			{
				return _formTypeID;
			}
			set
			{
				_formTypeIDNull = false;
				_isSetFormTypeID = true;
				_formTypeID = value;
			}
		}
		public bool IsFormTypeIDNull
		{
			get {
				 return _formTypeIDNull; }
			set { _formTypeIDNull = value; }
		}
		public bool _IsSetFormTypeID
		{
			get { return _isSetFormTypeID; }
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
	}
	[Serializable]
	public class View_FromData
	{
		private int _formID;
		private string _formName;
		private int _sortOrder;
		private int _jFCaseTypeID;
		private bool _isActive;
		private bool _isReview;
		private int _formTypeID;
		private string _formTypeName;
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public string FormName
		{
			get{ return _formName; }
			set{ _formName = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
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
		public string FormTypeName
		{
			get{ return _formTypeName; }
			set{ _formTypeName = value; }
		}
	}
	[Serializable]
	public class View_FromPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_FromRow[] view_FromRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_FromItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_FromItems : View_FromData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_FromItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_FromItems[] view_FromItems { get; set; }
	}
}

