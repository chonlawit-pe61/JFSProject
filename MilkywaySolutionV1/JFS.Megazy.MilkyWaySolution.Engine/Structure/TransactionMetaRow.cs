using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class TransactionMetaRow
	{
		private int _metaID;
		private bool _isSetMetaID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _metaKey;
		private bool _isSetMetaKey = false;
		private string _metaValue;
		private bool _isSetMetaValue = false;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
		/// <summary>
		/// รหัสเมตา
		/// </summary>
		[Required]
		public int MetaID
		{
			get { return _metaID; }
			set { _metaID = value;
			      _isSetMetaID = true; }
		}
		public bool _IsSetMetaID
		{
			get { return _isSetMetaID; }
		}
		/// <summary>
		/// รหัสรายการ อ้างอิงตาราง Transaction
		/// </summary>
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
		/// <summary>
		/// คีย์ข้อมูลรายการ
		/// </summary>
		public string MetaKey
		{
			get { return _metaKey; }
			set { _metaKey = value;
			      _isSetMetaKey = true; }
		}
		public bool _IsSetMetaKey
		{
			get { return _isSetMetaKey; }
		}
		/// <summary>
		/// ค่าข้อมูลรายการ
		/// </summary>
		public string MetaValue
		{
			get { return _metaValue; }
			set { _metaValue = value;
			      _isSetMetaValue = true; }
		}
		public bool _IsSetMetaValue
		{
			get { return _isSetMetaValue; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
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
	public class TransactionMetaData
	{
		private int _metaID;
		private int _transactionID;
		private string _metaKey;
		private string _metaValue;
		private DateTime _modifiedDate;
		/// <summary>
		/// รหัสเมตา
		/// </summary>
		public int MetaID
		{
			get{ return _metaID; }
			set{ _metaID = value; }
		}
		/// <summary>
		/// รหัสรายการ อ้างอิงตาราง Transaction
		/// </summary>
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		/// <summary>
		/// คีย์ข้อมูลรายการ
		/// </summary>
		public string MetaKey
		{
			get{ return _metaKey; }
			set{ _metaKey = value; }
		}
		/// <summary>
		/// ค่าข้อมูลรายการ
		/// </summary>
		public string MetaValue
		{
			get{ return _metaValue; }
			set{ _metaValue = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ
		/// </summary>
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		/// <summary>
		/// วันเวลาที่แก้ไขรายการ เก็บวันที่แบบ String
		/// </summary>
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TransactionMetaPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionMetaRow[] transactionMetaRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionMetaItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionMetaItems : TransactionMetaData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionMetaItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionMetaItems[] transactionMetaItems { get; set; }
	}
}

