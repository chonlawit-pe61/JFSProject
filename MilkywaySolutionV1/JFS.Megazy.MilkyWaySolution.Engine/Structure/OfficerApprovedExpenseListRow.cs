using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class OfficerApprovedExpenseListRow
	{
		private int _approvedID;
		private bool _isSetApprovedID = false;
		private int _expenseID;
		private bool _isSetExpenseID = false;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int ExpenseID
		{
			get { return _expenseID; }
			set { _expenseID = value;
			      _isSetExpenseID = true; }
		}
		public bool _IsSetExpenseID
		{
			get { return _isSetExpenseID; }
		}
		public double Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amountNull = false;
				_isSetAmount = true;
				_amount = value;
			}
		}
		public bool IsAmountNull
		{
			get {
				 return _amountNull; }
			set { _amountNull = value; }
		}
		public bool _IsSetAmount
		{
			get { return _isSetAmount; }
		}
		public string Note
		{
			get { return _note; }
			set { _note = value;
			      _isSetNote = true; }
		}
		public bool _IsSetNote
		{
			get { return _isSetNote; }
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
	public class OfficerApprovedExpenseListData
	{
		private int _approvedID;
		private int _expenseID;
		private double _amount;
		private string _note;
		private DateTime _modifiedDate;
		public int ApprovedID
		{
			get{ return _approvedID; }
			set{ _approvedID = value; }
		}
		public int ExpenseID
		{
			get{ return _expenseID; }
			set{ _expenseID = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public string Note
		{
			get{ return _note; }
			set{ _note = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class OfficerApprovedExpenseListPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public OfficerApprovedExpenseListRow[] officerApprovedExpenseListRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส OfficerApprovedExpenseListItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class OfficerApprovedExpenseListItems : OfficerApprovedExpenseListData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class OfficerApprovedExpenseListItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public OfficerApprovedExpenseListItems[] officerApprovedExpenseListItems { get; set; }
	}
}

