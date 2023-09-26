using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_WorkStepPathRow
	{
		private int _workStepID;
		private bool _isSetWorkStepID = false;
		private string _workStepName;
		private bool _isSetWorkStepName = false;
		private bool _isAppeal;
		private bool _isSetIsAppeal = false;
		private int _sortOrder;
		private bool _isSetSortOrder = false;
		private bool _sortOrderNull = true;
		private int _finalApprovedID;
		private bool _isSetFinalApprovedID = false;
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
		public string WorkStepName
		{
			get { return _workStepName; }
			set { _workStepName = value;
			      _isSetWorkStepName = true; }
		}
		public bool _IsSetWorkStepName
		{
			get { return _isSetWorkStepName; }
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
	}
	[Serializable]
	public class View_WorkStepPathData
	{
		private int _workStepID;
		private string _workStepName;
		private bool _isAppeal;
		private int _sortOrder;
		private int _finalApprovedID;
		public int WorkStepID
		{
			get{ return _workStepID; }
			set{ _workStepID = value; }
		}
		public string WorkStepName
		{
			get{ return _workStepName; }
			set{ _workStepName = value; }
		}
		public bool IsAppeal
		{
			get{ return _isAppeal; }
			set{ _isAppeal = value; }
		}
		public int SortOrder
		{
			get{ return _sortOrder; }
			set{ _sortOrder = value; }
		}
		public int FinalApprovedID
		{
			get{ return _finalApprovedID; }
			set{ _finalApprovedID = value; }
		}
	}
	[Serializable]
	public class View_WorkStepPathPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_WorkStepPathRow[] view_WorkStepPathRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_WorkStepPathItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_WorkStepPathItems : View_WorkStepPathData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_WorkStepPathItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_WorkStepPathItems[] view_WorkStepPathItems { get; set; }
	}
}

