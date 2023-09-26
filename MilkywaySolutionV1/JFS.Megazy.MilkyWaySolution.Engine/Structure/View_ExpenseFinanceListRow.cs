using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class View_ExpenseFinanceListRow
	{
		private int _jFCaseTypeID;
		private bool _isSetJFCaseTypeID = false;
		private string _caseTypeName;
		private bool _isSetCaseTypeName = false;
		private string _caseTypeNameAbbr;
		private bool _isSetCaseTypeNameAbbr = false;
		private string _expenseList;
		private bool _isSetExpenseList = false;
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
		public string CaseTypeName
		{
			get { return _caseTypeName; }
			set { _caseTypeName = value;
			      _isSetCaseTypeName = true; }
		}
		public bool _IsSetCaseTypeName
		{
			get { return _isSetCaseTypeName; }
		}
		public string CaseTypeNameAbbr
		{
			get { return _caseTypeNameAbbr; }
			set { _caseTypeNameAbbr = value;
			      _isSetCaseTypeNameAbbr = true; }
		}
		public bool _IsSetCaseTypeNameAbbr
		{
			get { return _isSetCaseTypeNameAbbr; }
		}
		public string ExpenseList
		{
			get { return _expenseList; }
			set { _expenseList = value;
			      _isSetExpenseList = true; }
		}
		public bool _IsSetExpenseList
		{
			get { return _isSetExpenseList; }
		}
	}
	[Serializable]
	public class View_ExpenseFinanceListData
	{
		private int _jFCaseTypeID;
		private string _caseTypeName;
		private string _caseTypeNameAbbr;
		private string _expenseList;
		public int JFCaseTypeID
		{
			get{ return _jFCaseTypeID; }
			set{ _jFCaseTypeID = value; }
		}
		public string CaseTypeName
		{
			get{ return _caseTypeName; }
			set{ _caseTypeName = value; }
		}
		public string CaseTypeNameAbbr
		{
			get{ return _caseTypeNameAbbr; }
			set{ _caseTypeNameAbbr = value; }
		}
		public string ExpenseList
		{
			get{ return _expenseList; }
			set{ _expenseList = value; }
		}
	}
	[Serializable]
	public class View_ExpenseFinanceListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public View_ExpenseFinanceListRow[] view_ExpenseFinanceListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส View_ExpenseFinanceListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class View_ExpenseFinanceListItems : View_ExpenseFinanceListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class View_ExpenseFinanceListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public View_ExpenseFinanceListItems[] view_ExpenseFinanceListItems { get; set; }
	}
}

