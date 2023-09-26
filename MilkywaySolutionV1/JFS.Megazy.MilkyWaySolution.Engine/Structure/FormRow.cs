using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class FormRow
	{
		private int _formID;
		private bool _isSetFormID = false;
		private int _formTypeID;
		private bool _isSetFormTypeID = false;
		private bool _formTypeIDNull = true;
		private string _formName;
		private bool _isSetFormName = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _isReview;
		private bool _isSetIsReview = false;
		private bool _isReviewNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
	public class FormData
	{
		private int _formID;
		private int _formTypeID;
		private string _formName;
		private int _sortOrder;
		private bool _isReview;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int FormID
		{
			get{ return _formID; }
			set{ _formID = value; }
		}
		public int FormTypeID
		{
			get{ return _formTypeID; }
			set{ _formTypeID = value; }
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
		public bool IsReview
		{
			get{ return _isReview; }
			set{ _isReview = value; }
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
	public class FormPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public FormRow[] formRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส FormItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class FormItems : FormData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class FormItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public FormItems[] formItems { get; set; }
	}
}

