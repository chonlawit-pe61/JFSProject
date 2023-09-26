using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionTypeRow
	{
		private int _transactiontypeID;
		private bool _isSetTransactionTypeID = false;
		private string _trasactiontypeDesc;
		private bool _isSetTrasactionTypeDesc = false;
		[Required]
		public int TransactionTypeID
		{
			get { return _transactiontypeID; }
			set { _transactiontypeID = value;
			      _isSetTransactionTypeID = true; }
		}
		public bool _IsSetTransactionTypeID
		{
			get { return _isSetTransactionTypeID; }
		}
		[Required]
		public string TrasactionTypeDesc
		{
			get { return _trasactiontypeDesc; }
			set { _trasactiontypeDesc = value;
			      _isSetTrasactionTypeDesc = true; }
		}
		public bool _IsSetTrasactionTypeDesc
		{
			get { return _isSetTrasactionTypeDesc; }
		}
	}
	[Serializable]
	public class TransactionTypeData
	{
		private int _transactiontypeID;
		private string _trasactiontypeDesc;
		public int TransactionTypeID
		{
			get{ return _transactiontypeID; }
			set{ _transactiontypeID = value; }
		}
		public string TrasactionTypeDesc
		{
			get{ return _trasactiontypeDesc; }
			set{ _trasactiontypeDesc = value; }
		}
	}
	[Serializable]
	public class TransactionTypePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionTypeRow[] transactiontypeRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionTypeItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionTypeItems : TransactionTypeData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionTypeItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionTypeItems[] transactiontypeItems { get; set; }
	}
}

