using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerOpinionRow
	{
		private int _opinionID;
		private bool _isSetOpinionID = false;
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private bool _jFCaseTypeIDNull = true;
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int OpinionID
		{
			get { return _opinionID; }
			set { _opinionID = value;
			      _isSetOpinionID = true; }
		}
		public bool _IsSetOpinionID
		{
			get { return _isSetOpinionID; }
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
		[Required]
		public int OfficerRoleID
		{
			get { return _officerRoleID; }
			set { _officerRoleID = value;
			      _isSetOfficerRoleID = true; }
		}
		public bool _IsSetOfficerRoleID
		{
			get { return _isSetOfficerRoleID; }
		}
		public int SortOrder
		{
			get
			{
				return _sortOrder;
			}
			set
			{
				_sortOrderNull = false;
				_isSetSortOrder = true;
				_sortOrder = value;
			}
		}
		public bool IsSortOrderNull
		{
			get {
				 return _sortOrderNull; }
			set { _sortOrderNull = value; }
		}
		public bool _IsSetSortOrder
		{
			get { return _isSetSortOrder; }
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
	public class OfficerOpinionData
	{
		private int _opinionID;
		private int _jFCaseTypeID;
		private int _officerRoleID;
		private int _sortOrder;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
		}
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
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
	public class OfficerOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerOpinionRow[] officeropinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerOpinionItems : OfficerOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerOpinionItems[] officeropinionItems { get; set; }
	}
}

