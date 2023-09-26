using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class BudgetRow
	{
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private string _budgetName;
		private bool _isSetBudgetName = false;
		private string _description;
		private bool _isSetDescription = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
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
		public string BudgetName
		{
			get { return _budgetName; }
			set { _budgetName = value;
			      _isSetBudgetName = true; }
		}
		public bool _IsSetBudgetName
		{
			get { return _isSetBudgetName; }
		}
		public string Description
		{
			get { return _description; }
			set { _description = value;
			      _isSetDescription = true; }
		}
		public bool _IsSetDescription
		{
			get { return _isSetDescription; }
		}
		[Required]
		public bool IsActive
		{
			get { return _isActive; }
			set { _isActive = value;
			      _isSetIsActive = true; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
	}
	[Serializable]
	public class BudgetData
	{
		private int _budgetID;
		private string _budgetName;
		private string _description;
		private bool _isActive;
		public int BudgetID
		{
			get{ return _budgetID; }
			set{ _budgetID = value; }
		}
		public string BudgetName
		{
			get{ return _budgetName; }
			set{ _budgetName = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
	}
	[Serializable]
	public class BudgetPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public BudgetRow[] budgetRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส BudgetItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class BudgetItems : BudgetData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class BudgetItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public BudgetItems[] budgetItems { get; set; }
	}
}

