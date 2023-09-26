using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class MemberTransactionMappingRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _rowID;
		private bool _isSetRowID = false;
		private int _memberID;
		private bool _isSetMemberID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		public bool Many
		{
			get { return _isMany; }
			set {_isMany = value;}
		}
		public bool MapRecord
		{
			get { return _isMapRecord; }
			set {_isMapRecord = value;}
		}
		[Required]
		public int RowID
		{
			get { return _rowID; }
			set { _rowID = value;
			      _isMapRecord = false;
			      _isSetRowID = true; }
		}
		public Boolean _IsSetRowID
		{
			get { return _isSetRowID; }
		}
		[Required]
		public int MemberID
		{
			get { return _memberID; }
			set { _memberID = value;
			      _isMapRecord = false;
			      _isSetMemberID = true; }
		}
		public Boolean _IsSetMemberID
		{
			get { return _isSetMemberID; }
		}
		[Required]
		public int TransactionID
		{
			get { return _transactionID; }
			set { _transactionID = value;
			      _isMapRecord = false;
			      _isSetTransactionID = true; }
		}
		public Boolean _IsSetTransactionID
		{
			get { return _isSetTransactionID; }
		}
	}
	[Serializable]
	public class MemberTransactionMappingData
	{
		private int _rowID;
		private int _memberID;
		private int _transactionID;
		public int RowID
		{
			get{ return _rowID; }
			set{ _rowID = value; }
		}
		public int MemberID
		{
			get{ return _memberID; }
			set{ _memberID = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
	}
	[Serializable]
	public class MemberTransactionMappingPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public MemberTransactionMappingRow[] memberTransactionmappingRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส MemberTransactionMappingItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class MemberTransactionMappingItems : MemberTransactionMappingData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class MemberTransactionMappingItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public MemberTransactionMappingItems[] memberTransactionmappingItems { get; set; }
	}
}

