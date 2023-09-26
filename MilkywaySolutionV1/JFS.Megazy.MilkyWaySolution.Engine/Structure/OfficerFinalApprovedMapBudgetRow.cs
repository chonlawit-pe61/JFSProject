using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerFinalApprovedMapBudgetRow
	{
		private int _approvedID;
		private bool _isSetApprovedID = false;
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private DateTime _dateCreated;
		private bool _isSetDateCreated = false;
		private bool _dateCreatedNull = true;
		[Required]
		public int ApprovedID
		{
			get { return _approvedID; }
			set { _approvedID = value;
			      _isSetApprovedID = true; }
		}
		public bool _IsSetApprovedID
		{
			get { return _isSetApprovedID; }
		}
		[Required]
		public int BudgetID
		{
			get { return _budgetID; }
			set { _budgetID = value;
			      _isSetBudgetID = true; }
		}
		public bool _IsSetBudgetID
		{
			get { return _isSetBudgetID; }
		}
		[Required]
		public DateTime DateCreated
		{
			get { return _dateCreated; }
			set { _dateCreated = value;
			      _dateCreatedNull = false;
			      _isSetDateCreated = true; }
		}
		public bool IsDateCreatedNull
		{
			get {
				 return _dateCreatedNull; }
			set { _dateCreatedNull = value; }
		}
		public bool _IsSetDateCreated
		{
			get { return _isSetDateCreated; }
		}
	}
	[Serializable]
	public class OfficerFinalApprovedMapBudgetData
	{
		private int _approvedID;
		private int _budgetID;
		private DateTime _dateCreated;
		public int ApprovedID
		{
			get{ return _approvedID; }
			set{ _approvedID = value; }
		}
		public int BudgetID
		{
			get{ return _budgetID; }
			set{ _budgetID = value; }
		}
		public DateTime DateCreated
		{
			get{ return _dateCreated; }
			set{ _dateCreated = value; }
		}
		public string DateCreatedStr { get; set; }
	}
	[Serializable]
	public class OfficerFinalApprovedMapBudgetPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerFinalApprovedMapBudgetRow[] officerFinalApprovedMapBudgetRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerFinalApprovedMapBudgetItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerFinalApprovedMapBudgetItems : OfficerFinalApprovedMapBudgetData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerFinalApprovedMapBudgetItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerFinalApprovedMapBudgetItems[] officerFinalApprovedMapBudgetItems { get; set; }
	}
}

