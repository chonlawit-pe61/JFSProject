using System;
using System.ComponentModel.DataAnnotations;
using JFS.Megazy.MilkyWaySolution.Engine.Dal;
namespace JFS.Megazy.MilkyWaySolution.Engine.Structure
{
	public class TransactionAttachfileRow
	{
		private bool _isMapRecord = true;
		private bool _isMany = true;
		private int _attachFileID;
		private bool _isSetAttachFileID = false;
		private int _transactionID;
		private bool _isSetTransactionID = false;
		private string _lableFile;
		private bool _isSetLableFile = false;
		private bool _lableFileNull = true;
		private string _description;
		private bool _isSetDescription = false;
		private bool _descriptionNull = true;
		private DateTime _modifiedDate;
		private bool _isSetModifiedDate = false;
		private bool _modifiedDateNull = true;
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
		public int AttachFileID
		{
			get { return _attachFileID; }
			set { _attachFileID = value;
			      _isMapRecord = false;
			      _isSetAttachFileID = true; }
		}
		public Boolean _IsSetAttachFileID
		{
			get { return _isSetAttachFileID; }
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
		public string LableFile
		{
			get
			{
				return _lableFile;
			}
			set
			{
				_lableFileNull = false;
				_isSetLableFile = true;
				_lableFile = value;
				_isMapRecord = false;
			}
		}
		public bool IsLableFileNull
		{
			get {
				 return _lableFileNull; }
			set { _lableFileNull = value; }
		}
		public Boolean _IsSetLableFile
		{
			get { return _isSetLableFile; }
		}
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_descriptionNull = false;
				_isSetDescription = true;
				_description = value;
				_isMapRecord = false;
			}
		}
		public bool IsDescriptionNull
		{
			get {
				 return _descriptionNull; }
			set { _descriptionNull = value; }
		}
		public Boolean _IsSetDescription
		{
			get { return _isSetDescription; }
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
				_isMapRecord = false;
			}
		}
		public bool IsModifiedDateNull
		{
			get {
				 return _modifiedDateNull; }
			set { _modifiedDateNull = value; }
		}
		public Boolean _IsSetModifiedDate
		{
			get { return _isSetModifiedDate; }
		}
	}
	[Serializable]
	public class TransactionAttachfileData
	{
		private int _attachFileID;
		private int _transactionID;
		private string _lableFile;
		private string _description;
		private DateTime _modifiedDate;
		public int AttachFileID
		{
			get{ return _attachFileID; }
			set{ _attachFileID = value; }
		}
		public int TransactionID
		{
			get{ return _transactionID; }
			set{ _transactionID = value; }
		}
		public string LableFile
		{
			get{ return _lableFile; }
			set{ _lableFile = value; }
		}
		public string Description
		{
			get{ return _description; }
			set{ _description = value; }
		}
		public DateTime ModifiedDate
		{
			get{ return _modifiedDate; }
			set{ _modifiedDate = value; }
		}
		public string ModifiedDateStr { get; set; }
	}
	[Serializable]
	public class TransactionAttachfilePaging
	{
		public int totalPage{ get; set; }
		public int totalRow{ get; set; }
		public TransactionAttachfileRow[] transactionAttachfileRow { get; set; }
	}
	/// <summary>
	/// ส่วนขยายคลาส TransactionAttachfileItemsPaging เพิ่ม RowRank
	/// </summary>
	[Serializable]
	public class TransactionAttachfileItems : TransactionAttachfileData
	{
		public int RowRank { get; set; }
	}
	/// <summary>
	/// คลาสสำหรับการแบ่งหน้าที่มีตำแหน่งแถวข้อมูล(int RowRank,int totalPage,int totalRow)
	/// </summary>
	public class TransactionAttachfileItemsPaging
	{
		public int totalPage { get; set; }
		public int totalRow { get; set; }
		public TransactionAttachfileItems[] transactionAttachfileItems { get; set; }
	}
}

