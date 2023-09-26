using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class WorkStepPathRow
	{
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private int _finalApprovedID;
		private bool _isSetFinalApprovedID = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		[Required]
		public int WorkStepID
		{
			get { return _workStepID; }
			set { _workStepID = value;
			      _isSetWorkStepID = true; }
		}
		public bool _IsSetWorkStepID
		{
			get { return _isSetWorkStepID; }
		}
		[Required]
		public bool IsAppeal
		{
			get { return _isAppeal; }
			set { _isAppeal = value;
			      _isSetIsAppeal = true; }
		}
		public bool _IsSetIsAppeal
		{
			get { return _isSetIsAppeal; }
		}
		[Required]
		public int FinalApprovedID
		{
			get { return _finalApprovedID; }
			set { _finalApprovedID = value;
			      _isSetFinalApprovedID = true; }
		}
		public bool _IsSetFinalApprovedID
		{
			get { return _isSetFinalApprovedID; }
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
	}
	[Serializable]
	public class WorkStepPathData
	{
		private int _workStepID;
		private bool _isAppeal;
		private int _finalApprovedID;
		private int _sortOrder;
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public int FinalApprovedID
		{
			get{ return _finalApprovedID; }
			set{ _finalApprovedID = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
	}
	[Serializable]
	public class WorkStepPathPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public WorkStepPathRow[] workStepPathRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส WorkStepPathItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class WorkStepPathItems : WorkStepPathData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class WorkStepPathItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public WorkStepPathItems[] workStepPathItems { get; set; }
	}
}

