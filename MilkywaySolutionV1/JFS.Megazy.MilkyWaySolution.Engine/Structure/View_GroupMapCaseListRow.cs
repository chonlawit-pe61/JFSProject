using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_GroupMapCaseListRow
	{
		private int _caseID;
		private bool _isSetCaseID = false;
		private string _subject;
		private bool _isSetSubject = false;
		private int _departmentId;
		private bool _isSetDepartmentID = false;
		[Required]
		public int CaseID
		{
			get { return _caseID; }
			set { _caseID = value;
			      _isSetCaseID = true; }
		}
		public bool _IsSetCaseID
		{
			get { return _isSetCaseID; }
		}
		public string Subject
		{
			get { return _subject; }
			set { _subject = value;
			      _isSetSubject = true; }
		}
		public bool _IsSetSubject
		{
			get { return _isSetSubject; }
		}
		[Required]
		public int DepartmentID
		{
			get { return _departmentId; }
			set { _departmentId = value;
			      _isSetDepartmentID = true; }
		}
		public bool _IsSetDepartmentID
		{
			get { return _isSetDepartmentID; }
		}
	}
	[Serializable]
	public class View_GroupMapCaseListData
	{
		private int _caseID;
		private string _subject;
		private int _departmentId;
		public int CaseID
		{
			get{ return _caseID; }
			set{ _caseID = value; }
		}
		public string Subject
		{
			get{ return _subject; }
			set{ _subject = value; }
		}
		public int DepartmentID
		{
			get{ return _departmentId; }
			set{ _departmentId = value; }
		}
	}
	[Serializable]
	public class View_GroupMapCaseListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_GroupMapCaseListRow[] view_GroupMapCaseListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_GroupMapCaseListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_GroupMapCaseListItems : View_GroupMapCaseListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_GroupMapCaseListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_GroupMapCaseListItems[] view_GroupMapCaseListItems { get; set; }
	}
}

