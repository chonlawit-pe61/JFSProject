using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class CausesOfTerminateRow
	{
		private int _terminateID;
		private bool _isSetTerminateID = false;
		private string _terminateName;
		private bool _isSetTerminateName = false;
		private bool _isShowOther;
		private bool _isSetIsShowOther = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TerminateID
		{
			get { return _terminateID; }
			set { _terminateID = value;
			      _isSetTerminateID = true; }
		}
		public bool _IsSetTerminateID
		{
			get { return _isSetTerminateID; }
		}
		public string TerminateName
		{
			get { return _terminateName; }
			set { _terminateName = value;
			      _isSetTerminateName = true; }
		}
		public bool _IsSetTerminateName
		{
			get { return _isSetTerminateName; }
		}
		[Required]
		public bool IsShowOther
		{
			get { return _isShowOther; }
			set { _isShowOther = value;
			      _isSetIsShowOther = true; }
		}
		public bool _IsSetIsShowOther
		{
			get { return _isSetIsShowOther; }
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
	public class CausesOfTerminateData
	{
		private int _terminateID;
		private string _terminateName;
		private bool _isShowOther;
		private int _sortOrder;
		private DateTime _modifiedDate;
		public int TerminateID
		{
			get{ return _terminateID; }
			set{ _terminateID = value; }
		}
		public string TerminateName
		{
			get{ return _terminateName; }
			set{ _terminateName = value; }
		}
		public bool IsShowOther
		{
			get{ return _isShowOther; }
			set{ _isShowOther = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class CausesOfTerminatePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public CausesOfTerminateRow[] causesOfTerminateRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส CausesOfTerminateItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class CausesOfTerminateItems : CausesOfTerminateData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class CausesOfTerminateItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public CausesOfTerminateItems[] causesOfTerminateItems { get; set; }
	}
}

