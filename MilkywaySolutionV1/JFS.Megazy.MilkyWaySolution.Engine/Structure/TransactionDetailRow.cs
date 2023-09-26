using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionDetailRow
	{
		private int _transactionDetailID;
		private bool _isSetTransactionDetailID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private int _budgetID;
		private bool _isSetBudgetID = false;
		private bool _budgetIDNull = true;
		private int _qty;
		private bool _isSetQty = false;
		private bool _qtyNull = true;
		private double _amount;
		private bool _isSetAmount = false;
		private bool _amountNull = true;
		private double _lineTotal;
		private bool _isSetLineTotal = false;
		private bool _lineTotalNull = true;
		private string _unit;
		private bool _isSetUnit = false;
		private string _note;
		private bool _isSetNote = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		[Required]
		public int TransactionDetailID
		{
			get { return _transactionDetailID; }
			set { _transactionDetailID = value;
			      _isSetTransactionDetailID = true; }
		}
		public bool _IsSetTransactionDetailID
		{
			get { return _isSetTransactionDetailID; }
		}
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isSetTransactionID = true; }
		}
		public bool _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
		public int BudgetID
		{
			get
			{
				return _budgetID;
			}
			set
			{
				_budgetIDNull = false;
				_isSetBudgetID = true;
				_budgetID = value;
			}
		}
		public bool IsBudgetIDNull
		{
			get {
				 return _budgetIDNull; }
			set { _budgetIDNull = value; }
		}
		public bool _IsSetBudgetID
		{
			get { return _isSetBudgetID; }
		}
		public int Qty
		{
			get
			{
				return _qty;
			}
			set
			{
				_qtyNull = false;
				_isSetQty = true;
				_qty = value;
			}
		}
		public bool IsQtyNull
		{
			get {
				 return _qtyNull; }
			set { _qtyNull = value; }
		}
		public bool _IsSetQty
		{
			get { return _isSetQty; }
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
		public double LineTotal
		{
			get
			{
				return _lineTotal;
			}
			set
			{
				_lineTotalNull = false;
				_isSetLineTotal = true;
				_lineTotal = value;
			}
		}
		public bool IsLineTotalNull
		{
			get {
				 return _lineTotalNull; }
			set { _lineTotalNull = value; }
		}
		public bool _IsSetLineTotal
		{
			get { return _isSetLineTotal; }
		}
		public string Unit
		{
			get { return _unit; }
			set { _unit = value;
			      _isSetUnit = true; }
		}
		public bool _IsSetUnit
		{
			get { return _isSetUnit; }
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
	public class TransactionDetailData
	{
		private int _transactionDetailID;
		private int _transactionID;
		private int _budgetID;
		private int _qty;
		private double _amount;
		private double _lineTotal;
		private string _unit;
		private string _note;
		private DateTime _modifiedDate;
		public int TransactionDetailID
		{
			get{ return _transactionDetailID; }
			set{ _transactionDetailID = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public int BudgetID
		{
			get{ return _budgetID; }
			set{ _budgetID = value; }
		}
		public int Qty
		{
			get{ return _qty; }
			set{ _qty = value; }
		}
		public double Amount
		{
			get{ return _amount; }
			set{ _amount = value; }
		}
		public double LineTotal
		{
			get{ return _lineTotal; }
			set{ _lineTotal = value; }
		}
		public string Unit
		{
			get{ return _unit; }
			set{ _unit = value; }
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
	public class TransactionDetailPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionDetailRow[] transactionDetailRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionDetailItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionDetailItems : TransactionDetailData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionDetailItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionDetailItems[] transactionDetailItems { get; set; }
	}
}

