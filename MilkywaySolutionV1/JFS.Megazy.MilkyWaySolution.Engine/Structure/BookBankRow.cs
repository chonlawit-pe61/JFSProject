using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	[Serializable]
	public class BookBankRow
	{
		private int _bookbankID;
		private bool _isSetBookBankID = false;
		private string _bankName;
		private bool _isSetBankName = false;
		private bool _isActive;
		private bool _isSetIsActive = false;
		private bool _isActiveNull = true;
		private DateTime _modified;
		private bool _isSetModified = false;
		private bool _modifiedNull = true;
		[Required]
		public int BookBankID
		{
			get { return _bookbankID; }
			set { _bookbankID = value;
			      _isSetBookBankID = true; }
		}
		public bool _IsSetBookBankID
		{
			get { return _isSetBookBankID; }
		}
		public string BankName
		{
			get { return _bankName; }
			set { _bankName = value;
			      _isSetBankName = true; }
		}
		public bool _IsSetBankName
		{
			get { return _isSetBankName; }
		}
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActiveNull = false;
				_isSetIsActive = true;
				_isActive = value;
			}
		}
		public bool IsIsActiveNull
		{
			get {
				 return _isActiveNull; }
			set { _isActiveNull = value; }
		}
		public bool _IsSetIsActive
		{
			get { return _isSetIsActive; }
		}
		public DateTime Modified
		{
			get
			{
				return _modified;
			}
			set
			{
				_modifiedNull = false;
				_isSetModified = true;
				_modified = value;
			}
		}
		public bool IsModifiedNull
		{
			get {
				 return _modifiedNull; }
			set { _modifiedNull = value; }
		}
		public bool _IsSetModified
		{
			get { return _isSetModified; }
		}
	}
	[Serializable]
	public class BookBankData
	{
		private int _bookbankID;
		private string _bankName;
		private bool _isActive;
		private DateTime _modified;
		public int BookBankID
		{
			get{ return _bookbankID; }
			set{ _bookbankID = value; }
		}
		public string BankName
		{
			get{ return _bankName; }
			set{ _bankName = value; }
		}
		public bool IsActive
		{
			get{ return _isActive; }
			set{ _isActive = value; }
		}
		public DateTime Modified
		{
			get{ return _modified; }
			set{ _modified = value; }
		}
		public string ModifiedStr { get; set; }
	}
	[Serializable]
	public class BookBankPaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public BookBankRow[] bookbankRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส BookBankItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class BookBankItems : BookBankData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class BookBankItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public BookBankItems[] bookbankItems { get; set; }
	}
}

