using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerMapOpinionRow
	{
		private int _officerRoleID;
		private bool _isSetOfficerRoleID = false;
		private int _opinionID;
		private bool _isSetOpinionID = false;
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
	public class OfficerMapOpinionData
	{
		private int _officerRoleID;
		private int _opinionID;
		private int _sortOrder;
		private bool _isActive;
		private DateTime _modifiedDate;
		public int OfficerRoleID
		{
			get{ return _officerRoleID; }
			set{ _officerRoleID = value; }
		}
		public int OpinionID
		{
			get{ return _opinionID; }
			set{ _opinionID = value; }
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
	public class OfficerMapOpinionPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerMapOpinionRow[] officerMapopinionRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerMapOpinionItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerMapOpinionItems : OfficerMapOpinionData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerMapOpinionItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerMapOpinionItems[] officerMapopinionItems { get; set; }
	}
}

